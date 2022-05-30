using ExCommonControlsCore.ExUtility;
using MenuContainerModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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

   
   
    /// <summary>
    /// ExTemplatedMainWindowControl2.xaml 的交互逻辑
    /// </summary>
    public partial class ExTemplatedMainWindowControl2 : Window
    {
        static ExTemplatedMainWindowControl2()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExTemplatedMainWindowControl2), new FrameworkPropertyMetadata(typeof(ExTemplatedMainWindowControl2)));
        }


        public ExTemplatedMainWindowControl2()
        {
            this.SourceInitialized += new EventHandler(SetCorrectWindowSize.MyMacClass_SourceInitialized);
            this.WindowStyle = WindowStyle.None;
            this.Loaded += ExTemplatedMainWindowControl2_Loaded;
            this.Closing += ExTemplatedMainWindowControl2_Closing;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }




        //only for x64 app
        private void ExTemplatedMainWindowControl2_Loaded(object sender, RoutedEventArgs e)
        {
            //获取窗体句柄
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            // 获得窗体的 样式
            long oldstyle = NativeMethods.GetWindowLong(hwnd, NativeMethods.GWL_STYLE);
            // 更改窗体的样式为无边框窗体
            //NativeMethods.SetWindowLong(hwnd, NativeMethods.GWL_STYLE, oldstyle & ~NativeMethods.WS_CAPTION);
            NativeMethods.SetWindowLong(hwnd, NativeMethods.GWL_STYLE, oldstyle & (~(0x00C00000L | 0x00C0000L)));
            //设置窗体为透明窗体
            NativeMethods.SetLayeredWindowAttributes(hwnd, 1 | 2 << 8 | 3 << 16, 0, NativeMethods.LWA_ALPHA);
        }



        private void ExTemplatedMainWindowControl2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ConfirmClose)
            {
                if (ExMessageBox.Show(null, "确认是否关闭窗体?", "提示信息", MessageBoxButton.YesNo, HintMessageType.Warn) != MessageBoxResult.Yes)
                    e.Cancel = true;
            }
        }
        public bool ConfirmClose
        {
            get { return (bool)GetValue(ConfirmCloseProperty); }
            set { SetValue(ConfirmCloseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConfirmClose.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConfirmCloseProperty =
            DependencyProperty.Register("ConfirmClose", typeof(bool), typeof(ExTemplatedMainWindowControl2), new PropertyMetadata(false));



        public double TitleFontSize
        {
            get { return (double)GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }


        public static readonly DependencyProperty TitleFontSizeProperty =
            DependencyProperty.Register("TitleFontSize", typeof(double), typeof(ExTemplatedMainWindowControl2), new PropertyMetadata(25d));



        public Brush TitleForeground
        {
            get { return (Brush)GetValue(TitleForegroundProperty); }
            set { SetValue(TitleForegroundProperty, value); }
        }

        public static readonly DependencyProperty TitleForegroundProperty =
            DependencyProperty.Register("TitleForeground", typeof(Brush), typeof(ExTemplatedMainWindowControl2), new PropertyMetadata(Brushes.Black));


        public Geometry WindowIcon
        {
            get { return (Geometry)GetValue(WindowIconProperty); }
            set { SetValue(WindowIconProperty, value); }
        }

        public static readonly DependencyProperty WindowIconProperty =
            DependencyProperty.Register("WindowIcon", typeof(Geometry), typeof(ExTemplatedMainWindowControl2), new PropertyMetadata(null));


        public double WindowIconSize
        {
            get { return (double)GetValue(WindowIconSizeProperty); }
            set { SetValue(WindowIconSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowIconSizeProperty =
            DependencyProperty.Register("WindowIconSize", typeof(double), typeof(ExTemplatedMainWindowControl2), new PropertyMetadata(44d));



        public Brush WindowIconBrush
        {
            get { return (Brush)GetValue(WindowIconBrushProperty); }
            set { SetValue(WindowIconBrushProperty, value); }
        }

        public static readonly DependencyProperty WindowIconBrushProperty =
            DependencyProperty.Register("WindowIconBrush", typeof(Brush), typeof(ExTemplatedMainWindowControl2), new PropertyMetadata(Brushes.White));



        public Brush WindowIconBackground
        {
            get { return (Brush)GetValue(WindowIconBackgroundProperty); }
            set { SetValue(WindowIconBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WindowIconBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowIconBackgroundProperty =
            DependencyProperty.Register("WindowIconBackground", typeof(Brush), typeof(ExTemplatedMainWindowControl2),
                new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 54, 66, 80))));






        public FrameworkElement Header
        {
            get { return (FrameworkElement)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(FrameworkElement), typeof(ExTemplatedMainWindowControl2), new PropertyMetadata(null));




        public FrameworkElement StatusBarContent
        {
            get { return (FrameworkElement)GetValue(StatusBarContentProperty); }
            set { SetValue(StatusBarContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StatusBarContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusBarContentProperty =
            DependencyProperty.Register("StatusBarContent", typeof(FrameworkElement), typeof(ExTemplatedMainWindowControl2), new PropertyMetadata(null));




        public FrameworkElement RightShowContent
        {
            get { return (FrameworkElement)GetValue(RightShowContentProperty); }
            set { SetValue(RightShowContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RightShowContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RightShowContentProperty =
            DependencyProperty.Register("RightShowContent", typeof(FrameworkElement), typeof(ExTemplatedMainWindowControl2), new PropertyMetadata(null));







        public ObservableCollection<MessageModel> HintMessages
        {
            get { return (ObservableCollection<MessageModel>)GetValue(HintMessagesProperty); }
            set { SetValue(HintMessagesProperty, value); }
        }

        public static readonly DependencyProperty HintMessagesProperty =
            DependencyProperty.Register("HintMessages", typeof(ObservableCollection<MessageModel>), typeof(ExTemplatedMainWindowControl2),
                new PropertyMetadata(new ObservableCollection<MessageModel>()));







        public ObservableCollection<MenuItemModel> Menus
        {
            get { return (ObservableCollection<MenuItemModel>)GetValue(MenusProperty); }
            set { SetValue(MenusProperty, value); }
        }

        public static readonly DependencyProperty MenusProperty =
            DependencyProperty.Register("Menus", typeof(ObservableCollection<MenuItemModel>), typeof(ExTemplatedMainWindowControl2),
                new PropertyMetadata(new ObservableCollection<MenuItemModel>()));








        private Border PART_TitleBar;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.PART_TitleBar = Template.FindName("PART_TitleBar", this) as Border;
            if (this.PART_TitleBar != null)
            {
                this.PART_TitleBar.MouseLeftButtonDown += (s, e) => { this.DragMove(); };
                this.PART_TitleBar.MouseLeftButtonDown += (s, e) =>
                {
                    if (e.ClickCount == 2)
                    {
                        this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                    }
                };
            }
        }
    }

}
