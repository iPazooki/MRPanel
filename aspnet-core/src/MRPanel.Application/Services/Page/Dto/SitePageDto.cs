using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;

namespace MRPanel.Services
{
    //TODO: We should use Fluent Validation
    public class SitePageDto : EntityDto<Guid>
    {
        public string Title { get; set; }

        public string Summery { get; set; }

        public List<WidgetDto> Widgets { get; set; }
    }
}