using DemoOnionArchitecture.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DemoOnionArchitecture.DataAccess.Context;

public partial class ApplicationdbContext : DbContext
{
    public ApplicationdbContext()
    {
    }

    public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Villa> Villas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<User>(entity =>
    //    {
    //        entity.HasKey(e => e.UserId).HasName("User_pkey");
    //    });

    //    modelBuilder.Entity<Villa>(entity =>
    //    {
    //        entity.Property(e => e.VillaAddress).HasDefaultValueSql("''::text");
    //        entity.Property(e => e.VillaName).HasDefaultValueSql("''::text");
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
