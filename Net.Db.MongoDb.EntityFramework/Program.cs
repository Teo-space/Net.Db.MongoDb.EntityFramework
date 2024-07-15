using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Net.Db.MongoDb.EntityFramework.Domain;
using Net.Db.MongoDb.EntityFramework.Infrastructure;

print("Start");


var mongoClient = new MongoClient("mongodb://localhost:27017");

var dbContextOptions = new DbContextOptionsBuilder<ArticleDbContext>().UseMongoDB(mongoClient, "Articles");

var dbContext = new ArticleDbContext(dbContextOptions.Options);

print($"count: {dbContext.Articles.Count()}");

for (int i = 0; i < 10; i++)
{
    ArticleVersion version = new ArticleVersion($"Title_{Guid.NewGuid()}", "Description", "Me");

    Article article = new Article(version);

    dbContext.Articles.Add(article);
}

dbContext.SaveChanges();

print($"count: {dbContext.Articles.Count()}");




