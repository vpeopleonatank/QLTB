using Microsoft.AspNetCore.Mvc;
using HD.Station.Qltb.Abstractions.Data;
using HD.Station.Qltb.Abstractions.Abstractions;
using HD.Station.Qltb.Mvc.Models;

namespace HD.Station.Qltb.Mvc.ApiControllers
{
    [Route("[controller]")]
    public class QltbController : Controller
    {
        private readonly IDeviceManagement _deviceManagement;
        public QltbController(IDeviceManagement deviceManagement)
        {
            _deviceManagement = deviceManagement;
        }

        // [HttpGet]
        // public async Task<IActionResult<IEnumerable<ThietbiDTO>>> Get(int id)
        // {
        //     var devices = await _deviceManage.GetAllDevices();
        //     var devicesVM = new ThietbiDTO
        //     {
        //         Thietbis = devices as List<Thietbi>
        //     };
        // }
    }
}