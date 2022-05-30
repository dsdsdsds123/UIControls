using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExCommonControlsCore.ExControls.ExNumeric
{
    internal enum EnumCompare
    {
        Less,
        Equal,
        Larger,
        None
    }
    [TemplatePart(Name = "PART_ContentHost", Type = typeof(ScrollViewer))]
    [TemplatePart(Name = "PART_UP", Type = typeof(Button))]
    [TemplatePart(Name = "PART_DOWN", Type = typeof(Button))]
    public abstract class NumericUpDown<T> : NumericUpDownBase where T : struct, IComparable
    {
        private Button PART_UP;
        private Button PART_DOWN;


        protected abstract T IncrementValue(T value, T increment);
        protected abstract T DecrementValue(T value, T decrement);
        protected abstract T ParseValue(string value);


        public Action UpButtonClick;
        public Action DownButtonClick;
        public Action<object> ValueChanged;




        public T Maximum
        {
            get { return (T)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(T), typeof(NumericUpDown<T>), new PropertyMetadata(default(T)));



        public T Minimum
        {
            get { return (T)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(T), typeof(NumericUpDown<T>), new PropertyMetadata(default(T)));





        public T Increment
        {
            get { return (T)GetValue(IncrementProperty); }
            set { SetValue(IncrementProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Increment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IncrementProperty =
            DependencyProperty.Register("Increment", typeof(T), typeof(NumericUpDown<T>), new PropertyMetadata(default(T)));




        public T Value
        {
            get { return (T)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(T), typeof(NumericUpDown<T>), new PropertyMetadata(default(T)));





        public bool ShowTip
        {
            get { return (bool)GetValue(ShowTipProperty); }
            set { SetValue(ShowTipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowTip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowTipProperty =
            DependencyProperty.Register("ShowTip", typeof(bool), typeof(NumericUpDown<T>), new PropertyMetadata(false));




        public string TipText
        {
            get { return (string)GetValue(TipTextProperty); }
            set { SetValue(TipTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TipText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TipTextProperty =
            DependencyProperty.Register("TipText", typeof(string), typeof(NumericUpDown<T>), new PropertyMetadata(""));






        public Brush TipBackground
        {
            get { return (Brush)GetValue(TipBackgroundProperty); }
            set { SetValue(TipBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TipBackgroundProperty =
            DependencyProperty.Register("TipBackground", typeof(Brush), typeof(NumericUpDown<T>), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(252, 110, 81))));




        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.PART_UP = Template.FindName("PART_UP", this) as Button;
            this.PART_DOWN = Template.FindName("PART_DOWN", this) as Button;

            if (PART_UP != null) PART_UP.Click += PART_UP_Click;
            if (PART_DOWN != null) PART_DOWN.Click += PART_DOWN_Click;

            this.TextChanged += NumericUpDown_TextChanged;
            this.KeyUp += NumericUpDown_KeyUp;

            SetBtnEnabled(this.Value.ToString());
            this.MoveCursorToEnd();
            EnumCompare type = default;
            this.Value = CoreValueCompareMinMax(this.Value, ref type);
        }

        private void NumericUpDown_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (this.IsFocused == false) return;
            switch (e.Key)
            {
                case System.Windows.Input.Key.Up:
                    if (this.PART_UP != null) UpButtonClick();
                    break;
                case System.Windows.Input.Key.Down:
                    if (PART_DOWN != null) DownButtonClick();
                    break;

            }
        }

        private bool seting = false;
        private void SetStr(string str)
        {
            seting = true;
            this.Text = str;
            seting = false;
        }

        private void NumericUpDown_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsReadOnly) return;
            if (seting) return;

            ShowTip = false;
            string newValue = ((TextBox)sender).Text;
            EnumCompare type = default;
            this.Value = CoreValueCompareMinMax(ParseValue(newValue), ref type);
            switch (type)
            {
                case EnumCompare.Less:
                    ShowTip = true;
                    TipText = $"您输入的数值为:{newValue},小于最小值:{this.Minimum}";
                    break;
              
                case EnumCompare.Larger:
                    ShowTip = true;
                    TipText = $"您输入的数值为:{newValue},大于最大值:{this.Maximum}";
                    break;
            }
            SetStr(this.Value.ToString());
            SetBtnEnabled(this.Value.ToString());
            MoveCursorToEnd();
        }

        private void PART_DOWN_Click(object sender, RoutedEventArgs e)
        {
            T value = this.DecrementValue(this.Value, this.Increment);
            EnumCompare type = EnumCompare.None;
            this.Value = CoreValueCompareMinMax(value, ref type);
            MoveCursorToEnd();
        }

        private void PART_UP_Click(object sender, RoutedEventArgs e)
        {
            T value = this.IncrementValue(this.Value, this.Increment);
            EnumCompare type = EnumCompare.None;
            this.Value = CoreValueCompareMinMax(value, ref type);
            MoveCursorToEnd();
        }


        private bool LessThan(T value1, T value2)
        {
            return value1.CompareTo(value2) < 0;

        }
        private bool LargerThan(T value1, T value2)
        {
            return value1.CompareTo(value2) > 0;
        }

        private T CoreValueCompareMinMax(T value, ref EnumCompare type)
        {
            T result = value;
            type = EnumCompare.None;
            if (LessThan(result, this.Minimum))
            {
                result = this.Minimum;
                type = EnumCompare.Less;
            }
            else
            {
                if (LargerThan(result, this.Maximum))
                {
                    result = this.Maximum;
                    type = EnumCompare.Larger;
                }
            }
            return result;
        }


        private void SetBtnEnabled(string value)
        {
            if (value != null)
            {
                T result = ParseValue(value.ToString());
                if (PART_UP != null)
                {
                    if (LargerThan(result, Maximum)||result.Equals(this.Maximum)) PART_UP.IsEnabled = false;
                   else PART_UP.IsEnabled = true;
                }
                if (PART_DOWN != null)
                {
                    if (LessThan(result, Minimum)||result.Equals(this.Minimum)) PART_DOWN.IsEnabled = false;
                    else PART_DOWN.IsEnabled = true;
                }
            }
        }
        private void MoveCursorToEnd() => this.SelectionStart = Convert.ToString(this.Value).Length;
    }
}
