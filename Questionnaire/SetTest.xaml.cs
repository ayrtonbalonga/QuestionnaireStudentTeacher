using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Questionnaire
{
    /// <summary>
    /// Interaction logic for SetTest.xaml
    /// </summary>
    public partial class SetTest : Window
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\PROGRAMMING POE\Questionnaire\Questionaire.mdf;Integrated Security=True;Connect Timeout=30");
        public SetTest()
        {
            InitializeComponent();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
           tbQuestion1.Clear();
             tbQuestion1a.Clear();
             tbQuestion1b.Clear();
             tbQuestion1c.Clear();
             tbQuestion1d.Clear();
             tbAnswer1.Clear();

        tbQuestion2.Clear();
             tbQuestion2a.Clear();
            tbQuestion2b.Clear();
             tbQuestion2c.Clear();
             tbQuestion2d.Clear();
             tbAnswer2.Clear();

             tbQuestion3.Clear();
            tbQuestion3a.Clear();
           tbQuestion3b.Clear();
            tbQuestion3c.Clear();
           tbQuestion3d.Clear();
            tbAnswer3.Clear();


             tbQuestion4.Clear();
            tbQuestion4a.Clear();
           tbQuestion4b.Clear();
             tbQuestion4c.Clear();
            tbQuestion4d.Clear();
            tbAnswer4.Clear();







        }

        private void BtnSetTest_Click(object sender, RoutedEventArgs e)
        {



            if ((tbQuestion1.Text == "") && (tbQuestion2.Text == "") && (tbQuestion3.Text == "") && (tbQuestion4.Text == ""))
            {

                MessageBox.Show("there data you have input is incorrect ");
            }
            else
            {
                try
                {
                    conn.Open();

                    String sqlInsert = "insert into Questions(Question1, Question1A,Question1B, Question1C,Question1D, Answer1, Question2," +
                        "Question2A,Question2B,Question2C,Question2D,Answer2,Question3,Question3A,Question3B,Question3C,Question3D,Answer3," +
                        "Question4,Question4A,Question4B,Question4C,Question4D,Answer4) Values(@Question1, @Question1A,@Question1B,@Question1C,@Question1D, @Answer1,@Question2," +
                        "@Question2A,@Question2B,@Question2C,@Question2D,@Answer2,@Question3,@Question3A,@Question3B,@Question3C,@Question3D,@Answer3," +
                        "@Question4,@Question4A,@Question4B,@Question4C,@Question4D,@Answer4)";

                   
                    
                    SqlCommand commad = new SqlCommand(sqlInsert, conn);



                    commad.Parameters.AddWithValue("@Question1", tbQuestion1.Text);
                    commad.Parameters.AddWithValue("@Question1A", tbQuestion1a.Text);
                    commad.Parameters.AddWithValue("@Question1B", tbQuestion1b.Text);
                    commad.Parameters.AddWithValue("@Question1C", tbQuestion1c.Text);
                    commad.Parameters.AddWithValue("@Question1D", tbQuestion1d.Text);
                    commad.Parameters.AddWithValue("@Answer1", tbAnswer1.Text);

                    commad.Parameters.AddWithValue("@Question2", tbQuestion2.Text);
                    commad.Parameters.AddWithValue("@Question2A", tbQuestion2a.Text);
                    commad.Parameters.AddWithValue("@Question2B", tbQuestion2b.Text);
                    commad.Parameters.AddWithValue("@Question2C", tbQuestion2c.Text);
                    commad.Parameters.AddWithValue("@Question2D", tbQuestion2d.Text);
                    commad.Parameters.AddWithValue("@Answer2", tbAnswer2.Text);

                    commad.Parameters.AddWithValue("@Question3", tbQuestion3.Text);
                    commad.Parameters.AddWithValue("@Question3A", tbQuestion3a.Text);
                    commad.Parameters.AddWithValue("@Question3B", tbQuestion3b.Text);
                    commad.Parameters.AddWithValue("@Question3C", tbQuestion3c.Text);
                    commad.Parameters.AddWithValue("@Question3D", tbQuestion3d.Text);
                    commad.Parameters.AddWithValue("@Answer3", tbAnswer3.Text);


                    commad.Parameters.AddWithValue("@Question4", tbQuestion4.Text);
                    commad.Parameters.AddWithValue("@Question4A", tbQuestion4a.Text);
                    commad.Parameters.AddWithValue("@Question4B", tbQuestion4b.Text);
                    commad.Parameters.AddWithValue("@Question4C", tbQuestion4c.Text);
                    commad.Parameters.AddWithValue("@Question4D", tbQuestion4d.Text);
                    commad.Parameters.AddWithValue("@Answer4", tbAnswer4.Text);



                    commad.ExecuteNonQuery();
                    MessageBox.Show("Questions have been saved successfully");



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

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();

            Teacher t = new Teacher();
            t.Show();

        }
    }
}
