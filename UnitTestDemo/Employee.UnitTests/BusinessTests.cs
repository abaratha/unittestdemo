using Business;
using Data.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Employee.UnitTests
{
    public class BusinessTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository;
        private EmployeeService _employeeService;

        public BusinessTests()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
        }

        [Fact]
        public async Task Can_save_Employee_success()
        {
            Data.Employee employee = new Data.Employee()
            {
                DateOfBirth = DateTime.Now.AddYears(-22),
                EmployeeNumber = 10001,
                Id = 1
            };

            _employeeRepository.Setup(x => x.Save(It.IsAny<Data.Employee>())).ReturnsAsync(1);
            _employeeService = new EmployeeService(_employeeRepository.Object);
            var result = await _employeeService.Save(employee);

            Assert.Equal(1, result);

        }

        [Theory]
        [InlineData(-10, 10001, 0)]
        [InlineData(-23, 0, -1)]
        public async Task Can_save_Employee_failure(int age, int employeeNumber, int expectedResult)
        {
            Data.Employee employee = new Data.Employee()
            {
                DateOfBirth = DateTime.Now.AddYears(age),
                EmployeeNumber = employeeNumber,
                Id = 1
            };

            _employeeRepository.Setup(x => x.Save(It.IsAny<Data.Employee>())).ReturnsAsync(1);
            _employeeService = new EmployeeService(_employeeRepository.Object);
            var result = await _employeeService.Save(employee);

            Assert.Equal(expectedResult, result);

        }

     }
}
