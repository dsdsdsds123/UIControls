using ExCommonControlsCore.ExUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;


namespace ExCommonControlsCore.ExControls.ExWindows
{
    public enum AnimationType
    {
        LoadedBounce,
        LoadedRotatePositive,
        LoadedRotateNegative
    }

    [TemplatePart(Name = "PART_Btn_Close", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Btn_Minimized", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Btn_Maximized", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Btn_Restore", Type = typeof(Button))]
    [TemplatePart(Name = "PART_TitleBar", Type = typeof(Grid))]
    [TemplatePart(Name = "PART_Popup_Menu", Type = typeof(Popup))]
    public class ExWindow : Window
    {
        static ExWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExWindow), new FrameworkPropertyMetadata(typeof(ExWindow)));
        }

        #region 私有属性
        private Button PART_Btn_Close; //关闭按钮
        private Button PART_Btn_Minimized; //最小化按钮
        private Button PART_Btn_Maximized; //最大化按钮
        private Button PART_Btn_Restore; //还原按钮

        private Grid PART_TitleBar;
        private Popup PART_Popup_Menu;

        /// <summary>
        /// 保存上一次窗体的宽度
        /// </summary>
        private double restore_window_width;
        /// <summary>
        /// 保存上一次窗体的高度
        /// </summary>
        private double restore_window_height;
        /// <summary>
        /// 保存上一次窗体距离屏幕左边位置
        /// </summary>
        private double resotre_left;
        /// <summary>
        /// 保存上一次窗体距离屏幕顶部位置
        /// </summary>
        private double resotre_top;
        /// <summary>
        /// 鼠标点击次数，用于判断鼠标双击
        /// </summary>
        private int mouseClickCount;
        /// <summary>
        /// 当前窗体是否处于最大化状态，用于窗体最大化与原大小间切换
        /// </summary>
        private bool mIsMaximized = false;
        #endregion

        #region 依赖属性





        public bool IsUseAnimation
        {
            get { return (bool)GetValue(IsUseAnimationProperty); }
            set { SetValue(IsUseAnimationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsUseAnimation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsUseAnimationProperty =
            DependencyProperty.Register("IsUseAnimation", typeof(bool), typeof(ExWindow), new PropertyMetadata(true));



        public double TitleFontSize
        {
            get { return (double)GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleFontSizeProperty =
            DependencyProperty.Register("TitleFontSize", typeof(double), typeof(ExWindow), new PropertyMetadata(13d));



        public double Iconsize
        {
            get { return (double)GetValue(IconsizeProperty); }
            set { SetValue(IconsizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Iconsize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconsizeProperty =
            DependencyProperty.Register("Iconsize", typeof(double), typeof(ExWindow), new PropertyMetadata(14d));




        public Grid HeaderContent
        {
            get { return (Grid)GetValue(HeaderContentProperty); }
            set { SetValue(HeaderContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderContentProperty =
            DependencyProperty.Register("HeaderContent", typeof(Grid), typeof(ExWindow));



        public static readonly DependencyProperty MaximizeBoxProperty = DependencyProperty.Register("MaximizeBox"
            , typeof(bool), typeof(ExWindow), new PropertyMetadata(true));
        /// <summary>
        /// 是否显示最大化按钮
        /// </summary>
        public bool MaximizeBox
        {
            get { return (bool)GetValue(MaximizeBoxProperty); }
            set { SetValue(MaximizeBoxProperty, value); }
        }

        public static readonly DependencyProperty MinimizeBoxProperty = DependencyProperty.Register("MinimizeBox"
            , typeof(bool), typeof(ExWindow), new PropertyMetadata(true));
        /// <summary>
        /// 是否显示最小化按钮
        /// </summary>
        public bool MinimizeBox
        {
            get { return (bool)GetValue(MinimizeBoxProperty); }
            set { SetValue(MinimizeBoxProperty, value); }
        }

        public static readonly DependencyProperty CloseBoxProperty = DependencyProperty.Register("CloseBox"
            , typeof(bool), typeof(ExWindow), new PropertyMetadata(true));
        /// <summary>
        /// 是否显示关闭按钮
        /// </summary>
        public bool CloseBox
        {
            get { return (bool)GetValue(CloseBoxProperty); }
            set { SetValue(CloseBoxProperty, value); }
        }






        public static readonly DependencyProperty CaptionHeightProperty = DependencyProperty.Register("CaptionHeight"
            , typeof(double), typeof(ExWindow), new PropertyMetadata(30d));
        /// <summary>
        /// 标题栏高度
        /// </summary>
        public double CaptionHeight
        {
            get { return (double)GetValue(CaptionHeightProperty); }
            set { SetValue(CaptionHeightProperty, value); }
        }

        public static readonly DependencyProperty CanMoveWindowProperty = DependencyProperty.Register("CanMoveWindow"
            , typeof(bool), typeof(ExWindow), new PropertyMetadata(true));
        /// <summary>
        /// 窗体能否被拖动
        /// </summary>
        public bool CanMoveWindow
        {
            get { return (bool)GetValue(CanMoveWindowProperty); }
            set { SetValue(CanMoveWindowProperty, value); }
        }

        public static readonly DependencyProperty TitleBackgroundProperty = DependencyProperty.Register("TitleBackground"
            , typeof(Brush), typeof(ExWindow));
        /// <summary>
        /// 窗口标题栏背景色
        /// </summary>
        public Brush TitleBackground
        {
            get { return (Brush)GetValue(TitleBackgroundProperty); }
            set { SetValue(TitleBackgroundProperty, value); }
        }







        public AnimationType AnimationLoadType
        {
            get { return (AnimationType)GetValue(AnimationLoadTypeProperty); }
            set { SetValue(AnimationLoadTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AnimationLoadType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnimationLoadTypeProperty =
            DependencyProperty.Register("AnimationLoadType", typeof(AnimationType), typeof(ExWindow), new PropertyMetadata(AnimationType.LoadedRotateNegative));




        #endregion

        #region 事件定义

        #endregion

        #region 构造函数
        public ExWindow() : base()
        {
            this.AllowsTransparency = true;
            this.WindowStyle = WindowStyle.None;
            this.Loaded += ExWindow_Loaded;
            this.Closing += ExWindow_Closing;
        }

        private void ExWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IsUseAnimation)
                VisualStateManager.GoToState(this, "Closing", true);
        }

        private void ExWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.IsUseAnimation)
            {
                switch (this.AnimationLoadType)
                {
                    case AnimationType.LoadedBounce:
                        VisualStateManager.GoToState(this, nameof(AnimationType.LoadedBounce), true);
                        break;
                    case AnimationType.LoadedRotatePositive:
                        VisualStateManager.GoToState(this, nameof(AnimationType.LoadedRotatePositive), true);
                        break;
                    case AnimationType.LoadedRotateNegative:
                        VisualStateManager.GoToState(this, nameof(AnimationType.LoadedRotateNegative), true);
                        break;
                }
            }

            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    this.WindowState = WindowState.Normal;
                    this.PART_Btn_Maximized.Visibility = Visibility.Collapsed;
                    this.SetWindowMaximized();
                    break;
                case WindowState.Normal:
                    this.PART_Btn_Restore.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }


        }
        #endregion

        #region 事件处理

        #region 窗体标题栏双击最大化、还原
        private void GridTitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //不允许最大化的时候，双击标题栏自然也不允许将窗体最大化
            if (!this.MaximizeBox) return;

            mouseClickCount += 1;
            DispatcherTimer timer = new DispatcherTimer();
            //设置鼠标左键点击间隔为0.3秒，超过0.3秒将mouseClickCount重置
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timer.Tick += (s, e1) => { timer.IsEnabled = false; mouseClickCount = 0; };
            timer.IsEnabled = true;
            if (mouseClickCount % 2 == 0)
            {
                timer.IsEnabled = false;
                mouseClickCount = 0;

                //判断当前窗体状态，如果是最大化，则双击之后还原窗体大小，否则将窗体最大化
                if (this.mIsMaximized)
                {
                    this.SetWindowSizeRestore();
                }
                else
                {
                    this.SetWindowMaximized();
                }
            }
        }
        #endregion

        /// <summary>
        /// 还原窗体大小按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PART_Btn_Restore_Click(object sender, RoutedEventArgs e)
        {
            SetWindowSizeRestore();
        }

        /// <summary>
        /// 窗口最大化按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PART_Btn_Maximized_Click(object sender, RoutedEventArgs e)
        {
            SetWindowMaximized();
        }



        public bool ShowConfirm
        {
            get { return (bool)GetValue(ShowConfirmProperty); }
            set { SetValue(ShowConfirmProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowConfirm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowConfirmProperty =
            DependencyProperty.Register("ShowConfirm", typeof(bool), typeof(ExWindow), new PropertyMetadata(false));


        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            if (ShowConfirm)
            {
                if (ExMessageBox.Show(this, "确认是否关闭?", "提示", MessageBoxButton.YesNo, HintMessageType.Info) == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }


        #endregion

        #region 设置窗口大小
        /// <summary>
        /// 设置窗口最大化
        /// </summary>
        private void SetWindowMaximized()
        {
            if (VisualTreeHelper.GetChildrenCount(this) > 0)
            {
                //最大化窗体前保留窗体的原始大小与位置
                this.restore_window_width = this.Width;
                this.restore_window_height = this.Height;
                this.resotre_left = this.Left;
                this.resotre_top = this.Top;

                Grid a = (Grid)VisualTreeHelper.GetChild(this, 0);
                //设置Grid的Margin为0，用于去除窗体阴影
                a.Margin = new Thickness(0, 0, 0, 0);
                Border b = (Border)VisualTreeHelper.GetChild(a, 0);
                //隐藏阴影
                b.Visibility = Visibility.Collapsed;
                this.Left = 0;
                this.Top = 0;
                Rect rc = SystemParameters.WorkArea;//获取工作区大小
                this.Width = rc.Width;
                this.Height = rc.Height;

                //this.Animation(this.Width, this.Height, rc.Width, rc.Height);

                this.mIsMaximized = true;
                this.PART_Btn_Maximized.Visibility = Visibility.Hidden;
                this.PART_Btn_Restore.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// 还原窗体大小
        /// </summary>
        private void SetWindowSizeRestore()
        {
            if (VisualTreeHelper.GetChildrenCount(this) > 0)
            {
                Grid a = (Grid)VisualTreeHelper.GetChild(this, 0);
                //设置Grid的Margin，用于显示窗体阴影
                a.Margin = new Thickness(20, 20, 20, 20);
                Border b = (Border)VisualTreeHelper.GetChild(a, 0);
                //显示阴影
                b.Visibility = Visibility.Visible;
                this.Left = this.resotre_left;
                this.Top = this.resotre_top;
                this.Width = this.restore_window_width;
                this.Height = this.restore_window_height;

                this.mIsMaximized = false;
                this.PART_Btn_Restore.Visibility = Visibility.Hidden;
                this.PART_Btn_Maximized.Visibility = Visibility.Visible;
            }
        }
        #endregion


        #region 方法重写
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.PART_Btn_Close = VisualHelper.FindVisualElement<Button>(this, "PART_Btn_Close");
            this.PART_Btn_Minimized = VisualHelper.FindVisualElement<Button>(this, "PART_Btn_Minimized");
            this.PART_Btn_Maximized = VisualHelper.FindVisualElement<Button>(this, "PART_Btn_Maximized");
            this.PART_Btn_Restore = VisualHelper.FindVisualElement<Button>(this, "PART_Btn_Restore");
            this.PART_TitleBar = VisualHelper.FindVisualElement<Grid>(this, "PART_TitleBar");
            //this.PART_Btn_More = VisualHelper.FindVisualElement<Button>(this, "PART_Btn_More");
            this.PART_Popup_Menu = VisualHelper.FindVisualElement<Popup>(this, "PART_Popup_Menu");


            if (this.PART_Btn_Close != null)
            {
                this.PART_Btn_Close.Click += Btn_close_Click;
            }

            if (this.PART_Btn_Maximized != null)
            {
                this.PART_Btn_Maximized.Click += PART_Btn_Maximized_Click;
            }

            if (this.PART_Btn_Restore != null)
            {
                this.PART_Btn_Restore.Click += PART_Btn_Restore_Click;
            }

            if (!this.MaximizeBox && !this.MinimizeBox && !this.CloseBox && string.IsNullOrEmpty(this.Title.Trim()))
            {
                this.PART_TitleBar.Visibility = Visibility.Collapsed;
            }


            if (this.PART_TitleBar != null)
            {
                this.PART_TitleBar.MouseLeftButtonDown += GridTitleBar_MouseLeftButtonDown;
            }
        }

        /// <summary>
        /// 拖动窗体
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (!this.CanMoveWindow) return;

            if (this.mIsMaximized) return;

            base.OnMouseLeftButtonDown(e);

            if (PART_TitleBar != null)
            {
                // 获取鼠标相对标题栏位置  
                Point position = e.GetPosition(PART_TitleBar);

                // 如果鼠标位置在标题栏内，允许拖动  
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    if (position.X >= 0 && position.X < PART_TitleBar.ActualWidth && position.Y >= 0
                        && position.Y < PART_TitleBar.ActualHeight)
                    {
                        this.DragMove();
                    }
                }
            }
        }

        #endregion


    }
}
