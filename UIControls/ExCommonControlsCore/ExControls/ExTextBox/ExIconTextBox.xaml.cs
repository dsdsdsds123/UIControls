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

namespace ExCommonControlsCore.ExControls.ExTextBox
{

    public enum IconPlacement
    {
        Left,
        Right
    }

    /// <summary>
    /// ExFlatButton.xaml 的交互逻辑
    /// </summary>
    public partial class ExIconTextBox : ExIconTextBoxBase
    {
        static ExIconTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExIconTextBox), new FrameworkPropertyMetadata(typeof(ExIconTextBox)));
        }




        public IconPlacement IconPlacement
        {
            get { return (IconPlacement)GetValue(IconPlacementProperty); }
            set { SetValue(IconPlacementProperty, value); }
        }

        public static readonly DependencyProperty IconPlacementProperty =
            DependencyProperty.Register("IconPlacement", typeof(IconPlacement), typeof(ExIconTextBox), new PropertyMetadata(IconPlacement.Left));


    }
}


