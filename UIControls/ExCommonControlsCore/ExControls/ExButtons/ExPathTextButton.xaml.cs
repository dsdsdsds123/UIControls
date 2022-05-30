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
    public partial class ExPathTextButton : ExPathIconButton
    {
        static ExPathTextButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExPathTextButton), new FrameworkPropertyMetadata(typeof(ExPathTextButton)));
        }
    }
}
