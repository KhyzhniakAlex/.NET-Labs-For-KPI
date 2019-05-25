using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.InMemoryDb;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Serializable]
    [Table(Name = "Customer")]
    public class Customer : IEntity
    {
        [DataMember()]
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public Guid Id { get; set; }

        [DataMember()]
        [Column]
        public string FirstName { get; set; }

        [DataMember()]
        [Column]
        public string LastName { get; set; }

        [DataMember()]
        [Column]
        public string PhoneNumber { get; set; }

        [DataMember()]
        [Column]
        public string PassportSeries { get; set; }

        [DataMember()]
        [Column]
        public string AccoutId { get; set; }
       
        public object Clone() => new Customer()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = this.PhoneNumber,
                PassportSeries = this.PassportSeries,
                AccoutId = this.AccoutId
        };

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (Customer)mapFrom;
            this.Id = entity.Id;
            this.FirstName = entity.FirstName;
            this.LastName = entity.LastName;
            this.PhoneNumber = entity.PhoneNumber;
            this.PassportSeries = entity.PassportSeries;
            this.AccoutId = entity.AccoutId;

            return this;
        }
    }
}
