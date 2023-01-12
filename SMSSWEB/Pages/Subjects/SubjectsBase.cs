using Microsoft.AspNetCore.Components;
using MudBlazor;
using SMSSModels;
using SMSSWEB.Services;

namespace SMSSWEB.Pages.Subjects
{
    public class SubjectsBase : ComponentBase
    {
        [Inject]
        public ISubjectService subjectService { get; set; }
        [Inject]
        public IClassService classService { get; set; }
        [Inject]
        public IStaffService staffService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        public IEnumerable<SubjectDetails> allSubjects { get; set; }
        public SubjectDetails subjectDetails { get; set; } = new SubjectDetails();
        public IEnumerable<ClassDetails> allClass { get; set; }
        public List<StaffDetails> teachersList { get; set; }

        public DialogOptions dialogOptionsAdd = new() { FullWidth = true, MaxWidth = MaxWidth.Small, CloseOnEscapeKey = true, CloseButton = true };


        public bool isOpenExpandSec;
        public bool addVisible = false;
        public bool editClassVisible = false;

        public bool editSubjectVisible = false;


        protected override async Task OnInitializedAsync()
        {
            allClass = (await classService.GetClass()).ToList();
            teachersList = (await staffService.GetStaff()).Where(x => x.StaffType == 1).ToList();
        }

        public void OpenAddDialog() => addVisible = true;
       

        public void OpenEditSubjectDialog(ClassDetails classDet)
        {
            editSubjectVisible = true;
            //classDetails = classDet;
        }


        public void CloseAddDialog() => addVisible = false;
        public void OpenAddSubjectDialog(int classId)
        {
            addVisible = true;
            subjectDetails = new SubjectDetails();
            subjectDetails.ClassId = classId;
        }
        public void CloseEditSubjectDialog() => editSubjectVisible = false;

        public void OpenEditSubjectDialog(SubjectDetails subject)
        {
            editSubjectVisible = true;
            subjectDetails = subject;
        }
        public async void UpdateSubject()
        {
            var res = await subjectService.UpdateSubject(subjectDetails);
            Snackbar.Add("Subject details updated successfully", Severity.Info);
            navigationManager.NavigateTo("subjectindex", true);
        }
        public void DeletSubjectDialog(int Id)
        {

        }

        public async void AddNewSubject()
        {

            subjectDetails.IsActive = true;
            var res = await subjectService.CreateSubject(subjectDetails);
            Snackbar.Add("Subject details saved successfully", Severity.Info);
            navigationManager.NavigateTo("subjectindex", true);
        }
    }
}
