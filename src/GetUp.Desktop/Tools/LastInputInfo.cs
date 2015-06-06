// -----------------------------------------------------------------------
// <copyright file="LastInputInfo.cs" company="WebForAll">
//   Copyright © WebForAll. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
// <author>Julien Poulin</author>
// <date>06/06/2015</date>
// <project>GetUp.Desktop</project>
// <web>http://www.webforall.be</web>
// -----------------------------------------------------------------------

namespace GetUp.Desktop.Tools
{

  using System.Runtime.InteropServices;

  /// <summary>
  /// Contains the time of the last input.
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct LastInputInfo
  {

    /// <summary>
    /// The size of the structure, in bytes. This member must be set to sizeof(LASTINPUTINFO).
    /// </summary>
    [MarshalAs(UnmanagedType.U4)]
    public uint Size;

    /// <summary>
    /// The tick count when the last input event was received.
    /// </summary>
    [MarshalAs(UnmanagedType.U4)]
    public uint Time;

  }

}