using System;
using System.Runtime.Serialization;

namespace WcfRestService.DTOModels
{
    [DataContract]
    public class CarDto : IBaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Brand { get; set; }

        [DataMember]
        public string Model { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public string Color { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public Guid ManufacturerId { get; set; }
    }
}
