using MenuContainerModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ControlTest
{
    public class MainViewModel
    {
        public MainViewModel()
        {

            Menus.Add(new MenuItemModel() { Header = "Agv状态视图", TargetViewName = "AgvStatusView", MenuIcon = (Geometry)System.Windows.Application.Current.FindResource("MonitorGeometry") });
            Menus.Add(new MenuItemModel() { Header = "任务列表视图", TargetViewName = "TaskListView", MenuIcon = (Geometry)System.Windows.Application.Current.FindResource("CameraGeometry") });
            Menus.Add(new MenuItemModel() { Header = "任务呼叫试图", TargetViewName = "AgvCallView", MenuIcon = (Geometry)System.Windows.Application.Current.FindResource("SettingGeometry"), IsChecked = true });



            var meu = new MenuItemModel() { Header = "Agv状态视图", TargetViewName = "AgvStatusView", MenuIcon = (Geometry)System.Windows.Application.Current.FindResource("MonitorGeometry") };
            meu.Children.Add(new MenuItemModel() { Header = "Agv状态视图", TargetViewName = "AgvStatusView", MenuIcon = (Geometry)System.Windows.Application.Current.FindResource("MonitorGeometry") });
            meu.Children.Add(new MenuItemModel() { Header = "Agv状态视图", TargetViewName = "AgvStatusView", MenuIcon = (Geometry)System.Windows.Application.Current.FindResource("MonitorGeometry") });
            meu.Children.Add(new MenuItemModel() { Header = "Agv状态视图", TargetViewName = "AgvStatusView", MenuIcon = (Geometry)System.Windows.Application.Current.FindResource("MonitorGeometry") });
            meu.Children.Add(new MenuItemModel() { Header = "Agv状态视图", TargetViewName = "AgvStatusView", MenuIcon = (Geometry)System.Windows.Application.Current.FindResource("MonitorGeometry") });

            Menus.Add(meu);








        }

        public ObservableCollection<MenuItemModel> Menus { get; set; } = new ObservableCollection<MenuItemModel>();

    }
}
