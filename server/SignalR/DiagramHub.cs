using System;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;

namespace SimpleSystem.Server;

public class DiagramHub : Hub
{

    private readonly IDiagramService _diagramService;

    public DiagramHub (IDiagramService diagramService)
    {
        _diagramService = diagramService;
    }
    
    public async Task JoinRoom(string userName, string roomCode)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomCode);
        await Clients.Group(roomCode).SendAsync("User joined", userName);
    }

    public async Task LeaveRoom(string roomCode)
    {
        await Groups.RemoveFromGroupAsync(
            Context.ConnectionId,
            roomCode);

        await Clients.Group(roomCode)
            .SendAsync("UserLeft", Context.ConnectionId);
    }

    public async Task CreateNode(CreateNodeDto createNodeDto)
    {
        var createNode = await _diagramService.CreateNodeAsync(createNodeDto);
        await Clients.Group(createNodeDto.RoomId).SendAsync("Node Created", createNode);
    }

    public async Task MoveNode(MoveNodeDto moveNodeDto, int id)
    {
        var updateNode = await _diagramService.MoveNodeAsync(moveNodeDto, id);
        await Clients.Group(moveNodeDto.RoomId).SendAsync("Node Moved", updateNode);
    }

    public async Task DeleteNode(int id, int roomId)
    {
        var deleteNode = await _diagramService.DeleteNodeAsync(id);
        await Clients.Group(roomId.ToString()).SendAsync("Node Deleted", deleteNode);
    }
    public async Task CreateEdge(CreateEdgeDto createEdgeDto)
    {
        var createEdge = _diagramService.CreateEdgeAsync(createEdgeDto);
        await Clients.Group(createEdgeDto.RoomId).SendAsync("Edge Created", createEdge);
    }
    public async Task DeleteEdge(int id, int roomId)
    {
        var deleteEdge = await _diagramService.DeleteEdgeAsync(id);
        await Clients.Group(roomId.ToString()).SendAsync("Edge Deleted", deleteEdge);
    }

    public async Task CursorMoved(CursorDto cursorDto)
    {
        await Clients.Others.SendAsync("CursorPositionUpdated", Context.ConnectionId, cursorDto);
    }


}
