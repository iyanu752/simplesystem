using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleSystem.Server;

public class User
{
    public int Id {get; set;}
    public string UserName {get; set;} = string.Empty;
    public int? RoomId {get; set;}
    public Room? Room {get; set;} = null;
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

};
