using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts_Management_System.Models
{
    public class Student: User
    {
        public Student(string passwordHash, string username, string firstName, string lastName, string email)
        {
            PasswordHash = passwordHash;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
