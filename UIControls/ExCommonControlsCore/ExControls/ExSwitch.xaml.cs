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
    /// ExFlatButton.xaml 的交互逻辑
    /// </summary>
    public partial class ExSwitch : ToggleButton
    {
        static ExSwitch()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExSwitch), new FrameworkPropertyMetadata(typeof(ExSwitch)));
        }



        public bool ShowTip
        {
            get { return (bool)GetValue(ShowTipProperty); }
            set { SetValue(ShowTipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowTip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowTipProperty =
            DependencyProperty.Register("ShowTip", typeof(bool), typeof(ExSwitch), new PropertyMetadata(false));




        public string CheckedTip
        {
            get { return (string)GetValue(CheckedTipProperty); }
            set { SetValue(CheckedTipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckedTip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckedTipProperty =
            DependencyProperty.Register("CheckedTip", typeof(string), typeof(ExSwitch), new PropertyMetadata("关"));



        public string UncheckedTip
        {
            get { return (string)GetValue(UncheckedTipProperty); }
            set { SetValue(UncheckedTipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UncheckedTip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UncheckedTipProperty =
            DependencyProperty.Register("UncheckedTip", typeof(string), typeof(ExSwitch), new PropertyMetadata("开"));






    }
}
