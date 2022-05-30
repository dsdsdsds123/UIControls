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
    public class ExCalendarButton : Button
    {
        static ExCalendarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExCalendarButton), new FrameworkPropertyMetadata(typeof(ExCalendarButton)));
        }

        public ExCalendar Owner { get; set; }




        public bool HasSelectedDates
        {
            get { return (bool)GetValue(HasSelectedDatesProperty); }
            set { SetValue(HasSelectedDatesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HasSelectedDates.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasSelectedDatesProperty =
            DependencyProperty.Register("HasSelectedDates", typeof(bool), typeof(ExCalendarButton), new PropertyMetadata(false));


    }
}
