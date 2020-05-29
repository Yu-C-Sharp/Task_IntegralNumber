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
using ClassLibraryNumber;
using DatabaseConnection;
using ConsoleDataEntryAndProcessing;

namespace WpfAppIntegralNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DbMethodes query = new DbMethodes();
            Output.Text = "ID" + "\t::\t" + "Number\t" + "\t::\t" + "Result\n";// Костиль...
            foreach (Number n in query.UploadFromDbLastFiveResults())
            {
                Output.Text += ($"{n.NumberID} \t::\t {n.Num}\t\t::\t[{n.Result}]\n");
            }
            if (query.UploadFromDbLastFiveResults().Count() < 5) Output.Text += "There are no more results in Database...";
        }

        ApplicationContext db = new ApplicationContext(CreateOptions.JSON_FILE_Configuration());

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string input = Input.Text;
            ControlInput num = new ControlInput();
            if (!num.Check(input)) MessageBox.Show("Incorrect Input");
            else
            {
                Number _Input = new Number() { Num = Convert.ToInt32(input) };
                Calculate Calculator = new Calculate();
                Calculator.Squaring(_Input);
                db.Numbers.Add(_Input);
                db.SaveChanges();
                Result.Text = $"[{_Input.Result}]";
            }
        }
        private void Result_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
