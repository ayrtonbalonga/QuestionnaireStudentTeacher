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
    /// Interaction logic for Teacher.xaml
    /// </summary>
    public partial class Teacher : Window
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void BtnSetTest_Click(object sender, RoutedEventArgs e)
        {
            SetTest st = new SetTest();


            this.Hide();


            st.Show();
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow m = new MainWindow();
            m.Show();
        }

        private void BtnSeeMark_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            SeeMarkByTeacher sm = new SeeMarkByTeacher();
            sm.Show();
        }
    }
}
