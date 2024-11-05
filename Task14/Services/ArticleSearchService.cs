using Task14.Models;

namespace Task14.Services
{
    public class ArticleSearchService
    {
        private DbContext _dbContext;

        public ArticleSearchService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Article> GetArticlesByAuthor(string nickname)
        {
            return _dbContext.Articles
                .Where(a => a.Author.NickName == nickname)
                .ToList();
        }

        public List<Article> GetArticlesByKeyword(string keyword)
        {
            return _dbContext.Articles
                .Where(a => a.Text.Contains(keyword) || a.Title.Contains(keyword))
                .ToList();
        }
    }
}
