﻿using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAll();
        Task Add(Car car);
        Task Delete(Guid id);
        Task<Car?> GetOrDefault(Guid carId);
    }
}
