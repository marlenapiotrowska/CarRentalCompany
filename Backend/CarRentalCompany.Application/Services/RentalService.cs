using CarRentalCompany.Application.Exceptions;
using CarRentalCompany.Application.Factories.Interfaces;
using CarRentalCompany.Application.Services.Inputs;
using CarRentalCompany.Application.Services.Interfaces;
using CarRentalCompany.Domain.Repositories;

namespace CarRentalCompany.Application.Services
{
    internal class RentalService : IRentalService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICarRepository _carRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IRentalDbFactory _factory;

        public RentalService(IClientRepository clientRepository, ICarRepository carRepository, IRentalRepository rentalRepository, IRentalDbFactory factory)
        {
            _clientRepository = clientRepository;
            _carRepository = carRepository;
            _rentalRepository = rentalRepository;
            _factory = factory;
        }

        public async Task CreateRental(CreateRentalInput input)
        {
            var clientExists = _clientRepository.CheckIfExists(input.ClientId);
            if (!clientExists)
            {
                throw new InvalidProcedureException($"Client with id {input.ClientId} does not exists.");
            }
            var carExists = _carRepository.CheckIfExists(input.CarId);

            if (!carExists)
            {
                throw new InvalidProcedureException($"Car with id {input.CarId} does not exists.");
            }

            var rentalNotEndedForCarExists = _rentalRepository.CheckIfExistsNotEndedForCar(input.CarId);
            if (rentalNotEndedForCarExists)
            {
                throw new InvalidProcedureException($"There is another not ended rental for car with Id {input.CarId}");
            }

            var rental = _factory.Create(input.ClientId, input.CarId);
            await _rentalRepository.Add(rental);
        }
    }
}
