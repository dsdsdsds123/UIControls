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

    /// <summary>
    /// ExFlatButton.xaml 的交互逻辑
    /// </summary>
    public partial class ExTextBox : ExTextBoxBase
    {
        static ExTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExTextBox), new FrameworkPropertyMetadata(typeof(ExTextBox)));
        }



        public bool MultiRow
        {
            get { return (bool)GetValue(MultiRowProperty); }
            set { SetValue(MultiRowProperty, value); }
        }

        public static readonly DependencyProperty MultiRowProperty =
            DependencyProperty.Register("MultiRow", typeof(bool), typeof(ExTextBox), new PropertyMetadata(false));


    }
}

