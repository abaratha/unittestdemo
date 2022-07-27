using Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _employeeDbContext = context;
        }

        public async Task<int> Save(Employee employee)
        {
            if(employee.Id > 0)
                _employeeDbContext.Update(employee);
            else
                _employeeDbContext.Add(employee);

            return await _employeeDbContext.SaveChangesAsync();
        }

        public Employee? GetById(int id)
        {
            return _employeeDbContext.Employee.FirstOrDefault(x => x.Id == id);
        }
    }
}
