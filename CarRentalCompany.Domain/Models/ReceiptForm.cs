using CarRentalCompany.Domain.Enums;
using CarRentalCompany.Domain.Exceptions;

namespace CarRentalCompany.Domain.Models
{
    public class ReceiptForm
    {
        public int TirePressure { get; private set; }
        public FuelLevel FuelLevel { get; private set; }
        public int CarMileage { get; private set; }
        public bool SystemUpdated { get; private set; }
        public bool Refuled { get; private set; }
        public bool Washed { get; private set; }

        public void SetTirePressure(int tirePressure)
        {
            if (tirePressure < 0)
            {
                throw new InvalidTirePressureException(tirePressure);
            }

            TirePressure = tirePressure;
        }

        public void SetFuelLevel(FuelLevel fuelLevel)
        {
            FuelLevel = fuelLevel;
        }

        public void SetCarMileage(int carMileage)
        {
            if (carMileage < 0)
            {
                throw new InvalidCarMileageException(carMileage);

            }

            CarMileage = carMileage;
        }

        public void SetIfSystemUpdated(bool isSystemUpdated)
        {
            SystemUpdated = isSystemUpdated;
        }

        public void SetIfRefuled(bool isRefuled)
        {
            Refuled = isRefuled;
        }

        public void SetIfWashed(bool isWashed)
        {
            Washed = isWashed;
        }
    }
}
