using SMSSModels;

namespace SMSSAPI.Models.Interface
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDetails>> GetSubjectDetails();
        Task<SubjectDetails> GetSubjectDetails(int Id);
        Task<SubjectDetails> AddSubject(SubjectDetails subject);
        Task<SubjectDetails> UpdateSubject(SubjectDetails subject);
        Task DeleteSubject(int Id);
    }
}
