using System.ComponentModel.DataAnnotations;
namespace BusPassManagementSystem.Models
{
    public class Login
    {
        [Required]  
        public String UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
