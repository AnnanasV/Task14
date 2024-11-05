namespace Task14.Models
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Rating>? Ratings { get; set; }

        public Article()
        {
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
        }

        public double GetAverageRating()
        {
            return Ratings != null && Ratings.Count > 0
                ? Ratings.Average(r => r.Value) // average raring
                : 0; // without rating
        }
    }
}
