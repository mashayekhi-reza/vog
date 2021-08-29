using System;
using VogCodeChallenge.Shared;

namespace VogCodeChallenge.Domain
{
    public class Company : Entity
    {
        public Company(Guid id, string name)
        {
            
            id.EnsureIsNotEmpty("company ID");
            name.EnsureIsNotEmpty("company name");            

            Id = id;
            Name = name;
        }
        
        public string Name { get; }
    }
}
