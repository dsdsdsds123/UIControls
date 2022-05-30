using ExCommonControlsCore.ExControls;
using ExCommonControlsCorePreview.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ExCommonControlsCorePreview.Views
{
    public class TabInfo
    {
        public string Title { get; set; }
        public int Type { get; set; }
    }
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<TabInfo> list = new ObservableCollection<TabInfo>();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();


            list.Add(new TabInfo() { Title = "Windows", Type = 1 });
            list.Add(new TabInfo() { Title = "MacOS", Type = 2 });
            list.Add(new TabInfo() { Title = "Linux", Type = 3 });
            this.tabcontrol1.ItemsSource = list;
        }

        private void ExSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Console.WriteLine("当前slider值:" + e.NewValue);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.timepicker.SelectedDate?.ToString("yyyy-MM-dd"));
            MessageBox.Show(this.timepicker.SelectedTime?.ToString("HH:mm:ss"));
            MessageBox.Show(this.timepicker.CurrentSelectedDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ExMessageBox.Show("123");
            ExMessageBox.Show(null, "123", "提示", MessageBoxButton.OKCancel, HintMessageType.Error);
            ExMessageBox.Show("123", HintMessageType.Warn);
            ExMessageBox.Show("123", HintMessageType.Success);
        }
    }
}
