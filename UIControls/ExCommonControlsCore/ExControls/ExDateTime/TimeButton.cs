using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExCommonControlsCore.ExControls.ExDateTime
{
    public class TimeButton : ListBoxItem
    {
        static TimeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeButton), new FrameworkPropertyMetadata(typeof(TimeButton)));
        }
    }
}
