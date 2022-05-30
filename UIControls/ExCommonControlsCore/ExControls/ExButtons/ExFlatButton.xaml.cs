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

namespace ExCommonControlsCore.ExControls.ExButtons
{


    public enum ExFlatButtonType
    {
        Yes,
        No,
        Ghost,
        Default,
        Text,
        Info,
        Success,
        Error,
        Warning
    }

    /// <summary>
    /// ExFlatButton.xaml 的交互逻辑
    /// </summary>
    public partial class ExFlatButton : Button
    {
        static ExFlatButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExFlatButton), new FrameworkPropertyMetadata(typeof(ExFlatButton)));
        }

        public ExFlatButtonType Type
        {
            get { return (ExFlatButtonType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(ExFlatButtonType), typeof(ExFlatButton),
                new PropertyMetadata(ExFlatButtonType.Default));





        public Brush MouseOverBackground
        {
            get { return (Brush)GetValue(MouseOverBackgroundProperty); }
            set { SetValue(MouseOverBackgroundProperty, value); }
        }

        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(ExFlatButton),
                new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 79, 193, 233))));





        public Brush MouseOverForeground
        {
            get { return (Brush)GetValue(MouseOverForegroundProperty); }
            set { SetValue(MouseOverForegroundProperty, value); }
        }

        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.Register("MouseOverForeground", typeof(Brush), typeof(ExFlatButton), new PropertyMetadata(Brushes.White));





        public Brush MousePressedBackground
        {
            get { return (Brush)GetValue(MousePressedBackgroundProperty); }
            set { SetValue(MousePressedBackgroundProperty, value); }
        }

        public static readonly DependencyProperty MousePressedBackgroundProperty =
            DependencyProperty.Register("MousePressedBackground", typeof(Brush), typeof(ExFlatButton),
                new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 74, 137, 200))));




        public Brush MousePressedForeground
        {
            get { return (Brush)GetValue(MousePressedForegroundProperty); }
            set { SetValue(MousePressedForegroundProperty, value); }
        }

        public static readonly DependencyProperty MousePressedForegroundProperty =
            DependencyProperty.Register("MousePressedForeground", typeof(Brush), typeof(ExFlatButton), new PropertyMetadata(Brushes.White));





        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ExFlatButton), new PropertyMetadata(new CornerRadius(3)));




    }
}
