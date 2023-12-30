using System;
using System.Collections.Generic;
using System.IO;
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

namespace CSV_Template_Converter_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string csvFilePath = "C:\\Users\\Joe\\Desktop\\software\\CSV_Template_Converter\\CSV_Template_Converter\\CSV_Template_Converter_GUI\\Data\\Input.csv";

        public MainWindow()
        {
            InitializeComponent();
            SourceTextBlock.Text = File.ReadAllText(csvFilePath);

        }
        public void Save(object sender, EventArgs e)
        {

        }
        public void SelectSource(object sender, EventArgs e)
        {

        }
        public void SelectTemplate(object sender, EventArgs e)
        {

        }
    }
}
