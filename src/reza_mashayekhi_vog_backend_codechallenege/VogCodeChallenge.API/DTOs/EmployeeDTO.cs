using System;

namespace VogCodeChallenge.API.DTOs
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }

        public string Company { get; set; }

        public string Department { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public string Address { get; set; }
    }
}
