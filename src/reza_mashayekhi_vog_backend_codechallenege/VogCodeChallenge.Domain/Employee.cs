using System;
using VogCodeChallenge.Shared;
using VogCodeChallenge.Shared.Exceptions;

namespace VogCodeChallenge.Domain
{
    public class Employee : Entity
    {
        public Employee(Guid id, Department department, string firstName, string lastName, string jobTitle, string address)
        {
            EnsureArgumentsAreValid(id, department, firstName, lastName, jobTitle, address);

            Id = id;
            Department = department;
            FirstName = firstName;
            LastName = lastName;
            JobTitle = jobTitle;
            Address = address;
        }

        public Department Department { get; }

        public string FirstName { get; }
        
        public string LastName { get; }
        
        public string JobTitle { get; }
        
        public string Address { get; }

        private static void EnsureArgumentsAreValid(Guid id, Department department, string firstName, string lastName, string jobTitle, string address)
        {
            id.EnsureIsNotEmpty("employee ID");
            
            if(department == null)
            {
                throw new InvalidArgumentException("The department cannot be null");
            }

            firstName.EnsureIsNotEmpty("employee first name");
            lastName.EnsureIsNotEmpty("employee last name");
            jobTitle.EnsureIsNotEmpty("employee job title");
            address.EnsureIsNotEmpty("employee address");
        }
    }
}
