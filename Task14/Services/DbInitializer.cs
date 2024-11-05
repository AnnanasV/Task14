using Task14.Models;

namespace Task14.Services
{
    public class DbInitializer
    {
        public static void Seed(DbContext context)
        {
            // check for records
            if (!context.Authors.Any())
            {
                // add authors
                var authors = new List<Author>
                {
                    new Author { NickName = "Writer1" },
                    new Author { NickName = "BloggerPro" },
                    new Author { NickName = "LiteraryGenius" }
                };

                context.Authors.AddRange(authors);
                context.SaveChanges();

                // add articles
                var articles = new List<Article>
                {
                    new Article { 
                        Title = "The Art of Coding", 
                        Text = "Coding is both art and science...", 
                        AuthorID = authors[0].AuthorID },
                    new Article { 
                        Title = "The Future of AI", 
                        Text = "Artificial Intelligence is changing the world...", 
                        AuthorID = authors[1].AuthorID },
                    new Article { 
                        Title = "Understanding Databases", 
                        Text = "Databases store and retrieve data efficiently...", 
                        AuthorID = authors[2].AuthorID },
                    new Article { 
                        Title = "Exploring the Cosmos", 
                        Text = "Space exploration has fascinated humanity...", 
                        AuthorID = authors[1].AuthorID },
                };

                context.Articles.AddRange(articles);
                context.SaveChanges();

                // add comments
                var comments = new List<Comment>
                {
                    new Comment { Text = "Great article, very insightful!", ArticleID = articles[0].ArticleID },
                    new Comment { Text = "I totally agree with this perspective.", ArticleID = articles[1].ArticleID },
                    new Comment { Text = "Interesting points, but could use more data.", ArticleID = articles[2].ArticleID },
                    new Comment { Text = "Looking forward to more on this topic!", ArticleID = articles[3].ArticleID },
                    new Comment { Text = "Amazing read, thanks for sharing!", ArticleID = articles[0].ArticleID }
                };

                context.Comments.AddRange(comments);
                context.SaveChanges();

                var ratings = new List<Rating>
                {
                    new Rating
                    {
                        ArticleID = 1,
                        Value = 5
                    },
                    new Rating
                    {
                        ArticleID = 1,
                        Value = 3
                    },
                    new Rating
                    {
                        ArticleID = 1,
                        Value = 5
                    }
                };

                context.Ratings.AddRange(ratings);
                context.SaveChanges();
            }
        }
    }
}
