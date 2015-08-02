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

  using System;
  using System.Windows;
  using System.Windows.Input;
  using GalaSoft.MvvmLight.Command;
  using ViewModels;

  public partial class MainWindow
  {

    private ICommand _RestoreWindowCommand;

    public MainWindow()
    {
      InitializeComponent();
      DataContext = new MainViewModel();
    }

    public ICommand RestoreWindowCommand
    {
      get { return _RestoreWindowCommand ?? (_RestoreWindowCommand = new RelayCommand(RestoreWindow)); }
    }
    
    private void RestoreWindow()
    {
      WindowState = WindowState.Normal;
    }

    protected override void OnStateChanged(EventArgs e)
    {
      base.OnStateChanged(e);

      ShowInTaskbar = WindowState == WindowState.Normal;
    }

  }

}