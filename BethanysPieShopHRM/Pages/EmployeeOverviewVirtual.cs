using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Pages;

public partial class EmployeeOverviewVirtual
{
    public List<Employee> Employees { get; set; }

    [Inject]
    public IEmployeeDataService EmployeeDataService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Employees = (await EmployeeDataService.GetLongEmployeeList()).ToList();
    }

    private float itemHeight = 50;
}