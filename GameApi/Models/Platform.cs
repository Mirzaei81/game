namespace gameapi.Model
{
    public partial class Platform
    {
        public Platform()
        {
            Gamesplatforms = new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;

        public virtual ICollection<Game> Gamesplatforms { get; set; }
    }
}
