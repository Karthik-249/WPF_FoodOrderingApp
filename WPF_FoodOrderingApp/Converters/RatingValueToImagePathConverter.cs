using System.Globalization;
using System.Windows.Data;

namespace WPF_FoodOrderingApp.Converters;

public class RatingValueToImagePathConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        double.TryParse(value.ToString(), out double ratingValue);

        if (ratingValue >= 4.5)
        {
            return "../Resources/Icons/Ratings/ExcellentRatingIcon.png";
        }
        else if (ratingValue >= 4)
        {
            return "../Resources/Icons/Ratings/GoodRatingIcon.png";
        }
        else if (ratingValue >= 3.5)
        {
            return "../Resources/Icons/Ratings/DecentRatingIcon.png";
        }
        else
        {
            return "../Resources/Icons/Ratings/PoorRatingIcon.png";
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
