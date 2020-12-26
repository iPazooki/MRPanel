using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRPanel.Domain;

namespace MRPanel.EntityFrameworkCore.Mappings
{
    public class MenuMapping : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable($"Mrp{nameof(Menu)}s");

            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(50);

            builder.Property(x => x.Icon)
                .HasMaxLength(25);

            builder.Property(x => x.IsExternal)
                .HasDefaultValue<bool>(false);

            builder.HasOne(x => x.Page)
                .WithOne(x => x.Menu)
                .HasForeignKey<Menu>(x => x.PageId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Menus)
                .HasForeignKey(x => x.ParentId)
                .IsRequired(false);
        }
    }
}