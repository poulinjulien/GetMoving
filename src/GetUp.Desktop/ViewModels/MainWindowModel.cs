// -----------------------------------------------------------------------
// <copyright file="MainWindowModel.cs" company="WebForAll">
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

  public sealed class MainWindowModel : ViewModelBase
  {

    private readonly StatusViewModel _StatusViewModel;

    private ViewModelBase _CurrentViewModel;

    public ViewModelBase CurrentViewModel
    {
      get { return _CurrentViewModel; }
      set
      {
        if (value != _CurrentViewModel)
        {
          _CurrentViewModel = value;
          RaisePropertyChanged();
        }
      }
    }

    public MainWindowModel()
    {
      _StatusViewModel = new StatusViewModel();
      CurrentViewModel = _StatusViewModel;
    }

  }

}