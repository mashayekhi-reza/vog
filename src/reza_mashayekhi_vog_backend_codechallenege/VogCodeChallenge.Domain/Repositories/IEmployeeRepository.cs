using System.Linq;

namespace VogCodeChallenge.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAll();
    }
}
