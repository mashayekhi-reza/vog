using System;
using VogCodeChallenge.Shared.Exceptions;
using Xunit;

namespace VogCodeChallenge.Domain.Tests
{
    public class EmployeeTest
    {
        private readonly Department _department;

        public EmployeeTest()
        {
            var company = new Company(Guid.NewGuid(), "Vog");
            _department = new Department(Guid.NewGuid(), company, "IT", "Here!");
        }

        [Fact]
        public void NewEmployeeShouldThrowInvalidArgumentExceptionWhenIdIsEmpty()
        {

            var exception = Record.Exception(() => new Employee(Guid.Empty, null, null, null, null, null));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The employee ID cannot be null or empty", exception.Message);
        }

        [Fact]
        public void NewEmployeeShouldThrowInvalidArgumentExceptionWhenDepartmentIsNull()
        {
            var exception = Record.Exception(() => new Employee(Guid.NewGuid(), null, null, null, null, null));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The department cannot be null", exception.Message);
        }

        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void NewEmployeeShouldThrowInvalidArgumentExceptionWhenFirstNameIsEmpty(string firstName)
        {
            var exception = Record.Exception(() => new Employee(Guid.NewGuid(), _department, firstName, null, null, null));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The employee first name cannot be null or empty", exception.Message);
        }

        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void NewEmployeeShouldThrowInvalidArgumentExceptionWhenLastNameIsEmpty(string lastName)
        {
            var exception = Record.Exception(() => new Employee(Guid.NewGuid(), _department, "firstName", lastName, null, null));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The employee last name cannot be null or empty", exception.Message);
        }

        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void NewEmployeeShouldThrowInvalidArgumentExceptionWhenJobTitleIsEmpty(string jobTitle)
        {
            var exception = Record.Exception(() => new Employee(Guid.NewGuid(), _department, "firstName", "lastName", jobTitle, null));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The employee job title cannot be null or empty", exception.Message);
        }

        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void NewEmployeeShouldThrowInvalidArgumentExceptionWhenAddressIsEmpty(string address)
        {
            var exception = Record.Exception(() => new Employee(Guid.NewGuid(), _department, "firstName", "lastName", "jobTitle", address));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The employee address cannot be null or empty", exception.Message);
        }

        [Fact]
        public void NewEmployeeShouldBeCreatedCorrectlyWhenGivenArgumentsAreNotEmpty()
        {
            Guid id = Guid.NewGuid();
            var employee = new Employee(id, _department, "firstName", "lastName", "jobTitle", "address");

            Assert.Equal(id, employee.Id);
            Assert.Same(_department, employee.Department);
            Assert.Equal("firstName", employee.FirstName);
            Assert.Equal("lastName", employee.LastName);
            Assert.Equal("jobTitle", employee.JobTitle);
            Assert.Equal("address", employee.Address);
        }
    }
}
