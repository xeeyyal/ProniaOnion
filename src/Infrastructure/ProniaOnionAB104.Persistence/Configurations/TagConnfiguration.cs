using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnionAB104.Domain.Entities;

namespace ProniaOnionAB104.Persistence.Configurations
{
    internal class TagConnfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t=>t.Name).IsRequired().HasMaxLength(25);
            builder.HasIndex(t => t.Name).IsUnique();
        }
    }
}
