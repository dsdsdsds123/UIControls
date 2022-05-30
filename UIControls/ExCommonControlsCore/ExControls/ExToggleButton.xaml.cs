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
    public partial class ExToggleButton : ToggleButton
    {
        static ExToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExToggleButton), new FrameworkPropertyMetadata(typeof(ExToggleButton)));
        }


        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ExToggleButton), new PropertyMetadata(new CornerRadius(3)));



    }
}
