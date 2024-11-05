using Task14.Models;
using Task14.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var dbContext = new DbContext();
        var searchService = new ArticleSearchService(dbContext);
        DbInitializer.Seed(dbContext); // add records to db

        var articles = searchService.GetArticlesByAuthor("BloggerPro");
        PrintArticles(articles);
        Console.WriteLine("================");
        articles = searchService.GetArticlesByKeyword("and");
        PrintArticles(articles);
    }

    private static void PrintArticles(List<Article> list)
    {
        foreach (Article a in list)
        {
            Console.WriteLine($"Title:\t{a.Title}\nText:\t{a.Text}");
        }
    }
}