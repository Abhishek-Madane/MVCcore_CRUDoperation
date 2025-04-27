using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCcoreCURD.Models;

public partial class MvccoreContext : DbContext
{
    public MvccoreContext()
    {
    }

    public MvccoreContext(DbContextOptions<MvccoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__student__DDDFDD367279C187");

            entity.ToTable("student");

            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.Sage).HasColumnName("sage");
            entity.Property(e => e.Sname)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("sname");
            entity.Property(e => e.Sstd).HasColumnName("sstd");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
