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
using System.Windows.Shapes;

namespace Questionnaire
{
    /// <summary>
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class Student : Window
    {
        public Student()
        {
            InitializeComponent();
        }

        private void BtnDoTest_Click(object sender, RoutedEventArgs e)
        {
            Test test = new Test();

            this.Hide();

            test.Show();
        }

        private void BtnResults_Click(object sender, RoutedEventArgs e)
        {
            SeeMarkByStudent seeMark = new SeeMarkByStudent();

            this.Hide();

            seeMark.Show();


        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow m = new MainWindow();
            m.Show();

        }
    }
}
