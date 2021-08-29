using System;
using System.Collections.Generic;
using System.Linq;
using VogCodeChallenge.Domain;

namespace VogCodeChallenge.ApplicationServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees;


        public EmployeeService()
        {
            var company = new Company(Guid.NewGuid(), "Vog");
            var departments = new Department[]
            {
                new Department(new Guid("45064EE1-65D2-464E-92EE-1F3D70A8D0BC"), company, "IT", "Here"),
                new Department(new Guid("1DD4DE62-1D98-4FA5-9141-64894B41E910"), company, "Business", "There")
            };
            _employees = new List<Employee>()
            {

                new Employee(Guid.NewGuid(), departments[0], "John", "Smith", "IT man1", "address IT 1"),
                new Employee(Guid.NewGuid(), departments[0], "Peter", "White", "IT man2", "address IT 2"),
                new Employee(Guid.NewGuid(), departments[1], "John", "Doe", "Business Man1", "address business 1"),
                new Employee(Guid.NewGuid(), departments[1], "Jean", "Doe", "Business Woman2", "address business 2")
            };
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public IList<Employee> ListAll()
        {
            return _employees;
        }

        public IEnumerable<Employee> GetByDepartment(Guid departmentId)
        {
            return _employees.Where(e => e.Department.Id == departmentId);
        }
    }
}
