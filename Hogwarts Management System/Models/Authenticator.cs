using System;
using System.Linq;
using Hogwarts_Management_System.Services;

namespace Hogwarts_Management_System.Models
{
    public static class Authenticator
    {
        public static void SignUp(string username, string password, string passwordRepeat,
            string firstName, string lastName, string email, string activationCode)
        {
            if (!username.StartsWith("s"))
                throw new ArgumentException("Student usernames should start with 's'");

            if (Globals.Students.Any(s => s.Username == username))
                throw new ArgumentException("Username already taken.");

            if (!PasswordManager.IsValid(password, passwordRepeat))
                throw new ArgumentException("The entered passwords do not match.");

            if (!PasswordManager.IsStrong(password))
                throw new ArgumentException("Password must be at least 8 characters and contain upper and lower letters.");

            if (!Globals.ActivationCodes.Any(ac => ac.Username == username && ac.Code == activationCode))
                throw new ArgumentException("Invalid activation code.");

            string passwordHash = PasswordManager.GetHash(password);

            Student student = new Student(passwordHash, username, firstName, lastName, email);
            Globals.Students.Add(student);

            FileManager.Save();
        }

        public static void Login(string username, string password, AccessLevel accessLevel)
        {
            User loggedInUser = null;

            string passwordHash = PasswordManager.GetHash(password);

            switch (accessLevel)
            {
                case AccessLevel.Student:
                    loggedInUser = Globals.Students.FirstOrDefault(i => i.Username == username && i.PasswordHash == passwordHash);
                    break;

                case AccessLevel.Teacher:
                    loggedInUser = Globals.Teachers.FirstOrDefault(i => i.Username == username && i.PasswordHash == passwordHash);
                    break;

                case AccessLevel.Admin:
                    loggedInUser = Globals.Admins.FirstOrDefault(i => i.Username == username && i.PasswordHash == passwordHash);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"Unknown access level {accessLevel}");
            }

            if (loggedInUser != null)
            {
                Globals.LoggedInUser = loggedInUser;
                Globals.HasLoggedIn = true;
            }

            else
            {
                Globals.LoggedInUser = null;
                Globals.HasLoggedIn = false;
            }
        }

        public static void Logout()
        {
            Globals.LoggedInUser = null;
            Globals.HasLoggedIn = false;
        }

    }
}
