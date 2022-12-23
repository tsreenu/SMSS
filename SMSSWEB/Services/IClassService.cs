using SMSSModels;

namespace SMSSWEB.Services
{
    public interface IClassService
    {
        Task<IEnumerable<ClassDetails>> GetClass();
        Task<ClassDetails> GetClass(int id);
        Task<ClassDetails> UpdateClass(ClassDetails Class);
        Task<ClassDetails> CreateClass(ClassDetails Class);
        Task<bool> DeleteClass(int Id);
        Task<SectionDetails> CreateSection(SectionDetails sectionDetails);
        Task<SectionDetails> UpdateSection(SectionDetails sectionDetails);
    }
}
