using System;

namespace CrudWebService.DTOModels
{
    public class ManagerDto : IBaseDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public double Salary { get; set; }

        public string Position { get; set; }
    }
}
