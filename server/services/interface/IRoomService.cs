using System;

namespace SimpleSystem.Server;

public interface IRoomService
{
    Task<CreateRoomDto> CreateRoomAsync();
    Task<JoinRoomDto> JoinRoomAsync(int roomId, int code);

}
