namespace BookTrackerAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;

        public List<Book_Author>? Book_Authors { get; set; }
    }
}
