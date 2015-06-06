// -----------------------------------------------------------------------
// <copyright file="TimeSpanToIntConverter.cs" company="WebForAll">
//   Copyright © WebForAll. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
// <author>Julien Poulin</author>
// <date>29/05/2015</date>
// <project>GetUp.Desktop</project>
// <web>http://www.webforall.be</web>
// -----------------------------------------------------------------------

namespace GetUp.Desktop.Converters
{

  using System;
  using System.Globalization;
  using System.Windows.Data;
  using System.Windows.Markup;

  [ValueConversion(typeof(TimeSpan), typeof(int))]
  public class TimeSpanToIntConverter : MarkupExtension, IValueConverter
  {

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      return this;
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return ((TimeSpan) value).TotalMinutes;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return TimeSpan.FromMinutes((int) value);
    }

  }

}