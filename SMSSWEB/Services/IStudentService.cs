using SMSSModels;

namespace SMSSWEB.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDetails>> GetStudents();
        Task<StudentDetails> GetStudent(int id);
        Task<StudentDetails> UpdateStudent(StudentDetails student);
        Task<StudentDetails> CreateStudent(StudentDetails student);
        Task<bool> DeleteStudent(int Id);
    }
}
