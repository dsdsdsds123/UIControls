using ExCommonControlsCore.ExControls;
using MenuContainerModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExCommonControlsCorePreview.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public string Title { get; set; } = "模板窗体";
        public ObservableCollection<MenuItemModel> Menus { get; set; } = new ObservableCollection<MenuItemModel>();
        public ObservableCollection<MessageModel> Messages { get; set; } = new ObservableCollection<MessageModel>();
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

        private int value1 = 334124;
        public int Value1 { get => value1; set { SetProperty(ref value1, value); } }

    }
}

