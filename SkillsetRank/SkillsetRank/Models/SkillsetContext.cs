using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SkillsetRank.Models;

public partial class SkillsetContext : DbContext
{
    public SkillsetContext()
    {
    }

    public SkillsetContext(DbContextOptions<SkillsetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=B619LCOK;Initial Catalog=Skillset;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83F6838B244");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.Uid, "UQ__Employee__DD70126531CE14B9").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Account)
                .HasMaxLength(20)
                .HasColumnName("account");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ReportingManager)
                .HasMaxLength(50)
                .HasColumnName("reporting_manager");
            entity.Property(e => e.Skillsets)
                .HasMaxLength(200)
                .HasColumnName("skillsets");
            entity.Property(e => e.Uid)
                .HasMaxLength(10)
                .HasColumnName("uid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
