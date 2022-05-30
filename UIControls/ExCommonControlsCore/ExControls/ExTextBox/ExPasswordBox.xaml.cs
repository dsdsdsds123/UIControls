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

namespace ExCommonControlsCore.ExControls.ExTextBox
{

    /// <summary>
    /// ExFlatButton.xaml 的交互逻辑
    /// </summary>
    [TemplatePart(Name = "PART_CanShowRealPassword", Type = typeof(ToggleButton))]
    public partial class ExPasswordBox : ExIconTextBoxBase
    {
        private bool mIsHandledTextChanged = false;
        static ExPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExPasswordBox), new FrameworkPropertyMetadata(typeof(ExPasswordBox)));
        }

        private void SetText(string str)
        {
            this.mIsHandledTextChanged = false;
            this.Text = str;
            this.mIsHandledTextChanged = true;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.TextChanged += ExPasswordBox_TextChanged;

            SetText(ConvertPasswordToMaskPwd(Password.Length));

            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy, CommandBinding_Executed, CommandBinding_CanExecute));
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
        }


        private void ExPasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!mIsHandledTextChanged) return;
            foreach (TextChange c in e.Changes)
            {
                //从密码文中根据本次Change对象的索引和长度删除对应个数的字符
                this.Password = this.Password.Remove(c.Offset, c.RemovedLength);
                //将Text新增的部分记录给密码文
                this.Password = this.Password.Insert(c.Offset, Text.Substring(c.Offset, c.AddedLength));
            }

            if (!this.ShowRealPassword)
            {
                this.SetText(ConvertPasswordToMaskPwd(Text.Length));
            }

            //将光标放到最后面
            this.SelectionStart = this.Text.Length + 1;
        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(ExPasswordBox), new PropertyMetadata(""));






        public char PasswordChar
        {
            get { return (char)GetValue(PasswordCharProperty); }
            set { SetValue(PasswordCharProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PasswordChar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordCharProperty =
            DependencyProperty.Register("PasswordChar", typeof(char), typeof(ExPasswordBox), new PropertyMetadata('●'));




        public bool CanShowRealPassword
        {
            get { return (bool)GetValue(CanShowRealPasswordProperty); }
            set { SetValue(CanShowRealPasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanShowRealPassword.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanShowRealPasswordProperty =
            DependencyProperty.Register("CanShowRealPassword", typeof(bool), typeof(ExPasswordBox), new PropertyMetadata(true, OnCanSeeRealPassowrdChanged));

        private static void OnCanSeeRealPassowrdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public bool ShowRealPassword
        {
            get { return (bool)GetValue(ShowRealPasswordProperty); }
            set { SetValue(ShowRealPasswordProperty, value); }
        }

        public static readonly DependencyProperty ShowRealPasswordProperty =
            DependencyProperty.Register("ShowRealPassword", typeof(bool), typeof(ExPasswordBox), new PropertyMetadata(false, OnShowRealPasswordChanged));

        //是否显示真实密码改变的时候设置一下需要显示的密码
        private static void OnShowRealPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ExPasswordBox pb = d as ExPasswordBox;
            if (pb != null)
            {
                pb.SetText((bool)e.NewValue ? pb.Password : pb.ConvertPasswordToMaskPwd(pb.Password.Length));
            }
        }


        private string ConvertPasswordToMaskPwd(int len)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Password.Length; i++)
            {
                sb.Append(this.PasswordChar);
            }
            return sb.ToString();
        }
    }
}


