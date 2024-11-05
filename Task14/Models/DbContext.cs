using Microsoft.EntityFrameworkCore;

namespace Task14.Models
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext() { }

        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Users\\user\\Documents\\BlogPlatform.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(author => author.Articles)
                .HasForeignKey(a => a.AuthorID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(a => a.ArticleID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Rating>()
                .ToTable(r => r.HasCheckConstraint("CK_Rating_Value", "[Value] >= 1 AND [Value] <= 5"))
                .HasOne(r => r.Article)
                .WithMany(a => a.Ratings)
                .HasForeignKey(r => r.ArticleID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
