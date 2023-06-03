using HD.Station.Qltb.Abstractions.Abstractions;
using HD.Station.Qltb.Abstractions.Data;
using HD.Station.Qltb.Abstractions.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.Station.Qltb.Abstractions.Services
{
    public class DeviceManagement : IDeviceManagement
    {
        private readonly IDeviceStore _deviceStore;
        public DeviceManagement(IDeviceStore deviceStore)
        {
            _deviceStore = deviceStore;
        }
        public async Task<IEnumerable<Thietbi?>?> GetAllDevices()
        {
            var DevicesList = await _deviceStore.GetAllDevices();
            if (DevicesList == null)
            {
                return null;
            }

            return DevicesList;
        }
        public async Task<Thietbi?> GetDeviceById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var Device = await _deviceStore.GetDeviceById(id);
            if (Device == null)
            {
                return null;
            }
            return Device;
        }
        public async Task<IEnumerable<Donvi?>?> GetAllDonvi()
        {
            var DonviList = await _deviceStore.GetAllDonvi();
            if (DonviList == null)
            {
                return null;
            }

            return DonviList;
        }

        public async Task<IEnumerable<Loaithietbi?>?> GetAllLoaithietbi()
        {
            var LoaithietbiList = await _deviceStore.GetAllLoaithietbi();
            if (LoaithietbiList == null)
            {
                return null;
            }

            return LoaithietbiList;
        }
        public async void Add(int? thietbiId)
        {
            var thietbi = await _deviceStore.GetDeviceById(thietbiId);
            _deviceStore.Add(thietbi);
        }
        public void Add(Thietbi thietbi)
        {
            _deviceStore.Add(thietbi);
        }
        public async void Remove(int? thietbiId)
        {
            var thietbi = await _deviceStore.GetDeviceById(thietbiId);
            _deviceStore.Remove(thietbi);
        }
        public void Update(Thietbi? thietbi)
        {
            _deviceStore.Update(thietbi);
        }
    }
}
