using Microsoft.EntityFrameworkCore;
using SMSSAPI.Data;
using SMSSAPI.Models.Interface;
using SMSSModels;

namespace SMSSAPI.Models.Repository
{
    public class SubjectRepository : ISubjectService
    {
        private SMSSContext context;
        public SubjectRepository(SMSSContext context)
        {
            this.context = context;
        }
        public async Task<SubjectDetails> AddSubject(SubjectDetails subject)
        {
            var result = await context.SubjectDetails.AddAsync(subject);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteSubject(int Id)
        {
            var result = await context.SubjectDetails.Where(x => x.SubjectId == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false;
                var res = await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SubjectDetails>> GetSubjectDetails()
        {
            var subjectList = new List<SubjectDetails>();
            subjectList = await context.SubjectDetails.Where(x => x.IsActive == true).ToListAsync();
            return subjectList;
        }

        public async Task<SubjectDetails> GetSubjectDetails(int Id)
        {
            var subjectDetails = new SubjectDetails();
            try
            {
                subjectDetails = await context.SubjectDetails.Where(x => x.SubjectId == Id).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

            }
            return subjectDetails;
        }

        public async Task<SubjectDetails> UpdateSubject(SubjectDetails subject)
        {
            context.Entry(subject).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return subject;
        }
    }
}
