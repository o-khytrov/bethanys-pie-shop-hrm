using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Pages;

public partial class EmployeeEdit
{
    [Inject]
    public IEmployeeDataService EmployeeDataService { get; set; }


    [Inject]
    public ICountryDataService CountryDataService { get; set; }

    [Inject]
    public IJobCategoryDataService JobCategoryDataService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string EmployeeId { get; set; }

    public IEnumerable<Country> Countries { get; set; }

    public IEnumerable<JobCategory> JobCategories { get; set; }

    public string CountryId { get; set; }

    public string JobCategoryId { get; set; }

    public bool Saved { get; set; }

    public Employee Employee { get; set; } = new Employee();

    public string StatusClass { get; set; }

    public string StatusMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Saved = false;
        Countries = await CountryDataService.GetAllCountries();
        JobCategories = await JobCategoryDataService.GetAllJobCategories();
        int.TryParse(EmployeeId, out var employeeId);
        if (employeeId == 0)
        {
            Employee = new Employee() { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now };
        }
        else
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
        }

        CountryId = Employee.CountryId.ToString();
        JobCategoryId = Employee.JobCategoryId.ToString();
    }

    private async Task DeleteEmployee()
    {
        await EmployeeDataService.DeleteEmployee(int.Parse(EmployeeId));
        StatusClass = "alert-success";
        StatusMessage = "Deleted successfully";
        Saved = true;
    }

    private async Task HandleValidSubmit()
    {
        Employee.CountryId = int.Parse(CountryId);
        Employee.JobCategoryId = int.Parse(JobCategoryId);
        if (Employee.EmployeeId == 0) // new
        {
            var newEmployee = await EmployeeDataService.AddEmployee(Employee);
            if (newEmployee is not null)
            {
                StatusClass = "alert-success";
                StatusMessage = "Employee created successfully";
                Saved = true;
            }
            else
            {
                StatusClass = "alert-danger";
                StatusMessage = "Something went wrong";
                Saved = false;
            }
        }
        else
        {
            await EmployeeDataService.UpdateEmployee(Employee);
            StatusClass = "alert-success";
            StatusMessage = "Employee updated successfully";
            Saved = true;
        }
    }

    private void OnInvalidSubmit()
    {
        StatusClass = "alert-danger";
        StatusMessage = "There are some validation errors. Please try again";
    }

    private void NavigateToOverview()
    {
        NavigationManager.NavigateTo("/employeeoverview");
    }
}