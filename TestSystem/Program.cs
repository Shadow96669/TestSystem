
using System.Text.Json;
using TestSystem.Models;

public
class MainMenu
{
    private List<Category> categories;
    private Administrator admin;
    private Tested tested;
    private const string DataFile = "data/categories.json";

    public MainMenu()
    {
        LoadData();
        admin = new Administrator("Admin", categories);
        tested = new Tested("User", categories);
    }

    private void LoadData()
    {
        if (File.Exists(DataFile))
        {
            string json = File.ReadAllText(DataFile);
            categories = JsonSerializer.Deserialize<List<Category>>(json) ?? new();
        }
        else
        {
            categories = new List<Category>();
        }
    }

    private void SaveData()
    {
        string json = JsonSerializer.Serialize(categories, new JsonSerializerOptions { WriteIndented = true });
        Directory.CreateDirectory(Path.GetDirectoryName(DataFile));
        File.WriteAllText(DataFile, json);
    }

    public void Run()
    {
        // Главное меню: выбор роли, затем соответствующие подменю
        // После каждого действия администратора вызывать SaveData()
    }
}