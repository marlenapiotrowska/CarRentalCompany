﻿using CarRentalCompany.API.Factories;
using CarRentalCompany.Application.Services;
using CarRentalCompany.Core.Dto.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalCompany.API.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;
        private readonly IClientDtoFactory _factory;

        public ClientController(IClientService service, IClientDtoFactory factory)
        {
            _service = service;
            _factory = factory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAllClients()
        {
            var clients = _service.GetAllClients();

            return _factory
                .Create(clients)
                .ToList();
        }
    }
}
