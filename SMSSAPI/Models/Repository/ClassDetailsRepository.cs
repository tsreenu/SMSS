using Microsoft.EntityFrameworkCore;
using SMSSAPI.Data;
using SMSSAPI.Models.Interface;
using SMSSModels;

namespace SMSSAPI.Models.Repository
{
    public class ClassDetailsRepository : IClassDetailsService
    {
        private SMSSContext context;
        public ClassDetailsRepository(SMSSContext context)
        {
            this.context = context;
        }
        public async Task<ClassDetails> AddClass(ClassDetails Class)
        {
            var result = await context.ClassDetails.AddAsync(Class);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ClassDetails> DeleteClass(int Id)
        {
            var result = await context.ClassDetails.FirstOrDefaultAsync(x => x.Id == Id);
            if (result != null)
            {
                result.IsActive = false;
                result.UpdatedOn = DateTime.Now;
                result.UpdatedBy = "Admin";
                await context.SaveChangesAsync();
                return result;
            }
            return result;
        }

        public async Task<IEnumerable<ClassDetails>> GetClassDetails()
        {
            IEnumerable<ClassDetails> classList = new List<ClassDetails>();
            try
            {
                classList = await context.ClassDetails.Where(x=>x.SchoolId == "Test")
                    .Include(x => x.SectionDetails)
                    .Include(x=>x.SubjectDetails)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return classList;
        }

        public async Task<ClassDetails> GetClassDetails(int Id)
        {
            var classDetails = await context.ClassDetails.Where(x => x.Id == Id).AsNoTracking().FirstOrDefaultAsync();
            return classDetails;
        }
        public async Task<ClassDetails> UpdateClass(ClassDetails classDetails)
        {
            var result = await context.ClassDetails.AsNoTracking().FirstOrDefaultAsync(x => x.Id == classDetails.Id);
            try
            {
                if (result != null)
                {
                    //result.ClassName = classDetails.ClassName;
                    //result.UpdatedBy = classDetails.UpdatedBy;
                    //result.UpdatedOn = classDetails.UpdatedOn;
                    context.Entry(classDetails).State = EntityState.Modified;
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
