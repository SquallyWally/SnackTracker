using SQLite;

namespace SnackTracker.Data;

public class FoodEntryService
{
    private SQLiteConnection  _connection;   
    
    public FoodEntryService()
    {
        _connection = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "snackTracker.db"));
        _connection.CreateTable<FoodEntry>();
    }
    
    public List<FoodEntry> GetEntries() => _connection.Table<FoodEntry>().ToList();
    public void AddEntry(FoodEntry entry) => _connection.Insert(entry);
    
}

public class FoodEntry
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string FoodName { get; set; }
    public int Calories { get; set; }
    public DateTime? EntryDate { get; set; }
}