using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Journal_App_MAUI.Models
{
    public class Tag
    {
        [PrimaryKey, AutoIncrement]
        public int TagId { get; set; }

        [Required(ErrorMessage = "Tag name is required")]
        public string TagName { get; set; } = string.Empty;

        public bool IsPredefined { get; set; } = false;
    }
}
