namespace Hogwarts.Core.Models.Authentication.Services
{
    public interface IPasswordService
    {
        string GetHash(string? password);
        bool IsStrong(string? password);
        bool IsValid(string? password, string? passwordRepeat);
    }
}
