using eCommerce.Core.Domain.IdentityEntities;

namespace eCommerce.Core.RepositoryContracts
{
    /// <summary>
    /// Interface for the Users repository
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Method to add a user to the data store and return the added user
        /// </summary>
        /// <param name="user">The user to be added</param>
        /// <returns>The user if added successfully, otherwise null</returns>
        Task<ApplicationUser?> AddUser(ApplicationUser user);

        /// <summary>
        /// Method to get a user by email and password
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="password">The password of the user</param>
        /// <returns>The user if found, otherwise null</returns>
        Task<ApplicationUser?> GetUserByEmailAndPassword(
            string? email,
            string? password);

        /// <summary>
        /// Returns the users data based on the given userID
        /// </summary>
        /// <param name="userID">User ID to search for</param>
        /// <returns>ApplicationUser object that matches with given userID</returns>
        Task<ApplicationUser?> GetUserByUserID(Guid? userID);
    }
}