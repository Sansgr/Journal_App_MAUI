using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Journal_App_MAUI.Models
{
    public class EntryMood
    {
        [PrimaryKey, AutoIncrement]
        public int EntryMoodId { get; set; }

        [Required]
        public int EntryId { get; set; }

        [Required]
        public int MoodId { get; set; }

        [Required]
        [RegularExpression("Primary|Secondary", ErrorMessage = "Mood role must be Primary or Secondary")]
        public string MoodRole { get; set; } = "Primary";
    }
}
