namespace Hogwarts.Core.Models.Authentication
{
    public static class SessionManager
    {
        public static Session? CurrentSession { get; set; } = null;
        public static bool IsCurrentSessionActive()
        {
            return CurrentSession != null &&
                   !CurrentSession.HasExpired;
        }

        public static void AuthorizeMethodAccess(AccessLevels requiredAccessLevel)
        {
            if (requiredAccessLevel == AccessLevels.Unauthorized) return;
            if (!IsCurrentSessionActive() || CurrentSession?.User.AccessLevel < requiredAccessLevel)
            {
                throw new UnauthorizedAccessException("You are not authorized to access this functionality.");
            }
        }
    }
}
