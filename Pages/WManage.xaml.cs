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
using static MyNewApp.Common.PluginBase;
using static MyNewApp.Pages.WidgetsList;

namespace MyNewApp.Pages
{
    /// <summary>
    /// WManage.xaml 的交互逻辑
    /// </summary>
    public partial class WManage : Page
    {
        public WManage()
        {
            InitializeComponent();
            wiLV.ItemsSource = widgetInstances;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InstancesOnDisplay = new List<WidgetInstance>();
            foreach (var item in widgetInstances)
            {
                if(item.Plugin ==((ComboBox)sender).SelectedItem)
                {
                    InstancesOnDisplay.Add(item);
                }
            }
            //pluginFilter.ItemsSource = InstancesOnDisplay;
            wiLV.ItemsSource=InstancesOnDisplay;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pluginFilter.SelectedItem = null;
            wiLV.ItemsSource = widgetInstances;

        }

        private void ScrollViewer_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;

        }
    }

    public static class WidgetsList
    {
        public static MainWindow MainWindow { get; set; }

        public class WidgetInstance : NotifyBase
        {
            private UserControl _widget;


            public UserControl widget
            {
                get { return _widget; }
                set { _widget = value; this.DoNotify(); }
            }

            private IPlugin _plugin;

            public IPlugin Plugin
            {
                get { return _plugin; }
                set { _plugin = value; DoNotify(); }
            }


            private bool _enabled;

            public bool Enabled
            {
                get { return _enabled; }
                set
                {

                    _enabled = value;
                    if (value)
                    {
                        MainWindow.RefreshWidgets();
                    }
                    else
                    {
                        IWidgetBase iw = (IWidgetBase)widget;

                        if (iw.action != null)
                        {
                            MainWindow.SaveWidgetStatue();
                            iw.action.Invoke();
                        }
                    }
                    this.DoNotify();
                }
            }

            public Point point { get; set; }


        }

        public static List<WidgetInstance> widgetInstances { get; set; }

        private static List<WidgetInstance> _InstancesOnDisplay { get; set; }

        public static List<WidgetInstance> InstancesOnDisplay
        {
            get { return _InstancesOnDisplay; }
            set { _InstancesOnDisplay = value; }
        }


    }

}
