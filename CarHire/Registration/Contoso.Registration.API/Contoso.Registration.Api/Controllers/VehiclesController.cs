﻿// <copyright file="VehiclesController.cs" company="CaioCesarCalisto">
// Copyright (c) CaioCesarCalisto. All rights reserved.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using Contoso.Registration.Api.Authorization;
using Contoso.Registration.Application.Commands;
using Contoso.Registration.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Contoso.Registration.Api.Controllers
{
    /// <summary>
    /// Vehicles controller.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesQueries vehiclesQueries;
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehiclesController"/> class.
        /// </summary>
        /// <param name="vehiclesQueries">Queries.</param>
        /// <param name="mediator">Mediator.</param>
        public VehiclesController(IVehiclesQueries vehiclesQueries, IMediator mediator)
        {
            this.vehiclesQueries = vehiclesQueries;
            this.mediator = mediator;
        }

        /// <summary>
        /// Get vehicles by paramaters.
        /// </summary>
        /// <param name="vehicles">Parameters.</param>
        /// <returns>Vehicles.</returns>
        [HttpGet]
        [Route("query")]
        public IActionResult GetVehicles([FromQuery] Application.Model.Vehicle vehicles)
        {
            Application.Model.PagedList<Application.Model.Vehicle> result = this.vehiclesQueries.Find(vehicles);
            this.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(new
            {
                result.Total,
                result.Page,
                result.Limit,
            }));

            return result.Count() == 0
                ? this.NotFound()
                : this.Ok(result);
        }

        /// <summary>
        /// Create new vehicle.
        /// </summary>
        /// <param name="addVehicleCommand">Command.</param>
        /// <returns>Vehicle created.</returns>
        [HttpPost]
        [Authorize(Policy = Policies.CanEdit)]
        public async Task<IActionResult> Create([FromBody] AddVehicleCommand addVehicleCommand) => this.Ok(await this.mediator.Send(addVehicleCommand));
    }
}