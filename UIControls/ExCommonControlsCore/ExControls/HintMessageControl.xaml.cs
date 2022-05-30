using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class MessageModel
    {
        public MessageType CurrentMessageType { get; set; } = MessageType.Information;
        public string CurrentMessageTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
        public string CurrentMessageContent { get; set; }
    }

    public enum MessageType
    {
        [Description("正常消息")]
        Information,
        [Description("错误消息")]
        Error,
        [Description("警告消息")]
        Warning,
        [Description("调试消息")]
        Debug
    }

    public class HintMessageControl : Control
    {
        static HintMessageControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HintMessageControl), new FrameworkPropertyMetadata(typeof(HintMessageControl)));
        }


        private RoutedCommand ClearCommandRouted = new RoutedCommand();

        public HintMessageControl()
        {
            var cb = new CommandBinding(ClearCommandRouted, ClearExecute, ClearCanExecute);
            this.CommandBindings.Add(cb);

            ClearCommand = ClearCommandRouted;
        }

        private void ClearCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Messages.Count > 0;
            e.Handled = true;
        }

        private void ClearExecute(object sender, ExecutedRoutedEventArgs e)
        {
            Messages.Clear();
            e.Handled = true;
        }




        public System.Windows.Input.ICommand ClearCommand
        {
            get { return (System.Windows.Input.ICommand)GetValue(ClearCommandProperty); }
            set { SetValue(ClearCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ClearCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClearCommandProperty =
            DependencyProperty.Register("ClearCommand", typeof(System.Windows.Input.ICommand), typeof(HintMessageControl), new PropertyMetadata(null));






        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(HintMessageControl), new PropertyMetadata(string.Empty));




        public double MessageFontSize
        {
            get { return (double)GetValue(MessageFontSizeProperty); }
            set { SetValue(MessageFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageFontSizeProperty =
            DependencyProperty.Register("MessageFontSize", typeof(double), typeof(HintMessageControl), new PropertyMetadata(13d));



        public Brush MessageBackground
        {
            get { return (Brush)GetValue(MessageBackgroundProperty); }
            set { SetValue(MessageBackgroundProperty, value); }
        }

        public static readonly DependencyProperty MessageBackgroundProperty =
            DependencyProperty.Register("MessageBackground", typeof(Brush), typeof(HintMessageControl), new PropertyMetadata(Brushes.Transparent));



        public Brush MessageForeground
        {
            get { return (Brush)GetValue(MessageForegroundProperty); }
            set { SetValue(MessageForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageForegroundProperty =
            DependencyProperty.Register("MessageForeground", typeof(Brush), typeof(HintMessageControl), new PropertyMetadata(Brushes.Black));




        public ObservableCollection<MessageModel> Messages
        {
            get { return (ObservableCollection<MessageModel>)GetValue(MessagesProperty); }
            set { SetValue(MessagesProperty, value); }
        }

        public static readonly DependencyProperty MessagesProperty =
            DependencyProperty.Register("Messages", typeof(ObservableCollection<MessageModel>),
                typeof(HintMessageControl), new PropertyMetadata(new ObservableCollection<MessageModel>()));


    }
}
