﻿using HD.Station.Qltb.Abstractions.Abstractions;
using HD.Station.Qltb.Abstractions.Data;
using HD.Station.Qltb.Abstractions.DTO;
using HD.Station.Qltb.Abstractions.Stores;

namespace HD.Station.Qltb.Abstractions.Services
{
    public class DeviceManagement : IDeviceManagement
    {
        private readonly IDeviceStore _deviceStore;
        public DeviceManagement(IDeviceStore deviceStore)
        {
            _deviceStore = deviceStore;
        }
        public async Task<IEnumerable<Thietbi>> GetAllDevices()
        {
            var DevicesList = await _deviceStore.GetAllDevices();
            if (DevicesList == null)
            {
                return null;
            }

            return DevicesList;
        }

        public async Task<DevicesResponseDto> GetAllDevices(PagingParameters pagingParameters)
        {
            var thietbis = (List<Thietbi>)await _deviceStore.GetAllDevices(pagingParameters);
            var thietbiDtos = thietbis.Select(
                thietbiEntity => ThietbiDTO.MapFromThietbi(thietbiEntity)).ToList();
            var devicesTotal = await _deviceStore.GetDevicesTotal();
            return new DevicesResponseDto(thietbiDtos, devicesTotal);

        }

        public async Task<ThietbiDTO> AddDeviceAsync(NewDeviceDto deviceDto,
            Donvi donvi, Loaithietbi loaithietbi)
        {
            var thietbi = new Thietbi
            {
                Madv = deviceDto.Madv,
                Maloai = deviceDto.Maloai,
                Tentb = deviceDto.Tentb,
                Nuocsx = deviceDto.Nuocsx,
            };
            await _deviceStore.Add(thietbi);
            thietbi.Donvi = donvi;
            thietbi.Loaithietbi = loaithietbi;
            var thietbiDto = ThietbiDTO.MapFromThietbi(thietbi);
            return thietbiDto;
        }

        public async Task<ThietbiDTO> UpdateDeviceAsync(UpdateDeviceDto deviceDto, long matb,
            Donvi donviReq, Loaithietbi loaithietbiReq)
        {
            var thietbi = await _deviceStore.FindDeviceById(matb);
            thietbi.UpdateThietbi(deviceDto);
            await _deviceStore.SaveChangesAsync();
            thietbi.Donvi = donviReq;
            thietbi.Loaithietbi = loaithietbiReq;
            var thietbiDto = ThietbiDTO.MapFromThietbi(thietbi);
            return thietbiDto;
        }

        public async Task<ThietbiDTO> GetDeviceById(long id)
        {
            var Device = await _deviceStore.GetDeviceById(id);
            if (Device == null)
            {
                return null;
            }
            var thietbiDto = ThietbiDTO.MapFromThietbi(Device);
            return thietbiDto;
        }
        public async Task<IEnumerable<Donvi>> GetAllDonvi()
        {
            var DonviList = await _deviceStore.GetAllDonvi(true);
            if (DonviList == null)
            {
                return null;
            }

            return DonviList;
        }

        public async Task<IEnumerable<DonviDTO>> GetDonvis()
        {
            var DonviList = await _deviceStore.GetAllDonvi(true);
            if (DonviList == null)
            {
                return null;
            }
            IEnumerable<DonviDTO> donviDTOs = DonviList
                .Select(a => new DonviDTO { Madv = a.Madv, Tendv = a.Tendv }).ToList();

            return donviDTOs;
        }

        public async Task<IEnumerable<Loaithietbi>> GetAllLoaithietbi()
        {
            var LoaithietbiList = await _deviceStore.GetAllLoaithietbi(true);
            if (LoaithietbiList == null)
            {
                return null;
            }

            return LoaithietbiList;
        }

        public async Task<IEnumerable<LoaiThietbiDTO>> GetLoaithietbis()
        {
            var LoaithietbiList = await _deviceStore.GetAllLoaithietbi(true);
            if (LoaithietbiList == null)
            {
                return null;
            }
            IEnumerable<LoaiThietbiDTO> loaithietbis = LoaithietbiList
                .Select(a => 
                new LoaiThietbiDTO { Maloai = a.Maloai, Tenloai = a.Tenloai, Danhmuc = a.Danhmuc, Ghichu = a.Ghichu})
                .ToList();

            return loaithietbis;
        }

        public async Task DeleteDevice(long id)
        {
          var device = await _deviceStore.FindDeviceById(id);
          if (device == null)
          {
            return;
          }
          else
          {
              await _deviceStore.Remove(device);
          }
        }

        public async Task Add(int thietbiId)
        {
            var thietbi = await _deviceStore.GetDeviceById(thietbiId);
            await _deviceStore.Add(thietbi);
        }
        public async Task Add(Thietbi thietbi)
        {
            await _deviceStore.Add(thietbi);
        }
        public async Task Remove(int thietbiId)
        {
            var thietbi = await _deviceStore.GetDeviceById(thietbiId);
            await _deviceStore.Remove(thietbi);
        }
        public async Task Update(Thietbi thietbi)
        {
            await _deviceStore.Update(thietbi);
        }
    }
}
