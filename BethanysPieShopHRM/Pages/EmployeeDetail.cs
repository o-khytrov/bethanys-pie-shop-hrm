using BethanysPieShopHRM.ComponentsLibrary.Map;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Pages;

public partial class EmployeeDetail
{
    [Parameter]
    public string? EmployeeId { get; set; }

    public Employee? Employee { get; set; } = new();

    public List<Marker> MapMarkers { get; set; } = new();

    [Inject]
    private IEmployeeDataService EmployeeDataService { get; set; } = null!;


    protected override async Task OnInitializedAsync()
    {
        if (EmployeeId != null) Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
        MapMarkers = new List<Marker>()
        {
            new Marker() { Description = $"{Employee.FirstName} {Employee.LastName}", ShowPopup = false, X = Employee.Longitude, Y = Employee.Latitude }
        };
    }
}