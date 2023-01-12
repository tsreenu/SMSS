using SMSSModels;

namespace SMSSAPI.Models.Interface
{
    public interface IStudentDetailsService
    {
        Task<IEnumerable<StudentDetails>> GetStudentDetails();
        Task<StudentDetails> GetStudentDetails(int Id);
        Task<StudentDetails> AddStudent(StudentDetails student);
        Task<StudentDetails> UpdateStudent(StudentDetails student);
        Task DeleteStudent(int Id);
    }
}
