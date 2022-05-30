using MenuContainerModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ExMenuContainer : UserControl
    {
        static ExMenuContainer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExMenuContainer), new FrameworkPropertyMetadata(typeof(ExMenuContainer)));
        }


        public ExMenuContainer()
        {

        }

        public ObservableCollection<MenuItemModel> Menus
        {
            get { return (ObservableCollection<MenuItemModel>)GetValue(MenusProperty); }
            set { SetValue(MenusProperty, value); }
        }
        public static readonly DependencyProperty MenusProperty =
            DependencyProperty.Register("Menus", typeof(ObservableCollection<MenuItemModel>),
                typeof(ExMenuContainer),
                new PropertyMetadata(new ObservableCollection<MenuItemModel>()));
    }
}

