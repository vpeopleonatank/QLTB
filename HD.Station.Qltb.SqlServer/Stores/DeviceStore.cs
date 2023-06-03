using HD.Station.Qltb.Abstractions.Data;
using HD.Station.Qltb.Abstractions.Stores;
using Microsoft.EntityFrameworkCore;

namespace HD.Station.Qltb.SqlServer
{
    public class DeviceStore : IDeviceStore
    {
        private readonly QltbContext _qltbContext;
        public DeviceStore(QltbContext qltbContext)
        {
            _qltbContext = qltbContext;
        }

        public async Task<IEnumerable<Thietbi?>?> GetAllDevices()
        {
            //var Devices = from d in _qltbContext.Thietbi.Include(s => s.Loaithietbi)
            //              .Include(s => s.Donvi)
            //              select d;
            //var DevicesList = await Devices.ToListAsync();
            //if (DevicesList == null)
            //{
            //    return null;
            //}

            //return DevicesList;
            return await _qltbContext.Thietbi.Include(s => s.Donvi).ToListAsync();
        }
        public async Task<Thietbi?> GetDeviceById(int? id)
        {
            //if (id == null)
            //{
            //    return null;
            //}
            //var Device = await _qltbContext.Thietbi.FirstOrDefaultAsync(m => m.Matb == id);
            //if (Device == null)
            //{
            //    return null;
            //}
            //return Device;
            return await _qltbContext.Thietbi.FindAsync(id);
        }

        public async Task<IEnumerable<Donvi?>?> GetAllDonvi()
        {
            return await _qltbContext.Donvi.ToListAsync();
        }

        public async Task<IEnumerable<Loaithietbi?>?> GetAllLoaithietbi()
        {
            return await _qltbContext.Loaithietbi.ToListAsync();
        }
        public async void Add(Thietbi? thietbi)
        {
            if (thietbi != null)
            {
                _qltbContext.Thietbi.Add(thietbi);
                await _qltbContext.SaveChangesAsync();
            }
        }
        public async void Remove(Thietbi? thietbi)
        {
            if (thietbi != null)
            {
                _qltbContext.Thietbi.Remove(thietbi);
                await _qltbContext.SaveChangesAsync();
            }
        }
        public async void Update(Thietbi? thietbi)
        {
            if (thietbi != null)
            {
                _qltbContext.Thietbi.Update(thietbi);
                await _qltbContext.SaveChangesAsync();
            }
        }
    }
}
