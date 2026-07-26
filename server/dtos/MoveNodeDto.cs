using System;

namespace SimpleSystem.Server;

public class MoveNodeDto
{
    string NodeId {get; set;} = string.Empty;
    double PositionX {get; set;}
    double PositionY {get; set;}

}
