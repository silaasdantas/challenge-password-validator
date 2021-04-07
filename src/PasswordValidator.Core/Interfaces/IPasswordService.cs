namespace PasswordValidator.Core.Interfaces
{
    public interface IPasswordService
    {
        bool IsValid(string password);
    }
}
