using Microsoft.EntityFrameworkCore;
using System.Linq;
using VogCodeChallenge.Domain;
using VogCodeChallenge.Domain.Repositories;

namespace VogCodeChallenge.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly VogDBContext _dBContext;

        public EmployeeRepository(VogDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IQueryable<Employee> GetAll()
        {
            return _dBContext.Employees.Include(e => e.Department).Include(e => e.Department.Company);
        }
    }
}
