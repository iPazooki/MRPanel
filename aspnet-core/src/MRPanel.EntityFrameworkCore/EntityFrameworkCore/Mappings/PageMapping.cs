using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRPanel.Domain;

namespace MRPanel.EntityFrameworkCore.Mappings
{
    public class PageMapping : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable($"Mrp{nameof(Page)}s");

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(MRPanelConsts.Length256);

            builder.Property(x => x.Content);

            builder.Property(x => x.PageType)
               .IsRequired()
               .HasConversion<int>();

            builder.HasMany(x => x.Widgets)
                .WithOne(s => s.Page)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Menu)
                .WithOne(x => x.Page)
                .HasForeignKey<Page>(x => x.MenuId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
        }
    }
}