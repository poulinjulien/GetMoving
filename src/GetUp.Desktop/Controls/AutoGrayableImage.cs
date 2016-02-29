// -----------------------------------------------------------------------
// <copyright file="AutoGrayableImage.cs" company="WebForAll">
//   Copyright © WebForAll. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
// <author>Julien Poulin</author>
// <date>27/05/2015</date>
// <project>GetUp.Desktop</project>
// <web>http://www.webforall.be</web>
// -----------------------------------------------------------------------

namespace GetUp.Desktop.Controls
{

  using System;
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Media;
  using System.Windows.Media.Imaging;

  /// <summary>
  /// Class used to have an image that is able to be grayed when the control is not enabled.
  /// Author: Thomas LEBRUN (http://blogs.developpeur.org/tom/archive/2009/01/19/wpf-comment-griser-l-icone-d-un-menuitem-qui-est-d-sactiv.aspx).
  /// </summary>
  public class AutoGrayableImage : Image
  {

    private BitmapSource _OriginalImage;

    private BitmapSource _GrayedImage;

    private Brush _GrayedOpacityMask;

    private BitmapSource OriginalImage
    {
      get { return _OriginalImage ?? (_OriginalImage = (BitmapSource) Source); }
    }

    private BitmapSource GrayedImage
    {
      get { return _GrayedImage ?? (_GrayedImage = new FormatConvertedBitmap(OriginalImage, PixelFormats.Gray32Float, null, 0)); }
    }

    private Brush GrayedOpacityMask
    {
      get { return _GrayedOpacityMask ?? (_GrayedOpacityMask = new ImageBrush(OriginalImage)); }
    }

    static AutoGrayableImage()
    {
      IsEnabledProperty.OverrideMetadata(typeof (AutoGrayableImage), new FrameworkPropertyMetadata(true, OnAutoGreyScaleImageIsEnabledPropertyChanged));
      SourceProperty.OverrideMetadata(typeof (AutoGrayableImage), new FrameworkPropertyMetadata(null, OnAutoGreyScaleImageSourcePropertyChanged));
    }

    private static void OnAutoGreyScaleImageSourcePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
    {
      var autoGreyScaleImg = source as AutoGrayableImage;
      if (autoGreyScaleImg != null)
      {
        if (!autoGreyScaleImg.IsEnabled)
        {
          autoGreyScaleImg.Source = autoGreyScaleImg.GrayedImage;
          autoGreyScaleImg.OpacityMask = autoGreyScaleImg.GrayedOpacityMask;
        }
        else
        {
          autoGreyScaleImg.Source = autoGreyScaleImg.OriginalImage;
          autoGreyScaleImg.OpacityMask = null;
        }
      }
    }

    private static void OnAutoGreyScaleImageIsEnabledPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
    {
      var autoGreyScaleImg = source as AutoGrayableImage;
      if (autoGreyScaleImg != null && autoGreyScaleImg.Source != null)
      {
        var isEnable = Convert.ToBoolean(args.NewValue);
        if (!isEnable)
        {
          autoGreyScaleImg.Source = autoGreyScaleImg.GrayedImage;
          autoGreyScaleImg.OpacityMask = autoGreyScaleImg.GrayedOpacityMask;
        }
        else
        {
          autoGreyScaleImg.Source = autoGreyScaleImg.OriginalImage;
          autoGreyScaleImg.OpacityMask = null;
        }
      }
    }

  }

}