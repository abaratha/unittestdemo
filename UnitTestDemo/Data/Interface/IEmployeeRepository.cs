﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IEmployeeRepository
    {
        Task<int> Save(Employee employee);

        Employee? GetById(int id);
    }
}
