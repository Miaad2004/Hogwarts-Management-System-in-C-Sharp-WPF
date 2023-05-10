namespace Hogwarts.Core.Models.Authentication
{
    public static class SessionManager
    {
        public static Session? CurrentSession { get; set; } = null;
    }
}
