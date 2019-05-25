using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "Manufacturer")]
    [Serializable]
    public class Manufacturer : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        [DataMember()]
        public Guid Id { get; set; }

        [Column]
        [DataMember()]
        public string Name { get; set; }

        [DataMember()]
        [Column]
        public string OfficePhoneNumber { get; set; }

        [Column]
        [DataMember()]
        public string Country { get; set; }
        
        public object Clone() => new Manufacturer()
        {
            Id = this.Id,
            Name = this.Name,
            OfficePhoneNumber = this.OfficePhoneNumber,
            Country = this.Country
        };

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (Manufacturer)mapFrom;
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.OfficePhoneNumber = entity.OfficePhoneNumber;
            this.Country = entity.Country;

            return this;
        }
    }
}
