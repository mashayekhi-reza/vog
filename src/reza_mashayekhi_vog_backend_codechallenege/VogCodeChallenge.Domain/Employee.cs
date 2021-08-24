namespace VogCodeChallenge.Domain
{
    public class Employee
    {
        internal Employee(string firstName, string lastName, string jobTitle, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            JobTitle = jobTitle;
            Address = address;
        }
        public string FirstName { get; }
        public string LastName { get; }
        public string JobTitle { get; }
        public string Address { get; }
    }
}
