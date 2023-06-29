using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HD.Station.Qltb.Abstractions.Abstractions;
using HD.Station.Qltb.Abstractions.DTO;

namespace HD.Station.Qltb.Mvc.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QltbController : Controller
    {
        private readonly IDeviceManagement _deviceManagement;
        public QltbController(IDeviceManagement deviceManagement)
        {
            _deviceManagement = deviceManagement;
        }

        [HttpGet]
        public async Task<ActionResult<DevicesResponseDto>> Get([FromQuery] PagingParameters pagingParameters)
        {
            var devices = await _deviceManagement.GetAllDevices(pagingParameters);
            return devices;
        }
    }
}
