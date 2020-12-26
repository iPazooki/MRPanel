using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MRPanel.Domain
{
    public class Menu : Entity<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Url { get; set; }

        public Page Page { get; set; }

        public Guid? PageId { get; set; }

        public Menu Parent { get; set; }

        public Guid? ParentId { get; set; }

        public bool IsExternal { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}