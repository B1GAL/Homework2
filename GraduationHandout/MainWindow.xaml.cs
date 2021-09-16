using System.Windows;

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

            double gpa;// VVV

            if (double.TryParse(txtGpa.Text, out gpa) == false)
            {
                infoCorrect = false;
                MessageBox.Show("Please enter valid GPA number");//good (Double)
            }

            if (string.IsNullOrWhiteSpace(txtMajor.Text) == true)
            {
                infoCorrect = false;
                MessageBox.Show("Enter a valid major that OU offers");//good
            }

            int streetNumber; // VVV

            if (int.TryParse(txtSnumber.Text, out streetNumber) == false)
            {
                infoCorrect = false;
                MessageBox.Show("Enter a real street number");//Integer
            }

            if (string.IsNullOrWhiteSpace(txtSname.Text) == true)
            {
                infoCorrect = false;
                MessageBox.Show("Enter a valid street name");//good
            }

            int zipcode; // VVV

            if (int.TryParse(txtZip.Text, out zipcode) == false)
            {
                infoCorrect = false;
                MessageBox.Show("Enter a real zipcode");//Integer
            }

            if (infoCorrect == false)
            {
                return;
            }

            Student student = new Student()
            {
                FirstName = txtFname.Text,
                LastName = txtLname.Text,
                GPA = gpa,
                Major = txtMajor.Text,



            };
            student.SetAddress(streetNumber, txtSname.Text, txtCity.Text, txtState.Text, zipcode);


            lstGrad.Items.Add(student);

        }
    }
}
