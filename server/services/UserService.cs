using System;
using Microsoft.EntityFrameworkCore;

namespace SimpleSystem.Server;

public class UserService : IUserService
{
    public readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserDto?> CreateUserAsync(CreateUserDto createUserDto)
    {
        var userNameExists = await _context.Users.AnyAsync(user => user.UserName == createUserDto.UserName);

        if (userNameExists) {
            return null;
        }

        var user = new User
        {
            UserName = createUserDto.UserName
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserDto
        {
            Id = user.Id,
            UserName = user.UserName
            
        };
        
    }

}
