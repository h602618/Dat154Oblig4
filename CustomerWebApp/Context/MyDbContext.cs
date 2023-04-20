using CustomerWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebApp.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<customer> customer { get; set; }

    public virtual DbSet<requests> requests { get; set; }

    public virtual DbSet<reservations> reservations { get; set; }

    public virtual DbSet<room> room { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Host=ider-database.westeurope.cloudapp.azure.com:5432;Database=h602618;Username=h602618;Password=aGsp2iret4gSuXFoYBXvrjxDmG7VmOS1b6CWrsnS");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<customer>(entity => { entity.HasKey(e => e.id).HasName("customer_pkey"); });

        modelBuilder.Entity<requests>(entity => {
            entity.HasKey(e => e.id).HasName("requests_pkey");

            entity.Property(e => e.status).HasDefaultValueSql("'New'::text");

            entity.HasOne(d => d.roomNrNavigation).WithMany(p => p.requests).OnDelete(DeleteBehavior.Restrict).
                HasConstraintName("requests_roomNr_fkey");
        });

        modelBuilder.Entity<reservations>(entity => {
            entity.HasKey(e => new { e.roomNr, e.start }).HasName("reservations_pkey");

            entity.Property(e => e.status).HasDefaultValueSql("'Booked'::text");

            entity.HasOne(d => d.customer).WithMany(p => p.reservations).OnDelete(DeleteBehavior.Restrict).
                HasConstraintName("reservations_customerId_fkey");

            entity.HasOne(d => d.roomNrNavigation).WithMany(p => p.reservations).OnDelete(DeleteBehavior.Restrict).
                HasConstraintName("reservations_roomNr_fkey");
        });

        modelBuilder.Entity<room>(entity => {
            entity.HasKey(e => e.nr).HasName("room_pkey");

            entity.Property(e => e.nr).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
