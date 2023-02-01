using System.ComponentModel.DataAnnotations;
namespace BusPassManagementSystem.Models
{
    public class Resetpassword
    {
        [Required]
        public String UserId { get; set; }
        [Required]
        public String MobileNumber { get; set; }

    }
}
