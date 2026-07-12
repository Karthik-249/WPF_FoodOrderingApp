using System.Collections.ObjectModel;
using WPF_FoodOrderingApp.Models;
using WPF_FoodOrderingApp.Services;

namespace WPF_FoodOrderingApp.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    private readonly IDataAccessService _dataAccessService;

    private ObservableCollection<MenuCategoryDetails> _menuCategories = new();
    public ObservableCollection<MenuCategoryDetails> MenuCategories
    {
        get => _menuCategories;
        set
        {
            _menuCategories = value;
            OnPropertyChanged(nameof(MenuCategories));
        }
    }

    private ObservableCollection<MenuItem> _menuItems = new();
    public ObservableCollection<MenuItem> MenuItems
    {
        get => _menuItems;
        set
        {
            _menuItems = value;
            OnPropertyChanged(nameof(MenuItems));
        }
    }

    private MenuCategoryDetails _selectedMenuCategory = new();
    public MenuCategoryDetails SelectedMenuCategory
    {
        get => _selectedMenuCategory;
        set
        {
            if (_selectedMenuCategory != value)
            {
                _selectedMenuCategory = value;
                OnPropertyChanged(nameof(SelectedMenuCategory));
                PopulateMenuItems();
            }
        }
    }

    public MainWindowViewModel(IDataAccessService dataAccessService)
    {
        _dataAccessService = dataAccessService;
        PopulateMenuCategories();
        SelectedMenuCategory = MenuCategories.First();
    }

    private void PopulateMenuCategories()
    {
        MenuCategories = new ObservableCollection<MenuCategoryDetails>(_dataAccessService.GetAllMenuCategories());
    }

    private void PopulateMenuItems()
    {
        MenuItems = new ObservableCollection<MenuItem>(_dataAccessService.GetMenuItemsForCategory(_selectedMenuCategory));
    }
}
