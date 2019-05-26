using System;
using System.Runtime.Serialization;

namespace WcfRestService.DTOModels
{
    [DataContract]
    public class OrderDto: IBaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public double Sum { get; set; }

        [DataMember]
        public Guid CustomerId { get; set; }
    }
}
