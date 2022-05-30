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
    public enum StateType
    {
        MinimizeButton,
        NormalizeButton,
        MaximizeButton,
        CloseButton
    }


    /// <summary>
    /// ExFlatButton.xaml 的交互逻辑
    /// </summary>
    public partial class ExWindowStateButton : Button
    {
        static ExWindowStateButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExWindowStateButton), new FrameworkPropertyMetadata(typeof(ExWindowStateButton)));
            
        }


        public StateType ButtonType
        {
            get { return (StateType)GetValue(ButtonTypeProperty); }
            set { SetValue(ButtonTypeProperty, value); }
        }

        public static readonly DependencyProperty ButtonTypeProperty =
            DependencyProperty.Register("ButtonType", typeof(StateType), typeof(ExWindowStateButton), new PropertyMetadata(StateType.NormalizeButton));
    }
}
