using System;

namespace SimpleSystem.Server;

public class Room
{
   public string RoomId {get; set;} = string.Empty;
    public required List<User> Users {get; set;}
    public string Code {get; set;} = string.Empty;
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

}
