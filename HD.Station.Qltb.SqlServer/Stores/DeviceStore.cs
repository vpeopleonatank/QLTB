using HD.Station.Qltb.Abstractions.Data;
using HD.Station.Qltb.Abstractions.DTO;
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

        public async Task<IEnumerable<Thietbi>> GetAllDevices()
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

        public async Task<IEnumerable<Thietbi>> GetAllDevices(PagingParameters pagingParameters)
        {
            var query = _qltbContext.Thietbi.Select(x => x)
                .Include(x => x.Donvi)
                .Include(x => x.Loaithietbi);
            var pageQuery = query
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .AsNoTracking();

            var page = await pageQuery.ToListAsync();
            return page;
        }
        
        public async Task<int> GetDevicesTotal()
        {
          return await _qltbContext.Thietbi.CountAsync();
        }

        public async Task<Thietbi> GetDeviceById(long id)
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
            return await _qltbContext.Thietbi.Where(x => x.Matb == id)
              .Include(x => x.Donvi)
              .Include(x => x.Loaithietbi)
              .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Donvi>> GetAllDonvi(bool exclude_relation = false)
        {
            List<Donvi> donvis;
            if (exclude_relation)
            {
                donvis = await _qltbContext.Donvi.Select(x => new Donvi() { Madv = x.Madv, Tendv = x.Tendv }).ToListAsync();
            }
            else
            {
                donvis = await _qltbContext.Donvi.ToListAsync();
            }
            return donvis;
        }

        public async Task<IEnumerable<Loaithietbi>> GetAllLoaithietbi(bool exclude_relation = false)
        {
            List<Loaithietbi> loaithietbis;
            if (exclude_relation)
            {
                loaithietbis = await _qltbContext.Loaithietbi.Select(x =>
                    new Loaithietbi() { Maloai = x.Maloai, Tenloai = x.Tenloai }).ToListAsync();
            }
            else
            {
                loaithietbis = await _qltbContext.Loaithietbi.ToListAsync();
            }
            return loaithietbis;
        }
        public async Task Add(Thietbi thietbi)
        {
            _qltbContext.Thietbi.Add(thietbi);
            await _qltbContext.SaveChangesAsync();
        }
        public async Task Remove(Thietbi thietbi)
        {
            if (thietbi != null)
            {
                _qltbContext.Thietbi.Remove(thietbi);
                await _qltbContext.SaveChangesAsync();
            }
        }
        public async Task Update(Thietbi thietbi)
        {
            if (thietbi != null)
            {
                _qltbContext.Thietbi.Update(thietbi);
                await _qltbContext.SaveChangesAsync();
            }
        }
        public async Task SaveChangesAsync()
        {
          await _qltbContext.SaveChangesAsync();
        }
        public async Task<UserAccount> GetUser(string email, string password)
        {
            return await _qltbContext.UserAccount.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<bool> CheckUserExist(string email)
        {
            return await _qltbContext.UserAccount.AnyAsync(x => x.Email == email);
        }
        public async Task<UserAccount> CreateUser(string username, string email, string password)
        {
            var user = new UserAccount
            {
                Name = username,
                Email = email,
                Password = password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _qltbContext.AddAsync(user);
            await _qltbContext.SaveChangesAsync();

            return user;
        }


        public async Task<Thietbi> FindDeviceById(long id)
        {
            var thietbi = await _qltbContext.Thietbi.Where(x => x.Matb == id)
              .Include(x => x.Donvi)
              .Include(x => x.Loaithietbi)
              .SingleOrDefaultAsync();

            return thietbi;
        }

        public async Task<UserAccount> FindUser(string email, string password)
        {
            var user = await _qltbContext.UserAccount.Where(x => x.Email == email)
              .SingleOrDefaultAsync();
            return user;
        }

        public async Task<UserAccount> FindUserById(long id)
        {
            return await _qltbContext.UserAccount
              .Where(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}
