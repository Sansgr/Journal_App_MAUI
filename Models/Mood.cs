using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Journal_App_MAUI.Models
{
    public class Mood
    {
        [PrimaryKey, AutoIncrement]
        public int MoodId { get; set; }

        [Required(ErrorMessage = "Mood name is required")]
        public string MoodName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mood type is required")]
        [RegularExpression("Positive|Neutral|Negative", ErrorMessage = "Mood type must be Positive, Neutral, or Negative")]
        public string MoodType { get; set; } = string.Empty;
    }
}
