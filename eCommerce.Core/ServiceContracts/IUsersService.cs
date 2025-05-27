using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;
/// <summary>
/// Interface for the Users service
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Method to handle the user login use case
    /// </summary>
    /// <param name="loginRequest">The login request containing the user's email and password</param>
    /// <returns>The authentication response containing the user's details and token</returns>
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

    /// <summary>
    /// Method to handle the user registration use case
    /// </summary>
    /// <param name="registerRequest">The registration request containing the user's details</param>
    /// <returns>The authentication response containing the user's details and token</returns>
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);

    /// <summary>
    /// Returns the users data based on the given userID
    /// </summary>
    /// <param name="userID">The user ID to search for</param>
    /// <returns>A UserDTO object that matches the given userID, or null if not found</returns>
    Task<UserDTO> GetUserByUserID(Guid userID);
}