using System;
using System.Threading;

namespace TeamServices.Microservice.TDD.Domain.Models
{
    public class Member
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Member()
        {
            
        }

        public Member(Guid id)
        {
            this.Id = id;
        }

        public Member(string firstName, string lastName, Guid id) : this(id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
