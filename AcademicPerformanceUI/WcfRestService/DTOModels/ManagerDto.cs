using System;
using System.Runtime.Serialization;

namespace WcfRestService.DTOModels
{
    [DataContract]
    public class ManagerDto : IBaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public double Salary { get; set; }

        [DataMember]
        public string Position { get; set; }
    }
}
