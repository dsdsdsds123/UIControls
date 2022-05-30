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
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Threading;

namespace ExCommonControlsCore.ExControls
{
    /// <summary>
    /// MonitorControl.xaml 的交互逻辑
    /// </summary>
    public partial class ExMonitorControl : UserControl
    {
        SystemInfoQueryEngine monitor = new SystemInfoQueryEngine();
        DispatcherTimer timer;
        DateTime startTime = DateTime.Now;
        public ExMonitorControl()
        {
            InitializeComponent();
            startTime = DateTime.Now;
            this.Loaded += MonitorControl_Loaded;
        }

        private async Task Init()
        {
            await Task.Run(() =>
            {
                Application.Current?.Dispatcher?.Invoke(() =>
                {
                    ExDiskProgressBar barC = new ExDiskProgressBar
                    {
                        Width = 120,
                        Minimum = 0,
                        Maximum = 100,
                        Value = SystemInfoQueryEngine.QueryCpu(),
                        Unit = "%",
                        Tag = "Cpu:",
                        Margin = new Thickness(2, 0, 2, 0)
                    };
                    stackPanel.Children.Add(barC);
                    ExDiskProgressBar barM = new ExDiskProgressBar
                    {
                        Width = 120,
                        Minimum = 0,
                        Maximum = SystemInfoQueryEngine.QueryPhysicalMemory() * 1.0f / 1024 / 1024 / 1024,
                        Value = SystemInfoQueryEngine.QueryFreeSpaceMemory() * 1.0f / 1024 / 1024 / 1024,
                        Tag = "RAM:",
                        Margin = new Thickness(2, 0, 2, 0)
                    };
                    stackPanel.Children.Add(barM);
                    List<SystemInfoQueryEngine.DiskInfo> disk = SystemInfoQueryEngine.QueryDrivesInfo();
                    foreach (var item in disk)
                    {
                        ExDiskProgressBar bar = new ExDiskProgressBar();
                        bar.Minimum = 0;
                        bar.Maximum = item.DiskSize * 1.0f / 1024 / 1024 / 1024;
                        bar.Value = item.FreeSpace * 1.0f / 1024 / 1024 / 1024;
                        bar.Tag = item.DiskName;
                        bar.Margin = new Thickness(2, 0, 2, 0);
                        stackPanel.Children.Add(bar);
                    }

                    //运行时间
                    TextBlock txtRuntime = new TextBlock()
                    {
                        Foreground = Brushes.Black,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 12,
                        Text = "运行时间:",
                        Margin = new Thickness(2, 0, 1, 0)
                    };
                    stackPanel.Children.Add(txtRuntime);

                    TextBlock text = new TextBlock()
                    {
                        Name = "txtTime",
                        Text = $"[0天0小时0分0秒]",
                        Foreground = Brushes.Black,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 12,
                        Margin = new Thickness(1, 0, 1, 0)
                    };
                    stackPanel.Children.Add(text);
                });
            });
        }

        private async void MonitorControl_Loaded(object sender, RoutedEventArgs e)
        {
            await Init();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Application.Current?.Dispatcher?.Invoke(() =>
                {
                    List<SystemInfoQueryEngine.DiskInfo> disks = SystemInfoQueryEngine.QueryDrivesInfo();
                    List<string> diskNames = disks.Select(c => c.DiskName).ToList();
                    foreach (var mo in stackPanel.Children)
                    {
                        if (mo is TextBlock)
                        {
                            TextBlock txt = (TextBlock)mo;
                            if (txt.Name.Equals("txtTime"))
                            {
                                TimeSpan span = DateTime.Now.Subtract(startTime);
                                txt.Text = $"[{span.Days}天{span.Hours}小时{span.Minutes}分{span.Seconds}秒]";
                            }
                        }
                        if (mo is ExDiskProgressBar)
                        {
                            ExDiskProgressBar bar = (ExDiskProgressBar)mo;
                            if (diskNames.Contains(bar.Tag.ToString()))
                            {
                                bar.Value = bar.Maximum * 1.0f - disks.FirstOrDefault(c => c.DiskName == bar.Tag.ToString()).FreeSpace * 1.0f / 1024 / 1024 / 1024;

                                //bar.Value = bar.Maximum * 0.82;
                            }

                            else if (bar.Tag.ToString() == "RAM:")
                            {
                                bar.Value = bar.Maximum - SystemInfoQueryEngine.QueryFreeSpaceMemory() * 1.0f / 1024 / 1024 / 1024;
                            }
                            else if (bar.Tag.ToString() == "Cpu:")
                            {
                                bar.Value = SystemInfoQueryEngine.QueryCpu();
                                //bar.Value = 80;
                            }
                        }
                    }
                });
            });
        }
    }

    ///  
    /// 系统信息类 - 获取CPU、内存、磁盘、进程信息 
    ///  
    public class SystemInfoQueryEngine
    {
        private static PerformanceCounter pcCpuLoad;   //CPU计数器 
        private static PerformanceCounter upTime;     //系统运行时间
        ///  
        /// 构造函数，初始化计数器等 
        ///  
        static SystemInfoQueryEngine()
        {
            //初始化CPU计数器 
            pcCpuLoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            upTime = new PerformanceCounter("System", "System Up Time");

            pcCpuLoad.MachineName = ".";
            pcCpuLoad.NextValue();
        }

        /// <summary>
        /// 查询系统运行时间
        /// </summary>
        /// <returns></returns>
        private static TimeSpan QuerySystemUpTime()
        {
            return TimeSpan.FromSeconds(upTime.NextValue());
        }



        /// <summary>
        /// 查询全部得内存大小
        /// </summary>
        /// <returns></returns>
        public static long QueryPhysicalMemory()
        {
            long physicalMemory = 0;
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo["TotalPhysicalMemory"] != null)
                {
                    physicalMemory = long.Parse(mo["TotalPhysicalMemory"].ToString());
                }
            }
            return physicalMemory;
        }

        /// <summary>
        /// 获取逻辑处理器个数
        /// </summary>
        /// <returns></returns>
        public static int QueryCpuCount()
        {
            return Environment.ProcessorCount;
        }

        /// <summary>
        /// 查询Cpu负载
        /// </summary>
        /// <returns></returns>
        private static float QueryCpuLoad()
        {
            return pcCpuLoad.NextValue();
        }

        /// <summary>
        /// 查询剩余内存
        /// </summary>
        /// <returns></returns>
        public static long QueryFreeSpaceMemory()
        {
            long availablebytes = 0;
            ManagementClass mos = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject mo in mos.GetInstances())
            {
                if (mo["FreePhysicalMemory"] != null)
                {
                    availablebytes = 1024 * long.Parse(mo["FreePhysicalMemory"].ToString());
                }
            }
            return availablebytes;
        }





        public class DiskInfo
        {
            public string DiskName { get; set; }
            public long DiskSize { get; set; }
            public long FreeSpace { get; set; }
            public DiskInfo(string diskName, long disSize, long freeSpace)
            {
                DiskName = diskName;
                DiskSize = disSize;
                FreeSpace = freeSpace;
            }
        }



        /// <summary>
        /// 获取所有盘符使用情况
        /// </summary>
        /// <returns></returns>
        public static List<DiskInfo> QueryDrivesInfo()
        {

            List<DiskInfo> drives = new List<DiskInfo>();
            ManagementClass diskClass = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection disks = diskClass.GetInstances();
            foreach (ManagementObject disk in disks)
            {
                // DriveType.Fixed 为固定磁盘(硬盘) 
                if (int.Parse(disk["DriveType"].ToString()) == (int)DriveType.Fixed)
                {
                    drives.Add(new DiskInfo(disk["Name"].ToString(), long.Parse(disk["Size"].ToString()), long.Parse(disk["FreeSpace"].ToString())));
                }
            }
            return drives;
        }

        public static float QueryCpu()
        {
            return QueryCpuLoad();
        }



        public static string QuerySystemInfo()
        {
            string iResult = string.Empty;

            float cpuLoad = QueryCpuLoad();
            iResult += $"Cpu:{cpuLoad.ToString("f2")}%  ";


            iResult += $"RAM:{(QueryFreeSpaceMemory() / 1024f / 1024f / 1024f).ToString("f1")}G/{(QueryPhysicalMemory() / 1024f / 1024f / 1024f).ToString("f1")}G  ";


            foreach (DiskInfo item in QueryDrivesInfo())
            {
                iResult += $"{item.DiskName}{(item.FreeSpace / 1024f / 1024f / 1024f).ToString("f1")}G/{(item.DiskSize / 1024f / 1024f / 1024f).ToString("f1")}G  ";
            }

            //TimeSpan span = QuerySystemUpTime();
            //iResult += $"系统运行时间:{span.Days}Days,{span.Hours}Hours,{span.Minutes}Minutes,{span.Seconds}Seconds";

            return iResult;

        }
    }
}
