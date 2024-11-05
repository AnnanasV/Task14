namespace Task14.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int Value { get; set; }

        public int ArticleID { get; set; }
        public Article Article { get; set; }
    }
}
