using Data;
using Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeService)
        {
            _employeeRepository = employeeService;
        }

        public Employee? GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public async Task<int> Save(Employee employee)
        {
            return await _employeeRepository.Save(employee);
        }
    }
}
