using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Net.Db.MongoDb.EntityFramework.Domain;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Net.Db.MongoDb.EntityFramework.Infrastructure.Configurations;

internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToCollection("Articles");

        builder.HasKey(x => x.ArticleId);

        builder.OwnsOne(x => x.Current, owned =>
        {
            owned.HasIndex(o => o.Title);
        });

        builder.OwnsMany(x => x.History);

    }
}