using Microsoft.EntityFrameworkCore;
using Net.Db.MongoDb.EntityFramework.Domain;
using System.Reflection;

namespace Net.Db.MongoDb.EntityFramework.Infrastructure;

internal class ArticleDbContext : DbContext
{
    public DbSet<Article> Articles { get; init; }

    public ArticleDbContext(DbContextOptions options) : base(options)
    {
    }

#if DEBUG
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.LogTo(Console.WriteLine, minimumLevel: Microsoft.Extensions.Logging.LogLevel.Information);
    }
#endif

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        /*
        var ArticleModelBuilder = modelBuilder.Entity<Article>().ToCollection("Articles");

        ArticleModelBuilder.HasKey(x => x.ArticleId);

        ArticleModelBuilder.OwnsOne(x => x.Current);
        ArticleModelBuilder.OwnsMany(x => x.History);

        //BlogModelBuilder.HasIndex(x => x.Current.Title);
        */
    }
}

