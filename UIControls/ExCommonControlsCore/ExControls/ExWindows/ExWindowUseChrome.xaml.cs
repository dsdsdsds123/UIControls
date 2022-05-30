using ExCommonControlsCore.ExUtility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;


namespace ExCommonControlsCore.ExControls.ExWindows
{
    public class WindowStateNormalToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WindowState state = (WindowState)value;

            return state == WindowState.Normal ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class WindowStateNormalToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WindowState state = (WindowState)value;

            return state == WindowState.Normal ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// WindowBase.xaml 的交互逻辑
    /// </summary>
    public partial class ExWindowUseChrome : Window
    {
        public ExWindowUseChrome()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExWindowUseChrome), new FrameworkPropertyMetadata(typeof(ExWindowUseChrome)));
        }


        public double TitleFontSize
        {
            get { return (double)GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }


        public static readonly DependencyProperty TitleFontSizeProperty =
            DependencyProperty.Register("TitleFontSize", typeof(double), typeof(ExWindowUseChrome), new PropertyMetadata(14d));



        public Brush TitleForeground
        {
            get { return (Brush)GetValue(TitleForegroundProperty); }
            set { SetValue(TitleForegroundProperty, value); }
        }

        public static readonly DependencyProperty TitleForegroundProperty =
            DependencyProperty.Register("TitleForeground", typeof(Brush), typeof(ExWindowUseChrome), new PropertyMetadata(Brushes.White));


        public ImageSource WindowIcon
        {
            get { return (ImageSource)GetValue(WindowIconProperty); }
            set { SetValue(WindowIconProperty, value); }
        }

        public static readonly DependencyProperty WindowIconProperty =
            DependencyProperty.Register("WindowIcon", typeof(ImageSource), typeof(ExWindowUseChrome), new PropertyMetadata(null));




        public double WindowIconSize
        {
            get { return (double)GetValue(WindowIconSizeProperty); }
            set { SetValue(WindowIconSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowIconSizeProperty =
            DependencyProperty.Register("WindowIconSize", typeof(double), typeof(ExWindowUseChrome), new PropertyMetadata(35d));




        public FrameworkElement Header
        {
            get { return (FrameworkElement)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(FrameworkElement), typeof(ExWindowUseChrome), new PropertyMetadata(null));



    }
}
