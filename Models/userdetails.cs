using System.ComponentModel.DataAnnotations;

namespace BusPassManagementSystem.Models
{
    public class userdetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime DoB { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? ContactNo { get; set; }
        [Required]
        public string? UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}

