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

namespace ExCommonControlsCore.ExControls.ExNumeric
{

    /// <summary>
    /// ExFlatButton.xaml 的交互逻辑
    /// </summary>
    [TemplatePart(Name = "PART_ContentHost", Type = typeof(ScrollViewer))]
    [TemplatePart(Name = "PART_UP", Type = typeof(Button))]
    [TemplatePart(Name = "PART_DOWN", Type = typeof(Button))]
    public partial class ExDoubleUpDown : NumericUpDown<double>
    {
        //static ExDoubleUpDown()
        //{
        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(ExDoubleUpDown), new FrameworkPropertyMetadata(typeof(ExDoubleUpDown)));
        //}

        public ExDoubleUpDown()
        {
            this.Minimum = 0d;
            this.Maximum = 100d;
            this.Increment = 1d;
            this.Value = this.Minimum;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        protected override double DecrementValue(double value, double decrement)
        {
            return value - decrement;
        }

        protected override double IncrementValue(double value, double increment)
        {
            return value + increment;
        }

        protected override double ParseValue(string value)
        {
            if (double.TryParse(value, out double val))
            {
                return val;
            }
            return this.Minimum;
        }
    }




    /// <summary>
    /// ExFlatButton.xaml 的交互逻辑
    /// </summary>
    [TemplatePart(Name = "PART_ContentHost", Type = typeof(ScrollViewer))]
    [TemplatePart(Name = "PART_UP", Type = typeof(Button))]
    [TemplatePart(Name = "PART_DOWN", Type = typeof(Button))]
    public partial class ExIntUpDown : NumericUpDown<int>
    {
        //static ExIntUpDown()
        //{
        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(ExIntUpDown), new FrameworkPropertyMetadata(typeof(ExIntUpDown)));
        //}

        public ExIntUpDown()
        {
            this.Minimum = 0;
            this.Maximum = 100;
            this.Increment = 1;
            this.Value = this.Minimum;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        protected override int DecrementValue(int value, int decrement)
        {
            return value - decrement;
        }

        protected override int IncrementValue(int value, int increment)
        {
            return value + increment;
        }

        protected override int ParseValue(string value)
        {
            if (int.TryParse(value, out int val))
            {
                return val;
            }
            return this.Minimum;
        }
    }
}
