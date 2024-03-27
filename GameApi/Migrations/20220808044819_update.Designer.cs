﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gameapi.GameContext;

#nullable disable

namespace gameapi.Migrations
{
    [DbContext(typeof(gamecontext))]
    [Migration("20220808044819_update")]
    partial class update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("gameapi.Model.Game", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("Added")
                        .HasColumnType("int")
                        .HasColumnName("added");

                    b.Property<string>("BackgroundImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("background_image");

                    b.Property<int?>("Metacritic")
                        .HasColumnType("int")
                        .HasColumnName("metacritic");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<double>("Rating")
                        .HasColumnType("float")
                        .HasColumnName("rating");

                    b.Property<int>("RatingsCount")
                        .HasColumnType("int")
                        .HasColumnName("ratings_count");

                    b.Property<string>("Released")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("released");

                    b.HasKey("Id");

                    b.ToTable("games", (string)null);
                });

            modelBuilder.Entity("gameapi.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("GamesCount")
                        .HasColumnType("int")
                        .HasColumnName("games_count");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("slug");

                    b.HasKey("Id");

                    b.ToTable("genres", (string)null);
                });

            modelBuilder.Entity("gameapi.Model.Platform", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("slug");

                    b.HasKey("Id");

                    b.ToTable("platforms", (string)null);
                });

            modelBuilder.Entity("gameapi.Model.Tag", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("GamesCount")
                        .HasColumnType("int")
                        .HasColumnName("games_count");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("slug");

                    b.HasKey("Id");

                    b.ToTable("tags", (string)null);
                });

            modelBuilder.Entity("gameapi.Model.UserGameRate", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("UserRate");
                });

            modelBuilder.Entity("Genresgame", b =>
                {
                    b.Property<int>("Gamesid")
                        .HasColumnType("int")
                        .HasColumnName("gamesid");

                    b.Property<int>("Genresid")
                        .HasColumnType("int")
                        .HasColumnName("genresid");

                    b.HasKey("Gamesid", "Genresid");

                    b.HasIndex(new[] { "Genresid" }, "IX_Genresgames_genresid");

                    b.ToTable("Genresgames", (string)null);
                });

            modelBuilder.Entity("Platformsgame", b =>
                {
                    b.Property<int>("Gamesplatformsid")
                        .HasColumnType("int")
                        .HasColumnName("gamesplatformsid");

                    b.Property<int>("Platformsid")
                        .HasColumnType("int")
                        .HasColumnName("platformsid");

                    b.HasKey("Gamesplatformsid", "Platformsid");

                    b.HasIndex(new[] { "Platformsid" }, "IX_Platformsgames_platformsid");

                    b.ToTable("Platformsgames", (string)null);
                });

            modelBuilder.Entity("Tagsgame", b =>
                {
                    b.Property<int>("Gamesid")
                        .HasColumnType("int")
                        .HasColumnName("gamesid");

                    b.Property<int>("Tagsid")
                        .HasColumnType("int")
                        .HasColumnName("tagsid");

                    b.HasKey("Gamesid", "Tagsid");

                    b.HasIndex(new[] { "Tagsid" }, "IX_Tagsgames_tagsid");

                    b.ToTable("Tagsgames", (string)null);
                });

            modelBuilder.Entity("Genresgame", b =>
                {
                    b.HasOne("gameapi.Model.Game", null)
                        .WithMany()
                        .HasForeignKey("Gamesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gameapi.Model.Genre", null)
                        .WithMany()
                        .HasForeignKey("Genresid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Platformsgame", b =>
                {
                    b.HasOne("gameapi.Model.Game", null)
                        .WithMany()
                        .HasForeignKey("Gamesplatformsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gameapi.Model.Platform", null)
                        .WithMany()
                        .HasForeignKey("Platformsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tagsgame", b =>
                {
                    b.HasOne("gameapi.Model.Game", null)
                        .WithMany()
                        .HasForeignKey("Gamesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gameapi.Model.Tag", null)
                        .WithMany()
                        .HasForeignKey("Tagsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
