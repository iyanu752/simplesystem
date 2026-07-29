using System;
using AutoMapper;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
namespace SimpleSystem.Server;

public class RoomService : IRoomService
{
    public readonly AppDbContext _context;
    public readonly IMapper _mapper;

    public RoomService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RoomDto> CreateRoomAsync (CreateRoomDto createRoomDto)
    {
        var room = _mapper.Map<Room>(createRoomDto);
        room.Code = RandomNumberGenerator.GetInt32(1000, 10000).ToString();
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return _mapper.Map<RoomDto>(room);
    }

    public async Task<RoomDto?> JoinRoomAsync (JoinRoomDto joinRoomDto)
    {
        var room = await _context.Rooms
        .Include(r => r.Users)
        .FirstOrDefaultAsync(r => r.Code == joinRoomDto.Code);

        if(room == null)
        {
            return null;
        }
        room.Users.Add(new User
        {
           UserName = joinRoomDto.UserName 
        });
    

        await _context.SaveChangesAsync();
        return _mapper.Map<RoomDto>(room);

    }

    
    public async Task<RoomDto?> LeaveRoomAsync (LeaveRoomDto leaveRoomDto)
    {
        var room = await _context.Rooms
        .Include(r => r.Users)
        .FirstOrDefaultAsync(r => r.Code == leaveRoomDto.Code);

        if (room == null)
        {
            return null;
        }

            var user = room.Users
        .FirstOrDefault(u => u.UserName == leaveRoomDto.UserName);

        if (user == null)
        {
            return null;
        }

        room.Users.Remove(user);

        await _context.SaveChangesAsync();

        return _mapper.Map<RoomDto>(room);

        
    }

    public async Task<bool> DestroyRoomAsync(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
        {
            return false;
        }
        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
        return true;
    }

}
