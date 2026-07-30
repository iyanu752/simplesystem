using System;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;

namespace SimpleSystem.Server;

public class DiagramHub : Hub
{

    private readonly IDiagramService _diagramService;
    private readonly IRoomService _roomService;

    public DiagramHub (IDiagramService diagramService, IRoomService roomService)
    {
        _diagramService = diagramService;
        _roomService = roomService;
    }
    
    public async Task JoinRoom(JoinRoomDto joinRoomDto)
    {
        var joinRoom = await _roomService.JoinRoomAsync(joinRoomDto);
        if (joinRoom == null)
        {
            await Clients.Caller.SendAsync("JoinRoomFailed", joinRoomDto.Code);
            return;
        }

        await Groups.AddToGroupAsync(Context.ConnectionId, joinRoomDto.Code);
        await Clients.Group(joinRoomDto.Code).SendAsync("UserJoined", joinRoom);
    }

    public async Task LeaveRoom(LeaveRoomDto leaveRoomDto)
    {
        var leaveRoom = await _roomService.LeaveRoomAsync(leaveRoomDto);
        if (leaveRoom == null)
        {
            await Clients.Caller.SendAsync("LeaveRoomFailed", leaveRoomDto.Code);
            return;
        }

        await Groups.RemoveFromGroupAsync(
            Context.ConnectionId,
            leaveRoomDto.Code);

        await Clients.Group(leaveRoomDto.Code)
            .SendAsync("UserLeft", leaveRoom);
    }

    public async Task CreateNode(CreateNodeDto createNodeDto)
    {
        var createNode = await _diagramService.CreateNodeAsync(createNodeDto);
        await Clients.Group(createNodeDto.RoomId).SendAsync("NodeCreated", createNode);
    }

    public async Task MoveNode(MoveNodeDto moveNodeDto)
    {
        var updateNode = await _diagramService.MoveNodeAsync(moveNodeDto);
        if (updateNode != null)
        {
            await Clients.Group(moveNodeDto.RoomId).SendAsync("NodeMoved", updateNode);
        }
    }

    public async Task DeleteNode(string nodeId, string roomId)
    {
        var deleteNode = await _diagramService.DeleteNodeAsync(nodeId);
        await Clients.Group(roomId).SendAsync("NodeDeleted", new { NodeId = nodeId, Deleted = deleteNode });
    }
    public async Task CreateEdge(CreateEdgeDto createEdgeDto)
    {
        var createEdge = await _diagramService.CreateEdgeAsync(createEdgeDto);
        await Clients.Group(createEdgeDto.RoomId).SendAsync("EdgeCreated", createEdge);
    }
    public async Task DeleteEdge(int id, string roomId)
    {
        var deleteEdge = await _diagramService.DeleteEdgeAsync(id);
        await Clients.Group(roomId).SendAsync("EdgeDeleted", new { Id = id, Deleted = deleteEdge });
    }

    public async Task CursorMoved(string roomId, CursorDto cursorDto)
    {
        await Clients.OthersInGroup(roomId).SendAsync("CursorPositionUpdated", Context.ConnectionId, cursorDto);
    }


}
