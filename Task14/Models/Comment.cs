namespace Task14.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Text { get; set; }

        public int ArticleID { get; set; }
        public Article Article { get; set; }
    }
}
