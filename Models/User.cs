using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Journal_App_MAUI.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be 3-50 characters")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string PasswordSalt { get; set; } = string.Empty;

        [RegularExpression(@"^\d{4}$", ErrorMessage = "PIN must be 4 digits")]
        public string? Pin { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
