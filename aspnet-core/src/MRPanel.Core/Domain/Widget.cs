using Abp.Domain.Entities;
using MRPanel.Domain.Enum;
using System;
using System.Collections.Generic;

namespace MRPanel.Domain
{
    public class Widget : Entity<Guid>
    {
        public WidgetType WidgetType { get; set; }

        public string Content { get; set; }

        public string ImageAddress { get; set; }

        public SizeType SizeType { get; set; }

        public Position Position { get; set; }

        public Page Page { get; set; }

        public Guid PageId { get; set; }

        public Guid? ParentId { get; set; }

        public Widget Parent { get; set; }

        public int Order { get; set; }

        public ICollection<Widget> Widgets { get; set; }
    }
}