using Microsoft.EntityFrameworkCore;

namespace Net.Db.MongoDb.EntityFramework.Domain;

[Owned]
public sealed record ArticleVersion
{
    public string Title { get; init; }
    public string Description { get; init; }

    public string Author { get; init; }

    public DateTime Created { get; init; }

    private ArticleVersion() { }
    public ArticleVersion(string title, string description, string author) 
    {
        Title = title;
        Description = description;
        Author = author;
        Created = DateTime.Now;
    }

}