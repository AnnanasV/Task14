using Microsoft.EntityFrameworkCore;
using Task14.Models;
using Task14.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var dbContext = new Task14.Models.DbContext())
        {
            var searchService = new ArticleSearchService(dbContext);
            DbInitializer.Seed(dbContext); // add records to db

            var articles = searchService.GetArticlesByAuthor("BloggerPro");
            PrintArticles(articles);
            Console.WriteLine("================");
            articles = searchService.GetArticlesByKeyword("and");
            PrintArticles(articles);
            Console.WriteLine("================");
            var article = dbContext.Articles.Include(a => a.Ratings).FirstOrDefault(a => a.ArticleID == 1);
            Console.WriteLine($"Average rating of article '{article?.Title}': {article?.GetAverageRating()}");
        }
    }

    private static void PrintArticles(List<Article> list)
    {
        foreach (Article a in list)
        {
            Console.WriteLine($"Title:\t{a.Title}\nText:\t{a.Text}");
        }
    }
}