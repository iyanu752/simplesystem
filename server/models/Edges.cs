using System;

namespace SimpleSystem.Server;

public class Edges
{
    public int Id {get; set;}
   public string RoomId {get; set;} = string.Empty;
    public int SourceNodeId {get; set;}
    public int TargetNodeId {get; set;}
    
}

