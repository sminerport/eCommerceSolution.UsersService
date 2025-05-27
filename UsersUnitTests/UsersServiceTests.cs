using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Domain.IdentityEntities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Mappers;

namespace UsersUnitTests;

public class UsersServiceTests
{
    private static IMapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(ApplicationUserToAuthenticationResponseMappingProfile).Assembly);
        });
        return config.CreateMapper();
    }

    private static IUsersService CreateService(FakeUsersRepository repository, IMapper mapper)
    {
        var type = typeof(IUsersService).Assembly.GetType("eCommerce.Core.Services.UsersService", true)!;
        return (IUsersService)Activator.CreateInstance(type, repository, mapper)!;
    }

    [Fact]
    public async Task Login_InvalidCredentials_ReturnsNull()
    {
        var repo = new FakeUsersRepository { UserForLogin = null };
        var mapper = CreateMapper();
        var service = CreateService(repo, mapper);

        var result = await service.Login(new LoginRequest("fake@example.com", "bad"));

        Assert.Null(result);
    }

    [Fact]
    public async Task Login_ValidCredentials_ReturnsUser()
    {
        var user = new ApplicationUser
        {
            UserID = Guid.NewGuid(),
            Email = "valid@example.com",
            PersonName = "Valid",
            Gender = "Male"
        };
        var repo = new FakeUsersRepository { UserForLogin = user };
        var mapper = CreateMapper();
        var service = CreateService(repo, mapper);

        var result = await service.Login(new LoginRequest("valid@example.com", "good"));

        Assert.NotNull(result);
        Assert.True(result!.Success);
        Assert.Equal(user.UserID, result.UserID);
        Assert.Equal("token", result.Token);
    }

    [Fact]
    public async Task Register_ReturnsAuthenticationResponse()
    {
        var repo = new FakeUsersRepository();
        var mapper = CreateMapper();
        var service = CreateService(repo, mapper);

        var request = new RegisterRequest(
            "alice@example.com",
            "password",
            "Alice",
            GenderOptions.Female);

        var result = await service.Register(request);

        Assert.NotNull(result);
        Assert.True(result!.Success);
        Assert.Equal(request.Email, result.Email);
        Assert.Equal("token", result.Token);
    }

    [Fact]
    public async Task GetUserByUserID_ReturnsDto()
    {
        var userId = Guid.NewGuid();
        var repo = new FakeUsersRepository
        {
            UserForGetById = new ApplicationUser
            {
                UserID = userId,
                Email = "user@example.com",
                PersonName = "User",
                Gender = "Male"
            }
        };
        var mapper = CreateMapper();
        var service = CreateService(repo, mapper);

        var result = await service.GetUserByUserID(userId);

        Assert.NotNull(result);
        Assert.Equal(userId, result.UserID);
        Assert.Equal("User", result.PersonName);
    }

    private class FakeUsersRepository : IUsersRepository
    {
        public ApplicationUser? UserForLogin { get; set; }
        public ApplicationUser? UserForGetById { get; set; }

        public Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserID = Guid.NewGuid();
            return Task.FromResult<ApplicationUser?>(user);
        }

        public Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
            => Task.FromResult(UserForLogin);

        public Task<ApplicationUser?> GetUserByUserID(Guid? userID)
            => Task.FromResult(UserForGetById);
    }
}
