using Abp.Application.Services.Dto;
using MRPanel.Domain;
using System;

namespace MRPanel.Services
{
    public class TopPageDto : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string MenuTitle { get; set; }

        public PageType PageType { get; set; }
    }
}