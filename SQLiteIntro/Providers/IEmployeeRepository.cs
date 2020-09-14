using System.Collections.Generic;
using System.Threading.Tasks;
using SQLiteIntro.Models;

namespace SQLiteIntro.Providers
{
    public interface IEmployeeRepository
    {
        Task AddEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesAsync();
    }
}