using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ExCommonControlsCore.ExControls.ExDateTime
{
    public class ExCalendarDayButton : Button
    {
        static ExCalendarDayButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExCalendarDayButton), new FrameworkPropertyMetadata(typeof(ExCalendarDayButton)));
        }

        public ExCalendar Owner { get; set; }


        /// <summary>
        /// 日期是否被选中
        /// </summary>
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(ExCalendarDayButton), new PropertyMetadata(false));


        public bool IsToday
        {
            get { return (bool)GetValue(IsTodayProperty); }
            set { SetValue(IsTodayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsToday.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsTodayProperty =
            DependencyProperty.Register("IsToday", typeof(bool), typeof(ExCalendarDayButton), new PropertyMetadata(false));



        public bool IsBlackedOut
        {
            get { return (bool)GetValue(IsBlackedOutProperty); }
            set { SetValue(IsBlackedOutProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsBlackedOut.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsBlackedOutProperty =
            DependencyProperty.Register("IsBlackedOut", typeof(bool), typeof(ExCalendarDayButton), new PropertyMetadata(false));








        public bool IsBelongCurrentMonth
        {
            get { return (bool)GetValue(IsBelongCurrentMonthProperty); }
            set { SetValue(IsBelongCurrentMonthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsBelongCurrentMonth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsBelongCurrentMonthProperty =
            DependencyProperty.Register("IsBelongCurrentMonth", typeof(bool), typeof(ExCalendarDayButton), new PropertyMetadata(true));




        public bool IsHighLight
        {
            get { return (bool)GetValue(IsHighLightProperty); }
            set { SetValue(IsHighLightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsHighLight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsHighLightProperty =
            DependencyProperty.Register("IsHighLight", typeof(bool), typeof(ExCalendarDayButton), new PropertyMetadata(true));



    }
}
