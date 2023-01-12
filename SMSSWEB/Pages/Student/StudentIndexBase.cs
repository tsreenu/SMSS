using Microsoft.AspNetCore.Components;
using MudBlazor;
using SMSSModels;
using SMSSWEB.Services;

namespace SMSSWEB.Pages.Student
{
    public class StudentIndexBase : ComponentBase
    {
        [Inject]
        public IStudentService studentService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        public StudentDetails selectedStudent = new StudentDetails();
        public StudentDetails StudentForDel = new StudentDetails();
        public bool visible;
        public HashSet<StaffDetails> selectedItems = new HashSet<StaffDetails>();


        public List<StudentDetails> allStudents { get; set; }

        protected override async Task OnInitializedAsync()
        {
            allStudents = (await studentService.GetStudents()).ToList();
        }

        public void OpenAddNew()
        {
            navigationManager.NavigateTo("addstudent");
        }

        public void EditStudent(int Id)
        {
            navigationManager.NavigateTo($"editstudent/{Id}");
        }
        public void OpenDeleteStaff(int Id)
        {
            StudentForDel = allStudents.Where(x => x.Id == Id).FirstOrDefault();
            OpenDialog();
        }
        public void OpenDialog() => visible = true;
        public void Cancel() => visible = false;
    }
}
