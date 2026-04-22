using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Integrators;

namespace CarRentalCompany.Integration.Porsche.Integrators
{
    public class PorscheReceiptFormIntegrator : ICarReceiptFormIntegrator
    {
        private const string _cayenneModel = "Cayenne";

        public static string Type
            => BrandsNames.Porsche;

        public void Apply(CarReceiptForm form)
        {
            form.AddActivity(new ActivityInstance("Cars paint condition", 4.1));
            form.AddActivity(new ActivityInstance("Porsche sign condition", 4.2));

            if (form.Car.Model == _cayenneModel)
            {
                form.AddActivity(new ActivityInstance("Cayenne specific activity", 4.3));
            }
        }
    }
}
