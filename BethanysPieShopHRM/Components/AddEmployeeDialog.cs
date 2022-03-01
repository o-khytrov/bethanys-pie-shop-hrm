using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components;

public partial class AddEmployeeDialog
{
    public Employee Employee { get; set; } = new() { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };

    [Inject]
    public IEmployeeDataService EmployeeDataService { get; set; }

    public bool ShowDialog { get; set; }

    [Parameter]
    public EventCallback<bool> CloseEventCallback { get; set; }

    public void Show()
    {
        ResetDialog();
        ShowDialog = true;
        StateHasChanged();
    }

    public void Close()
    {
        ShowDialog = false;
        StateHasChanged();
    }

    private void ResetDialog()
    {
        Employee = new() { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
    }

    private Task HandleInvalidSubmit()
    {
        throw new NotImplementedException();
    }

    private async Task HandleValidSubmit()
    {
        await EmployeeDataService.AddEmployee(Employee);
        ShowDialog = false;
        await CloseEventCallback.InvokeAsync(true);
        StateHasChanged();
    }
}