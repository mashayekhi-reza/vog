using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VogCodeChallenge.Domain;
using VogCodeChallenge.Domain.Repositories;

namespace VogCodeChallenge.ApplicationServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetByDepartment(Guid departmentId)
        {
            return await _repository.GetAll().Where(e => e.Department.Id == departmentId).ToListAsync();
        }

        public async Task<IList<Employee>> ListAll()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}
