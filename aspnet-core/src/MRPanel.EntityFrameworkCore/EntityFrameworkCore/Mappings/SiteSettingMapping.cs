using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRPanel.Domain;

namespace MRPanel.EntityFrameworkCore.Mappings
{
    public class SiteSettingMapping : IEntityTypeConfiguration<SiteSetting>
    {
        public void Configure(EntityTypeBuilder<SiteSetting> builder)
        {
            builder.Property(x => x.SiteName)
                .IsRequired()
                .HasMaxLength(MRPanelConsts.Length256);

            builder.Property(x => x.Slogan)
                .HasMaxLength(MRPanelConsts.Length256);

            builder.Property(x => x.FacebookUrl)
                 .HasMaxLength(MRPanelConsts.Length256);

            builder.Property(x => x.TwitterUrl)
                 .HasMaxLength(MRPanelConsts.Length256);

            builder.Property(x => x.InstagramUrl)
                 .HasMaxLength(MRPanelConsts.Length256);

            builder.Property(x => x.GithubUrl)
                 .HasMaxLength(MRPanelConsts.Length256);
        }
    }
}