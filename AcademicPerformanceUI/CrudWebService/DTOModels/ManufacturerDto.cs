using System;

namespace CrudWebService.DTOModels
{
    public class ManufacturerDto : IBaseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string OfficePhoneNumber { get; set; }

        public string Country { get; set; }
    }
}
