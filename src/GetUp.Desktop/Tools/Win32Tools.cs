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

  public static class Win32Tools
  {

    /// <summary>
    /// Locks the workstation's display. Locking a workstation protects it from unauthorized use.
    /// </summary>
    /// <returns>
    /// <para>
    /// If the function succeeds, the return value is nonzero. Because the function executes asynchronously, a nonzero return value indicates that the operation has been initiated. It does not indicate whether the workstation has been successfully locked.
    /// </para>
    /// <para>
    /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
    /// </para>
    /// </returns>
    [DllImport("User32.dll")]
    public static extern bool LockWorkStation();

    /// <summary>
    /// Retrieves the time of the last input event.
    /// </summary>
    /// <param name="lastInputInfo">A pointer to a LASTINPUTINFO structure that receives the time of the last input event.</param>
    /// <returns>
    /// <para>
    /// If the function succeeds, the return value is nonzero.
    /// </para>
    /// <para>
    /// If the function fails, the return value is zero.
    /// </para>
    /// </returns>
    [DllImport("User32.dll")]
    private static extern bool GetLastInputInfo(ref LastInputInfo lastInputInfo);

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
      var lastinputinfo = new LastInputInfo();
      lastinputinfo.Size = (uint) Marshal.SizeOf(lastinputinfo);

      if (!GetLastInputInfo(ref lastinputinfo))
      {
        throw new Exception(Marshal.GetLastWin32Error().ToString());
      }

      return TimeSpan.FromMilliseconds(lastinputinfo.Time);
    }

  }

}