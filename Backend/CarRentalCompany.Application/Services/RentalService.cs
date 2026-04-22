using CarRentalCompany.Application.Exceptions;
using CarRentalCompany.Application.Factories.Interfaces;
using CarRentalCompany.Application.Services.Inputs;
using CarRentalCompany.Application.Services.Interfaces;
using CarRentalCompany.Domain.Providers;
using CarRentalCompany.Domain.Repositories;
using CarRentalCompany.Infrastructure;

namespace CarRentalCompany.Application.Services;

internal class RentalService : IRentalService
{
    private readonly IClientRepository _clientRepository;
    private readonly ICarRepository _carRepository;
    private readonly IRentalRepository _rentalRepository;
    private readonly IRentalDbFactory _factory;
    private readonly IReceiptFormFactory _receiptFormFactory;
    private readonly IClock _clock;
    private readonly ITransaction _transaction;

    public RentalService(
        IClientRepository clientRepository,
        ICarRepository carRepository,
        IRentalRepository rentalRepository,
        IRentalDbFactory rentalFactory,
        IReceiptFormFactory receiptFormFactory,
        IClock clock,
        ITransaction transaction)
    {
        _clientRepository = clientRepository;
        _carRepository = carRepository;
        _rentalRepository = rentalRepository;
        _factory = rentalFactory;
        _receiptFormFactory = receiptFormFactory;
        _clock = clock;
        _transaction = transaction;
    }

    public async Task CreateAsync(CreateRentalInput input)
    {
        _ = await _clientRepository.GetOrDefaultAsync(input.ClientId)
            ?? throw new InvalidProcedureException($"Client with id {input.ClientId} does not exists.");
        _ = await _carRepository.GetOrDefaultAsync(input.CarId) 
            ?? throw new InvalidProcedureException($"Car with id {input.CarId} does not exist.");

        var rentalNotEndedForCar = await _rentalRepository.GetOrDefaultNotEndedForCarIdAsync(input.CarId);
        if (rentalNotEndedForCar != null)
            throw new InvalidProcedureException($"There is another not ended rental for car with Id {input.CarId}");

        var rental = _factory.Create(input.ClientId, input.CarId);
        await _rentalRepository.AddAsync(rental);
    }

    public async Task EndAsync(Guid id)
    {
        var rental = await _rentalRepository.GetOrDefaultAsync(id)
            ?? throw new InvalidProcedureException($"Rental with id {id} does not exist.");

        if (rental.IsEnded)
            throw new InvalidOperationException($"Rental with id {id} is completed.");

        var car = await _carRepository.GetOrDefaultAsync(rental.CarId)
             ?? throw new InvalidProcedureException($"Car with id {id} does not exist.");

        _transaction.Begin();

        var receiptForm = _receiptFormFactory.CreateNewCarReceiptForm(car, rental.ClientId);
        rental.SetReceiptForm(receiptForm.Id);
        rental.End(_clock.GetTime());
        await _rentalRepository.UpdateAsync(rental);

        _transaction.Commit();
    }
}
