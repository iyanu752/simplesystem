using System;

namespace SimpleSystem.Server;

public class MoveNodeDto
{   
    public string NodeId {get; set;} = string.Empty;
    public string RoomId {get; set;} = string.Empty;
    public double PositionX {get; set;}
    public double PositionY {get; set;}

}
