using SMSSModels;

namespace SMSSWEB.Services
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDetails>> GetSubjects();
        Task<SubjectDetails> GetSubject(int id);
        Task<SubjectDetails> UpdateSubject(SubjectDetails subject);
        Task<SubjectDetails> CreateSubject(SubjectDetails subject);
        Task<bool> DeleteSubject(int Id);
    }
}
