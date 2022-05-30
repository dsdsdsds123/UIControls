using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ExCommonControlsCore.ExControls.ExTextBox
{
    public class ExIconTextBoxBase : ExTextBoxBase
    {
        static ExIconTextBoxBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExIconTextBoxBase), new FrameworkPropertyMetadata(typeof(ExIconTextBoxBase)));
        }



        public bool ShowIcon
        {
            get { return (bool)GetValue(ShowIconProperty); }
            set { SetValue(ShowIconProperty, value); }
        }

        public static readonly DependencyProperty ShowIconProperty =
            DependencyProperty.Register("ShowIcon", typeof(bool), typeof(ExIconTextBoxBase), new PropertyMetadata(true));





        public static readonly RoutedEvent EnterKeyClickEvent = EventManager.RegisterRoutedEvent("EnterKeyClick",
            RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventArgs<object>),
            typeof(ExIconTextBoxBase));

        protected virtual void OnEnterKeyClick(object oldValue, object newValue)
        {
            this.RaiseEvent(new RoutedPropertyChangedEventArgs<object>(oldValue, newValue, EnterKeyClickEvent));
        }




        public Brush IconBackground
        {
            get { return (Brush)GetValue(IconBackgroundProperty); }
            set { SetValue(IconBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconBackgroundProperty =
            DependencyProperty.Register("IconBackground", typeof(Brush), typeof(ExIconTextBoxBase), new PropertyMetadata(Brushes.Transparent));




        public Brush IconForeground
        {
            get { return (Brush)GetValue(IconForegroundProperty); }
            set { SetValue(IconForegroundProperty, value); }
        }

        public static readonly DependencyProperty IconForegroundProperty =
            DependencyProperty.Register("IconForeground", typeof(Brush), typeof(ExIconTextBoxBase), new PropertyMetadata(Brushes.Black));





        public Brush IconBorderBrush
        {
            get { return (Brush)GetValue(IconBorderBrushProperty); }
            set { SetValue(IconBorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconBorderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconBorderBrushProperty =
            DependencyProperty.Register("IconBorderBrush", typeof(Brush), typeof(ExIconTextBoxBase), new PropertyMetadata(Brushes.Gray));





        public Thickness IconBorderThickness
        {
            get { return (Thickness)GetValue(IconBorderThicknessProperty); }
            set { SetValue(IconBorderThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconBorderThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconBorderThicknessProperty =
            DependencyProperty.Register("IconBorderThickness", typeof(Thickness), typeof(ExIconTextBoxBase), new PropertyMetadata(new Thickness(1)));






        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof(double), typeof(ExIconTextBoxBase), new PropertyMetadata(16d));




        public Thickness IconPadding
        {
            get { return (Thickness)GetValue(IconPaddingProperty); }
            set { SetValue(IconPaddingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconPadding.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconPaddingProperty =
            DependencyProperty.Register("IconPadding", typeof(Thickness), typeof(ExIconTextBoxBase), new PropertyMetadata(new Thickness(0)));





        public CornerRadius IconCornerRadius
        {
            get { return (CornerRadius)GetValue(IconCornerRadiusProperty); }
            set { SetValue(IconCornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconCornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconCornerRadiusProperty =
            DependencyProperty.Register("IconCornerRadius", typeof(CornerRadius), typeof(ExIconTextBoxBase), new PropertyMetadata(new CornerRadius(0)));





        public Geometry IconPathData
        {
            get { return (Geometry)GetValue(IconPathDataProperty); }
            set { SetValue(IconPathDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconPathData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconPathDataProperty =
            DependencyProperty.Register("IconPathData", typeof(Geometry), typeof(ExIconTextBoxBase), new PropertyMetadata(null));


        public ExIconTextBoxBase()
        {
            this.KeyUp += (s, e) =>
            {
                if (e.Key == System.Windows.Input.Key.Enter)
                    OnEnterKeyClick(null, null);
            };
        }
    }
}

