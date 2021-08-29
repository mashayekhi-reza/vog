using System;
using VogCodeChallenge.Shared.Exceptions;
using Xunit;

namespace VogCodeChallenge.Domain.Tests
{
    public class CompanyTest
    {
        [Fact]
        public void NewCompanyShouldThrowInvalidArgumentExceptionWhenIdIsEmpty()
        {
            var exception = Record.Exception(() => new Company(Guid.Empty, null));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The company ID cannot be null or empty", exception.Message);
        }

        [Theory]
        [ClassData(typeof(EmptyStringData))]
        public void NewCompanyShouldThrowInvalidArgumentExceptionWhenNameIsEmpty(string name)
        {
            var exception = Record.Exception(() => new Company(Guid.NewGuid(), name));
            Assert.NotNull(exception);
            Assert.IsType<InvalidArgumentException>(exception);
            Assert.Equal("The company name cannot be null or empty", exception.Message);
        }

        [Fact]
        public void NewCompanyShouldBeCreatedCorrectlyWhenGivenArgumentsAreNotEmpty()
        {
            Guid id = Guid.NewGuid();
            var company = new Company(id, "Vog");
            
            Assert.Equal(id, company.Id);
            Assert.Equal("Vog", company.Name);
        }        
    }
}
