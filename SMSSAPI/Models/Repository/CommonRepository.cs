using Microsoft.EntityFrameworkCore;
using SMSSAPI.Data;
using SMSSAPI.Models.Interface;
using SMSSModels;
using System.Security.Claims;

namespace SMSSAPI.Models.Repository
{
    public class CommonRepository : ICommonService
    {
        private SMSSContext context;
        public CommonRepository(SMSSContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<States>> GetStates()
        {
            var result = await context.States.ToListAsync();
            return result;
        }
    }
}
