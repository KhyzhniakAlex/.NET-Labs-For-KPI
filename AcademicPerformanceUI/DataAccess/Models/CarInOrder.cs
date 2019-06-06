using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "CarInOrder")]
    [Serializable]
    public class CarInOrder : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        [DataMember()]
        public Guid Id { get; set; }

        [Column]
        [DataMember()]
        public Guid OrderId { get; set; }
       
        [Column]
        [DataMember()]
        public Guid CarId { get; set; }
       
        public object Clone() => new CarInOrder()
        {
            Id = this.Id,
            OrderId = this.OrderId,
            CarId = this.CarId
        };

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (CarInOrder)mapFrom;
            this.Id = entity.Id;
            this.OrderId = entity.OrderId;
            this.CarId = entity.CarId;

            return this;
        }
    }
}
