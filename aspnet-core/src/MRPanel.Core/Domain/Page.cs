using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace MRPanel.Domain
{
    public class Page : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }

        public string Summery { get; set; }

        public string Content { get; set; }

        public PageType PageType { get; set; }

        public bool IsHomePage { get; set; }

        public Menu Menu { get; set; }

        public Guid? MenuId { get; set; }

        public ICollection<Widget> Widgets { get; set; }
    }
}