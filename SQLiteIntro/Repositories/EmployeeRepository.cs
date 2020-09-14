using Microsoft.EntityFrameworkCore;
using SQLiteIntro.DAL;
using SQLiteIntro.Models;
using SQLiteIntro.Providers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLiteIntro.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeRepository(ApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));

        public async Task<Employee> GetEmployeeAsync(int id) =>
            await _applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

        public async Task<IEnumerable<Employee>> GetEmployeesAsync() =>
            await _applicationDbContext.Employees.ToListAsync().ConfigureAwait(false);

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _applicationDbContext.Employees.AddAsync(employee).ConfigureAwait(false);
            await _applicationDbContext.SaveChangesAsync();
        }
            
    }
}
