using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HD.Station.Qltb.Abstractions.Abstractions;
using HD.Station.Qltb.Abstractions.DTO;

namespace HD.Station.Qltb.Mvc.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IDeviceManagement _deviceManagement;
        private readonly IUserManagement _userManagement;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public UserController(IDeviceManagement deviceManagement, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator, IUserManagement userManagement)
        {
            _deviceManagement = deviceManagement;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManagement = userManagement;
            _passwordHasher = passwordHasher;
        }

        [HttpGet("GetCurrentUser")]
        public async Task<UserDTO> Current(CancellationToken cancellationToken)
        {
            return await _userManagement.GetCurrentUser();
        }

    }
}

