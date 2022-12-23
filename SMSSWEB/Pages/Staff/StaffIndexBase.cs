using Microsoft.AspNetCore.Components;
using MudBlazor;
using SMSSModels;
using SMSSWEB.Services;
using static MudBlazor.Colors;

namespace SMSSWEB.Pages.Staff
{
    public class StaffIndexBase : ComponentBase
    {
        [Inject]
        public IStaffService staffService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        public StaffDetails selectedStaff = new StaffDetails();
        public StaffDetails staffForDel = new StaffDetails();
        public bool visible;
        public HashSet<StaffDetails> selectedItems = new HashSet<StaffDetails>();


        public List<StaffDetails> allStaffs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            allStaffs = (await staffService.GetStaff()).ToList();
        }
        public void EditStaff(int Id)
        {
            navigationManager.NavigateTo($"editstaff/{Id}");
        }
        public void OpenDeleteStaff(int Id)
        {
            staffForDel = allStaffs.Where(x => x.Id == Id).FirstOrDefault();
            OpenDialog();
        }
        public async void DeleteStaffConfirm()
        {
            var res = await staffService.DeleteStaff(staffForDel.Id);
            if (res)
            {
                Snackbar.Add("Staff details Deleted successfully", Severity.Info);
            }
            else
            {
                Snackbar.Add("Something went wrong, Please try again.", Severity.Warning);
            }
            visible = false;
            navigationManager.NavigateTo("staffindex", true);
        }

        public DialogOptions dialogOptions = new() { FullWidth = true, MaxWidth = MaxWidth.Small, CloseOnEscapeKey = true, CloseButton = true };
        public void OpenDialog() => visible = true;
        public void Cancel() => visible = false;

        public void OpenAddNew()
        {
            navigationManager.NavigateTo("addstaff");
        }

    }
}
