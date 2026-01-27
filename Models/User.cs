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

        public string Password { get; set; } = string.Empty; // stores salted+hashed password

        public string Pin { get; set; } = string.Empty; // stores salted+hashed PIN

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
