using SMSSModels;

namespace SMSSAPI.Models.Interface
{
    public interface IClassDetailsService
    {
        Task<IEnumerable<ClassDetails>> GetClassDetails();
        Task<ClassDetails> GetClassDetails(int Id);
        Task<ClassDetails> AddClass(ClassDetails Class);
        Task<ClassDetails> DeleteClass(int Id);
        Task<ClassDetails> UpdateClass(ClassDetails classDetails);
    }
}
