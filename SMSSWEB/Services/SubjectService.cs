using SMSSModels;
using System.Net.Http.Json;

namespace SMSSWEB.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly HttpClient httpClient;

        public SubjectService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<SubjectDetails> CreateSubject(SubjectDetails subject)
        {
            try
            {
                var res = await httpClient.PostAsJsonAsync<SubjectDetails>("api/Subject", subject);

                if (res != null)
                {
                    subject = await res.Content.ReadFromJsonAsync<SubjectDetails>();
                }
            }
            catch (Exception ex)
            {
            }
            return subject;
        }

        public async Task<bool> DeleteSubject(int Id)
        {
            var res = await httpClient.DeleteAsync($"api/Staff/{Id}");
            return res.IsSuccessStatusCode;
        }

        public async Task<SubjectDetails> GetSubject(int id)
        {
            return await httpClient.GetFromJsonAsync<SubjectDetails>($"api/Subject/{id}");
        }

        public async Task<IEnumerable<SubjectDetails>> GetSubjects()
        {
            return await httpClient.GetFromJsonAsync<SubjectDetails[]>("api/Subject");
        }

        public async Task<SubjectDetails> UpdateSubject(SubjectDetails subject)
        {
            var res = await httpClient.PutAsJsonAsync<SubjectDetails>("api/Subject", subject);

            if (res != null)
            {
                subject = await res.Content.ReadFromJsonAsync<SubjectDetails>();
            }
            return subject;
        }
    }
}
