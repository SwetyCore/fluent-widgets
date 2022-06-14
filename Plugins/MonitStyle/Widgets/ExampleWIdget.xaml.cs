using MyNewApp.Common;
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

namespace MonitStyle.Widgets
{
    /// <summary>
    /// ExampleWIdget.xaml 的交互逻辑
    /// </summary>
    public partial class ExampleWIdget : UserControl,IWidgetBase
    {
        int WidgetHeight => 230;
        int WidgetWidth => 230;

        string WidgetName => "未命名";
        string Description => "描述";


        string Icon => "";

        string GUID => "example.empty";

        bool WCanResize => false;

        public Action action { get; set; } = null;

        public ExampleWIdget()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //

        }
    }
}
