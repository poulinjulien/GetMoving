// -----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="WebForAll">
//   Copyright © WebForAll. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
// <author>Julien Poulin</author>
// <date>26/03/2015</date>
// <project>GetUp.Desktop</project>
// <web>http://www.webforall.be</web>
// -----------------------------------------------------------------------

namespace GetUp.Desktop
{

  using System.Windows;
  using ViewModels;

  public partial class MainWindow : Window
  {

    public MainWindow()
    {
      InitializeComponent();
      DataContext = new MainViewModel();
    }

  }

}