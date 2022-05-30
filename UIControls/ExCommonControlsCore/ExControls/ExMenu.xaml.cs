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
    public partial class ExMenu : Menu
    {
      
        static ExMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExMenu), new FrameworkPropertyMetadata(typeof(ExMenu)));
        }
        
    }

    public class ExMenuItem : MenuItem
    {
        static ExMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExMenuItem), new FrameworkPropertyMetadata(typeof(ExMenuItem)));
        }
    }

    public class ExSeparator : Separator
    {
        static ExSeparator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExSeparator), new FrameworkPropertyMetadata(typeof(ExSeparator)));
        }
    }
}
