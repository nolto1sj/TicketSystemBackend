using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TicketSystemBackend.Models;

public partial class TicketDbContext : DbContext
{
    public TicketDbContext()
    {
    }

    public TicketDbContext(DbContextOptions<TicketDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bookmark> Bookmarks { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Bookmark__1788CC4C0F51FB02");

            entity.ToTable("Bookmark");

            entity.Property(e => e.UserId)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(25);

            entity.HasOne(d => d.Ticket).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__Bookmark__Ticket__403A8C7D");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ticket__3214EC07647E1FCB");

            entity.ToTable("Ticket");

            entity.Property(e => e.Category).HasMaxLength(25);
            entity.Property(e => e.CompletedByEmail).HasMaxLength(50);
            entity.Property(e => e.CompletedByName).HasMaxLength(25);
            entity.Property(e => e.Created).HasColumnType("date");
            entity.Property(e => e.Detail).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(25);
            entity.Property(e => e.OpenedByEmail).HasMaxLength(50);
            entity.Property(e => e.OpenedByName).HasMaxLength(25);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
