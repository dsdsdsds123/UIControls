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

namespace ExCommonControlsCore.ExControls.ExButtons
{

    /// <summary>
    /// ExFlatButton.xaml 的交互逻辑
    /// </summary>
    public partial class ExPathButton : ExFlatButton
    {
        static ExPathButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExPathButton), new FrameworkPropertyMetadata(typeof(ExPathButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }



        public double PathWidth
        {
            get { return (double)GetValue(PathWidthProperty); }
            set { SetValue(PathWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PathWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PathWidthProperty =
            DependencyProperty.Register("PathWidth", typeof(double), typeof(ExPathButton), new PropertyMetadata(13d));



        public Geometry PathData
        {
            get { return (Geometry)GetValue(PathDataProperty); }
            set { SetValue(PathDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PathData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PathDataProperty =
            DependencyProperty.Register("PathData", typeof(Geometry), typeof(ExPathButton), new PropertyMetadata(null));





    }
}
