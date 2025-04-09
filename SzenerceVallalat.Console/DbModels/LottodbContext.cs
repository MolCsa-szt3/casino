using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using SzenerceVallalat.Console.Models;

namespace SzenerceVallalat.Console.DbModels;

public partial class LottodbContext : DbContext
{
    public LottodbContext()
    {
    }

    public LottodbContext(DbContextOptions<LottodbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=lottodb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<User>(entity =>
        {
            entity
                //.HasNoKey()
                .ToTable("players")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Money)
                .HasColumnType("int(5)")
                .HasColumnName("amount");
            entity.Property(e => e.Email)
                .HasMaxLength(26)
                .HasColumnName("email");
            entity.Property(e => e.Id)
                .HasColumnType("int(2)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(35)
                .HasColumnName("name");
            entity.HasKey(e => e.Id);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
