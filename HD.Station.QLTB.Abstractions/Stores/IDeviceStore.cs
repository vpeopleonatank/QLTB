using HD.Station.Qltb.Abstractions.Data;

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
        public Task<UserAccount?> GetUser(string email, string password);
        public Task<Boolean> CheckUserExist(string email);
        public Task<UserAccount> CreateUser(string? username, string? email, string? password);
        public Task<UserAccount?> FindUser(string? email, string? password);
    }
}
