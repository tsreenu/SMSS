using SMSSModels;

namespace SMSSWEB.Services
{
    public interface IStaffService
    {
        Task<IEnumerable<StaffDetails>> GetStaff();
        Task<StaffDetails> GetStaff(int id);
        Task<StaffDetails> UpdateStaff(StaffDetails staff);
        Task<StaffDetails> CreateStaff(StaffDetails staff);
        Task<bool> DeleteStaff(int Id);
    }
}
