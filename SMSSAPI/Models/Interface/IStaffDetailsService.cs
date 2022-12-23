using SMSSModels;

namespace SMSSAPI.Models.Interface
{
    public interface IStaffDetailsService
    {
        Task<IEnumerable<StaffDetails>> GetStaffDetails();
        Task<StaffDetails> GetStaffDetails(int Id);
        Task<StaffDetails> AddStaff(StaffDetails staff);
        Task<StaffDetails> UpdateStaff(StaffDetails staff);
        Task DeleteStaff(int Id);
    }
}
