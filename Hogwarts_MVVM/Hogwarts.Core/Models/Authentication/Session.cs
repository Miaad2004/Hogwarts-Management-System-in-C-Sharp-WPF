using System.ComponentModel.DataAnnotations;

namespace Hogwarts.Core.Models.Authentication
{
    public sealed class Session
    {
        private static readonly TimeSpan EXPIRE_TIME_SPAN = TimeSpan.FromMinutes(60);
        private readonly DateTime _creationDate;

        [Key]
        public readonly int Id;
        public User User { get; private set; }
        public DateTime ExpireDate => _creationDate + EXPIRE_TIME_SPAN;

        private bool _hasBeenRevoked = false;
        public bool HasExpired => DateTime.UtcNow >= ExpireDate || _hasBeenRevoked;

        public Session(User user)
            : base()
        {
            User = user;
            _creationDate = DateTime.UtcNow;
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
            return HashCode.Combine(_creationDate, User, ExpireDate, _hasBeenRevoked, HasExpired);
        }
    }
}
