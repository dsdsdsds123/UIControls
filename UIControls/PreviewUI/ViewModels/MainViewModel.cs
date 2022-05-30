using ExCommonControlsCore.ExControls;
using MenuContainerModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PreviewUI.ViewModels
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




            Messages.Add(new MessageModel() { CurrentMessageContent = "测试的正常消息测试的正常消息测试的正常消息测试的正常消息测试的正常消息测试的正常消息测试的正常消息测试的正常消息", CurrentMessageTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"), CurrentMessageType = MessageType.Information });
            Messages.Add(new MessageModel() { CurrentMessageContent = "测试的调试消息", CurrentMessageTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"), CurrentMessageType = MessageType.Debug });
            Messages.Add(new MessageModel() { CurrentMessageContent = "测试的错误消息", CurrentMessageTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"), CurrentMessageType = MessageType.Error });
            Messages.Add(new MessageModel() { CurrentMessageContent = "测试的警告消息", CurrentMessageTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"), CurrentMessageType = MessageType.Warning });








        }

        public ObservableCollection<MenuItemModel> Menus { get; set; } = new ObservableCollection<MenuItemModel>();
        public ObservableCollection<MessageModel> Messages { get; set; } = new ObservableCollection<MessageModel>();

    }
}
