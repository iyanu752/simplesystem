using System;
using Microsoft.EntityFrameworkCore;

namespace SimpleSystem.Server;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users {get; set;}
    public DbSet<Node> Nodes {get; set;}

}
