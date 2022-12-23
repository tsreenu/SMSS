using SMSSModels;

namespace SMSSWEB.Services
{
    public interface ICommonService
    {
        Task<IEnumerable<States>> GetStates();
    }
}
