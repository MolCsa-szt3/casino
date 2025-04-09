using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SzenerceVallalat.Console.Models;

namespace SzenerceVallalat.Console.DbModels;

public partial class PlayersContext : DbContext
{
    public PlayersContext()
    {
    }

    public PlayersContext(DbContextOptions<PlayersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Database\\players.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity
                //.HasNoKey()
                .ToTable("players");

            entity.Property(e => e.Money).HasColumnName("amount");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.HasKey(e => e.Id);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
