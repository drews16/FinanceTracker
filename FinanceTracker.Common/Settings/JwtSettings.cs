namespace FinanceTracker.Common.Settings
{
    public sealed class JwtSettings
    {
        public required string Issuer { get; init; }
        public required string Audience { get; init; }
        public required string Key { get; init; }
        public required int Expire { get; init; }
    }
}