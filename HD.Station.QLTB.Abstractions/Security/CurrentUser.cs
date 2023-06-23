using HD.Station.Qltb.Abstractions.Data;
using HD.Station.Qltb.Abstractions.Stores;

namespace HD.Station.Qltb.Abstractions.Security;

public class CurrentUser : ICurrentUser
{
    // private readonly IUserManagement _userManagement;

    private readonly IDeviceStore _deviceStore;

    public UserAccount? User { get; private set; }

    public CurrentUser(IDeviceStore deviceStore)
    {
      _deviceStore = deviceStore;
    }

    public async Task SetIdentifier(long identifier)
    {
        User = await _deviceStore.FindUserById(identifier);
    }
}
