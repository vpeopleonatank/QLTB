using HD.Station.Qltb.Abstractions.Data;

namespace HD.Station.Qltb.Abstractions.Abstractions
{
    public interface IDeviceManagement
    {
        public Task<IEnumerable<Thietbi?>?> GetAllDevices();

        public Task<Thietbi?> GetDeviceById(int? id);
        public Task<IEnumerable<Donvi?>?> GetAllDonvi();
        public Task<IEnumerable<Loaithietbi?>?> GetAllLoaithietbi();
        public Task Add(int? thietbiId);
        public Task Add(Thietbi? thietbi);
        public Task Remove(int? thietbiId);
        public Task Update(Thietbi? thietbi);
    }
}
