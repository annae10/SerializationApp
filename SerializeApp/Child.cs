using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeApp
{
    public class Child
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int64 BirthDate { get; set; }
        public Enums Gender { get; set; }
        public Child(int id, string firstName, string lastName,
            long birthdate, Enums gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthdate;
            Gender = gender;
        }
    }
}
