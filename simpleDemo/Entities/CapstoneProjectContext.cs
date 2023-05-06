using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace simpleDemo.Entities;

public partial class CapstoneProjectContext : DbContext
{
    public CapstoneProjectContext()
    {
    }

    public CapstoneProjectContext(DbContextOptions<CapstoneProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Demo> Demos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=tcp:poseidonserver.database.windows.net,1433;initial catalog=capstone-project;persist security info=false;user id=poseidon;password=Program@123;multipleactiveresultsets=false;encrypt=true;trustservercertificate=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Demo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__demo__3213E83F714E9C50");

            entity.ToTable("demo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(23)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
