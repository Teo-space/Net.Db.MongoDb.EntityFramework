namespace Net.Db.MongoDb.EntityFramework.Domain;

public sealed record Article
{
    public Guid ArticleId { get; init; }

    public ArticleVersion Current { get; private set; }
    public HashSet<ArticleVersion> History { get; private set; } = [];

    private Article() { }
    public Article(ArticleVersion articleVersion)
    {
        ArticleId = NUlid.Ulid.NewUlid().ToGuid();
        Current = articleVersion with { };
        History = [articleVersion];
    }

    public void Update(ArticleVersion articleVersion)
    {
        Current = articleVersion with { };
        History.Add(articleVersion);
    }
}