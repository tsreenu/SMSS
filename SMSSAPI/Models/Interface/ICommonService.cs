using SMSSModels;

namespace SMSSAPI.Models.Interface
{
    public interface ICommonService
    {
        Task<IEnumerable<States>> GetStates();
    }
}
