using Microsoft.EntityFrameworkCore;
using gameapi.Model;

namespace gameapi.GameContext
{
    public partial class gamecontext : DbContext
    {
        public gamecontext()
        {
        }

        public gamecontext(DbContextOptions<gamecontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Platform> Platforms { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<UserGameRate> UserRate{ get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGameRate>();
            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("games");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Added).HasColumnName("added");

                entity.Property(e => e.BackgroundImage).HasColumnName("background_image");

                entity.Property(e => e.Metacritic).HasColumnName("metacritic");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RatingsCount).HasColumnName("ratings_count");

                entity.Property(e => e.Released).HasColumnName("released");

                entity.HasMany(d => d.Genres)
                    .WithMany(p => p.Games)
                    .UsingEntity<Dictionary<string, object>>(
                        "Genresgame",
                        l => l.HasOne<Genre>().WithMany().HasForeignKey("Genresid"),
                        r => r.HasOne<Game>().WithMany().HasForeignKey("Gamesid"),
                        j =>
                        {
                            j.HasKey("Gamesid", "Genresid");

                            j.ToTable("Genresgames");

                            j.HasIndex(new[] { "Genresid" }, "IX_Genresgames_genresid");

                            j.IndexerProperty<int>("Gamesid").HasColumnName("gamesid");

                            j.IndexerProperty<int>("Genresid").HasColumnName("genresid");
                        });

                entity.HasMany(d => d.Platforms)
                    .WithMany(p => p.Gamesplatforms)
                    .UsingEntity<Dictionary<string, object>>(
                        "Platformsgame",
                        l => l.HasOne<Platform>().WithMany().HasForeignKey("Platformsid"),
                        r => r.HasOne<Game>().WithMany().HasForeignKey("Gamesplatformsid"),
                        j =>
                        {
                            j.HasKey("Gamesplatformsid", "Platformsid");

                            j.ToTable("Platformsgames");

                            j.HasIndex(new[] { "Platformsid" }, "IX_Platformsgames_platformsid");

                            j.IndexerProperty<int>("Gamesplatformsid").HasColumnName("gamesplatformsid");

                            j.IndexerProperty<int>("Platformsid").HasColumnName("platformsid");
                        });

                entity.HasMany(d => d.Tags)
                    .WithMany(p => p.Games)
                    .UsingEntity<Dictionary<string, object>>(
                        "Tagsgame",
                        l => l.HasOne<Tag>().WithMany().HasForeignKey("Tagsid"),
                        r => r.HasOne<Game>().WithMany().HasForeignKey("Gamesid"),
                        j =>
                        {
                            j.HasKey("Gamesid", "Tagsid");

                            j.ToTable("Tagsgames");

                            j.HasIndex(new[] { "Tagsid" }, "IX_Tagsgames_tagsid");

                            j.IndexerProperty<int>("Gamesid").HasColumnName("gamesid");

                            j.IndexerProperty<int>("Tagsid").HasColumnName("tagsid");
                        });
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genres");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.GamesCount).HasColumnName("games_count");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Slug).HasColumnName("slug");
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.ToTable("platforms");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Slug).HasColumnName("slug");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tags");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.GamesCount).HasColumnName("games_count");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Slug).HasColumnName("slug");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
