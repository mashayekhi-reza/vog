using System;
using System.Collections.Generic;
using System.Linq;
using VogCodeChallenge.Shared;
using VogCodeChallenge.Shared.Exceptions;

namespace VogCodeChallenge.Domain
{
    public class Company : Entity
    {
        public Company(string name)
        {
            name.EnsureIsNotEmpty("company name");

            Id = Guid.NewGuid();
            Name = name;
            _departments = new List<Department>();
        }
        
        public string Name { get; }
        
        public IReadOnlyCollection<Department> Departments => _departments.AsReadOnly();
        private List<Department> _departments;

        public void AddDepartment(string name, string address)
        {
            if(_departments.Any(d => d.Address == address))
            {
                throw new InvalidArgumentException("Given address exists for another department");
            }

            _departments.Add(new Department(name, address));
        }
    }
}
