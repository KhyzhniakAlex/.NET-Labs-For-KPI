using System;

namespace CrudWebService.DTOModels
{
    public class CustomerDto : IBaseDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string PassportSeries { get; set; }

        public string AccoutId { get; set; }
    }
}
