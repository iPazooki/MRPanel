using System.ComponentModel.DataAnnotations;

namespace MRPanel.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}