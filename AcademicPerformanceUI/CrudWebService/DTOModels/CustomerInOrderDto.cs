using System;

namespace CrudWebService.DTOModels
{
    public class CustomerInOrderDto : IBaseDto
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid CarId { get; set; }
    }
}
