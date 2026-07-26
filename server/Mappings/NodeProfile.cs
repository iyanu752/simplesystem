using System;
using AutoMapper;

namespace SimpleSystem.Server;

public class NodeProfile : Profile
{
    public NodeProfile()
    {
        CreateMap<Node, NodeDto>(); 
        CreateMap<MoveNodeDto, Node>(); 
    }



}
