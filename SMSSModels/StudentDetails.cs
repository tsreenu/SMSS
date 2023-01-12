using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSSModels
{
    public class StudentDetails
    {
        public int Id { get; set; }
        public string? AdmissionNo { get; set; }
        public string? SchoolId { get; set; }
        public string? StudentName { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public int? RollNumber { get; set; }
        public int Gender { get; set; }
        public int? BloodGroup { get; set; }
        public int? Religion { get; set; }
        public int? Category { get; set; }
        public string? Caste { get; set; }
        public string? AdharNumber { get; set; }
        public string? MobileNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfAdmission { get; set; }
        public string? PermnentAddress { get; set; }
        public string? PermnentCity { get; set; }
        public string? PermnentDistrict { get; set; }
        public string? PermnentPinCode { get; set; }
        public int? PermnentState { get; set; }
        public string? PresentAddress { get; set; }
        public string? PresentCity { get; set; }
        public string? PresentDistrict { get; set; }
        public string? PresentPinCode { get; set; }
        public int? PresentState { get; set; }
        public string? FatherName { get; set; }
        public string? FatherMobile { get; set; }
        public string? MotherName { get; set; }
        public string? MotherMobile { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
