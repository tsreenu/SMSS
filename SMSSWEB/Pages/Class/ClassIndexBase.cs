using Microsoft.AspNetCore.Components;
using MudBlazor;
using SMSSModels;
using SMSSWEB.Services;

namespace SMSSWEB.Pages.Class
{
    public class ClassIndexBase : ComponentBase
    {
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

        public IEnumerable<ClassDetails> allClass { get; set; }

        public bool isOpenExpandSec;
        public bool addVisible = false;
        public bool editClassVisible = false;
        public ClassDetails classDetails = new ClassDetails();

        public bool addSectionVisible = false;
        public SectionDetails sectionDetails = new SectionDetails();
        public bool editSectionVisible = false;
        public int selectedClass { get; set; }
        public List<StaffDetails> teachersList { get; set; }

        public DialogOptions dialogOptionsAdd = new() { FullWidth = true, MaxWidth = MaxWidth.Small, CloseOnEscapeKey = true, CloseButton = true };
        public void OpenAddDialog()
        {
            classDetails = new ClassDetails();
            addVisible = true;
        }
        public void CloseAddDialog() => addVisible = false;

        public void OpenAddSectionDialog(int classId)
        {
            sectionDetails = new SectionDetails();
            addSectionVisible = true;
            selectedClass = classId;
        }
        public void CloseAddSectionDialog() => addSectionVisible = false;
        protected override async Task OnInitializedAsync()
        {
            allClass = (await classService.GetClass()).ToList();
            teachersList = (await staffService.GetStaff()).Where(x => x.StaffType == 1).ToList();
        }

        public async void AddNewClass()
        {
            classDetails.SchoolId = "Test";
            classDetails.IsActive = true;
            classDetails.CreatedOn = DateTime.Now;
            classDetails.CreatedBy = "Admin";
            classDetails.UpdatedBy = "Admin";
            classDetails.UpdatedOn = DateTime.Now;
            var res = await classService.CreateClass(classDetails);
            Snackbar.Add("Class details saved successfully", Severity.Info);
            navigationManager.NavigateTo("classindex", true);
        }
        public async void RenameClass()
        {
            classDetails.SchoolId = "Test";
            classDetails.IsActive = true;
            classDetails.UpdatedBy = "Admin";
            classDetails.UpdatedOn = DateTime.Now;
            var res = await classService.UpdateClass(classDetails);
            Snackbar.Add("Class details updated successfully", Severity.Info);
            navigationManager.NavigateTo("classindex", true);
        }
        public async void AddNewSection()
        {
            sectionDetails.IsActive = true;
            sectionDetails.ClassId = selectedClass;
            var res = await classService.CreateSection(sectionDetails);
            Snackbar.Add("Section details saved successfully", Severity.Info);
            navigationManager.NavigateTo("classindex", true);
        }
        public async void UpdateSection()
        {
            //sectionDetails.IsActive = true;
            //sectionDetails.ClassId = selectedClass;
            var res = await classService.UpdateSection(sectionDetails);
            Snackbar.Add("Section details updated successfully", Severity.Info);
            navigationManager.NavigateTo("classindex", true);
        }
        public void OpenEditSecDialog(SectionDetails secDet)
        {
            sectionDetails = secDet;
            editSectionVisible = true;
        }
        public void CloseEditSecDialog() => editSectionVisible = false;

        public void OpenEditClassDialog(ClassDetails classDet)
        {
            editClassVisible = true;
            classDetails = classDet;
        }
        public void CloseEditClassDialog() => editClassVisible = false;
        public void DeletEditSecDialog(int Id)
        {

        }
    }
}
