using System;
using VogCodeChallenge.Shared;
using VogCodeChallenge.Shared.Exceptions;

namespace VogCodeChallenge.Domain
{
    public class Department : Entity
    {
        public Department()
        {

        }

        public Department(Guid id, Company company, string name, string address)
        {
            EnsureArgumentsAreValid(id, company, name, address);            
            Id = id;
            Company = company;
            Name = name;
            Address = address;
        }
        public Company Company { get;}
        
        public string Name { get; }
        
        public string Address { get; }

        private static void EnsureArgumentsAreValid(Guid id, Company company, string name, string address)
        {
            id.EnsureIsNotEmpty("department ID");
            
            if(company == null)
            {
                throw new InvalidArgumentException("The company cannot be null");
            }

            name.EnsureIsNotEmpty("department name");
            address.EnsureIsNotEmpty("department address");            
        }

    }
}
