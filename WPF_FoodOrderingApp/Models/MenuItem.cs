using WPF_FoodOrderingApp.Reusables.Enums;

namespace WPF_FoodOrderingApp.Models;

public class MenuItem
{
    public string Name { get; set; } = string.Empty;
    public ItemType Type { get; set; }
    public decimal Price { get; set; }
    public double Rating { get; set; }
}
