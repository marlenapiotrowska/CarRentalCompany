﻿using CarRentalCompany.Application.Services.Inputs;
using CarRentalCompany.Application.Services.Interfaces;
using CarRentalCompany.Core.Dto.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalCompany.API.Controllers
{
    [ApiController]
    [Route("rentals")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _service;

        public RentalController(IRentalService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRentalRequestModel request)
        {
            var input = new CreateRentalInput(request.ClientId, request.CarId);
            await _service.Create(input);

            return Ok(true);
        }

        [HttpPost]
        [Route("{id}/actions/end")]
        public async Task<IActionResult> End(Guid id)
        {
            //TODO: DRUKOWANIE ALBO ZWRACANIE JAKO REZULTAT FORMULARZA
            await _service.End(id);

            return Ok(true);
        }
    }
}
