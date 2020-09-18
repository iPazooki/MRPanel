using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MRPanel.Domain;
using MRPanel.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace MRPanel.Services
{
    //TODO: We should use Fluent Validation
    [AutoMapFrom(typeof(Page))]
    public class PageDto : FullAuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(MRPanelConsts.Length256)]
        public string Title { get; set; }

        public string Summery { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public PageType PageType { get; set; }


        public ContentPlace ContentPlace { get; set; }

        public bool IsMainPage { get; set; }
    }
}