namespace eCommerce.Core.Domain.IdentityEntities
{
    /// <summary>
    /// Represents a user in the application.
    /// </summary>
    public class ApplicationUser
    {
        public Guid UserID { get; set; }

        public string? Email { get; set; } = string.Empty;

        public string? Password { get; set; } = string.Empty;

        public string? PersonName { get; set; } = string.Empty;

        public string? Gender { get; set; } = string.Empty;
    }
}