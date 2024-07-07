﻿using CarRentalCompany.Application.Services.Inputs;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAll();
        Task<Car> Add(AddCarInput input);
        Task Delete(Guid carId);
    }
}