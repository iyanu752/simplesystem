using System;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;

namespace SimpleSystem.Server;

public class DiagramHub : Hub
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public DiagramHub (AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task JoinRoom(string userName, string roomCode)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomCode);
        await Clients.Group(roomCode).SendAsync("User joined", userName);
    }

    public async Task CreateNode(NodeDto nodeDto)
    {
        var node = _mapper.Map<Node>(nodeDto);
        _context.Nodes.Add(node);
        await _context.SaveChangesAsync();
        await Clients.Group(node.RoomId).SendAsync("Node Created", node);
    }

    //Todo: Migrate database before pushing to github

    public async Task MoveNode(MoveNodeDto moveNodeDto)
    {
        var node = _mapper.Map<Node>(moveNodeDto);
        _context.Nodes.Add(node);
        await _context.SaveChangesAsync();
        await Clients.Group(node.RoomId).SendAsync("Node Moved", moveNodeDto);
    }

    public async Task UpdateCursor(CursorDto cursorDto)
    {
        await Clients.Others.SendAsync("CursorPositionUpdated", Context.ConnectionId, cursorDto);
    }


}
