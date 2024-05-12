using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Integration.Porsche.Factories
{
    public class PorscheReceiptFormIntegrator : ICarReceiptFormIntegrator
    {
        public static string Type 
            => "Porsche";

        public void Apply(CarReceiptForm form)
        {
            form.AddActivity(new ActivityInstance("Cars paint condition", 4.1));
            form.AddActivity(new ActivityInstance("Porsche sign condition", 4.2));
        }
    }
}
