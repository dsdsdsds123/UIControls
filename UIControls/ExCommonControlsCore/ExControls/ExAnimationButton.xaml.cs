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
    /// Interaction logic for ExCheckBox.xaml
    /// </summary>
    public partial class ExAnimationButton : ToggleButton
    {
        public Brush TriangleColor
        {
            get { return (Brush)GetValue(TriangleColorProperty); }
            set { SetValue(TriangleColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TriangleColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TriangleColorProperty =
            DependencyProperty.Register("TriangleColor", typeof(Brush), typeof(ExAnimationButton), new PropertyMetadata(Brushes.White));


        static ExAnimationButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExAnimationButton), new FrameworkPropertyMetadata(typeof(ExAnimationButton)));
        }
        
    }
}
