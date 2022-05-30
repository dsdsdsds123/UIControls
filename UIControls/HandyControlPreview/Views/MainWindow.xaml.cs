using HandyControlPreview.ViewModels;
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

namespace HandyControlPreview.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private BitmapImage mi;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.MainViewModel();
            //mi = new BitmapImage(new Uri(@"C:\Users\Administrator\Desktop\新建文件夹 (3)\default.bmp", UriKind.RelativeOrAbsolute));
            //ib.ImageSource = mi;

            //List<List<Point>> pointss = new List<List<Point>>();
            //List<Point> p1 = new List<Point>();
            //p1.Add(new Point() { X = 0, Y = 0 });
            //p1.Add(new Point() { X = 100, Y = 0 });
            //p1.Add(new Point() { X = 100, Y = 50 });
            //p1.Add(new Point() { X = 0, Y = 50 });
            //pointss.Add(p1);



            //List<Point> p2 = new List<Point>();
            //p2.Add(new Point() { X = 100, Y = 20 });
            //p2.Add(new Point() { X = 300, Y = 80 });
            //p2.Add(new Point() { X = 250, Y = 100 });
            //p2.Add(new Point() { X = 50, Y = 50 });
            //pointss.Add(p2);
            //this.WindowState = WindowState.Maximized;
            //this.Loaded += MainWindow_Loaded;
            //this.SizeChanged += MainWindow_SizeChanged;
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            List<List<Point>> pointss = new List<List<Point>>();
            List<Point> p1 = new List<Point>();
            p1.Add(new Point() { X = 960, Y = 10 });
            p1.Add(new Point() { X = 1910, Y = 10 });
            p1.Add(new Point() { X = 1910, Y = 70 });
            p1.Add(new Point() { X = 960, Y = 70 });
            pointss.Add(p1);



            //DrawPolygon2(pointss, canvas);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            List<List<Point>> pointss = new List<List<Point>>();
            List<Point> p1 = new List<Point>();
            p1.Add(new Point() { X = 960, Y = 10 });
            p1.Add(new Point() { X = 1910, Y = 10 });
            p1.Add(new Point() { X = 1910, Y = 70 });
            p1.Add(new Point() { X = 960, Y = 70 });
            pointss.Add(p1);



            //DrawPolygon2(pointss, canvas);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MainViewModel vm = this.DataContext as MainViewModel;
            //Task.Factory.StartNew(() =>
            //{
            //    DispatcherObservableCollection<string> c = vm.Msgs;
            //    c.Add("添加一项");

            //    //(this.DataContext as ViewModels.MainViewModel).Msgs.Add("添加一项");
            //});
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //(this.DataContext as ViewModels.MainViewModel).Msgs.RemoveAt(0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // (this.DataContext as ViewModels.MainViewModel).Msgs.Insert(0, "插入第一项");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // (this.DataContext as ViewModels.MainViewModel).Msgs.Clear();
        }

        private void img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //Point point = e.GetPosition(img);
            //var x = Convert.ToInt32(point.X * (mi.PixelWidth / img.RenderSize.Width));
            //var y = Convert.ToInt32(point.Y * (mi.PixelHeight / img.RenderSize.Height));
            //Console.WriteLine($"{img.RenderSize.Width},{img.RenderSize.Height}--->{e.GetPosition(this.img)}------------------>{x}---{ y}");

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            barcode.BitmapImage= new BitmapImage(new Uri(@"C:\Users\Administrator\Desktop\新建文件夹 (3)\default.bmp", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }




        //private void DrawPolygon(List<List<Point>> points, Canvas parent)
        //{
        //    var remove = parent.Children;
        //    List<UIElement> toremove = new List<UIElement>();
        //    foreach (var item in remove)
        //    {
        //        if (item is Polygon po) toremove.Add(po);
        //    }

        //    foreach (var item in toremove)
        //    {
        //        parent.Children.Remove(item);
        //    }

        //    foreach (List<Point> polygonPoints in points)
        //    {
        //        Polygon py = new Polygon();
        //        py.Points = new PointCollection();
        //        foreach (var p in polygonPoints)
        //        {
        //            py.Points.Add(p);
        //        }
        //        py.Stroke = Brushes.Yellow;
        //        py.Fill = Brushes.Transparent;

        //        parent.Children.Add(py);
        //    }
        //}



        //private void DrawPolygon2(List<List<Point>> points, Canvas parent)
        //{
        //    Console.WriteLine($"{parent.Width},{parent.Height},---{parent.RenderSize}--{parent.ActualWidth},{parent.ActualHeight}");
        //    //Console.WriteLine($"{img.Width},{img.Height},---{img.RenderSize}--{img.ActualWidth},{img.ActualHeight}");
        //    var remove = parent.Children;
        //    List<UIElement> toremove = new List<UIElement>();
        //    foreach (var item in remove)
        //    {
        //        if (item is Polygon po) toremove.Add(po);
        //    }
        //    foreach (var item in toremove)
        //    {
        //        parent.Children.Remove(item);
        //    }

        //    foreach (List<Point> poss in points)
        //    {
        //        //List<Point> resultPoints = poss.Select(c => new Point()
        //        //{
        //        //    X = c.X * parent.RenderSize.Width / mi.PixelWidth,
        //        //    Y = c.Y * parent.RenderSize.Height / mi.PixelHeight
        //        //}).ToList();

        //         List<Point> resultPoints = poss.Select(c => GetOriginCoordinate(c, canvas)).ToList();

        //        foreach (var item in resultPoints)
        //        {
        //            Console.WriteLine(item);
        //        }

        //        Polygon py = new Polygon();
        //        py.Points = new PointCollection();
        //        foreach (var p in resultPoints)
        //        {
        //            py.Points.Add(p);
        //        }
        //        py.Stroke = Brushes.Yellow;
        //        py.Fill = Brushes.Transparent;

        //        parent.Children.Add(py);

        //    }
        //}

        //public Point GetOriginCoordinate(Point pointInPicture, Canvas parent)
        //{
        //    ImageBrush image = parent.Background as ImageBrush;
        //    if (image.ImageSource == null) return new Point();
        //    if (image != null)
        //    {
        //        double originalWidth = image.ImageSource.Width;
        //        double originalHeight = image.ImageSource.Height;


        //        double currentWidth = 0;
        //        double currentHeight = 0;

        //        //先计算图片的尺寸
        //        if (canvas.RenderSize.Width / canvas.RenderSize.Height > image.ImageSource.Width / image.ImageSource.Height)
        //        {
        //            currentWidth = image.ImageSource.Width * canvas.RenderSize.Height / image.ImageSource.Height;
        //            currentHeight = canvas.RenderSize.Height;
        //        }
        //        else
        //        {
        //            currentHeight = image.ImageSource.Height * canvas.RenderSize.Width / image.ImageSource.Width;
        //            currentWidth = canvas.RenderSize.Width;
        //        }

        //        double rate = (double)currentHeight / (double)originalHeight;

        //        double black_left_width = (currentWidth == canvas.RenderSize.Width) ? 0 : (canvas.RenderSize.Width - currentWidth) / 2;
        //        double black_top_height = (currentHeight == canvas.RenderSize.Height) ? 0 : (canvas.RenderSize.Height - currentHeight) / 2;





        //        double resultX = pointInPicture.X * rate + black_left_width;
        //        double resultY = pointInPicture.Y * rate + black_top_height;


        //        //double zoom_x = pointInPicture.X - black_left_width;
        //        //double zoom_y = pointInPicture.Y - black_top_height;

        //        //double original_x = (double)zoom_x / rate;
        //        //double original_y = (double)zoom_y / rate;
        //        return new Point(Convert.ToInt32(resultX), Convert.ToInt32(resultY));
        //    }
        //    return new Point();

        //}


    }
}
