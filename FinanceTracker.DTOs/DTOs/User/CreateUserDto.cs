namespace FinanceTracker.DTOs.DTOs.User
{
    public sealed record CreateUserDto(
        string FirstName,
        string LastName,
        string Login,
        string Password,
        string ConfirmedPassword);
}