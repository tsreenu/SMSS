using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSSModels
{
    public class StaffDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string StaffId { get; set; } = string.Empty;

        [Required]
        [MinLength(3, ErrorMessage = "First Name length can't be less than 3.")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MinLength(10, ErrorMessage = "Phone Number length can't be less than 10.")]
        [MaxLength(10, ErrorMessage = "Phone Number length can't be greater than 10.")]
        public string PhoneNumber { get; set; } = string.Empty;

        public string AltPhoneNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string EmailId { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        [Required]
        public string Qualification { get; set; } = string.Empty;

        [Required]
        public int Gender { get; set; } = 1;

        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public DateTime? DateOfJoining { get; set; }

    
        public string PermnentAddress { get; set; } = string.Empty;
     
        public string PermnentCity { get; set; } = string.Empty;
  
        public string PermnentDistrict { get; set; } = string.Empty;
  
        public string PermnentPinCode { get; set; } = string.Empty;
       
        public int PermnentState { get; set; }=2;

        [Required]
        public string PresentAddress { get; set; } = string.Empty;

        [Required]
        public string PresentCity { get; set; } = string.Empty;

        [Required]
        public string PresentDistrict { get; set; } = string.Empty;

        [Required]
        public string PresentPinCode { get; set; } = string.Empty;

        [Required]
        public int PresentState { get; set; } = 2;
        public string Photo { get; set; } = string.Empty;

        [Required]
        public int StaffType { get; set; } = 1;
        public string SchoolId { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}