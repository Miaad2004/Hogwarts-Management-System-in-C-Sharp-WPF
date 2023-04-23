using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hogwarts_Management_System.Models
{
    public static class Globals
    {
        public static User LoggedInUser { get; set; } = null;
        public static bool HasLoggedIn { get; set; } = false;
        public static string SavePath { get; set; } = "./";

        public static List<Student> Students = new List<Student>();
        public static List<Teacher> Teachers = new List<Teacher>();
        public static List<Admin> Admins = new List<Admin>();
        public static List<ChatMessage> ChatMessages = new List<ChatMessage>();
        public static List<Assignment> Assignments = new List<Assignment>();
        public static List<ActivationCode> ActivationCodes = new List<ActivationCode>();
    }
}
