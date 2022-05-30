using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExCommonControlsCore.ExControls
{
    /// <summary>
    /// Interaction logic for ExImageShow.xaml
    /// </summary>
    public partial class ExImageShow : UserControl
    {
        public Brush LineBrush
        {
            get { return (Brush)GetValue(LineBrushProperty); }
            set { SetValue(LineBrushProperty, value); }
        }

        public static readonly DependencyProperty LineBrushProperty =
            DependencyProperty.Register("LineBrush", typeof(Brush), typeof(ExImageShow), new PropertyMetadata(Brushes.Red));



        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ExImageShow), new PropertyMetadata(null));




        public double LineThickness
        {
            get { return (double)GetValue(LineThicknessProperty); }
            set { SetValue(LineThicknessProperty, value); }
        }

        public static readonly DependencyProperty LineThicknessProperty =
            DependencyProperty.Register("LineThickness", typeof(double), typeof(ExImageShow), new PropertyMetadata(1d));


        public Point START_POINT_IN_ORIGINIMAGE
        {
            get
            {
                return (Point)GetValue(start_point_in_originimageProperty);
            }
            set
            {
                SetValue(start_point_in_originimageProperty, value);
            }
        }
        public static readonly DependencyProperty start_point_in_originimageProperty = DependencyProperty.Register("START_POINT_IN_ORIGINIMAGE", typeof(Point), typeof(ExImageShow), new PropertyMetadata(new Point()));


        public Point END_POINT_IN_ORIGINIMAGE
        {
            get
            {
                return (Point)GetValue(end_point_in_originimageroperty);
            }
            set
            {
                SetValue(end_point_in_originimageroperty, value);
            }
        }
        public static readonly DependencyProperty end_point_in_originimageroperty = DependencyProperty.Register("END_POINT_IN_ORIGINIMAGE", typeof(Point), typeof(ExImageShow), new PropertyMetadata(new Point()));


        /// <summary>
        /// 绘制矩形标识
        /// </summary>
        public bool DrawRect
        {
            get
            {
                return (bool)GetValue(DrawRectProperty);
            }

            set
            {
                SetValue(DrawRectProperty, value);
            }
        }
        public static readonly DependencyProperty DrawRectProperty = DependencyProperty.Register("DrawRect", typeof(bool), typeof(ExImageShow), new PropertyMetadata(false));

        /// <summary>
        /// 绘制直线标志
        /// </summary>
        public bool DrawLine
        {
            get
            {
                return (bool)GetValue(DrawLineProperty);
            }

            set
            {
                SetValue(DrawLineProperty, value);
            }
        }
        public static readonly DependencyProperty DrawLineProperty = DependencyProperty.Register("DrawLine", typeof(bool), typeof(ExImageShow), new PropertyMetadata(false));

        //是否开启绘画标识
        public bool EnableDrawing
        {
            get
            {
                return (bool)GetValue(EnableDrawingProperty);
            }
            set
            {
                SetValue(EnableDrawingProperty, value);
            }
        }
        public static readonly DependencyProperty EnableDrawingProperty = DependencyProperty.Register("EnableDrawing", typeof(bool), typeof(ExImageShow), new PropertyMetadata(false));


        private Canvas canvas = default;
        public override void OnApplyTemplate()
        {
            canvas = Template.FindName("root", this) as Canvas;
            canvas.MouseMove += canvas_MouseMove;
            canvas.MouseUp += Canvas_MouseLeftButtonUp;
            canvas.MouseDown += Canvas_MouseLeftButtonDown;
        }

        public ExImageShow()
        {
            PreviewRect = new Rectangle() { Stroke = LineBrush, StrokeThickness = LineThickness };
            PreviewLine = new Line() { Stroke = LineBrush, StrokeThickness = LineThickness };
        }



        private bool moveDraw = false;//用来当鼠标按下移动的时候才绘图
        //用于绘制矩形或直线的起点终点 坐标
        private Point startPoint = new Point();
        private Point endPoint = new Point();





        private Rectangle PreviewRect;
        private Line PreviewLine;



        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (EnableDrawing)
            {
                startPoint = e.GetPosition(canvas);
                START_POINT_IN_ORIGINIMAGE = GetOriginCoordinate(startPoint);
                moveDraw = true;
                if (EnableDrawing)
                {
                    this.canvas.Children.Clear();
                    if (DrawRect && DrawLine == false)
                    {
                        PreviewRect = new Rectangle() { Stroke = LineBrush, StrokeThickness = LineThickness };
                        Canvas.SetLeft(PreviewRect, startPoint.X);
                        Canvas.SetTop(PreviewRect, startPoint.Y);
                        canvas.Children.Add(PreviewRect);
                    }
                    else if (DrawRect == false && DrawLine)
                    {
                        PreviewLine = new Line() { Stroke = LineBrush, StrokeThickness = LineThickness };
                        PreviewLine.X1 = startPoint.X;
                        PreviewLine.Y1 = startPoint.Y;
                        canvas.Children.Add(PreviewLine);
                    }
                }
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (EnableDrawing)
            {
                endPoint = e.GetPosition(this);
                END_POINT_IN_ORIGINIMAGE = GetOriginCoordinate(endPoint);
                moveDraw = false;
                if (EnableDrawing)
                {
                    if (DrawLine && DrawRect)
                    {
                        Console.WriteLine("不能同时选择绘制直线和矩形");
                        return;
                    }
                    if (DrawRect && !DrawLine)
                    {
                        if (startPoint.X <= 0 || endPoint.X <= 0 || startPoint.X > endPoint.X || startPoint.Y > endPoint.Y)
                        {
                            return;
                        }
                        PreviewRect.Width = endPoint.X - startPoint.X;
                        PreviewRect.Height = endPoint.Y - startPoint.Y;
                    }
                    else if (!DrawRect && DrawLine)
                    {
                        if (startPoint.X <= 0 || startPoint.X > endPoint.X)
                        {
                            return;
                        }
                        PreviewLine.X2 = endPoint.X;
                        PreviewLine.Y2 = endPoint.Y;
                    }
                }

                Console.WriteLine($"起点坐标:{START_POINT_IN_ORIGINIMAGE}");
                Console.WriteLine($"终点坐标:{END_POINT_IN_ORIGINIMAGE}");

                //Debug.WriteLine($"起点坐标:{START_POINT_IN_ORIGINIMAGE}");
                //Debug.WriteLine($"终点坐标:{END_POINT_IN_ORIGINIMAGE}");
                //MessageBox.Show($"{START_POINT_IN_ORIGINIMAGE}--->{END_POINT_IN_ORIGINIMAGE}");
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (EnableDrawing && moveDraw)
            {
                endPoint = e.GetPosition(canvas);

                END_POINT_IN_ORIGINIMAGE = GetOriginCoordinate(endPoint);

                if (EnableDrawing)
                {
                    if (moveDraw)
                    {
                        if (DrawLine && DrawRect)
                        {
                            Console.WriteLine("不能同时选择绘制直线和矩形");
                            return;
                        }
                        if (DrawRect && !DrawLine)
                        {
                            if (startPoint.X <= 0 || endPoint.X <= 0 || startPoint.X > endPoint.X || startPoint.Y > endPoint.Y)
                            {
                                return;
                            }
                            PreviewRect.Width = endPoint.X - startPoint.X;
                            PreviewRect.Height = endPoint.Y - startPoint.Y;
                        }
                        else if (!DrawRect && DrawLine)
                        {
                            if (startPoint.X <= 0 || startPoint.X > endPoint.X)
                            {
                                return;
                            }
                            PreviewLine.X2 = endPoint.X;
                            PreviewLine.Y2 = endPoint.Y;
                        }
                    }
                }
            }

        }



        /// <summary>
        /// 通过在pictureBox中的点来获取在原始图像中的点坐标
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="pointInPicture"></param>
        /// <returns></returns>
        public Point GetOriginCoordinate(Point pointInPicture)
        {
            ImageBrush image = canvas.Background as ImageBrush;
            if (image.ImageSource == null) return new Point();
            if (image != null)
            {
                double originalWidth = image.ImageSource.Width;
                double originalHeight = image.ImageSource.Height;


                double currentWidth = 0;
                double currentHeight = 0;

                //先计算图片的尺寸
                if (canvas.RenderSize.Width / canvas.RenderSize.Height > image.ImageSource.Width / image.ImageSource.Height)
                {
                    currentWidth = image.ImageSource.Width * canvas.RenderSize.Height / image.ImageSource.Height;
                    currentHeight = canvas.RenderSize.Height;
                }
                else
                {
                    currentHeight = image.ImageSource.Height * canvas.RenderSize.Width / image.ImageSource.Width;
                    currentWidth = canvas.RenderSize.Width;
                }

                double rate = (double)currentHeight / (double)originalHeight;

                double black_left_width = (currentWidth == canvas.RenderSize.Width) ? 0 : (canvas.RenderSize.Width - currentWidth) / 2;
                double black_top_height = (currentHeight == canvas.RenderSize.Height) ? 0 : (canvas.RenderSize.Height - currentHeight) / 2;

                double zoom_x = pointInPicture.X - black_left_width;
                double zoom_y = pointInPicture.Y - black_top_height;

                double original_x = (double)zoom_x / rate;
                double original_y = (double)zoom_y / rate;
                return new Point(Convert.ToInt32(original_x), Convert.ToInt32(original_y));
            }
            return new Point();

        }


    }
}
