﻿using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;
using CarRentalCompany.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using ClientDb = CarRentalCompany.Infrastructure.Entities.Client;

namespace CarRentalCompany.Infrastructure.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private readonly CarRentalCompanyDbContext _context;

        public ClientRepository(CarRentalCompanyDbContext context)
        {
            _context = context;
        }

        public async Task Add(Client client)
        {
            var clientDb = ClientDb.Create
                (client.Id, 
                client.Name);

            _context.Clients.Add(clientDb);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var clientDb = await _context.Clients
                .SingleOrDefaultAsync(c => c.Id == id)
                ?? throw new EntityNotFoundException("client", id);

            _context.Clients.Remove(clientDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            var clientsDb = await _context.Clients
                .ToListAsync();

            return clientsDb
                .Select(c => new Client(c.Id, c.Name))
                .ToList();
        }
    }
}
