using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using HD.Station.Qltb.Abstractions.Abstractions;
using HD.Station.Qltb.Abstractions.DTO;
using HD.Station.Qltb.Abstractions.Data;
using HD.Station.Qltb.Mvc.Models;

namespace HD.Station.Qltb.Mvc.ApiControllers
{
    [Route("api/qltb")]
    [ApiController]
    [Authorize]
    public class QltbApiController : Controller
    {
        private readonly IDeviceManagement _deviceManagement;
        public QltbApiController(IDeviceManagement deviceManagement)
        {
            _deviceManagement = deviceManagement;
        }

        [HttpGet]
        public async Task<ActionResult<DevicesResponseDto>> GetDevices([FromQuery] PagingParameters pagingParameters)
        {
            var devices = await _deviceManagement.GetAllDevices(pagingParameters);
            return devices;
        }

        [HttpGet("{matb}")]
        public async Task<ActionResult<AddDevicesResponseDto>> GetDevice(long matb)
        {
            var donvis = (List<Donvi>)await _deviceManagement.GetAllDonvi();
            var loaithietbis = (List<Loaithietbi>)await _deviceManagement.GetAllLoaithietbi();
            var device = await _deviceManagement.GetDeviceById(matb);
            return new AddDevicesResponseDto(donvis, loaithietbis, device);
        }

        [HttpPut("{matb}")]
        public async Task<ActionResult<AddDevicesResponseDto>> UpdateAsync(
            [Required][FromBody] UpdateDeviceDto request, long matb)
        {
            var donvis = (List<Donvi>)await _deviceManagement.GetAllDonvi();
            var loaithietbis = (List<Loaithietbi>)await _deviceManagement.GetAllLoaithietbi();
            var donviReq = donvis.SingleOrDefault(x => x.Madv == request.Madv);
            var loaithietbiReq = loaithietbis.SingleOrDefault(x => x.Maloai == request.Maloai);
            var device = await _deviceManagement.UpdateDeviceAsync(request, matb, donviReq, loaithietbiReq);
            return new AddDevicesResponseDto(donvis, loaithietbis, device);
        }

        [HttpPost]
        public async Task<ActionResult<AddDevicesResponseDto>> CreateAsync(
            [Required][FromBody] NewDeviceDto request)
        {
            var donvis = (List<Donvi>)await _deviceManagement.GetAllDonvi();
            var loaithietbis = (List<Loaithietbi>)await _deviceManagement.GetAllLoaithietbi();
            var donviReq = donvis.SingleOrDefault(x => x.Madv == request.Madv);
            var loaithietbiReq = loaithietbis.SingleOrDefault(x => x.Maloai == request.Maloai);
            var device = await _deviceManagement.AddDeviceAsync(request, donviReq, loaithietbiReq);
            return new AddDevicesResponseDto(donvis, loaithietbis, device);
        }

        [HttpDelete("{matb}")]
        public async Task<ActionResult> DeleteAsync(long matb)
        {
          await _deviceManagement.DeleteDevice(matb);
          return Ok();
        }
    }
}
