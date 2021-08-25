using System.Collections.Generic;
using VogCodeChallenge.Domain;

namespace VogCodeChallenge.ApplicationServices
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        IList<Employee> ListAll();
    }
}