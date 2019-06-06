using System;
using DataAccess.Interfaces;
using System.Runtime.Serialization;
using System.Data.Linq.Mapping;

namespace DataAccess.Models
{
    [Serializable]
    [Table(Name = "Order")]
    public class Order : IEntity
    {
        [DataMember()]
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public Guid Id { get; set; }

        [DataMember()]
        [Column]
        public DateTime StartDate { get; set; }

        [DataMember()]
        [Column]
        public DateTime EndDate { get; set; }

        [DataMember()]
        [Column]
        public double Sum { get; set; }

        [Column]
        [DataMember()]
        public Guid CustomerId { get; set; }

        [DataMember()]
        [Column]
        public Guid ManagerId { get; set; }

        public object Clone()
        {
            return new Order()
            {
                Id = this.Id,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                Sum = this.Sum,
                CustomerId = this.CustomerId,
                ManagerId = this.ManagerId
            };
        }

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (Order)mapFrom;
            this.Id = entity.Id;
            this.StartDate = entity.StartDate;
            this.EndDate = entity.EndDate;
            this.Sum = entity.Sum;
            this.CustomerId = entity.CustomerId;
            this.ManagerId = entity.ManagerId;

            return this;
        }
    }
}
