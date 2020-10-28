using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using static Questionnaire.MainWindow;

namespace Questionnaire
{
    /// <summary>
    /// Interaction logic for SeeMarkByStudent.xaml
    /// </summary>
    public partial class SeeMarkByStudent : Window
    {

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\PROGRAMMING POE\Questionnaire\Questionaire.mdf;Integrated Security=True;Connect Timeout=30");

        public String[,] Data = new string[100, 4];
        public String[,] arrMark = new string[100, 4];

        public SeeMarkByStudent()
        {
            InitializeComponent();
        }

       
        public void CollectData()
        {

            conn.Open();
            string getStudentInfo = "SELECT * FROM Mark";

            SqlDataAdapter cmd = new SqlDataAdapter(getStudentInfo, conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);

            conn.Close();

            int a = 0;

            foreach (DataRow row in dt.Rows)
            {


                Data[a, 0] = row["StudentId"].ToString();
                Data[a, 1] = row["TestId"].ToString();

                Data[a, 2] = row["Mark"].ToString();
                String Date = row["Date"].ToString();
                Data[a, 3] = Date.Substring(0, 11);

                



                a++;

            }
        }

        public void getMark(string studentNumber)
        {
            Boolean isfound = false ;
            for (int i = 0; i < 100; i++)
            {
                if (Data[i, 0] == studentNumber)
                {

                    isfound = true;

                    for (int j = 0; j < 4; j++)
                    {



                        arrMark[i, j] = Data[i, j];  // store the data in the array



                    }
                    rtbDisplay.AppendText( "Student Number : " + arrMark[i, 0] + "\nTest Id:" + arrMark[i, 1] +
                        "\nMark :" + arrMark[i, 2] + "\nDate:" + arrMark[i, 3] + "\n\n");




                }
                else
                {
                    isfound = false;
                }

            }
            if (isfound == false)
            {
               MessageBox.Show("The student number that you have input is not found, Please try to put a correct one");
            }
        }

        private void BtnDisplay_Click(object sender, RoutedEventArgs e)
        {
            CollectData();

            getMark(myGlobal.studentId);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            this.Hide();
            student.Show();

        }
    }
}
