using Dapper;

using eCommerce.Core.Domain.IdentityEntities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;
internal class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();

        // SQL Query to insert user data into the "Users" table.
        string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";

        int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

        if (rowCountAffected > 0)
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        // SQL query to select a user by email and password.
        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";

        // Execute the query and return the first matching user.
        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { Email = email, Password = password });

        return user;
    }

    public async Task<ApplicationUser?> GetUserByUserID(Guid? userID)
    {
        if (userID == null)
        {
            return null;
        }

        string query = "SELECT * FROM public.\"Users\" WHERE \"UserID\" = @UserID";

        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { UserID = userID });

        return user;
    }
}