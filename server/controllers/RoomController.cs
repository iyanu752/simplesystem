using Microsoft.AspNetCore.Mvc;

namespace SimpleSystem.Server;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpPost("create")]
    public async Task<ActionResult<RoomDto>> Create(CreateRoomDto createRoomDto)
    {
        var room = await _roomService.CreateRoomAsync(createRoomDto);
        return Ok(room);
    }

    [HttpPost("join")]
    public async Task<ActionResult<RoomDto>> Join(JoinRoomDto joinRoomDto)
    {
        var room = await _roomService.JoinRoomAsync(joinRoomDto);
        if (room == null)
        {
            return NotFound("Room not found.");
        }

        return Ok(room);
    }

    [HttpPost("leave")]
    public async Task<ActionResult<RoomDto>> Leave(LeaveRoomDto leaveRoomDto)
    {
        var room = await _roomService.LeaveRoomAsync(leaveRoomDto);
        if (room == null)
        {
            return NotFound("Room or user not found.");
        }

        return Ok(room);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Destroy(int id)
    {
        var destroyed = await _roomService.DestroyRoomAsync(id);
        if (!destroyed)
        {
            return NotFound("Room not found.");
        }

        return NoContent();
    }
}
