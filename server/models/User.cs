using System;

namespace SimpleSystem.Server;

public class User
{
    public int Id {get; set;}
    public string UserName {get; set;} = string.Empty;
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

};
