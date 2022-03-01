using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Pages;

public partial class EmployeeDetail
{
    [Parameter]
    public string? EmployeeId { get; set; }

    public Employee? Employee { get; set; } = new();


    [Inject]
    private IEmployeeDataService EmployeeDataService { get; set; } = null!;


    protected override async Task OnInitializedAsync()
    {
        if (EmployeeId != null) Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
    }
}