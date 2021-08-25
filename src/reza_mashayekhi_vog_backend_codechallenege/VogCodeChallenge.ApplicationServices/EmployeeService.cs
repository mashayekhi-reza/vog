using System.Collections.Generic;
using System.Linq;
using VogCodeChallenge.Domain;

namespace VogCodeChallenge.ApplicationServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Company _company;

        public EmployeeService()
        {
            _company = new Company("Vog");
            _company.AddDepartment("IT", "Here!");
            var it = _company.Departments.Single();
            it.AddEmployee("John", "Smith", "IT man1", "address IT 1");
            it.AddEmployee("Peter", "White", "IT man2", "address IT 2");

            _company.AddDepartment("Business", "There!");
            var business = _company.Departments.Last();
            business.AddEmployee("John", "Doe", "Business Man1", "address business 1");
            business.AddEmployee("Jean", "Doe", "Business Woman2", "address business 2");
        }

        public IEnumerable<Employee> GetAll()
        {
            return _company.Departments.SelectMany(d => d.Employees);
        }

        public IList<Employee> ListAll()
        {
            return GetAll().ToList();

        }

    }
}
