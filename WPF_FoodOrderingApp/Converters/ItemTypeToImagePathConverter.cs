using System.Globalization;
using System.Windows.Data;
using WPF_FoodOrderingApp.Reusables.Enums;

namespace WPF_FoodOrderingApp.Converters;

public class ItemTypeToImagePathConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        ItemType type = (ItemType)value;

        return type switch
        {
            ItemType.Veg => "../Resources/Icons/ItemTypes/VegIcon.png",
            ItemType.NonVeg => "../Resources/Icons/ItemTypes/NonVegIcon.png",
            ItemType.Egg => "../Resources/Icons/ItemTypes/ContainsEggIcon.png",
            _ => "../Resources/Icons/ItemTypes/NonVegIcon.png"
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
