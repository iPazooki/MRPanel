using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRPanel.Domain;

namespace MRPanel.EntityFrameworkCore.Mappings
{
    public class PageMapping : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(MRPanelConsts.Length256);

            builder.Property(x => x.Content)
                .IsRequired();

            builder.Property(x => x.PageType)
               .IsRequired()
               .HasConversion<int>();
        }
    }
}