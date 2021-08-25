using System;
using System.Linq;
using VogCodeChallenge.Shared.Exceptions;
using Xunit;

namespace VogCodeChallenge.Domain.Tests
{
    public class CompanyTest
    {
        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void CreateNewCompanyShouldThrowInvalidArgumentExceptionWhenNameIsEmpty(string name)
        {
            var exception = Record.Exception(() => new Company(name));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The company name cannot be null or empty", exception.Message);
        }

        [Fact]
        public void CreateNewCompanyCorrectlyWhenGivenNameIsNotEmpty()
        {
            var company = new Company("Vog");
            Assert.Equal("Vog", company.Name);
        }

        [Fact]
        public void NewCompanyShouldNotHaveEmptyId()
        {
            var company = new Company("Vog");
            Assert.NotEqual(Guid.Empty, company.Id);
        }

        [Fact]
        public void NewCompanyShouldHaveUniqueId()
        {
            var first = new Company("Vog");
            var second = new Company("Microsoft");
            Assert.NotEqual(first.Id, second.Id);
        }

        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void AddDepartmentShouldThrowInvalidArgumentExceptionWhenNameIsEmpty(string name)
        {
            var company = new Company("Vog");
            var exception = Record.Exception(() => company.AddDepartment(name, null));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The department name cannot be null or empty", exception.Message);
        }

        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void AddDepartmentShouldThrowInvalidArgumentExceptionWhenAddressIsEmpty(string address)
        {
            var company = new Company("Vog");
            var exception = Record.Exception(() => company.AddDepartment("IT", address));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The department address cannot be null or empty", exception.Message);
        }

        [Fact]
        public void AddDepartmentShouldAddNewDepartmentCorrectlyWhenGivenNameAndAddressAreNotEmpty()
        {
            var company = new Company("Vog");
            company.AddDepartment("IT", "There!");
            var department = company.Departments.Single();
            Assert.Equal("IT", department.Name);
            Assert.Equal("There!", department.Address);
        }

        [Fact]
        public void AddedDepartmentShouldNotHaveEmptyId()
        {
            var company = new Company("Vog");
            company.AddDepartment("IT", "There!");
            var department = company.Departments.Single();
            Assert.NotEqual(Guid.Empty, department.Id);
        }

        [Fact]
        public void AddedDepartmentShouldHaveUniqueId()
        {
            var company = new Company("Vog");
            company.AddDepartment("IT", "Here!");
            company.AddDepartment("Business", "There!");
            Assert.NotEqual(company.Departments.First().Id, company.Departments.Last().Id);
        }

        [Fact]
        public void AddDepartmentShouldThrowExceptionWhenAddressIsNotUnique()
        {
            var company = new Company("Vog");
            company.AddDepartment("IT", "Here!");

            var exception = Record.Exception(() => company.AddDepartment("Business", "Here!"));

            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("Given address exists for another department", exception.Message);
        }
    }
}
