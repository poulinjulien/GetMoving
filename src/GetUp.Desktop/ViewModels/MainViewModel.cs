﻿// -----------------------------------------------------------------------
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
  using JetBrains.Annotations;
  using Tools;

  public class MainViewModel : ViewModelBase
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
      IdleTime = Win32Tools.GetIdleTime();

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

  }

}