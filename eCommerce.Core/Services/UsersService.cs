using AutoMapper;

using eCommerce.Core.Domain.IdentityEntities;
using eCommerce.Core.DTO;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    internal class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(
                loginRequest.Email,
                loginRequest.Password);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<AuthenticationResponse>(user) with
            { Success = true, Token = "token" };
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            ApplicationUser? user = _mapper.Map<ApplicationUser>(registerRequest);

            // UserID created in the repository
            ApplicationUser? registeredUser = await _usersRepository.AddUser(user);

            if (registeredUser == null)
            {
                return null;
            }

            return _mapper.Map<AuthenticationResponse>(user) with
            { Success = true, Token = "token" };
        }

        public async Task<UserDTO> GetUserByUserID(Guid userID)
        {
            ApplicationUser? user = await _usersRepository.GetUserByUserID(userID);

            UserDTO userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }
    }
}