using ExCommonControlsCore.ExControls.ExWindows;
using ExCommonControlsCorePreview.ViewModels;
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
using System.Windows.Shapes;

namespace ExCommonControlsCorePreview.Views
{
    /// <summary>
    /// TemplatedWindowShow.xaml 的交互逻辑
    /// </summary>
    public partial class TemplatedWindowShow : ExTemplatedMainWindowControl
    {
        public TemplatedWindowShow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}
