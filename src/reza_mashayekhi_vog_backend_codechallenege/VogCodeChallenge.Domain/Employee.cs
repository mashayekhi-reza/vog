using System;
using VogCodeChallenge.Shared;

namespace VogCodeChallenge.Domain
{
    public class Employee : Entity
    {
        internal Employee(string firstName, string lastName, string jobTitle, string address)
        {
            EnsureArgumentsAreValid(firstName, lastName, jobTitle, address);

            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            JobTitle = jobTitle;
            Address = address;
        }

        public string FirstName { get; }
        
        public string LastName { get; }
        
        public string JobTitle { get; }
        
        public string Address { get; }

        private static void EnsureArgumentsAreValid(string firstName, string lastName, string jobTitle, string address)
        {
            firstName.EnsureIsNotEmpty("employee first name");
            lastName.EnsureIsNotEmpty("employee last name");
            jobTitle.EnsureIsNotEmpty("employee job title");
            address.EnsureIsNotEmpty("employee address");
        }
    }
}
