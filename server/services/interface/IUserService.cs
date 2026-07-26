using System;

namespace SimpleSystem.Server;

public interface IUserService
{
  Task<UserDto>CreateUserAsync(CreateUserDto createUserDto);
}
