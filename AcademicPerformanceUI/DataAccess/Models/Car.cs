using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "Car")]
    [Serializable]
    public class Car : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        [DataMember()]
        public Guid Id { get; set; }

        [DataMember()]
        [Column]
        public string Brand { get; set; }

        [DataMember()]
        [Column]
        public string Model { get; set; }

        [DataMember()]
        [Column]
        public string SerialNumber { get; set; }

        [DataMember()]
        [Column]
        public string Color { get; set; }

        [DataMember()]
        [Column]
        public double Price { get; set; }

        [DataMember()]
        [Column]
        public Guid ManufacturerId { get; set; }

        [DataMember()]
        [Column]
        public Guid ManagerId { get; set; }

        public object Clone() => new Car()
        {
            Id = this.Id,
            Brand = this.Brand,
            Model = this.Model,
            SerialNumber = this.SerialNumber,
            Color = this.Color,
            Price = this.Price,
            ManufacturerId = this.ManufacturerId,
            ManagerId = this.ManagerId
        };


        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (Car)mapFrom;
            this.Id = entity.Id;
            this.Brand = entity.Brand;
            this.Model = entity.Model;
            this.SerialNumber = entity.SerialNumber;
            this.Color = entity.Color;
            this.Price = entity.Price;
            this.ManufacturerId = entity.ManufacturerId;
            this.ManagerId = entity.ManagerId;

            return this;
        }
    }
}
