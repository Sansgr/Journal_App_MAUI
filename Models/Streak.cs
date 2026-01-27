using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Journal_App_MAUI.Models
{
    public class Streak
    {
        [PrimaryKey, AutoIncrement]
        public int StreakId { get; set; }

        [Required]
        public int UserId { get; set; }

        public int CurrentStreak { get; set; } = 0;
        public int LongestStreak { get; set; } = 0;
        public DateTime LastEntryDate { get; set; } = DateTime.MinValue;
    }
}
