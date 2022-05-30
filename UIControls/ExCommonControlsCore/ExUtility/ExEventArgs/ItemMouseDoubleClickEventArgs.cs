using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExCommonControlsCore.ExUtility.ExEventArgs
{
    public class ItemMouseDoubleClickEventArgs<T> : EventArgs
    {
        public ItemMouseDoubleClickEventArgs()
        {

        }
        public T NewValue { get; set; }

        public static ItemMouseDoubleClickEventArgs<T> ItemDoubleClick(T newValue)
        {
            return new ItemMouseDoubleClickEventArgs<T>() { NewValue = newValue };
        }
    }
    public class ItemMouseRightButtonDownEventArgs<T> : EventArgs
    {
        public ItemMouseRightButtonDownEventArgs() { }

        public T NewValue { get; private set; }

        public static ItemMouseRightButtonDownEventArgs<T> ItemRightMouseButtonDown(T newValue)
        {
            return new ItemMouseRightButtonDownEventArgs<T>() { NewValue = newValue };
        }

        public static ItemMouseRightButtonDownEventArgs<T> ShowContextMenu()
        {
            return new ItemMouseRightButtonDownEventArgs<T>() { };
        }
    }

    public class ItemMouseSingleClickEventArgs<T> : EventArgs
    {
        public ItemMouseSingleClickEventArgs() { }

        public T NewValue { get; set; }

        public static ItemMouseSingleClickEventArgs<T> ItemSingleClick(T newValue)
        {
            return new ItemMouseSingleClickEventArgs<T>() { NewValue = newValue };
        }


        public static ItemMouseSingleClickEventArgs<T> ShowContenxtMenu()
        {
            return new ItemMouseSingleClickEventArgs<T>() { };
        }
    }
}
