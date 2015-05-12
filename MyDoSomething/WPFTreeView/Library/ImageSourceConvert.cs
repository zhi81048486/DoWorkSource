using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WPFTreeView.Library
{
    public class ImageSourceConvert : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value)
                return "../Resources/" + GetImageName(value.ToString());
            else return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return "";
        }

        #endregion

        private string GetImageName(string text)
        {

            string name = default(string);
            if (!string.IsNullOrEmpty(text))
            {
                switch (text)
                {
                    case "中国":
                        name = "china.png";
                        break;
                    case "日本":
                        name = "japan.png";
                        break;
                    case "英国":
                        name = "uk.png";
                        break;
                    case "丹麦":
                        name = "denmark.png";
                        break;
                    default:
                        name = "";
                        break;
                }

            }

            return name;

        }
    }
}
