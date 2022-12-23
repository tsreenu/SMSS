using Microsoft.AspNetCore.Mvc;
using SMSSModels;

namespace SMSSAPI.Models.Interface
{
    public interface ISectionDetailsService
    {
        Task<IEnumerable<SectionDetails>> GetSectionDetails();
        Task<SectionDetails> GetSectionDetails(int id);
        Task<SectionDetails> AddSectionDetails(SectionDetails sectionDetails);
        Task<SectionDetails> UpdateSectionDetails(SectionDetails sectionDetails);
        Task DeleteSectionDetails(int id);
    }
}
