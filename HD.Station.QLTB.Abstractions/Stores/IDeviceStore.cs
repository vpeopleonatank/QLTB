﻿using HD.Station.Qltb.Abstractions.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.Station.Qltb.Abstractions.Stores
{
    public interface IDeviceStore
    {
        public Task<IEnumerable<Thietbi?>?> GetAllDevices();
        public Task<Thietbi?> GetDeviceById(int? id);
        public Task<IEnumerable<Donvi?>?> GetAllDonvi();
        public Task<IEnumerable<Loaithietbi?>?> GetAllLoaithietbi();
        public Task Add(Thietbi? thietbi);
        public Task Remove(Thietbi? thietbi);
        public Task Update(Thietbi? thietbi);
    }
}
