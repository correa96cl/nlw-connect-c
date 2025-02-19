using System;
using Connect.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Connect.Api.Infrastructure;

public class TechLibraryDbContext : DbContext
{
public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlite("Data Source=techlibrary.db");
    }
}
