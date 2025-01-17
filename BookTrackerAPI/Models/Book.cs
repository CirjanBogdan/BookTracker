﻿namespace BookTrackerAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<Book_Author>? Book_Authors { get; set; }
    }
}
