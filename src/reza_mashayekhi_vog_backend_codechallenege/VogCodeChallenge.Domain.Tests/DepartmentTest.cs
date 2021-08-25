using System;
using System.Linq;
using VogCodeChallenge.Shared.Exceptions;
using Xunit;

namespace VogCodeChallenge.Domain.Tests
{
    public class DepartmentTest
    {
        private readonly Company _company;

        public DepartmentTest()
        {
            _company = new Company("Vog");
        }

        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void AddEmployeeShouldThrowInvalidArgumentExceptionWhenFirstNameIsEmpty(string firstName)
        {
            _company.AddDepartment("IT", "There!");
            var department = _company.Departments.Single();
            var exception = Record.Exception(() => department.AddEmployee(firstName, null, null, null));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The employee first name cannot be null or empty", exception.Message);
        }

        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void AddEmployeeShouldThrowInvalidArgumentExceptionWhenLastNameIsEmpty(string lastName)
        {
            _company.AddDepartment("IT", "There!");
            var department = _company.Departments.Single();
            var exception = Record.Exception(() => department.AddEmployee("firstName", lastName, null, null));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The employee last name cannot be null or empty", exception.Message);
        }

        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void AddEmployeeShouldThrowInvalidArgumentExceptionWhenJobTitleIsEmpty(string jobTitle)
        {
            _company.AddDepartment("IT", "There!");
            var department = _company.Departments.Single();
            var exception = Record.Exception(() => department.AddEmployee("firstName", "lastName", jobTitle, null));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The employee job title cannot be null or empty", exception.Message);
        }

        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void AddEmployeeShouldThrowInvalidArgumentExceptionWhenAddressIsEmpty(string address)
        {
            _company.AddDepartment("IT", "There!");
            var department = _company.Departments.Single();
            var exception = Record.Exception(() => department.AddEmployee("firstName", "lastName", "jobTitle", address));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The employee address cannot be null or empty", exception.Message);
        }

        [Fact]
        public void CreateNewDepartmentWithEmployeeWhenGivenArgumentsAreNotEmpty()
        {
            _company.AddDepartment("IT", "There!");
            var department = _company.Departments.Single();
            department.AddEmployee("firstname", "lastname", "jobtitle", "address");
            var employee = department.Employees.Single();

            Assert.Equal("IT", department.Name);
            Assert.Equal("There!", department.Address);
            Assert.Equal("firstname", employee.FirstName);
            Assert.Equal("lastname", employee.LastName);
            Assert.Equal("jobtitle", employee.JobTitle);
            Assert.Equal("address", employee.Address);
        }

        [Fact]
        public void CreateNewDepartmentWithEmployeeInWhichTheEmployeeIdMustNotBeEmpty()
        {
            _company.AddDepartment("IT", "There!");
            var department = _company.Departments.Single();
            department.AddEmployee("firstname", "lastname", "jobtitle", "address");
            var employee = department.Employees.Single();

            Assert.NotEqual(Guid.Empty, employee.Id);
        }

        [Fact]
        public void CreateNewDepartmentWithTwoEmployeesInWhichTheEmployeesMustHaveUniqueIds()
        {
            _company.AddDepartment("IT", "There!");
            var department = _company.Departments.Single();
            department.AddEmployee("firstname1", "lastname1", "jobtitle1", "address1");
            department.AddEmployee("firstname2", "lastname2", "jobtitle2", "address2");
            var employee1 = department.Employees.Single(e => e.FirstName == "firstname1");
            var employee2 = department.Employees.Single(e => e.FirstName == "firstname2");

            Assert.NotEqual(employee1.Id, employee2.Id);
        }
    }
}
