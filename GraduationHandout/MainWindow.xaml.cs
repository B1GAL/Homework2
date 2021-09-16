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

namespace GraduationHandout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            bool infoCorrect = true;

            if (string.IsNullOrWhiteSpace(txtState.Text) == true)
            {
                infoCorrect = false;
                MessageBox.Show("Enter a real State");   //good
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text) == true)
            {
                infoCorrect = false;
                MessageBox.Show("Enter an actual City");//good
            }

            if (string.IsNullOrWhiteSpace(txtFname.Text) == true)
            {
                infoCorrect = false;
                MessageBox.Show("Input valid first name");//good
            }

            if (string.IsNullOrWhiteSpace(txtLname.Text) == true)
            {
                infoCorrect = false;
                MessageBox.Show("Enter real Lastname");//good
            }
            double gpa;
            if (double.TryParse(txtGpa.Text, out gpa) == false)
            {
                infoCorrect = false;
                MessageBox.Show("Please enter valid GPA number");//good?
            }

            if (string.IsNullOrWhiteSpace(txtMajor.Text) == true)
            {
                infoCorrect = false;
                MessageBox.Show("Enter a valid major that OU offers");//good
            }

            if (string.IsNullOrWhiteSpace(txtSnumber.Text) == true)
            {
                infoCorrect = false;
                MessageBox.Show("Enter a real street number");//good
            }

            if (string.IsNullOrWhiteSpace(txtSname.Text) == true)
            {
                infoCorrect = false;
                MessageBox.Show("Enter a valid street name");//good
            }

            if (string.IsNullOrWhiteSpace(txtZip.Text) == true)
            {
                infoCorrect = false;
                MessageBox.Show("Enter a real zipcode");//good
            }
        }
    }
}
