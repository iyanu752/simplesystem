using System;

namespace SimpleSystem.Server;

public class Room
{
    public int RoomId {get; set;}
    public required List<User> Users {get; set;}
    public int Code {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

}
