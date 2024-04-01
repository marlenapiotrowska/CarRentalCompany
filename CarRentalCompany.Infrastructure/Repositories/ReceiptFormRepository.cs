﻿using CarRentalCompany.Application.Repositories;
using CarRentalCompany.Domain.Models.CarBrands;
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

        public void Add(ICarReceiptForm carReceiptForm, Guid clientId)
        {
            var receiptForm = ReceiptForm
                .Create
                (carReceiptForm.Type
                    .Select(x => x.Value)
                    .First(),
                carReceiptForm.Payload,
                clientId);

            _context.ReceiptForms.Add(receiptForm);
            _context.SaveChanges();
        }
    }
}
