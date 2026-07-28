using System;

namespace SimpleSystem.Server;

public class EdgeDto
{
    public int Id {get; set;}
    public string RoomId {get; set;} = string.Empty;

    public string SourceNodeId {get; set;} = string.Empty;

    public string TargetNodeId {get; set;} = string.Empty;
}
