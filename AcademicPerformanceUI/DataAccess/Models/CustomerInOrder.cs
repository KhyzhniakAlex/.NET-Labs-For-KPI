using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "CustomerInOrder")]
    [Serializable]
    public class CustomerInOrder : IEntity
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
       
        public object Clone() => new CustomerInOrder()
        {
            Id = this.Id,
            OrderId = this.OrderId,
            CarId = this.CarId
        };

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (CustomerInOrder)mapFrom;
            this.Id = entity.Id;
            this.OrderId = entity.OrderId;
            this.CarId = entity.CarId;

            return this;
        }
    }
}
