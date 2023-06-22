using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HD.Station.Qltb.Abstractions.Abstractions;
using HD.Station.Qltb.Abstractions.DTO;

namespace HD.Station.Qltb.Mvc.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("")]
        public ActionResult<string> GetStr()
        {
            return "abc123";
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register([FromBody] NewUserDTO newUserDtoRequest, CancellationToken cancellationToken)
        {
            if (newUserDtoRequest != null && newUserDtoRequest.Email != null
                && newUserDtoRequest.Password != null
                && newUserDtoRequest.Username != null)
            {
                if (await _userManagement.CheckUserExist(newUserDtoRequest.Email))
                {
                    ModelState.AddModelError(nameof(newUserDtoRequest.Email), "Email existed!");
                }
            }
            else if (newUserDtoRequest == null)
            {
                ModelState.AddModelError("Body", "Parse body data error");
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                );
                var errorResponse = new ErrorResponse
                {
                    Message = "Validation failed",
                    Errors = errors
                };
                return BadRequest(errorResponse);
            }
            var userDTO = await _userManagement.CreateUser(newUserDtoRequest);
            return Ok(userDTO);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] UserLoginDTO userLoginDTO, CancellationToken cancellationToken)
        {
            UserDTO userDTO = new UserDTO();
            if (userLoginDTO != null && userLoginDTO.Email != null
                && userLoginDTO.Password != null)
            {
                var user = await _userManagement.Login(userLoginDTO);
                if (user?.Password is null || !_passwordHasher.Check(userLoginDTO.Password, user.Password))
                {
                    ModelState.AddModelError("Email or Password", "Bad credentials");
                }
                else
                {
                    userDTO = user.Map(_jwtTokenGenerator);
                }
            }
            else if (userLoginDTO == null)
            {
                ModelState.AddModelError("Body", "Parse body data error");
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                );
                var errorResponse = new ErrorResponse
                {
                    Message = "Validation failed",
                    Errors = errors
                };
                return BadRequest(errorResponse);
            }
            return Ok(userDTO);
        }
    }
}

