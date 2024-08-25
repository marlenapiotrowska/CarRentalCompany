using CarRentalCompany.Application.Exceptions;
using CarRentalCompany.Application.Factories.Interfaces;
using CarRentalCompany.Application.Services.Inputs;
using CarRentalCompany.Application.Services.Interfaces;
using CarRentalCompany.Domain.Providers;
using CarRentalCompany.Domain.Repositories;

namespace CarRentalCompany.Application.Services
{
    internal class RentalService : IRentalService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICarRepository _carRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IRentalDbFactory _factory;
        private readonly IReceiptFormFactory _receiptFormFactory;
        private readonly IClock _clock;

        public RentalService(IClientRepository clientRepository, 
            ICarRepository carRepository, 
            IRentalRepository rentalRepository, 
            IRentalDbFactory rentalFactory,
            IReceiptFormFactory receiptFormFactory,
            IClock clock)
        {
            _clientRepository = clientRepository;
            _carRepository = carRepository;
            _rentalRepository = rentalRepository;
            _factory = rentalFactory;
            _receiptFormFactory = receiptFormFactory;
            _clock = clock;
        }

        public async Task Create(CreateRentalInput input)
        {
            var clientExists = _clientRepository.GetOrDefault(input.ClientId)
                ?? throw new InvalidProcedureException($"Client with id {input.ClientId} does not exists.");
            var car = _carRepository.GetOrDefault(input.CarId) 
                ?? throw new InvalidProcedureException($"Car with id {input.CarId} does not exist.");

            var rentalNotEndedForCar = _rentalRepository.GetOrDefaultNotEndedForCarId(input.CarId);
            if (rentalNotEndedForCar != null)
            {
                throw new InvalidProcedureException($"There is another not ended rental for car with Id {input.CarId}");
            }

            var rental = _factory.Create(input.ClientId, input.CarId);
            await _rentalRepository.Add(rental);
        }

        public async Task End(Guid id)
        {
            var rental = await _rentalRepository.GetOrDefault(id)
                ?? throw new InvalidProcedureException($"Rental with id {id} does not exist.");

            if (rental.IsEnded)
            {
                throw new InvalidOperationException($"Rental with id {id} is completed.");
            }

            var car = await _carRepository.GetOrDefault(rental.CarId)
                 ?? throw new InvalidProcedureException($"Car with id {id} does not exist.");


            //TODO: TRANSAKCJA
            var receiptForm = _receiptFormFactory.CreateNewCarReceiptForm(car, rental.ClientId);
            rental.SetReceiptForm(receiptForm.Id);
            rental.End(_clock.GetTime());
            await _rentalRepository.Update(rental);
        }
    }
}
