using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRPanel.Domain;

namespace MRPanel.EntityFrameworkCore.Mappings
{
    public class MenuMapping : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.IsExternal)
                .HasDefaultValue<bool>(false);

            builder.HasOne(x => x.Page);

            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Menus)
                .HasForeignKey(x => x.ParentId);
        }
    }
}