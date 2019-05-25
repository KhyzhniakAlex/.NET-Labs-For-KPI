using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "Manager")]
    [Serializable]
    public class Manager : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        [DataMember()]
        public Guid Id { get; set; }

        [Column]
        [DataMember()]
        public string FirstName { get; set; }

        [Column]
        [DataMember()]
        public string LastName { get; set; }

        [Column]
        [DataMember()]
        public string PhoneNumber { get; set; }

        [Column]
        [DataMember()]
        public double Salary { get; set; }

        [Column]
        [DataMember()]
        public string Position { get; set; }
        
        public object Clone() => new Manager()
        {
            Id = this.Id,
            FirstName = this.FirstName,
            LastName = this.LastName,
            PhoneNumber = this.PhoneNumber,
            Salary = this.Salary,
            Position = this.Position,
        };

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (Manager)mapFrom;
            this.Id = entity.Id;
            this.FirstName = entity.FirstName;
            this.LastName = entity.LastName;
            this.PhoneNumber = entity.PhoneNumber;
            this.Salary = entity.Salary;
            this.Position = entity.Position;

            return this;
        }
    }
}
