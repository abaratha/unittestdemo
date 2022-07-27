using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IEmployeeService
    {
        Task<int> Save(Employee employee);
        Employee? GetById(int id);   
    }
}
