using System;

namespace SimpleSystem.Server;

public class JoinRoomDto
{
    public int RoomId {get; set;}
    public string UserName {get; set;} = string.Empty;
    public int Code {get; set;}


}
