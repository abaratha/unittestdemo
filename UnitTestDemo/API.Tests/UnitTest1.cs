using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTestDemo.Controllers;
using Xunit;

namespace API.Tests
{
    public class UnitTest1
    {
        private readonly Mock<IEmployeeService> _employeeService;
        private EmployeeController _employeeController;

        public UnitTest1()
        {
            _employeeService = new Mock<IEmployeeService>();
            _employeeController = new EmployeeController(_employeeService.Object);

        }

        [Fact]
        public void EmployeeController()
        {
            _employeeService.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Data.Employee { Id = 10, FullName="Test"});
            var result = _employeeController.Get(10) as OkObjectResult;
            var employee = result.Value as Employee;
            Assert.Equal("Test", employee.FullName);
        }
    }
}