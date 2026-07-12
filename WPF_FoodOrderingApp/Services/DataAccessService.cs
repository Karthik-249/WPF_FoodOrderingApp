using System.IO;
using System.IO.Abstractions;
using System.Text.Json;
using WPF_FoodOrderingApp.Models;

namespace WPF_FoodOrderingApp.Services;

public class DataAccessService : IDataAccessService
{
    private const string MenuFilesBasePath = "./DataStore";
    private readonly IFileSystem _fileSystem;
    private JsonSerializerOptions MenuFileSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        AllowOutOfOrderMetadataProperties = true
    };

    public DataAccessService(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public List<MenuCategoryDetails> GetAllMenuCategories()
    {
        List<MenuCategoryDetails> menuCategories = new();
        
        var filePaths = _fileSystem.Directory.EnumerateFiles(MenuFilesBasePath, "*.json", SearchOption.AllDirectories);

        foreach (string filePath in filePaths)
        {
            menuCategories.Add(new MenuCategoryDetails()
            {
                DisplayName = GetMenuCategoryDisplayName(filePath),
                ItemsFilePath = filePath
            });
        }

        return menuCategories;
    }

    public List<MenuItem> GetMenuItemsForCategory(MenuCategoryDetails menuCategory)
    {
        string menuFileContents = File.ReadAllText(menuCategory.ItemsFilePath);
        List<MenuItem> menuItems = JsonSerializer.Deserialize<List<MenuItem>>(menuFileContents, MenuFileSerializerOptions) ?? new();

        return menuItems;
    }

    private string GetMenuCategoryDisplayName(string filePath) =>
        _fileSystem.Path.GetFileNameWithoutExtension(filePath).Replace("_", " ");
}
