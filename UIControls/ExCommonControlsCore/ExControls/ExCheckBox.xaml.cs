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

    public enum CheckBoxType
    {
        /// <summary>
        /// 方形的CheckBox
        /// </summary>
        Square,
        /// <summary>
        /// 圆形的CheckBox
        /// </summary>
        Ellipse,
        /// <summary>
        /// 带勾的
        /// </summary>
        CircleTick
    }

    /// <summary>
    /// Interaction logic for ExCheckBox.xaml
    /// </summary>
    public partial class ExCheckBox : CheckBox
    {
        static ExCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExCheckBox), new FrameworkPropertyMetadata(typeof(ExCheckBox)));
        }

        #region 依赖属性
        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register("Type"
            , typeof(CheckBoxType), typeof(ExCheckBox), new PropertyMetadata(CheckBoxType.Square));
        /// <summary>
        /// CheckBox皮肤样式
        /// </summary>
        public CheckBoxType Type
        {
            get { return (CheckBoxType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly DependencyProperty UnCheckedColorProperty = DependencyProperty.Register("UnCheckedColor"
            , typeof(Brush), typeof(ExCheckBox));
        /// <summary>
        /// CheckBox未选中时的颜色
        /// </summary>
        public Brush UnCheckedColor
        {
            get { return (Brush)GetValue(UnCheckedColorProperty); }
            set { SetValue(UnCheckedColorProperty, value); }
        }

        public static readonly DependencyProperty CheckedColorProperty = DependencyProperty.Register("CheckedColor"
            , typeof(Brush), typeof(ExCheckBox));
        /// <summary>
        /// CheckBox选中后的颜色
        /// </summary>
        public Brush CheckedColor
        {
            get { return (Brush)GetValue(CheckedColorProperty); }
            set { SetValue(CheckedColorProperty, value); }
        }
        #endregion
    }
}
