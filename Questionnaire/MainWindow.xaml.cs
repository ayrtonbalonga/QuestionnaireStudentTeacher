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
using System.Windows.Navigation;
using System.Windows.Shapes;
using userDetails;

namespace Questionnaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\PROGRAMMING POE\Questionnaire\Questionaire.mdf;Integrated Security=True;Connect Timeout=30");
        public String[,] teacher = new string[100, 8];
        public String[,] Student = new string[100, 9];
        public static string studentid;
        public static string getStudentId(string studentid)
        {
            return studentid;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CbChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            readData();

            readData2();

            if (cbChoose.Text == "Teacher")
            {
                checkAndLogInTeacher();
            }else 
            if (cbChoose.Text == "Student")
            {
                checkAndLogInStudent();
            }
            else
            {
                MessageBox.Show("Can you choose who you are *Teacher* or *Student*");
            }

        }
        public void checkAndLogInTeacher()
        {
            Boolean isCorrect = false;

            string username, password;
            String[,] user = new string[100, 2];


            username = tbUserName.Text;
            password = tbPassword.Text;

            for (int i = 0; i < 100; i++)
            {

                if ((username == teacher[i, 6]) && (password == teacher[i, 7]))
                {
                    isCorrect = true;
                    this.Hide();
                    Teacher t = new Teacher();

                    t.Show();





                }

            }
            if (isCorrect == false)
            {
                
                MessageBox.Show("the username or passowrd is incorrect");

            }
        }

        public void checkAndLogInStudent()
        {
            Boolean isCorrect = false;

            string username, password;
            username = tbUserName.Text;
            password = tbPassword.Text;

            for (int i = 0; i < 100; i++)
            {

                if ((username == Student[i, 7]) && (password == Student[i, 8]))
                {
                    studentid = Student[i, 0] ;

                    isCorrect = true;
                    this.Hide();
                    
                    Student s = new Student();
                    s.Show();

                }

            }
            if (isCorrect == false)
            {

                MessageBox.Show("the username or passowrd is incorrect");

            }
        }

        public void readData()
        {
            conn.Open();
            string refresh = "SELECT * FROM Teacher";

            SqlDataAdapter cmd = new SqlDataAdapter(refresh, conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);

            conn.Close();
            int a = 0;

            foreach (DataRow row in dt.Rows)
            {


                teacher[a, 0] = row["teacherId"].ToString();
                teacher[a, 1] = row["Name"].ToString();
                teacher[a, 2] = row["Surname"].ToString();
                teacher[a, 3] = row["Modules"].ToString();

                teacher[a, 4] = row["Email"].ToString();
                teacher[a, 5] = row["Cell"].ToString();
                teacher[a, 6] = row["Username"].ToString();
                teacher[a, 7] = row["Password"].ToString();

                a++;




            }
        }
        public void readData2()
        {
            conn.Open();
            string refresh = "SELECT * FROM Student";

            SqlDataAdapter cmd = new SqlDataAdapter(refresh, conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);

            conn.Close();
            int a = 0;

            foreach (DataRow row in dt.Rows)
            {


                Student[a, 0] = row["studentId"].ToString();
                Student[a, 1] = row["Name"].ToString();
                Student[a, 2] = row["Surname"].ToString();
                Student[a, 3] = row["Program"].ToString();

                Student[a, 4] = row["Email"].ToString();

                Student[a, 5] = row["CellNumber"].ToString();
                Student[a, 6] = row["StudentNumber"].ToString();
                Student[a, 7] = row["username"].ToString();
                Student[a, 8] = row["password"].ToString();

                a++;




            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            tbPassword.Clear();
            tbUserName.Clear();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public static class myGlobal
        {
            public static string studentId = getStudentId(studentid);
        }
    }
}
