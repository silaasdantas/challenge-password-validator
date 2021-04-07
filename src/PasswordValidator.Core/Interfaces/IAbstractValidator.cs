namespace PasswordValidator.Core.Interfaces
{
    public interface IAbstractValidator<T>
    {
         bool IsValid(T value);
    }
}
