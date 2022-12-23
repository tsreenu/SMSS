using SMSSModels;
using System.Net.Http.Json;

namespace SMSSWEB.Services
{
    public class StaffService : IStaffService
    {
        private readonly HttpClient httpClient;

        public StaffService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<StaffDetails> CreateStaff(StaffDetails staff)
        {
            try
            {
                var res = await httpClient.PostAsJsonAsync<StaffDetails>("api/Staff", staff);

                if (res != null)
                {
                    staff = await res.Content.ReadFromJsonAsync<StaffDetails>();
                }
            }
            catch(Exception ex) 
            { 
            }
            return staff;
        }

        public async Task<StaffDetails> GetStaff(int id)
        {
            return await httpClient.GetFromJsonAsync<StaffDetails>($"api/Staff/{id}");
        }

        public async Task<IEnumerable<StaffDetails>> GetStaff()
        {
            return await httpClient.GetFromJsonAsync<StaffDetails[]>("api/Staff");
        }

        public async Task<StaffDetails> UpdateStaff(StaffDetails staff)
        {
            var res = await httpClient.PutAsJsonAsync<StaffDetails>("api/Staff", staff);

            if (res != null)
            {

                staff = await res.Content.ReadFromJsonAsync<StaffDetails>();
            }
            return staff;
        }
        public async Task<bool> DeleteStaff(int Id)
        {
            var res = await httpClient.DeleteAsync($"api/Staff/{Id}");

            //if (res != null)
            //{

            //    staff = await res.Content.ReadFromJsonAsync<StaffDetails>();
            //}
            return res.IsSuccessStatusCode;
        }
    }
}
