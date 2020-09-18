using Abp.Application.Services.Dto;
using System;

namespace MRPanel.Services
{
    //TODO: We should use Fluent Validation
    public class SitePageDto : EntityDto<Guid>
    {
        public string Title { get; set; }

        public string Summery { get; set; }
    }
}