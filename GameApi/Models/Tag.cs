
namespace gameapi.Model
{
    public partial class Tag
    {
        public Tag()
        {
            Games = new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public int GamesCount { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
