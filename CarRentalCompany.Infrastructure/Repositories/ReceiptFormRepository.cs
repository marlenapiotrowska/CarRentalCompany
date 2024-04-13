﻿using CarRentalCompany.Domain.Models;
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
            var value = carReceiptForm.Activities?
                    .Select(a => $"{a.Name} {a.Payload}")
                    .ToList();

            var receiptForm = ReceiptForm
                .Create
                (carReceiptForm.Id,
                carReceiptForm.Type,
                string.Join(", ", value) ?? string.Empty,
                carReceiptForm.ClientId);
            _context.ReceiptForms.Add(receiptForm);
            _context.SaveChanges();
        }
    }
}
