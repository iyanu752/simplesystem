using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleSystem.Server;

public class User
{
    public int Id {get; set;}

    [Required]
    
    public string UserName {get; set;} = string.Empty;
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

};
