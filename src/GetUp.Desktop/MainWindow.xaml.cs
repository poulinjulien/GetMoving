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
  using Hardcodet.Wpf.TaskbarNotification;
  using Properties;
  using ViewModels;

  public partial class MainWindow
  {

    private ICommand _RestoreWindowCommand;

    public MainWindow()
    {
      Loaded += MainWindow_Loaded;
      InitializeComponent();
      DataContext = CreateViewModel();
    }

    private MainViewModel CreateViewModel()
    {
      var viewModel = new MainViewModel();
      viewModel.MaximumActiveTimeElapsed += (s, e) => OnMaximumActiveTimeElapsed();

      return viewModel;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
      var settings = Settings.Default;
      if (settings.WindowPositionX != 0.0 && settings.WindowPositionY != 0.0)
      {
        Left = settings.WindowPositionX;
        Top = settings.WindowPositionY;
      }
    }

    public ICommand RestoreWindowCommand => _RestoreWindowCommand ?? (_RestoreWindowCommand = new RelayCommand(RestoreWindow));

    private void RestoreWindow()
    {
      if (Dispatcher.CheckAccess())
      {
        WindowState = WindowState.Normal;
      }
      else
      {
        Dispatcher.Invoke(RestoreWindow);
      }
    }

    protected override void OnStateChanged(EventArgs e)
    {
      base.OnStateChanged(e);

      ShowInTaskbar = WindowState == WindowState.Normal;
    }

    private void OnMaximumActiveTimeElapsed()
    {
      RestoreWindow();
      TaskbarIcon.ShowBalloonTip("Title", "Time to Get Up!", BalloonIcon.Info);
    }

    protected override void OnClosed(EventArgs e)
    {
      Settings.Default.WindowPositionX = Left;
      Settings.Default.WindowPositionY = Top;
      Settings.Default.Save();

      base.OnClosed(e);
    }

  }

}