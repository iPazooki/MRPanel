using Abp.Application.Services.Dto;
using MRPanel.Domain.Enum;
using System;

namespace MRPanel.Services
{
    public class WidgetSaveDto : FullAuditedEntityDto<Guid>
    {
        public WidgetType WidgetType { get; set; }

        public string Content { get; set; }

        public string ImageAddress { get; set; }

        public SizeType SizeType { get; set; }

        public int Order { get; set; }

        public Position Position { get; set; }

        public Guid PageId { get; set; }

        public Guid? ParentId { get; set; }
    }
}