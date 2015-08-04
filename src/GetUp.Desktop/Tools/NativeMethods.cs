// -----------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="WebForAll">
//   Copyright © WebForAll. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
// <author>Julien Poulin</author>
// <date>04/08/2015</date>
// <project>GetUp.Desktop</project>
// <web>http://www.webforall.be</web>
// -----------------------------------------------------------------------

namespace GetUp.Desktop.Tools
{

  using System.Runtime.InteropServices;

  internal static class NativeMethods
  {

    /// <summary>
    /// Retrieves the time of the last input event.
    /// </summary>
    /// <param name="lastInputInfo">A pointer to a LASTINPUTINFO structure that receives the time of the last input event.</param>
    /// <returns>S
    /// <para>
    /// If the function succeeds, the return value is nonzero.
    /// </para>
    /// <para>
    /// If the function fails, the return value is zero.
    /// </para>
    /// </returns>
    [DllImport("User32.dll")]
    internal static extern bool GetLastInputInfo(ref LastInputInfo lastInputInfo);

  }

}