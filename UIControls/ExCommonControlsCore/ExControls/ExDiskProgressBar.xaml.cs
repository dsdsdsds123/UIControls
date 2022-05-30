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

namespace ExCommonControlsCore.ExControls
{
    /// <summary>
    /// ExDiskProgressBar.xaml 的交互逻辑
    /// </summary>
    internal partial class ExDiskProgressBar : ProgressBar
    {
        static ExDiskProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExDiskProgressBar), new FrameworkPropertyMetadata(typeof(ExDiskProgressBar)));
        }

        public ExDiskProgressBar()
        {
            this.Minimum = 0;
            this.Maximum = 100;
            //this.Value = 0;
            this.SizeChanged += (s, e) => Refresh(this);
        }



        public Brush ProgressBarBackground
        {
            get { return (Brush)GetValue(ProgressBarBackgroundProperty); }
            set { SetValue(ProgressBarBackgroundProperty, value); }
        }
        public static readonly DependencyProperty ProgressBarBackgroundProperty =
            DependencyProperty.Register("ProgressBarBackground", typeof(Brush), typeof(ExDiskProgressBar), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 228, 228, 228))));





        public Brush ProgressBarForeground
        {
            get { return (Brush)GetValue(ProgressBarForegroundProperty); }
            set { SetValue(ProgressBarForegroundProperty, value); }
        }
        public static readonly DependencyProperty ProgressBarForegroundProperty =
            DependencyProperty.Register("ProgressBarForeground", typeof(Brush), typeof(ExDiskProgressBar), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 58, 196, 66))));



        public string Unit
        {
            get { return (string)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }
        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register("Unit", typeof(string), typeof(ExDiskProgressBar), new PropertyMetadata("G"));




        protected override void OnValueChanged(double oldValue, double newValue)
        {
            if (Value / Maximum > ErrorThreshold)
            {
                ProgressBarForeground = Brushes.Red;
            }
            else if (Value / Maximum > WarningThreshold)
            {
                ProgressBarForeground = Brushes.Yellow;
            }
            else
            {
                ProgressBarForeground = new SolidColorBrush(Color.FromArgb(255, 58, 196, 66));
            }
            Refresh(this);
        }



        public double WarningThreshold
        {
            get { return (double)GetValue(WarningThresholdProperty); }
            set { SetValue(WarningThresholdProperty, value); }
        }
        public static readonly DependencyProperty WarningThresholdProperty =
            DependencyProperty.Register("WarningThreshold", typeof(double), typeof(ExDiskProgressBar), new PropertyMetadata(0.6d));



        public double ErrorThreshold
        {
            get { return (double)GetValue(ErrorThresholdProperty); }
            set { SetValue(ErrorThresholdProperty, value); }
        }
        public static readonly DependencyProperty ErrorThresholdProperty =
            DependencyProperty.Register("ErrorThreshold", typeof(double), typeof(ExDiskProgressBar), new PropertyMetadata(0.9d));






        public double OutterWidth
        {
            get { return (double)GetValue(OutterWidthProperty); }
            set { SetValue(OutterWidthProperty, value); }
        }
        public static readonly DependencyProperty OutterWidthProperty =
            DependencyProperty.Register("OutterWidth", typeof(double), typeof(ExDiskProgressBar), new PropertyMetadata(30d));

        private static void Refresh(ExDiskProgressBar bar)
        {
            if (bar != null)
            {
                //bar.OutterWidth = bar.Value * bar.RenderSize.Width / bar.Maximum;
                if (bar.PART_BackgroundBorder != null)
                    bar.OutterWidth = bar.Value / bar.Maximum * bar.PART_BackgroundBorder.ActualWidth;
            }
        }


        private Border PART_BackgroundBorder;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PART_BackgroundBorder = Template.FindName("PART_BackgroundBorder", this) as Border;
        }
    }
}
