using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HandyControlPreview.ViewModels
{
    public class MainViewModel
    {
        public DispatcherObservableCollection<string> Msgs { get; set; } = new DispatcherObservableCollection<string>();
        //public DispatherV2<string> Msgs { get; set; } = new DispatherV2<string>();
        //public ObservableCollection<string> Msgs { get; set; } = new ObservableCollection<string>();

        public MainViewModel()
        {
            Msgs.Add("123");
            Msgs.Add("123");
            Msgs.Add("123");
            Msgs.Add("123");
            Msgs.Add(Thread.CurrentThread.ManagedThreadId.ToString());

            //Task.Factory.StartNew(() =>
            //{
            //    int index = 0;
            //    while (true)
            //    {
            //        if (index > 3) break;
            //        App.Current?.Dispatcher?.Invoke(() =>
            //        {
            //            Msgs.Add($"添加一项:{index++}");
            //            Console.WriteLine($"条目数:{Msgs.Count()}");
            //        });
            //        Task.Delay(2000).Wait();
            //    }
            //});
        }
    }
}
