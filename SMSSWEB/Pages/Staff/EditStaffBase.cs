using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using SMSSModels;
using SMSSWEB.Services;
using static MudBlazor.Colors;

namespace SMSSWEB.Pages.Staff
{
    public class EditStaffBase:ComponentBase
    {
        [Inject]
        public IStaffService staffService { get; set; }

        [Inject]
        public ICommonService commonService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Parameter]
        public string Id { get; set; }

        public IBrowserFile files;
        

        public StaffDetails staffDetails = new StaffDetails();

        public bool isPermAddressChecked { get; set; } = true;

        public IEnumerable<States> states = new List<States>();

        

        protected override async Task OnInitializedAsync()
        {
            states = (await commonService.GetStates()).ToList();
            Id = Id ?? "1";
            staffDetails = await staffService.GetStaff(Convert.ToInt32(Id));
        }
        public async void UpdateStaff()
        {
            var res = await staffService.UpdateStaff(staffDetails);
            Snackbar.Add("Staff details updated successfully", Severity.Info);
            navigationManager.NavigateTo("staffindex");
        }
        public void UploadFiles(InputFileChangeEventArgs e)
        {
            files = e.File;
            //TODO upload the files to the server
        }
        public void Cancel()
        {
            navigationManager.NavigateTo("staffindex");
        }
    }
}
