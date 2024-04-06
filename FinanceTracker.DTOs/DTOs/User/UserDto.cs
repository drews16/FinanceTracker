namespace FinanceTracker.DTOs.DTOs.User
{
    public sealed record UserDto(
        int UserId,
        string FirstName,
        string AccessToken
    );
}