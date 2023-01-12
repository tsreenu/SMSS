using Microsoft.EntityFrameworkCore;
using SMSSAPI.Data;
using SMSSAPI.Models.Interface;
using SMSSModels;

namespace SMSSAPI.Models.Repository
{
    public class StudentDetailsRepository : IStudentDetailsService
    {
        private SMSSContext context;

        public StudentDetailsRepository(SMSSContext context)
        {
            this.context = context;
        }
        public async Task<StudentDetails> AddStudent(StudentDetails student)
        {
            var result = await context.StudentDetails.AddAsync(student);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteStudent(int Id)
        {
            var result = await context.StudentDetails.FirstOrDefaultAsync(x => x.Id == Id);
            if (result != null)
            {
                result.IsActive = false;
                result.UpdatedBy = "Admin";
                result.UpdatedOn = DateTime.Now;
                var res = await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<StudentDetails>> GetStudentDetails()
        {
            var studentList = await context.StudentDetails.Where(x => x.IsActive == true).ToListAsync();
            return studentList;
        }

        public async Task<StudentDetails> GetStudentDetails(int Id)
        {
            var studentDetails = await context.StudentDetails.Where(x => x.Id == Id).AsNoTracking().FirstOrDefaultAsync();
            return studentDetails;
        }

        public async Task<StudentDetails> UpdateStudent(StudentDetails student)
        {
            var result = await context.StudentDetails.AsNoTracking().FirstOrDefaultAsync(x => x.Id == student.Id);

            if (result != null)
            {
                context.Entry(student).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return student;
        }
    }
}
