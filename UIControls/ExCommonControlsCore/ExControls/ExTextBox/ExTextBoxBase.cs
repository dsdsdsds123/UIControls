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

namespace ExCommonControlsCore.ExControls.ExTextBox
{

    public class ExTextBoxBase : TextBox
    {
        static ExTextBoxBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExTextBoxBase), new FrameworkPropertyMetadata(typeof(ExTextBoxBase)));
        }



        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("Watermark", typeof(string), typeof(ExTextBoxBase), new PropertyMetadata(string.Empty));



        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ExTextBoxBase), new PropertyMetadata(new CornerRadius(0), OnCornerRadiusChanged));

        protected static void OnCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ExTextBoxBase tb = d as ExTextBoxBase;
            if (tb != null && !string.IsNullOrWhiteSpace(e.NewValue.ToString()))
            {
                //do something
            }
        }
    }
}
