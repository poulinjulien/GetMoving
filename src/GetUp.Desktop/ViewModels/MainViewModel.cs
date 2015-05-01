// -----------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="WebForAll">
//   Copyright © WebForAll. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
// <author>Julien Poulin</author>
// <date>29/04/2015</date>
// <project>GetUp.Desktop</project>
// <web>http://www.webforall.be</web>
// -----------------------------------------------------------------------

namespace GetUp.Desktop.ViewModels
{

  using GalaSoft.MvvmLight;

  public class MainViewModel : ViewModelBase
  {

    public bool IsEnabled { get; set; }

    public int Hour { get; set; }

    public int Minute { get; set; }

  }

}