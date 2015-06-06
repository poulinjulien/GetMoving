// -----------------------------------------------------------------------
// <copyright file="Win32Tools.cs" company="WebForAll">
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

  public struct LASTINPUTINFO
  {

    public uint cbSize;

    public uint dwTime;

  }

  public class Win32Tools
  {

    [DllImport("User32.dll")]
    public static extern bool LockWorkStation();

    [DllImport("User32.dll")]
    private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

    [DllImport("Kernel32.dll")]
    private static extern uint GetLastError();

    public static TimeSpan GetIdleTime()
    {
      return GetTickCount() - GetLastInputTime();
    }

    public static TimeSpan GetTickCount()
    {
      return TimeSpan.FromMilliseconds(Environment.TickCount);
    }

    public static TimeSpan GetLastInputTime()
    {
      var lastinputinfo = new LASTINPUTINFO();
      lastinputinfo.cbSize = (uint) Marshal.SizeOf(lastinputinfo);

      if (!GetLastInputInfo(ref lastinputinfo))
      {
        throw new Exception(GetLastError().ToString());
      }

      return TimeSpan.FromMilliseconds(lastinputinfo.dwTime);
    }

  }

}