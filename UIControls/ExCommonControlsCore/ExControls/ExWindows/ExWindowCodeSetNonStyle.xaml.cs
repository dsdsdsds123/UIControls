using ExCommonControlsCore.ExUtility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;


namespace ExCommonControlsCore.ExControls.ExWindows
{
    /// <summary>
    /// WindowBase.xaml 的交互逻辑
    /// </summary>
    [TemplatePart(Name = "PART_TitleBar", Type = typeof(Border))]
    public partial class ExWindowCodeSetNonStyle : Window
    {
        DispatcherTimer timer;
        public ExWindowCodeSetNonStyle()
        {
            this.SourceInitialized += new EventHandler(SetCorrectWindowSize.MyMacClass_SourceInitialized);
            this.WindowStyle = WindowStyle.None;
            this.Loaded += ExWindowCodeSetNonStyle_Loaded;
            this.Closing += ExWindowCodeSetNonStyle_Closing;
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void ExWindowCodeSetNonStyle_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
            timer = null;
        }

        public string TimeString
        {
            get { return (string)GetValue(TimeStringProperty); }
            set { SetValue(TimeStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TimeString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeStringProperty =
            DependencyProperty.Register("TimeString", typeof(string), typeof(ExWindowCodeSetNonStyle), new PropertyMetadata(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));


        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void ExWindowCodeSetNonStyle_Loaded(object sender, RoutedEventArgs e)
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

        public double TitleFontSize
        {
            get { return (double)GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }


        public static readonly DependencyProperty TitleFontSizeProperty =
            DependencyProperty.Register("TitleFontSize", typeof(double), typeof(ExWindowCodeSetNonStyle), new PropertyMetadata(14d));



        public Brush TitleForeground
        {
            get { return (Brush)GetValue(TitleForegroundProperty); }
            set { SetValue(TitleForegroundProperty, value); }
        }

        public static readonly DependencyProperty TitleForegroundProperty =
            DependencyProperty.Register("TitleForeground", typeof(Brush), typeof(ExWindowCodeSetNonStyle), new PropertyMetadata(Brushes.White));


        public ImageSource WindowIcon
        {
            get { return (ImageSource)GetValue(WindowIconProperty); }
            set { SetValue(WindowIconProperty, value); }
        }

        public static readonly DependencyProperty WindowIconProperty =
            DependencyProperty.Register("WindowIcon", typeof(ImageSource), typeof(ExWindowCodeSetNonStyle), new PropertyMetadata(null));




        public double WindowIconSize
        {
            get { return (double)GetValue(WindowIconSizeProperty); }
            set { SetValue(WindowIconSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowIconSizeProperty =
            DependencyProperty.Register("WindowIconSize", typeof(double), typeof(ExWindowCodeSetNonStyle), new PropertyMetadata(35d));




        public FrameworkElement Header
        {
            get { return (FrameworkElement)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(FrameworkElement), typeof(ExWindowCodeSetNonStyle), new PropertyMetadata(null));


        private Border PART_TitleBar;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.PART_TitleBar = VisualHelper.FindVisualElement<Border>(this, "PART_TitleBar");
            if (this.PART_TitleBar != null)
            {
                this.PART_TitleBar.MouseLeftButtonDown += (s, e) => { this.DragMove(); };
                this.PART_TitleBar.MouseLeftButtonDown += (s, e) => {
                    if (e.ClickCount == 2)
                    {
                        this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                    }
                };
            }
        }
    }


    /// <summary>
    /// 设置无边框窗体
    /// </summary>
    public class NativeMethods
    {
        /// <summary>
        /// 带有外边框和标题的windows的样式
        /// </summary>
        public const long WS_CAPTION = 0X00C0000L;

        // public const long WS_BORDER = 0X0080000L;

        /// <summary>
        /// window 扩展样式 分层显示
        /// </summary>
        public const long WS_EX_LAYERED = 0x00080000L;

        /// <summary>
        /// 带有alpha的样式
        /// </summary>
        public const long LWA_ALPHA = 0x00000002L;

        /// <summary>
        /// 颜色设置
        /// </summary>
        public const long LWA_COLORKEY = 0x00000001L;

        /// <summary>
        /// window的基本样式
        /// </summary>
        public const int GWL_STYLE = -16;

        /// <summary>
        /// window的扩展样式
        /// </summary>
        public const int GWL_EXSTYLE = -20;

        /// <summary>
        /// 设置窗体的样式
        /// </summary>
        /// <param name="handle">操作窗体的句柄</param>
        /// <param name="oldStyle">进行设置窗体的样式类型.</param>
        /// <param name="newStyle">新样式</param>
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern void SetWindowLong(IntPtr handle, int oldStyle, long newStyle);

        /// <summary>
        /// 获取窗体指定的样式.
        /// </summary>
        /// <param name="handle">操作窗体的句柄</param>
        /// <param name="style">要进行返回的样式</param>
        /// <returns>当前window的样式</returns>
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern long GetWindowLong(IntPtr handle, int style);

        /// <summary>
        /// 设置窗体的工作区域.
        /// </summary>
        /// <param name="handle">操作窗体的句柄.</param>
        /// <param name="handleRegion">操作窗体区域的句柄.</param>
        /// <param name="regraw">if set to <c>true</c> [regraw].</param>
        /// <returns>返回值</returns>
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern int SetWindowRgn(IntPtr handle, IntPtr handleRegion, bool regraw);

        /// <summary>
        /// 创建带有圆角的区域.
        /// </summary>
        /// <param name="x1">左上角坐标的X值.</param>
        /// <param name="y1">左上角坐标的Y值.</param>
        /// <param name="x2">右下角坐标的X值.</param>
        /// <param name="y2">右下角坐标的Y值.</param>
        /// <param name="width">圆角椭圆的width.</param>
        /// <param name="height">圆角椭圆的height.</param>
        /// <returns>hRgn的句柄</returns>
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int width, int height);

        /// <summary>
        /// Sets the layered window attributes.
        /// </summary>
        /// <param name="handle">要进行操作的窗口句柄</param>
        /// <param name="colorKey">RGB的值</param>
        /// <param name="alpha">Alpha的值，透明度</param>
        /// <param name="flags">附带参数</param>
        /// <returns>true or false</returns>
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern bool SetLayeredWindowAttributes(IntPtr handle, ulong colorKey, byte alpha, long flags);
    }


    public class SetCorrectWindowSize
    {
        #region 这一部分用于最大化时不遮蔽任务栏
        /// <summary>
        /// 方法：设置最大化最小化
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lParam"></param>
        private static void WmGetMinMaxInfo(System.IntPtr hwnd, System.IntPtr lParam)
        {
            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            // Adjust the maximized size and position to fit the work area of the correct monitor
            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            System.IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

            if (monitor != System.IntPtr.Zero)
            {

                MONITORINFO monitorInfo = new MONITORINFO();
                GetMonitorInfo(monitor, monitorInfo);
                RECT rcWorkArea = monitorInfo.rcWork;
                RECT rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }

        /// <summary>
        /// POINT aka POINTAPI
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>
            /// x coordinate of point.
            /// </summary>
            public int x;
            /// <summary>
            /// y coordinate of point.
            /// </summary>
            public int y;

            /// <summary>
            /// Construct a point of coordinates (x,y).
            /// </summary>
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        };
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct RECT
        {
            /// <summary> Win32 </summary>
            public int left;
            /// <summary> Win32 </summary>
            public int top;
            /// <summary> Win32 </summary>
            public int right;
            /// <summary> Win32 </summary>
            public int bottom;

            /// <summary> Win32 </summary>
            public static readonly RECT Empty = new RECT();

            /// <summary> Win32 </summary>
            public int Width
            {
                get { return Math.Abs(right - left); }  // Abs needed for BIDI OS
            }
            /// <summary> Win32 </summary>
            public int Height
            {
                get { return bottom - top; }
            }

            /// <summary> Win32 </summary>
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            /// <summary> Win32 </summary>
            public RECT(RECT rcSrc)
            {
                this.left = rcSrc.left;
                this.top = rcSrc.top;
                this.right = rcSrc.right;
                this.bottom = rcSrc.bottom;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            /// <summary>
            /// </summary>            
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));

            /// <summary>
            /// </summary>            
            public RECT rcMonitor = new RECT();

            /// <summary>
            /// </summary>            
            public RECT rcWork = new RECT();

            /// <summary>
            /// </summary>            
            public int dwFlags = 0;
        }

        [DllImport("user32")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport("User32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);
        #endregion

        #region 重绘窗体

        private static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:/* WM_GETMINMAXINFO */
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
                default: break;
            }
            return (System.IntPtr)0;
        }


        private static HwndSource hs;
        /// <summary>
        /// 事件：实例化时调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void MyMacClass_SourceInitialized(object sender, EventArgs e)
        {
            hs = PresentationSource.FromVisual((Visual)sender) as HwndSource;
            hs.AddHook(new HwndSourceHook(WndProc));
        }

        #endregion


    }
}
