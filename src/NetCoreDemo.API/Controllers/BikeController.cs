﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreDemo.API.Controllers
{
    [Route("api/[controller]")]
    public class BikeController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public BikeController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost]
        public async Task<Vehicle> Post([FromBody] Vehicle value)
        {
            var entity = await _vehicleService.AddBikeAsync(value.Make, value.Model, value.Engine, value.Wheels, value.BodyType);
            return entity;
        }

        // PUT: api/Bike/5
        [HttpPut("{id}")]
        public async Task<Vehicle> Put(long id, [FromBody]Vehicle value)
        {
            return await _vehicleService.EditBikeAsync(id, value.Make, value.Model, value.Engine, value.Wheels, value.BodyType);
        }
    }
}
