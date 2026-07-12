using System.Text.Json.Serialization;

namespace WPF_FoodOrderingApp.Reusables.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ItemType
{
    Veg,
    Egg,
    NonVeg,
}
