namespace gameapi.Model
{
    public partial class Game
    {
        public Game()
        {
            Genres = new HashSet<Genre>();
            Platforms = new HashSet<Platform>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Released { get; set; } = null!;
        public string BackgroundImage { get; set; } = null!;
        public double Rating { get; set; }
        public int RatingsCount { get; set; }
        public int Added { get; set; }
        public int? Metacritic { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Platform> Platforms { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
