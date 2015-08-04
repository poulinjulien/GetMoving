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

  using System;
  using System.Runtime.CompilerServices;
  using System.Threading;
  using System.Windows;
  using GalaSoft.MvvmLight;
  using GalaSoft.MvvmLight.CommandWpf;
  using JetBrains.Annotations;
  using Tools;

  public sealed class MainViewModel : ViewModelBase, IDisposable
  {

    private const int TimerResolution = 250;

    private Timer _Timer;

#if DEBUG
    [NotifyPropertyChangedInvocator]
    protected override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
      base.RaisePropertyChanged(propertyName);
    }
#endif

    private bool _IsEnabled;

    public bool IsEnabled
    {
      get { return _IsEnabled; }
      set
      {
        if (value != _IsEnabled)
        {
          _IsEnabled = value;
          RaisePropertyChanged();
        }
      }
    }

    private TimeSpan _IdleTime;

    public TimeSpan IdleTime
    {
      get { return _IdleTime; }
      set
      {
        if (value.Equals(_IdleTime))
        {
          return;
        }
        _IdleTime = value;
        RaisePropertyChanged();
      }
    }

    private TimeSpan _ActiveTime;

    public TimeSpan ActiveTime
    {
      get { return _ActiveTime; }
      set
      {
        if (!value.Equals(_ActiveTime))
        {
          _ActiveTime = value;
          RaisePropertyChanged();
        }
      }
    }

    private TimeSpan _PauseThreshold;

    public TimeSpan PauseThreshold
    {
      get { return _PauseThreshold; }
      set
      {
        if (!value.Equals(_PauseThreshold))
        {
          _PauseThreshold = value;
          RaisePropertyChanged();
        }
      }
    }

    private TimeSpan _MaximumActiveTime;

    public TimeSpan MaximumActiveTime
    {
      get { return _MaximumActiveTime; }
      set
      {
        if (!value.Equals(_MaximumActiveTime))
        {
          _MaximumActiveTime = value;
          RaisePropertyChanged();
        }
      }
    }

    public MainViewModel()
    {
      MaximumActiveTime = TimeSpan.FromMinutes(30);
      PauseThreshold = TimeSpan.FromMinutes(3);
      _Timer = new Timer(_ => UpdateTimes(), null, TimeSpan.FromMilliseconds(TimerResolution), TimeSpan.FromMilliseconds(TimerResolution));
    }

    private void UpdateTimes()
    {
      IdleTime = UserInputTools.GetIdleTime();

      if (IdleTime < PauseThreshold)
      {
        ActiveTime = ActiveTime.Add(TimeSpan.FromMilliseconds(TimerResolution));
      }
      else
      {
        ActiveTime = TimeSpan.Zero;
      }

      if (ActiveTime > MaximumActiveTime + PauseThreshold)
      {
        MessageBox.Show("Pause needed!");
      }
    }

    private RelayCommand<int> _IncrementMaximumActiveTimeCommand;

    [UsedImplicitly]
    public RelayCommand<int> IncrementMaximumActiveTimeCommand
    {
      get { return _IncrementMaximumActiveTimeCommand ?? (_IncrementMaximumActiveTimeCommand = new RelayCommand<int>(IncrementMaximumActiveTime)); }
    }

    private void IncrementMaximumActiveTime(int step)
    {
      if (MaximumActiveTime + TimeSpan.FromMinutes(step) > TimeSpan.Zero)
      {
        MaximumActiveTime = MaximumActiveTime.Add(TimeSpan.FromMinutes(step));
      }
    }

    private RelayCommand<int> _IncrementPauseThresholdCommand;

    [UsedImplicitly]
    public RelayCommand<int> IncrementPauseThresholdCommand
    {
      get { return _IncrementPauseThresholdCommand ?? (_IncrementPauseThresholdCommand = new RelayCommand<int>(IncrementPauseThreshold)); }
    }

    private void IncrementPauseThreshold(int step)
    {
      if (PauseThreshold + TimeSpan.FromMinutes(step) > TimeSpan.Zero)
      {
        PauseThreshold = PauseThreshold.Add(TimeSpan.FromMinutes(step));
      }
    }

    public void Dispose()
    {
      _Timer.Dispose();
    }

  }

}