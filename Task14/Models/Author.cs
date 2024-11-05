namespace Task14.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string NickName { get; set; }

        public ICollection<Article> Articles { get; set; }

        public Author()
        {
            Articles = new List<Article>();
        }
    }
}
