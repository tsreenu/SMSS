using Microsoft.EntityFrameworkCore;
using SMSSAPI.Data;
using SMSSAPI.Models.Interface;
using SMSSModels;

namespace SMSSAPI.Models.Repository
{
    public class SectionDetailsRepository : ISectionDetailsService
    {
        private SMSSContext context;
        public SectionDetailsRepository(SMSSContext context)
        {
            this.context = context;
        }
        public async Task<SectionDetails> AddSectionDetails(SectionDetails sectionDetails)
        {
            var result = await context.SectionDetails.AddAsync(sectionDetails);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteSectionDetails(int id)
        {
            var result = await context.SectionDetails.Where(x => x.SectionId == id).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false;
                var res = await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SectionDetails>> GetSectionDetails()
        {
            var sectionDetailsList = new List<SectionDetails>();
            sectionDetailsList = await context.SectionDetails.Where(x => x.IsActive == true).ToListAsync();
            return sectionDetailsList;
        }

        public async Task<SectionDetails> GetSectionDetails(int id)
        {
            var sectionDetails = new SectionDetails();
            try
            {
                sectionDetails = await context.SectionDetails.Where(x => x.SectionId == id).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

            }
            return sectionDetails;
        }

        public async Task<SectionDetails> UpdateSectionDetails(SectionDetails sectionDetails)
        {
            context.Entry(sectionDetails).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return sectionDetails;
        }
    }
}
