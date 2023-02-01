using System.ComponentModel.DataAnnotations;
namespace BusPassManagementSystem.Models
{
    public class passtype
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Passtype { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int Cost { get; set; }
    }
}
