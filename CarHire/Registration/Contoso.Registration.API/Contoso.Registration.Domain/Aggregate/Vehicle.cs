﻿// <copyright file="Vehicle.cs" company="CaioCesarCalisto">
// Copyright (c) CaioCesarCalisto. All rights reserved.
// </copyright>

using System;
using Contoso.Registration.Domain.Common;

namespace Contoso.Registration.Domain.Aggregate
{
    /// <summary>
    /// Vehicle.
    /// </summary>
    public class Vehicle : Entity, IAggregateRoot
    {
        private Vehicle()
        {
        }

        private Vehicle(
            string name,
            string brand,
            Category category,
            int doors,
            int passengers,
            Transmission transmission,
            int consume,
            int emission)
        {
            this.Name = name;
            this.Brand = brand;
            this.Category = category;
            this.Doors = doors;
            this.Passengers = passengers;
            this.Transmission = transmission;
            this.Consume = consume;
            this.Emission = emission;
        }

        /// <summary>
        /// Gets Name.
        /// </summary>
        public virtual string Name { get; private set; }

        /// <summary>
        /// Gets Brand.
        /// </summary>
        public virtual string Brand { get; private set; }

        /// <summary>
        /// Gets Category.
        /// </summary>
        public virtual Category Category { get; private set; }

        /// <summary>
        /// Gets How many doors.
        /// </summary>
        public virtual int Doors { get; private set; }

        /// <summary>
        /// Gets How many passengers.
        /// </summary>
        public virtual int Passengers { get; private set; }

        /// <summary>
        /// Gets Gear transmission.
        /// </summary>
        public virtual Transmission Transmission { get; private set; }

        /// <summary>
        /// Gets Miles/Galon consume.
        /// </summary>
        public virtual int Consume { get; private set; }

        /// <summary>
        /// Gets g/km CO2.
        /// </summary>
        public virtual int Emission { get; private set; }

        /// <summary>
        /// Create a new vehicle.
        /// </summary>
        /// <param name="name">Vehicle name.</param>
        /// <param name="brand">Vehicle brand.</param>
        /// <param name="category">Vehicle category.</param>
        /// <param name="doors">How many doors.</param>
        /// <param name="passenger">How many passengers.</param>
        /// <param name="transmission">Gear transmission.</param>
        /// <param name="consume">miles/galon.</param>
        /// <param name="emission">g/km CO2.</param>
        /// <returns>Vehicle.</returns>
        public static Vehicle Create(
            string name,
            string brand,
            string category,
            int doors,
            int passenger,
            string transmission,
            int consume,
            int emission)
        {
            if (!Enum.TryParse(category.ToUpper(), out Category vehicleCategory))
            {
                throw new ArgumentException($"Category {category} doest not exists");
            }

            if (!Enum.TryParse(transmission.ToUpper(), out Transmission vehicleTransmission))
            {
                throw new ArgumentException($"Transmission {transmission} doest not exists");
            }

            return new Vehicle(name, brand, vehicleCategory, doors, passenger, vehicleTransmission, consume, emission);
        }
    }
}
