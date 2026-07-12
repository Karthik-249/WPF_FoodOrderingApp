using WPF_FoodOrderingApp.Models;

namespace WPF_FoodOrderingApp.Services;

public interface IDataAccessService
{
    public List<MenuCategoryDetails> GetAllMenuCategories();

    public List<MenuItem> GetMenuItemsForCategory(MenuCategoryDetails menuCategory);
}
