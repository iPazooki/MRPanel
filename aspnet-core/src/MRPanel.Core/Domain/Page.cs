using Abp.Domain.Entities.Auditing;
using System;

namespace MRPanel.Domain
{
    public class Page : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }

        public string Summery { get; set; }

        public string Content { get; set; }

        public PageType PageType { get; set; }
    }
}