﻿// <copyright file="Vehicle.cs" company="CaioCesarCalisto">
// Copyright (c) CaioCesarCalisto. All rights reserved.
// </copyright>

using Microsoft.Azure.Cosmos.Table;

namespace Contoso.Registration.Infrastructure.Model
{
    /// <summary>
    /// Database entity vehicle.
    /// </summary>
    public class Vehicle : TableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        public Vehicle()
        {
        }

        /// <summary>
        /// Gets Name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets Brand.
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Gets Category.
        /// </summary>
        public string Category { get; private set; }

        /// <summary>
        /// Gets How many doors.
        /// </summary>
        public int Doors { get; private set; }

        /// <summary>
        /// Gets How many passengers.
        /// </summary>
        public int Passengers { get; private set; }

        /// <summary>
        /// Gets Gear transmission.
        /// </summary>
        public string Transmission { get; private set; }

        /// <summary>
        /// Gets Miles/Galon consume.
        /// </summary>
        public int Consume { get; private set; }

        /// <summary>
        /// Gets g/km CO2.
        /// </summary>
        public int Emission { get; private set; }
    }
}
