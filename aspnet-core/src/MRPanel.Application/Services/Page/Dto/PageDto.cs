using Abp.Application.Services.Dto;
using MRPanel.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace MRPanel.Services
{
    //TODO: We should use Fluent Validation
    public class PageDto : FullAuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(MRPanelConsts.Length256)]
        public string Title { get; set; }

        public string Summery { get; set; }

        public string Content { get; set; }

        [Required]
        public PageType PageType { get; set; }

        public bool IsHomePage { get; set; }
    }
}