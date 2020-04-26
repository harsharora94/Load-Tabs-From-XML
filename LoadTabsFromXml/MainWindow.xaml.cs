using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace LoadTabsFromXml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadXml();
        }

        private void LoadXml()
        {
            string filename = System.Windows.Forms.Application.StartupPath;
            filename = System.IO.Path.Combine(filename, "..\\..");
            filename = Path.GetFullPath(filename) + "\\XMLFile.xml";
            DeserializeTreeView(mainGrid, filename);
        }

        private void DeserializeTreeView(Grid mainGrid, string filename)
        {
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.Load(filename);

            var tabControl = xml_doc.DocumentElement.Name;
            TabControl tbc = null;
            if (tabControl == "TabControl")
            {
                 tbc = new TabControl();
            }

            Debug.WriteLine(tabControl);

            foreach (XmlNode child_node in xml_doc.DocumentElement.ChildNodes)
            {
                var item = child_node.Name;
                TabItem tbItem;
                if (item == "TabItem")
                {
                    tbItem = new TabItem();
                    tbItem.Header = "Hello Tabs";
                    tbc.Items.Add(tbItem);
                    
                }
             
                Debug.WriteLine(item);
            }

            mainGrid.Children.Add(tbc);
        }
    }
}