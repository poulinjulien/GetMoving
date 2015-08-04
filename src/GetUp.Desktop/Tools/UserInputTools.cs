// -----------------------------------------------------------------------
// <copyright file="UserInputTools.cs" company="WebForAll">
//   Copyright © WebForAll. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
// <author>Julien Poulin</author>
// <date>27/05/2015</date>
// <project>GetUp.Desktop</project>
// <web>http://www.webforall.be</web>
// -----------------------------------------------------------------------

namespace GetUp.Desktop.Tools
{

  using System;
  using System.Runtime.InteropServices;

  public static class UserInputTools
  {

    public static TimeSpan GetIdleTime()
    {
      return GetTickCount() - GetLastInputTime();
    }

    private static TimeSpan GetTickCount()
    {
      return TimeSpan.FromMilliseconds(Environment.TickCount);
    }

    private static TimeSpan GetLastInputTime()
    {
      var lastinputinfo = new LastInputInfo();
      lastinputinfo.Size = (uint) Marshal.SizeOf(lastinputinfo);

      if (!NativeMethods.GetLastInputInfo(ref lastinputinfo))
      {
        throw new Exception(Marshal.GetLastWin32Error().ToString());
      }

      return TimeSpan.FromMilliseconds(lastinputinfo.Time);
    }

  }

}