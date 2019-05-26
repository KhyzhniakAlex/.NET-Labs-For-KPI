using System;
using System.Runtime.Serialization;

namespace WcfRestService.DTOModels
{
    [DataContract]
    public class CarInOrderDto : IBaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid OrderId { get; set; }

        [DataMember]
        public Guid CarId { get; set; }
    }
}
