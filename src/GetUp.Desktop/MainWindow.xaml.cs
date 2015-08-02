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
      Loaded += MainWindow_Loaded;
      InitializeComponent();
      DataContext = new MainViewModel();
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
      Left = Properties.Settings.Default.WindowPositionX;
      Top = Properties.Settings.Default.WindowPositionY;
      LocationChanged += MainWindow_LocationChanged;
    }

    private void MainWindow_LocationChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.WindowPositionX = Left;
      Properties.Settings.Default.WindowPositionY = Top;
      Properties.Settings.Default.Save();
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