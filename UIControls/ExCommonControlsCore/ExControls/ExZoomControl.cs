using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;


namespace ExCommonControlsCore.ExControls
{
    /// <summary>
    /// 用于对内容进行缩放的控件，支持单击平移和滚轮缩放
    /// </summary>
    [ContentProperty(nameof(ZoomContent))]
    [DefaultProperty(nameof(ZoomContent))]
    public class ExZoomControl : Label
    {
        //缩放和平移变换
        private ScaleTransform scaleTransform = new ScaleTransform();
        private TranslateTransform translateTransform = new TranslateTransform();
        private TransformGroup transformGroup = new TransformGroup();
        //存放被缩放内容的容器
        private ContentPresenter ContentPresenter = new ContentPresenter();

        #region ZoomContent依赖属性
        /// <summary>
        /// 要被缩放的内容
        /// </summary>
        public UIElement ZoomContent
        {
            get { return (UIElement)GetValue(ZoomContentProperty); }
            set { SetValue(ZoomContentProperty, value); }
        }

        public static readonly DependencyProperty ZoomContentProperty =
            DependencyProperty.Register("ZoomContent", typeof(Visual), typeof(ExZoomControl), new PropertyMetadata(null, ZoomContentChanged));

        public static void ZoomContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ExZoomControl)
                (d as ExZoomControl).SetZoomContent(e.OldValue as UIElement, e.NewValue as UIElement);
        }

        private void SetZoomContent(object oldValue, object newValue)
        {
            if (newValue != null && newValue is Control newControl)
                newControl.SizeChanged += ContentControl_SizeChanged;
            if (oldValue != null && oldValue is Control oldControl)
                oldControl.SizeChanged -= ContentControl_SizeChanged;

            ContentPresenter.Content = newValue;
            SetControlMiddle();
        }

        private void ContentControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetControlMiddle();
        }
        #endregion

        #region Scale依赖属性
        /// <summary>
        /// 缩放比例
        /// </summary>
        public double Scale
        {
            get { return (double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        public static readonly DependencyProperty ScaleProperty =
            DependencyProperty.Register("Scale", typeof(double), typeof(ExZoomControl), new PropertyMetadata(1.0, ScaleChanged));

        public static void ScaleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ExZoomControl)
                (d as ExZoomControl).SetScale((double)e.NewValue);
        }

        private void SetScale(double value)
        {
            scaleTransform.ScaleX = value;
            scaleTransform.ScaleY = value;
        }
        #endregion

        public ExZoomControl()
        {
            //属性初始化
            HorizontalContentAlignment = HorizontalAlignment.Stretch;
            VerticalContentAlignment = VerticalAlignment.Stretch;
            Focusable = false;
            ClipToBounds = true;
            Padding = new Thickness(0);
            Content = ContentPresenter;

            //设置变换
            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(translateTransform);
            ContentPresenter.RenderTransform = transformGroup;

            //监听鼠标事件
            MouseDoubleClick += ContentControl_MouseDoubleClick;
            MouseLeftButtonDown += ContentControl_MouseLeftButtonDown;
            MouseLeftButtonUp += ContentControl_MouseLeftButtonUp;
            PreviewMouseWheel += ContentControl_MouseWheel;
            MouseMove += ContentControl_MouseMove;

            //监听其他事件
            //SizeChanged += ZoomControl_SizeChanged;
            Loaded += ZoomControl_Loaded;
        }


        //当控件加载时使内容填充并居中
        private void ZoomControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 设置控件居中
        /// </summary>
        public void SetControlMiddle()
        {
            Fill();
            AlignToCenter();
        }

        /// <summary>
        /// 1:1缩放
        /// </summary>
        public void OneToOne()
        {
            Scale = 1;
        }

        /// <summary>
        /// 使内容填充此缩放控件，会忽略内容四周的空白区域
        /// </summary>
        public void Fill()
        {
            if (ZoomContent == null)
                return;
            Size size = RenderSize;
            Rect rect = VisualTreeHelper.GetDescendantBounds(ZoomContent);
            if (rect != Rect.Empty)
            {
                double a = size.Width / rect.Width;
                double b = size.Height / rect.Height;
                Scale = Math.Min(a, b);
            }
        }

        /// <summary>
        /// 使内容居中，会忽略内容四周的空白区域
        /// </summary>
        public void AlignToCenter()
        {
            if (ZoomContent == null)
                return;

            Size size = RenderSize;
            Rect rect = VisualTreeHelper.GetDescendantBounds(ZoomContent);
            if (rect != Rect.Empty)
            {
                translateTransform.X = (size.Width - rect.Width * Scale) / 2 - rect.Left * Scale;
                translateTransform.Y = (size.Height - rect.Height * Scale) / 2 - rect.Top * Scale;
            }
        }

        #region 图像缩放，移动
        //缩放比例变化的速度，鼠标滚轮每滚动一格，内容将放大/缩小scaleSpeed倍
        public static double scaleSpeed = 1.1;

        //鼠标是否按下
        private bool mouseDown;
        //鼠标按下时的位置/上一次移动的位置
        private Point mouseDownPosition;
        private void ContentControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CaptureMouse();
            mouseDownPosition = e.GetPosition(this);
            mouseDown = true;
        }

        /// <summary>
        /// 右键双击让图形居中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContentControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetControlMiddle();
        }

        private void ContentControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ReleaseMouseCapture();
            mouseDown = false;
        }

        //鼠标移动，在鼠标左键按下时用于平移内容
        private void ContentControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && e.LeftButton == MouseButtonState.Pressed)
            {
                var position = e.GetPosition(this);
                translateTransform.X -= mouseDownPosition.X - position.X;
                translateTransform.Y -= mouseDownPosition.Y - position.Y;
                mouseDownPosition = position;
            }
        }

        //鼠标滚轮滚动，调整缩放比例
        private void ContentControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var point = e.GetPosition(this);
            var pointToContent = transformGroup.Inverse.Transform(point);

            if (e.Delta > 0)
                Scale *= scaleSpeed;
            else
                Scale /= scaleSpeed;

            translateTransform.X = -1 * ((pointToContent.X * Scale) - point.X);
            translateTransform.Y = -1 * ((pointToContent.Y * Scale) - point.Y);
        }

        #endregion
    }
}
