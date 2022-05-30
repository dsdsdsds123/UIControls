using MenuContainerModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ControlTest
{
    /// <summary>
    /// ExWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MenuContainerV1 : UserControl
    {
        static MenuContainerV1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuContainerV1), new FrameworkPropertyMetadata(typeof(MenuContainerV1)));
        }


        public MenuContainerV1()
        {

        }

        public ObservableCollection<MenuItemModel> Menus
        {
            get { return (ObservableCollection<MenuItemModel>)GetValue(MenusProperty); }
            set { SetValue(MenusProperty, value); }
        }
        public static readonly DependencyProperty MenusProperty =
            DependencyProperty.Register("Menus", typeof(ObservableCollection<MenuItemModel>),
                typeof(MenuContainerV1),
                new PropertyMetadata(new ObservableCollection<MenuItemModel>()));
    }
}
namespace MenuContainerModels
{
    public class MenuItemModel : ObservableObjectCore
    {
        public string Header { get; set; }
        public Geometry MenuIcon { get; set; }
        public string TargetViewName { get; set; }

        public ObservableCollection<MenuItemModel> Children { get; set; } = new ObservableCollection<MenuItemModel>();

        private bool isChecked;
        public bool IsChecked { get => isChecked; set { isChecked = value; RaisePropertyChanged(); } }

        public ICommand OpenViewCommand { get; set; }
    }
    public abstract class ObservableObjectCore : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
