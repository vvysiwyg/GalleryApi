using Microsoft.EntityFrameworkCore;
using GalleryApi.Models;

public partial class GalleryContext : DbContext
{
    public GalleryContext()
    {
    }

    public GalleryContext(DbContextOptions<GalleryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Painting> Paintings { get; set; }

    public override void Dispose()
    {
        base.Dispose();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("author");

            entity.Property(e => e.AuthorName)
                .HasMaxLength(150)
                .HasColumnName("author_name");

            entity.Property(e => e.PlaceOfBirth)
                .HasMaxLength(100)
                .HasColumnName("place_of_birth");

            entity.Property(e => e.PlaceOfStudy)
                .HasMaxLength(100)
                .HasColumnName("place_of_study");

            entity.Property(e => e.Dob)
                .HasMaxLength(30)
                .HasColumnName("dob");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("location");

            entity.Property(e => e.LocationName)
                .HasMaxLength(55)
                .HasColumnName("location_name");

            entity.Property(e => e.Geolocation)
                .HasMaxLength(55)
                .HasColumnName("geolocation");
        });

        modelBuilder.Entity<Painting>(entity =>
        {
            entity.ToTable("painting");

            entity.Property(e => e.PaintingName)
                .HasMaxLength(100)
                .HasColumnName("painting_name");

            entity.Property(e => e.Genre)
                .HasMaxLength(40)
                .HasColumnName("genre");

            entity.Property(e => e.Size)
                .HasMaxLength(15)
                .HasColumnName("size");

            entity.Property(e => e.DateOfCreation)
                .HasMaxLength(30)
                .HasColumnName("date_of_creation");

            entity.Property(e => e.AuthorId)
                .HasColumnName("author_id");

            entity.Property(e => e.LocationId)
                .HasColumnName("location_id");

            entity.HasOne(e => e.Author)
                .WithMany()
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK1");
            
            entity.HasOne(e => e.Location)
                .WithMany()
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK2");
        });
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
