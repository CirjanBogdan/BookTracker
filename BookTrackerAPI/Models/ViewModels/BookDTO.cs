namespace BookTrackerAPI.Models.ViewModels
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<int> AuthorIds { get; set; }
    }

    public class BookWithAuthorsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> AuthorNames { get; set; }
    }
}
