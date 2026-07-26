using System;

namespace SimpleSystem.Server;

public class NodeDto
{

    public int Id {get; set;}
    public string RoomId {get; set;} = string.Empty;
    public int Type {get; set; }
    public int Width { get; set;}
    public int Height {get; set;}
    public double PositionX {get; set;}
    public double PositionY{get; set;}
    public int Color {get; set;}

}
