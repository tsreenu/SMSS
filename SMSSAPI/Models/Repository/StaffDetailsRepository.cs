using Microsoft.EntityFrameworkCore;
using SMSSAPI.Data;
using SMSSAPI.Models.Interface;
using SMSSModels;
using System;

namespace SMSSAPI.Models.Repository
{
    public class StaffDetailsRepository : IStaffDetailsService
    {
        private SMSSContext context;
        public StaffDetailsRepository(SMSSContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<StaffDetails>> GetStaffDetails()
        {
            var staffList = new List<StaffDetails>();
            try
            {
                staffList = await context.StaffDetails.Where(x => x.IsActive == true).ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return staffList;
        }

        public async Task<StaffDetails> GetStaffDetails(int Id)
        {
            var staffDetails = await context.StaffDetails.Where(x => x.Id == Id).AsNoTracking().FirstOrDefaultAsync();
            return staffDetails;
        }
        public async Task<StaffDetails> AddStaff(StaffDetails staff)
        {
            var result = await context.StaffDetails.AddAsync(staff);
            await context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteStaff(int Id)
        {
            var result = await context.StaffDetails.FirstOrDefaultAsync(x => x.Id == Id);
            if (result != null)
            {
                result.IsActive = false;
                result.UpdatedBy = "Admin";
                result.UpdatedOn = DateTime.Now;
                //context.StaffDetails.Remove(result);
               var res = await context.SaveChangesAsync();
                //return "";
            }
            //return result;
        }

        public async Task<StaffDetails> UpdateStaff(StaffDetails staff)
        {
            var result = await context.StaffDetails.AsNoTracking().FirstOrDefaultAsync(x => x.Id == staff.Id);
            try
            {
                if (result != null)
                {
                    //result.FirstName = staff.FirstName;
                    //result.LastName = staff.LastName;
                    //result.PhoneNumber = staff.PhoneNumber;
                    //result.AltPhoneNumber = staff.AltPhoneNumber;
                    //result.DateOfBirth = staff.DateOfBirth;
                    //result.DateOfJoining = staff.DateOfJoining;
                    //result.EmailId = staff.EmailId;
                    //result.Qualification = staff.Qualification;
                    //result.PermnentAddress = staff.PermnentAddress;
                    //result.PermnentState = staff.PermnentState;
                    //result.PermnentCity = staff.PresentCity;
                    //result.PermnentDistrict = staff.PermnentDistrict;
                    //result.PermnentPinCode = staff.PermnentPinCode;
                    //result.PresentAddress = staff.PresentAddress;
                    //result.PresentCity = staff.PresentCity;
                    //result.PresentDistrict = staff.PresentDistrict;
                    //result.PresentPinCode = staff.PresentPinCode;
                    //result.PresentPinCode = staff.PresentPinCode;
                    //result.PresentState = staff.PresentState;
                    //result.UpdatedBy = staff.UpdatedBy;
                    //result.UpdatedOn = DateTime.Now;
                    context.Entry(staff).State = EntityState.Modified;
                }
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
            return result;
        }
    }
}
