using HD.Station.Qltb.Abstractions.Data;

public interface ICurrentUser
{
    UserAccount? User { get; }

    Task SetIdentifier(long identifier);
}
