using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace ExCommonControlsCore.ExControls.ExDateTime
{
    public class TimePicker : Control
    {
        static TimePicker()
        {
            SelectedTimeChanedEvent = EventManager.RegisterRoutedEvent("SelectedTimeChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>),
                typeof(TimePicker));
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimePicker), new FrameworkPropertyMetadata(typeof(TimePicker)));
        }



        #region 路由事件
        public static readonly RoutedEvent SelectedTimeChanedEvent;
        public event RoutedPropertyChangedEventHandler<object> SelectedTimeChanged
        {
            add { AddHandler(SelectedTimeChanedEvent, value); }
            remove { RemoveHandler(SelectedTimeChanedEvent, value); }
        }

        protected virtual void OnSelectedTimeChanged(object oldValue, object newValue)
        {
            this.RaiseEvent(new RoutedPropertyChangedEventArgs<object>(oldValue, newValue, SelectedTimeChanedEvent));
        }
        #endregion

        /// <summary>
        /// 属性发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TimePicker timePicker = sender as TimePicker;
            if (timePicker != null)
            {
                DateTime dt1 = DateTime.Now;
                if (e.Property == ValueProperty)
                {
                    DateTime dt = Convert.ToDateTime(e.NewValue);
                    timePicker.Hour = dt.Hour;
                    timePicker.Minute = dt.Minute;
                    timePicker.Second = dt.Second;
                }
                else
                {
                    string time = $"{timePicker.Hour}:{timePicker.Minute}:{timePicker.Second}";
                    dt1 = Convert.ToDateTime(time);
                    timePicker.Value = dt1;
                }
                timePicker.OnSelectedTimeChanged(dt1, dt1);
            }
        }

        #region 依赖属性


        public int Hour
        {
            get { return (int)GetValue(HourProperty); }
            set { SetValue(HourProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Hour.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HourProperty =
            DependencyProperty.Register("Hour", typeof(int), typeof(TimePicker),
               new FrameworkPropertyMetadata(new PropertyChangedCallback(OnValueChanged)));

        public int Second
        {
            get { return (int)GetValue(SecondProperty); }
            set { SetValue(SecondProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Hour.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondProperty =
            DependencyProperty.Register("Second", typeof(int), typeof(TimePicker),
               new FrameworkPropertyMetadata(new PropertyChangedCallback(OnValueChanged)));

        public int Minute
        {
            get { return (int)GetValue(MinuteProperty); }
            set { SetValue(MinuteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Hour.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinuteProperty =
            DependencyProperty.Register("Minute", typeof(int), typeof(TimePicker),
               new FrameworkPropertyMetadata(new PropertyChangedCallback(OnValueChanged)));



        public DateTime? Value
        {
            get { return (DateTime?)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(DateTime?), typeof(TimePicker),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnValueChanged)));


        #endregion

        public TimePicker()
        {

        }
    }
}
