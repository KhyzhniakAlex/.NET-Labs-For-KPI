using System;
using System.Runtime.Serialization;

namespace WcfRestService.DTOModels
{
    [DataContract]
    public class ManufacturerDto : IBaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string OfficePhoneNumber { get; set; }

        [DataMember]
        public string Country { get; set; }
    }
}
