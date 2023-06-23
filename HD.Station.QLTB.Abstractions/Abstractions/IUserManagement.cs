using HD.Station.Qltb.Abstractions.Data;
using HD.Station.Qltb.Abstractions.DTO;

namespace HD.Station.Qltb.Abstractions.Abstractions
{
    public interface IUserManagement
    {
        public Task<UserAccount?> GetUserById(long id);
        public Task<bool> CheckUserExist(string email);
        public Task<UserDTO> CreateUser(NewUserDTO newUserDTO);
        public Task<UserAccount?> Login(UserLoginDTO userLoginDTO);
        public Task<UserDTO> GetCurrentUser();
    }
}
