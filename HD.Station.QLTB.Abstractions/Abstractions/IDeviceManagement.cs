using HD.Station.Qltb.Abstractions.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.Station.Qltb.Abstractions.Abstractions
{
    public interface IDeviceManagement
    {
        public Task<IEnumerable<Thietbi?>?> GetAllDevices();

        public Task<Thietbi?> GetDeviceById(int? id);
        public Task<IEnumerable<Donvi?>?> GetAllDonvi();
        public Task<IEnumerable<Loaithietbi?>?> GetAllLoaithietbi();
        public void Add(int? thietbiId);
        public void Add(Thietbi? thietbi);
        public void Remove(int? thietbiId);
        public void Update(Thietbi? thietbi);
    }
}
