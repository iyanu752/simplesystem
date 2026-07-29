using System;

namespace SimpleSystem.Server;

public interface IRoomService
{
    Task <RoomDto> CreateRoomAsync (CreateRoomDto createRoomDto);
    Task<RoomDto?> JoinRoomAsync (JoinRoomDto joinRoomDto);
    Task<RoomDto?> LeaveRoomAsync (LeaveRoomDto leaveRoomDto);
    Task <bool> DestroyRoomAsync (int id);

}
