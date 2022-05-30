using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExCommonControlsCore.ExControls.ExNumeric
{
    public enum UpDownOrientation
    {
        Horizontal,
        Vertical
    }

    public class NumericUpDownBase : TextBox
    {
        static NumericUpDownBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDownBase), new FrameworkPropertyMetadata(typeof(NumericUpDownBase)));
        }



        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(NumericUpDownBase), new PropertyMetadata(new CornerRadius(3)));




        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Watermark.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("Watermark", typeof(string), typeof(NumericUpDownBase), new PropertyMetadata(""));



        public UpDownOrientation UpDownOrientation
        {
            get { return (UpDownOrientation)GetValue(UpDownOrientationProperty); }
            set { SetValue(UpDownOrientationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UpDownOrientation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpDownOrientationProperty =
            DependencyProperty.Register("UpDownOrientation", typeof(UpDownOrientation), typeof(NumericUpDownBase), new PropertyMetadata(UpDownOrientation.Vertical));



    }
}
