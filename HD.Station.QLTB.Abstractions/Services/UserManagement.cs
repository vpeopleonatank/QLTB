using HD.Station.Qltb.Abstractions.Abstractions;

using HD.Station.Qltb.Abstractions.Stores;
using HD.Station.Qltb.Abstractions.Data;
using HD.Station.Qltb.Abstractions.DTO;


namespace HD.Station.Qltb.Abstractions.Services
{
    public record UserResponse(UserDTO User);
    public class UserManagement : IUserManagement
    {
        private readonly IDeviceStore _deviceStore;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ICurrentUser _currentUser;
        public UserManagement(IDeviceStore deviceStore, IPasswordHasher passwordHasher,
            IJwtTokenGenerator jwtTokenGenerator,
            ICurrentUser currentUser)
        {
            _deviceStore = deviceStore;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _currentUser = currentUser;
        }
        public async Task<UserAccount?> GetUserById(long id)
        {
            return await _deviceStore.FindUserById(id);
        }

        public async Task<bool> CheckUserExist(string email)
        {
            return await _deviceStore.CheckUserExist(email);
        }

        public async Task<UserDTO> CreateUser(NewUserDTO newUserDTO)
        {
            var user = await _deviceStore.CreateUser(newUserDTO.Username,
             newUserDTO.Email, _passwordHasher.Hash(newUserDTO.Password));

            return user.Map(_jwtTokenGenerator);
        }

        public async Task<UserAccount?> Login(UserLoginDTO userLoginDTO)
        {
          var user = await _deviceStore.FindUser(userLoginDTO.Email, userLoginDTO.Password);
          return user;
        }

        public async Task<UserDTO> GetCurrentUser()
        {
          return await Task.FromResult(_currentUser.User!.Map(_jwtTokenGenerator));
        }
    }

}
