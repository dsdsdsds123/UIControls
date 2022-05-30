using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HandyControlPreview
{
    /// <summary>
    /// BarcodeViewItem.xaml 的交互逻辑
    /// </summary>
    public partial class BarcodeViewItem : UserControl
    {
        private BitmapImage map;


        public BitmapImage BitmapImage
        {
            get { return (BitmapImage)GetValue(BitmapImageProperty); }
            set { SetValue(BitmapImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BitmapImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BitmapImageProperty =
            DependencyProperty.Register("BitmapImage", typeof(BitmapImage), typeof(BarcodeViewItem), new PropertyMetadata(null, OnBitmapImageChanged));

        private static void OnBitmapImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var item = d as BarcodeViewItem;
            if (item != null)
            {
                item.map = e.NewValue as BitmapImage;
                item.Refresh();
            }
        }





        public List<Point> PolygonPoints
        {
            get { return (List<Point>)GetValue(PolygonPointsProperty); }
            set { SetValue(PolygonPointsProperty, value); }
        }
        public static readonly DependencyProperty PolygonPointsProperty =
            DependencyProperty.Register("PolygonPoints", typeof(List<Point>), typeof(BarcodeViewItem), new PropertyMetadata(new List<Point>(), (d, e) =>
             {
                 var item = d as BarcodeViewItem;
                 if (item != null)
                 {
                     item.Refresh();
                 }
             }));



















        private void Refresh()
        {
            List<List<Point>> pointss = new List<List<Point>>();
            List<Point> p1 = new List<Point>();
            p1.Add(new Point() { X = 960, Y = 10 });
            p1.Add(new Point() { X = 1910, Y = 10 });
            p1.Add(new Point() { X = 1910, Y = 70 });
            p1.Add(new Point() { X = 960, Y = 70 });
            pointss.Add(p1);
            DrawPolygon2(pointss, canvas);
        }



        public BarcodeViewItem()
        {
            InitializeComponent();

            this.SizeChanged += BarcodeViewItem_SizeChanged;
        }

        private void BarcodeViewItem_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Refresh();
        }

        private void DrawPolygon2(List<List<Point>> points, Canvas parent)
        {
            if (BitmapImage == null) return;
            Console.WriteLine($"{parent.Width},{parent.Height},---{parent.RenderSize}--{parent.ActualWidth},{parent.ActualHeight}");
            //Console.WriteLine($"{img.Width},{img.Height},---{img.RenderSize}--{img.ActualWidth},{img.ActualHeight}");
            var remove = parent.Children;
            List<UIElement> toremove = new List<UIElement>();
            foreach (var item in remove)
            {
                if (item is Polygon po) toremove.Add(po);
            }
            foreach (var item in toremove)
            {
                parent.Children.Remove(item);
            }

            foreach (List<Point> poss in points)
            {
                //List<Point> resultPoints = poss.Select(c => new Point()
                //{
                //    X = c.X * parent.RenderSize.Width / BitmapImage.PixelWidth,
                //    Y = c.Y * parent.RenderSize.Height / BitmapImage.PixelHeight
                //}).ToList();

                List<Point> resultPoints = poss.Select(c => GetOriginCoordinate(c)).ToList();

                //foreach (var item in resultPoints)
                //{
                //    Console.WriteLine(item);
                //}

                Polygon py = new Polygon();
                py.Points = new PointCollection();
                foreach (var p in resultPoints)
                {
                    py.Points.Add(p);
                }
                py.Stroke = Brushes.Yellow;
                py.Fill = Brushes.Transparent;

                parent.Children.Add(py);

            }
        }

        public Point GetOriginCoordinate(Point pointInPicture)
        {
            if (map == null) return new Point();
            if (map != null)
            {
                double originalWidth = map.Width;
                double originalHeight = map.Height;


                double currentWidth = 0;
                double currentHeight = 0;

                //先计算图片的尺寸
                if (canvas.RenderSize.Width / canvas.RenderSize.Height > map.Width / map.Height)
                {
                    currentWidth = map.Width * canvas.RenderSize.Height / map.Height;
                    currentHeight = canvas.RenderSize.Height;
                }
                else
                {
                    currentHeight = map.Height * canvas.RenderSize.Width / map.Width;
                    currentWidth = canvas.RenderSize.Width;
                }

                double rate = (double)currentHeight / (double)originalHeight;

                double black_left_width = (currentWidth == canvas.RenderSize.Width) ? 0 : (canvas.RenderSize.Width - currentWidth) / 2;
                double black_top_height = (currentHeight == canvas.RenderSize.Height) ? 0 : (canvas.RenderSize.Height - currentHeight) / 2;

                double resultX = pointInPicture.X * rate + black_left_width;
                double resultY = pointInPicture.Y * rate + black_top_height;

                return new Point(Convert.ToInt32(resultX), Convert.ToInt32(resultY));
            }
            return new Point();

        }


        public Point GetOriginCoordinate33(Point pointInPicture, Canvas parent)
        {
            ImageBrush image = parent.Background as ImageBrush;
            if (image.ImageSource == null) return new Point();

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

                double resultX = pointInPicture.X * rate + black_left_width;
                double resultY = pointInPicture.Y * rate + black_top_height;

                return new Point(Convert.ToInt32(resultX), Convert.ToInt32(resultY));
            }
            return new Point();

        }
    }
}
