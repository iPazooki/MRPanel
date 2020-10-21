using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Application.Editions;
using Abp.Application.Features;
using MRPanel.Editions;
using MRPanel.Domain;

namespace MRPanel.EntityFrameworkCore.Seed.Host
{
    public class DefaultSiteSettingCreator
    {
        private readonly MRPanelDbContext _context;

        public DefaultSiteSettingCreator(MRPanelDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateSiteSetting();
        }

        private void CreateSiteSetting()
        {
            var siteSetting = _context.SiteSettings.IgnoreQueryFilters().FirstOrDefault();
            if (siteSetting == null)
            {
                siteSetting = new SiteSetting
                {
                    SiteName = "MRPanel",
                    Slogan = "Easy CMS",
                    FacebookUrl = "https://www.facebook.com/pazooki",
                    GithubUrl = "https://github.com/iPazooki/MRPanel",
                    InstagramUrl = "https://www.instagram.com/ipazooki/",
                    TwitterUrl = "https://twitter.com/iPazooki"
                };

                _context.SiteSettings.Add(siteSetting);

                _context.SaveChanges();
            }
        }
    }
}