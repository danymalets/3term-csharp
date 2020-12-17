using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Password password { get; set; }
        public Address address { get; set; }
        public EmailAddress emailAdress { set; get; }
        public PhoneNumber phoneNumber { set; get; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
