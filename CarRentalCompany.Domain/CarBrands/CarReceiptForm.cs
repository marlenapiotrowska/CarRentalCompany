﻿using CarRentalCompany.Domain.AdditionalTypes;

namespace CarRentalCompany.Strategies.CarBrands
{
    public class CarReceiptForm : ICarReceiptForm
    {
        public string Payload { get; set; }
        public int TirePressure { get; set; }
        public FuelLevel FuelLevel { get; set; }
        public int CarMileage { get; set; }
        public bool SystemUpdated { get; set; }
        public bool Refuled { get; set; }
        public bool Washed { get; set; }
    }
}
