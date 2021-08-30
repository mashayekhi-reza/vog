using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VogCodeChallenge.Domain;

namespace VogCodeChallenge.ApplicationServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<IList<Employee>> ListAll();
        Task<IEnumerable<Employee>> GetByDepartment(Guid departmentId);
    }
}