using Abp.Application.Services.Dto;
using System;

namespace MRPanel.Services
{
    public class MenuDto : EntityDto<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Url { get; set; }

        public Guid? PageId { get; set; }

        public string PageName { get; set; }

        public Guid? ParentId { get; set; }

        public bool IsExternal { get; set; }
    }
}