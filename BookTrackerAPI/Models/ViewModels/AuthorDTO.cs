namespace BookTrackerAPI.Models.ViewModels
{
    public class AuthorDTO
    {
        public string FullName { get; set; } = string.Empty;
    }

    public class AuthorWithBooksDTO
    {
        public string FullName { get; set; } = string.Empty;
        public List<string> BookTitles { get; set; } 
    }
}
