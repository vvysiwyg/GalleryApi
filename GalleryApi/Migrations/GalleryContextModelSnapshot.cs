﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GalleryApi.Migrations
{
    [DbContext(typeof(GalleryContext))]
    partial class GalleryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Russian_Russia.1251")
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GalleryApi.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("author_name");

                    b.Property<string>("Dob")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("dob");

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("place_of_birth");

                    b.Property<string>("PlaceOfStudy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("place_of_study");

                    b.HasKey("Id");

                    b.ToTable("author", (string)null);
                });

            modelBuilder.Entity("GalleryApi.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Geolocation")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("character varying(55)")
                        .HasColumnName("geolocation");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("character varying(55)")
                        .HasColumnName("location_name");

                    b.HasKey("Id");

                    b.ToTable("location", (string)null);
                });

            modelBuilder.Entity("GalleryApi.Models.Painting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    b.Property<string>("DateOfCreation")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("date_of_creation");

                    b.Property<string>("Genre")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("genre");

                    b.Property<int?>("LocationId")
                        .HasColumnType("integer")
                        .HasColumnName("location_id");

                    b.Property<string>("PaintingName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("painting_name");

                    b.Property<string>("Size")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("size");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("LocationId");

                    b.ToTable("painting", (string)null);
                });

            modelBuilder.Entity("GalleryApi.Models.Painting", b =>
                {
                    b.HasOne("GalleryApi.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK1");

                    b.HasOne("GalleryApi.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK2");

                    b.Navigation("Author");

                    b.Navigation("Location");
                });
#pragma warning restore 612, 618
        }
    }
}
