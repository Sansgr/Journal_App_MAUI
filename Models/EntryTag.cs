using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Journal_App_MAUI.Models
{
    public class EntryTag
    {
        [PrimaryKey, AutoIncrement]
        public int EntryTagId { get; set; }

        [Required]
        public int EntryId { get; set; }

        [Required]
        public int TagId { get; set; }
    }
}
