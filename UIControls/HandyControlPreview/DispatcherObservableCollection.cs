using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HandyControlPreview
{
    public class DispatcherObservableCollection<T> : Collection<T>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private void DispatherDo(Action action) => Application.Current?.Dispatcher?.Invoke(action);
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            DispatherDo(() => CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index)));
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            base.RemoveItem(index);
            DispatherDo(() => CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index)));
        }


        protected override void SetItem(int index, T item)
        {
            var old = this[index];
            base.SetItem(index, item);
            DispatherDo(() => CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, old, index)));
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            DispatherDo(() => CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)));
        }
    }
    public class ExDispatcherObservableCollection<T> : ObservableCollection<T>
    {
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            Application.Current?.Dispatcher.Invoke(() => base.OnCollectionChanged(e));
        }
    }
}

