using SMSSModels;
using System.Net.Http.Json;

namespace SMSSWEB.Services
{
    public class ClassService: IClassService
    {
        private readonly HttpClient httpClient;

        public ClassService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<ClassDetails> CreateClass(ClassDetails Class)
        {
            try
            {
                var res = await httpClient.PostAsJsonAsync<ClassDetails>("api/Class", Class);

                if (res != null)
                {
                    Class = await res.Content.ReadFromJsonAsync<ClassDetails>();
                }
            }
            catch (Exception ex)
            {
            }
            return Class;
        }

        public async Task<ClassDetails> GetClass(int id)
        {
            return await httpClient.GetFromJsonAsync<ClassDetails>($"api/Class/{id}");
        }

        public async Task<IEnumerable<ClassDetails>> GetClass()
        {
            return await httpClient.GetFromJsonAsync<ClassDetails[]>("api/Class");
        }

        public async Task<ClassDetails> UpdateClass(ClassDetails Class)
        {
            var res = await httpClient.PutAsJsonAsync<ClassDetails>("api/Class", Class);

            if (res != null)
            {
                Class = await res.Content.ReadFromJsonAsync<ClassDetails>();
            }
            return Class;
        }
        public async Task<bool> DeleteClass(int Id)
        {
            var res = await httpClient.DeleteAsync($"api/Class/{Id}");

            //if (res != null)
            //{

            //    Class = await res.Content.ReadFromJsonAsync<ClassDetails>();
            //}
            return res.IsSuccessStatusCode;
        }
        public async Task<SectionDetails> CreateSection(SectionDetails sectionDetails)
        {
            try
            {
                var res = await httpClient.PostAsJsonAsync<SectionDetails>("api/SectionDetails", sectionDetails);

                if (res != null)
                {
                    sectionDetails = await res.Content.ReadFromJsonAsync<SectionDetails>();
                }
            }
            catch (Exception ex)
            {
            }
            return sectionDetails;
        }
        public async Task<SectionDetails> UpdateSection(SectionDetails sectionDetails)
        {
            try
            {
                var res = await httpClient.PutAsJsonAsync<SectionDetails>("api/SectionDetails", sectionDetails);

                if (res != null)
                {
                    sectionDetails = await res.Content.ReadFromJsonAsync<SectionDetails>();
                }
            }
            catch (Exception ex)
            {
            }
            return sectionDetails;
        }
    }
}
