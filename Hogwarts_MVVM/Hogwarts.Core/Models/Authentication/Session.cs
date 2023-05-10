using System;

namespace Hogwarts.Core.Models.Authentication
{
    public sealed class Session
    {
        private readonly static TimeSpan EXPIRE_TIME_SPAN = TimeSpan.FromMinutes(60);
        private readonly DateTime _loginTime;

        public readonly int Id;
        public User User { get; private set; }
        public DateTime ExpireDate => _loginTime + EXPIRE_TIME_SPAN;

        private bool _hasBeenRevoked = false;
        public bool HasExpired => DateTime.UtcNow >= ExpireDate && _hasBeenRevoked;

        public Session(User user)
        {
            User = user;
            _loginTime = DateTime.UtcNow;
            Id = GetHashCode();
        }

        public void Revoke()
        {
            _hasBeenRevoked = true;
        }

        public override string ToString()
        {
            return $"Session - Username: {User.Username} - Access Level: {User.AccessLevel} - Session Expire date: {ExpireDate}";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(_loginTime, User, ExpireDate, _hasBeenRevoked, HasExpired);
        }
    }
}
