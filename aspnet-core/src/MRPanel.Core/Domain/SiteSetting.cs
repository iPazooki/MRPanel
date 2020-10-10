using Abp.Domain.Entities;

namespace MRPanel.Domain
{
    public class SiteSetting : Entity
    {
        public string SiteName { get; set; }

        public string Slogan { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string GithubUrl { get; set; }
    }
}