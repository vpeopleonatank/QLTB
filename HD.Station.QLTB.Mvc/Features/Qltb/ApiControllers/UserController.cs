using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using HD.Station.Qltb.Abstractions.Abstractions;

namespace HD.Station.Qltb.Mvc.ApiControllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IDeviceManagement _deviceManagement;
        public UserController(IDeviceManagement deviceManagement)
        {
            _deviceManagement = deviceManagement;
        }

        // [HttpPost]
        // public async Task< 
    }
}
