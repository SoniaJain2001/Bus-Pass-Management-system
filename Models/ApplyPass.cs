using System.ComponentModel.DataAnnotations;
namespace BusPassManagementSystem.Models
{
    public class ApplyPass
    {
        [Key]
        public int PassNo { get; set; }

        [Required]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Required]
        public string Passtype { get; set; }
        [Required]
        public string IdentityProof { get; set; }
        [Required]
        public int IdentityNo { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }

    }
}
