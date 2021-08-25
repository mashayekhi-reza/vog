using System;
using System.Collections.Generic;
using VogCodeChallenge.Shared;

namespace VogCodeChallenge.Domain
{
    public class Department : Entity
    {
        internal Department(string name, string address)
        {
            EnsureArgumentsAreValid(name, address);

            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            _employees = new List<Employee>();
        }
        
        public string Name { get; }
        
        public string Address { get; }
        
        public IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();
        private List<Employee> _employees;
        
        public void AddEmployee(string firstName, string lastName, string jobTitle, string address)
        {
            _employees.Add(new Employee(firstName, lastName, jobTitle, address));
        }

        private static void EnsureArgumentsAreValid(string name, string address)
        {
            name.EnsureIsNotEmpty("department name");
            address.EnsureIsNotEmpty("department address");
        }

    }
}
