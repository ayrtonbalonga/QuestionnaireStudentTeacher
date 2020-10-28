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
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\PROGRAMMING POE\Questionnaire\Questionaire.mdf;Integrated Security=True;Connect Timeout=30");

        public String[,] Data = new string[100, 25];
        public static string testId;
        public string[,] answer = new string[10, 4];

        public Test()
        {
            InitializeComponent();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        public void CollectData()
        {

            conn.Open();
            string getStudentInfo = "SELECT * FROM Questions";

            SqlDataAdapter cmd = new SqlDataAdapter(getStudentInfo, conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);

            conn.Close();

            int a = 0;

            foreach (DataRow row in dt.Rows)
            {


                Data[a, 0] = row["TestId"].ToString();

                Data[a, 1] = row["Question1"].ToString();
                Data[a, 2] = row["Question1A"].ToString();
                Data[a, 3] = row["Question1B"].ToString();
                Data[a, 4] = row["Question1C"].ToString();
                Data[a, 5] = row["Question1D"].ToString();
                Data[a, 6] = row["Answer1"].ToString();


                Data[a, 7] = row["Question2"].ToString();
                Data[a, 8] = row["Question2A"].ToString();
                Data[a, 9] = row["Question2B"].ToString();
                Data[a, 10] = row["Question2C"].ToString();
                Data[a, 11] = row["Question2D"].ToString();
                Data[a, 12] = row["Answer2"].ToString();


                Data[a, 13] = row["Question3"].ToString();
                Data[a, 14] = row["Question3A"].ToString();
                Data[a, 15] = row["Question3B"].ToString();
                Data[a, 16] = row["Question3C"].ToString();
                Data[a, 17] = row["Question3D"].ToString();
                Data[a, 18] = row["Answer3"].ToString();


                Data[a, 19] = row["Question4"].ToString();
                Data[a, 20] = row["Question4A"].ToString();
                Data[a, 21] = row["Question4B"].ToString();
                Data[a, 22] = row["Question4C"].ToString();
                Data[a, 23] = row["Question4D"].ToString();
                Data[a, 24] = row["Answer4"].ToString();


                a++;

            }
        }



        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            this.Hide();
            student.Show();

        }



        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {


            testId = tbSearch.Text;
            CollectData();

            for (int i = 0; i < 100; i++)
            {
                if (Data[i, 0] == testId)
                {
                    tbQuestion1.Text = Data[i, 1];
                    tbQuestion1a.Text = Data[i, 2];
                    tbQuestion1b.Text = Data[i, 3];
                    tbQuestion1c.Text = Data[i, 4];
                    tbQuestion1d.Text = Data[i, 5];
                    //  tbAnswer1.Text = Data[i, 6];

                    tbQuestion2.Text = Data[i, 7];
                    tbQuestion2a.Text = Data[i, 8];
                    tbQuestion2b.Text = Data[i, 9];
                    tbQuestion2c.Text = Data[i, 10];
                    tbQuestion2d.Text = Data[i, 11];
                    //  tbAnswer2.Text = Data[i, 12];

                    tbQuestion3.Text = Data[i, 13];
                    tbQuestion3a.Text = Data[i, 14];
                    tbQuestion3b.Text = Data[i, 15];
                    tbQuestion3c.Text = Data[i, 16];
                    tbQuestion3d.Text = Data[i, 17];
                    //tbAnswer3.Text = Data[i, 18];

                    tbQuestion4.Text = Data[i, 19];
                    tbQuestion4a.Text = Data[i, 20];
                    tbQuestion4b.Text = Data[i, 21];
                    tbQuestion4c.Text = Data[i, 22];
                    tbQuestion4d.Text = Data[i, 23];
                    //tbAnswer4.Text = Data[i, 24];

                }
            }



        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string answer1 = "";
            string answer2 = "";
            string answer3 = "";
            string answer4 = "";
            int[,] Mark = new int[1,4];
            int totalMark = 0;
            //CollectData();
            int index = Int32.Parse(testId) - 1;


            if ((tbAnswer1.Text=="") || (tbAnswer2.Text=="") || (tbAnswer3.Text=="") ||(tbAnswer4.Text==""))
            {
                MessageBox.Show("Please make sure all the questions has answers.");

            }else
            {

                if (tbAnswer1.Text == Data[index, 6])
                {
                    answer1 = tbAnswer1.Text;

                    Mark[0, 0] = 5;

                }
                else
                {
                    Mark[0, 0] = 0;
                }

                if (tbAnswer2.Text == Data[index, 12])
                {
                    answer2 = tbAnswer2.Text;
                    Mark[0, 1] = 5;
                }
                else
                {
                    Mark[0, 1] = 0;
                }

                if (tbAnswer3.Text == Data[index, 18])
                {
                    answer3 = tbAnswer3.Text;
                    Mark[0, 2] = 5;
                }
                else
                {
                    Mark[0, 2] = 0;
                }

                if (tbAnswer4.Text == Data[index, 24])
                {
                    answer4 = tbAnswer4.Text;
                    Mark[0, 3] = 5;
                }
                else
                {
                    Mark[0, 3] = 0;
                }
                //int x = Mark
                totalMark = Mark[0, 0] + Mark[0, 1] + Mark[0, 2] + Mark[0, 3];

                setAnswerAndMark(totalMark, answer1, answer2, answer3, answer4);


            }

        }



        public void setAnswerAndMark(int Mark, string answer1, string answer2, string answer3, string answer4)
        {
            try
            {
                conn.Open();

                String sqlInsertMark = "insert into Mark(TestId,StudentId,Mark,Date,Answer1,Answer2,Answer3,Answer4 ) Values(@TestId, " +
                    "@StudentId,@Mark, @Date,@Answer1,@Answer2,@Answer3,@Answer4)";



                SqlCommand commad = new SqlCommand(sqlInsertMark, conn);



                commad.Parameters.AddWithValue("@TestId", Int32.Parse(testId));
                commad.Parameters.AddWithValue("@StudentId", Int32.Parse(myGlobal.studentId));
                commad.Parameters.AddWithValue("@Mark", Mark);
                commad.Parameters.AddWithValue("@Date", DateTime.Now);
                commad.Parameters.AddWithValue("@Answer1", tbAnswer1.Text);
                commad.Parameters.AddWithValue("@Answer2", tbAnswer2.Text);
                commad.Parameters.AddWithValue("@Answer3", tbAnswer3.Text);
                commad.Parameters.AddWithValue("@Answer4", tbAnswer4.Text);



                commad.ExecuteNonQuery();
                MessageBox.Show("The test have been saved and submitted succesfuly");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }
    }
}
