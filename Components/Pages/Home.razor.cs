using MudBlazor;
using SnackTracker.Data;

namespace SnackTracker.Components.Pages;

public partial class Home
{
    private string foodName = string.Empty;
    private int calories;
    private DateTime? entryDate = DateTime.Now;
    private List<FoodEntry> foodEntries = new();
    private IEnumerable<IGrouping<DateTime, FoodEntry>> groupedEntries = new List<IGrouping<DateTime, FoodEntry>>();

    protected override void OnInitialized()
    {
        LoadEntries();
    }

    private void LoadEntries()
    {
        foodEntries = FoodEntryService.GetEntries();
        groupedEntries  = foodEntries.OrderBy(e => e.EntryDate.Value).GroupBy(e => e.EntryDate.Value.Date);
    }
    private void AddFoodEntry()
    {
        if (string.IsNullOrEmpty(foodName) || calories <= 0)
        {
            Snackbar.Add("Please fill in all fields.", Severity.Error);
            return;
        }

        FoodEntryService.AddEntry(new FoodEntry
        {
            FoodName = foodName,
            Calories = calories,
            EntryDate = entryDate
        });
        
        LoadEntries();
        
        foodName = string.Empty;
        calories = 0;
        
        Snackbar.Add("Food entry added!", Severity.Success);
    }
}