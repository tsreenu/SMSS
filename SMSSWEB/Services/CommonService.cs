using SMSSModels;

namespace SMSSWEB.Services
{
    public class CommonService : ICommonService
    {
        private readonly HttpClient httpClient;

        public CommonService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<States>> GetStates()
        {
            return await httpClient.GetFromJsonAsync<States[]>("api/Common/GetStates");
        }

    }
}
