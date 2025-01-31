using MudBlazor;

namespace SnackTracker.Components.Pages;

public partial class Home
{
    private string foodName = string.Empty;
    private int calories;
    private DateTime? entryDate = DateTime.Today;
    private List<FoodView> foodEntries = new();

    private void AddFoodEntry()
    {
        if (string.IsNullOrEmpty(foodName) || calories <= 0)
        {
            Snackbar.Add("Please fill in all fields.", Severity.Error);
            return;
        }

        foodEntries.Add(new FoodView
        {
            FoodName = foodName,
            Calories = calories,
            EntryDate = entryDate
        });

        foodName = string.Empty;
        calories = 0;
    }

    private class FoodView
    {
        public string FoodName { get; set; }
        public int Calories { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}