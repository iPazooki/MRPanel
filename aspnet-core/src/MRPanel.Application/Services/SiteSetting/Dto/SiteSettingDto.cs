using Abp.Application.Services.Dto;

namespace MRPanel.Services
{
    public class SiteSettingDto : EntityDto
    {
        public string SiteName { get; set; }

        public string Slogan { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string GithubUrl { get; set; }
    }
}