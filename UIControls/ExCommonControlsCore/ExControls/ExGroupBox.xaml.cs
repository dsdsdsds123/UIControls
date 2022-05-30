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
    /// Interaction logic for ExGroupBox.xaml
    /// </summary>
    public partial class ExGroupBox : HeaderedContentControl
    {
        public Brush HeadBackground
        {
            get { return (Brush)GetValue(HeadBackgroundProperty); }
            set { SetValue(HeadBackgroundProperty, value); }
        }

        public static readonly DependencyProperty HeadBackgroundProperty =
            DependencyProperty.Register("HeadBackground", typeof(Brush), typeof(ExGroupBox));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ExGroupBox));




        public Brush SplitLineBrush
        {
            get { return (Brush)GetValue(SplitLineBrushProperty); }
            set { SetValue(SplitLineBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SplitLineBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SplitLineBrushProperty =
            DependencyProperty.Register("SplitLineBrush", typeof(Brush), typeof(ExGroupBox), new PropertyMetadata(Brushes.Gray));


        public Thickness SplitBorderThickness
        {
            get { return (Thickness)GetValue(SplitBorderThicknessProperty); }
            set { SetValue(SplitBorderThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SplitBorderThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SplitBorderThicknessProperty =
            DependencyProperty.Register("SplitBorderThickness", typeof(Thickness), typeof(ExGroupBox), new PropertyMetadata(new Thickness(0, 0, 0, 1)));





        public PathGeometry Icon
        {
            get { return (PathGeometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(PathGeometry), typeof(ExGroupBox), new PropertyMetadata(null));



        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof(double), typeof(ExGroupBox), new PropertyMetadata(20d));




        static ExGroupBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExGroupBox), new FrameworkPropertyMetadata(typeof(ExGroupBox)));
        }
    }
}
