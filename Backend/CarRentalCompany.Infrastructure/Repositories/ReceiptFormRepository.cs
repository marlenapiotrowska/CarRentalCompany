using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;
using CarRentalCompany.Infrastructure.Entities;

namespace CarRentalCompany.Infrastructure.Repositories
{
    internal class ReceiptFormRepository : IReceiptFormRepository
    {
        private readonly CarRentalCompanyDbContext _context;

        public ReceiptFormRepository(CarRentalCompanyDbContext context)
        {
            _context = context;
        }

        public void Add(CarReceiptForm carReceiptForm)
        {
            var receiptForm = ReceiptForm
                .Create
                (carReceiptForm.Id,
                Guid.NewGuid(),
                carReceiptForm.ClientId);

            _context.ReceiptForms.Add(receiptForm);
            _context.SaveChanges();
        }
    }
}
