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
  

    [TemplatePart(Name = "PART_Clear", Type = typeof(Path))]
    [TemplatePart(Name = "PART_ContentHost", Type = typeof(ScrollViewer))]
    /// <summary>
    /// ExFlatButton.xaml 的交互逻辑
    /// </summary>
    public partial class ExTitleTextBox : TextBox
    {
        static ExTitleTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExTitleTextBox), new FrameworkPropertyMetadata(typeof(ExTitleTextBox)));
        }


        private Path PART_Clear;
        private ScrollViewer PART_ContentHost;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PART_Clear = Template.FindName("PART_Clear", this) as Path;
            if (PART_Clear != null) PART_Clear.MouseLeftButtonDown += (d, e) => this.Text = "";
            PART_ContentHost = Template.FindName("PART_ContentHost", this) as ScrollViewer;

            this.PreviewMouseWheel += ExTitleTextBox_PreviewMouseWheel;
        }

        private void ExTitleTextBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (this.PART_ContentHost != null)
            {
                this.PART_ContentHost.ScrollToVerticalOffset(this.PART_ContentHost.VerticalOffset - e.Delta);
            }
        }




        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ExTitleTextBox), new PropertyMetadata(""));



        public bool ShowTitle
        {
            get { return (bool)GetValue(ShowTitleProperty); }
            set { SetValue(ShowTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowTitleProperty =
            DependencyProperty.Register("ShowTitle", typeof(bool), typeof(ExTitleTextBox), new PropertyMetadata(true));



        public bool CanClear
        {
            get { return (bool)GetValue(CanClearProperty); }
            set { SetValue(CanClearProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanClear.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanClearProperty =
            DependencyProperty.Register("CanClear", typeof(bool), typeof(ExTitleTextBox), new PropertyMetadata(true));




        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ExTitleTextBox), new PropertyMetadata(new CornerRadius(3)));



    }
}


