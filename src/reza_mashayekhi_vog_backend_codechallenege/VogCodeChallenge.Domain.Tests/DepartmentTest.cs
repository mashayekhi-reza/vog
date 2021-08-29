using System;
using VogCodeChallenge.Shared.Exceptions;
using Xunit;

namespace VogCodeChallenge.Domain.Tests
{
    public class DepartmentTest
    {
        [Fact]
        public void NewDepartmentShouldThrowInvalidArgumentExceptionWhenIdIsEmpty()
        {
            var exception = Record.Exception(() => new Department(Guid.Empty, null, null, null));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The department ID cannot be null or empty", exception.Message);
        }

        [Fact]
        public void NewDepartmentShouldThrowInvalidArgumentExceptionWhenCompanyIsNull()
        {
            var exception = Record.Exception(() => new Department(Guid.NewGuid(), null, null, null));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The company cannot be null", exception.Message);
        }

        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void NewDepartmentShouldThrowInvalidArgumentExceptionWhenNameIsEmpty(string name)
        {
            var company = new Company(Guid.NewGuid(), "Vog");
            var exception = Record.Exception(() => new Department(Guid.NewGuid(), company, name, null));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The department name cannot be null or empty", exception.Message);
        }

        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void NewDepartmentShouldThrowInvalidArgumentExceptionWhenAddressIsEmpty(string address)
        {
            var company = new Company(Guid.NewGuid(), "Vog");
            var exception = Record.Exception(() => new Department(Guid.NewGuid(), company, "IT", address));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The department address cannot be null or empty", exception.Message);
        }

        [Fact]
        public void NewDepartmentShouldBeCreatedCorrectlyWhenGivenArgumentsAreNotEmpty()
        {
            Guid id = Guid.NewGuid();
            var company = new Company(Guid.NewGuid(), "Vog");            
            var department = new Department(id, company, "IT", "There!");

            Assert.Equal(id, department.Id);
            Assert.Same(company, department.Company);
            Assert.Equal("IT", department.Name);
            Assert.Equal("There!", department.Address);
        }
    }
}
