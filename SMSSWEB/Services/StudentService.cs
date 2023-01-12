using SMSSModels;
using System.Net.Http.Json;

namespace SMSSWEB.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient httpClient;

        public StudentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<StudentDetails> CreateStudent(StudentDetails student)
        {
            try
            {
                var res = await httpClient.PostAsJsonAsync<StudentDetails>("api/Student", student);

                if (res != null)
                {
                    student = await res.Content.ReadFromJsonAsync<StudentDetails>();
                }
            }
            catch (Exception ex)
            {
            }
            return student;
        }

        public async Task<bool> DeleteStudent(int Id)
        {
            var res = await httpClient.DeleteAsync($"api/Student/{Id}");
            return res.IsSuccessStatusCode;
        }

        public async Task<StudentDetails> GetStudent(int id)
        {
            return await httpClient.GetFromJsonAsync<StudentDetails>($"api/Student/{id}");
        }

        public async Task<IEnumerable<StudentDetails>> GetStudents()
        {
            return await httpClient.GetFromJsonAsync<StudentDetails[]>("api/Student");
        }

        public async Task<StudentDetails> UpdateStudent(StudentDetails student)
        {
            var res = await httpClient.PutAsJsonAsync<StudentDetails>("api/Student", student);

            if (res != null)
            {
                student = await res.Content.ReadFromJsonAsync<StudentDetails>();
            }
            return student;
        }
    }
}
