using System;

namespace CrudWebService.DTOModels
{
    public class CarDto : IBaseDto
    {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string SerialNumber { get; set; }

        public string Color { get; set; }

        public double Price { get; set; }

        public Guid ManufacturerId { get; set; }

        public Guid ManagerId { get; set; }
    }
}
