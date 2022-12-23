using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using SMSSModels;
using SMSSWEB.Services;
using System.ComponentModel.DataAnnotations;
using static SMSSWEB.Pages.Staff.AddStaff;

namespace SMSSWEB.Pages.Staff
{
    public class AddStaffBase : ComponentBase
    {
        [Inject]
        public IStaffService staffService { get; set; }

        [Inject]
        public ICommonService commonService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }

        public StaffDetails staffDetails { get; set; } = new StaffDetails();
        public IBrowserFile files;
       
        public IEnumerable<States> states = new List<States>();
        public bool isPermAddressChecked { get; set; } = true;

        public bool success;

        protected override async Task OnInitializedAsync()
        {
            states = (await commonService.GetStates()).ToList();

        }

        public void OnValidSubmit(EditContext context)
        {
            success = true;
            StateHasChanged();
        }
        public void UploadFiles(InputFileChangeEventArgs e)
        {
            files = e.File;
            //TODO upload the files to the server
        }
        public async Task AddNewStaff()
        {
            StaffDetails res = new StaffDetails();
            if(isPermAddressChecked)
            {
                staffDetails.PermnentAddress = staffDetails.PresentAddress;
                staffDetails.PermnentCity = staffDetails.PresentCity;
                staffDetails.PermnentDistrict = staffDetails.PresentDistrict;
                staffDetails.PermnentPinCode = staffDetails.PresentPinCode;
                staffDetails.PermnentState = staffDetails.PresentState;
            }
            staffDetails.StaffId = "Test";
            staffDetails.CreatedBy = "Admin";
            staffDetails.UpdatedBy = "Admin";
            staffDetails.CreatedOn = DateTime.Now;
            staffDetails.UpdatedOn = DateTime.Now;
            res = await staffService.CreateStaff(staffDetails);
            Snackbar.Add("Staff details saved successfully", Severity.Info);
            navigationManager.NavigateTo("staffindex");
        }
        public void Cancel()
        {
            navigationManager.NavigateTo("staffindex");
        }
    }
}
