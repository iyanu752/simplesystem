using System;
using AutoMapper;

namespace SimpleSystem.Server;

public class NodeProfile : Profile
{
    public NodeProfile()
    {
        CreateMap<CreateNodeDto, Node>();
        CreateMap<Node, NodeDto>(); 
        CreateMap<MoveNodeDto, Node>();
        CreateMap<CreateEdgeDto, Edge>();
        CreateMap<Edge, EdgeDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<User, UserDto>();
        CreateMap<CreateRoomDto, Room>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => new List<User>
            {
                new User { UserName = src.UserName }
            }));
        CreateMap<Room, RoomDto>();
    }

}
