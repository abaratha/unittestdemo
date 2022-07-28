using Business;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTestDemo.Controllers;
using Xunit;


namespace Employee.UnitTests
{
    public class EmployeeUnitTest
    {
        private readonly Mock<IEmployeeService> _employeeService;

        public EmployeeUnitTest()
        {
            _employeeService = new Mock<IEmployeeService>();
        }

        [Fact]
        public void Test_Employee_Get_Success()
        {
            _employeeService.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Data.Employee { Id = 1, DateOfBirth = System.DateTime.Now.AddYears(-10) });

            EmployeeController controller = new EmployeeController(_employeeService.Object);

            var result = controller.Get(1) as OkObjectResult;
            Assert.NotNull(result);
            var employee = result.Value as Data.Employee;
            Assert.Equal(1, employee.Id);
        }

        [Fact]
        public void Test_Employee_Get_Failure()
        {
            _employeeService.Setup(x => x.GetById(It.IsAny<int>())).Returns((Data.Employee)null);

            EmployeeController controller = new EmployeeController(_employeeService.Object);
            var result = controller.Get(1) as OkObjectResult;
            Assert.Null(result);

        }
    }
}