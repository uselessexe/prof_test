using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.SqlClient;

namespace ComplexPrototype
{
    public partial class Test3 : Form
    {
        NpgsqlConnection con = new NpgsqlConnection();
        DataTable questions = new DataTable();
        DataTable resultsDT = new DataTable();
        List<int> Answers = new List<int>();
        int i;
        int UserID;
        public Test3(NpgsqlConnection con,int UserID)
        {
            InitializeComponent();
            this.con = con;
            this.UserID = UserID;

            label2.Text = "";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            chart1.Visible = false;
            buttonNext.Enabled = false;
            try
            {
                con.Open();
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter($"SELECT * FROM \"Question\" q JOIN \"Answer\" a on (a.\"QuestionID\"=q.\"QuestionID\") WHERE \"TestID\" = 3", con);

                DA.Fill(questions);
                label1.Text = questions.Rows[0][1].ToString();
                ButtonA.Text = questions.Rows[i][5].ToString();
                ButtonB.Text = questions.Rows[i + 1][5].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            
            
            if (i < questions.Rows.Count - 2)
            {   
                AnswerKeep();
                i += 2;
                label1.Text = questions.Rows[i][1].ToString();
                ButtonA.Text = questions.Rows[i][5].ToString();
                ButtonB.Text = questions.Rows[i + 1][5].ToString();
            }
            else
            {
                EndTest();
            }
            if (i == questions.Rows.Count - 2)
            {
                buttonNext.Text = "Завершить";
            }
            ButtonA.Checked = false;
            ButtonB.Checked = false;
            buttonNext.Enabled = false;
        }
        private void AnswerKeep()
        {

            if (ButtonA.Checked == true) Answers.Add(Convert.ToInt32(questions.Rows[i][7]));//добавляется id результата, на который повлияет ответ
            else Answers.Add(Convert.ToInt32(questions.Rows[i + 1][7]));
            
        }
        private void EndTest()
        {
            chart1.Visible = true;
            label1.Text = "Результаты теста представлены на диаграмме. Чтобы отобразить рекомендации, наведите курсор мыши на нужный результат.";
            buttonNext.Visible = false;
            ButtonA.Visible = false;
            ButtonB.Visible = false;
            AnswerKeep();
            int[] result = new int[6];

            foreach (int a in Answers)
            {
                switch (a)
                {
                    case 12: result[0]++; break;
                    case 13: result[1]++; break;
                    case 14: result[2]++; break;
                    case 15: result[3]++; break;
                    case 16: result[4]++; break;
                }
            }
            try
            {
                con.Open();
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter($"SELECT * FROM \"Result\" WHERE \"TestID\" = 3 ", con);
                DA.Fill(resultsDT);


                string ResultList = "";
                for (int j = 0; j < resultsDT.Rows.Count; j++)
                {
                    double resultPercent = 100 * Convert.ToDouble(result[j]) / Convert.ToDouble(result.Sum());//резульат в процентах

                    chart1.Series["Series1"].Points.AddXY(resultsDT.Rows[j][1].ToString(),resultPercent);
                    chart1.Series["Series1"].Points[j].LabelFormat = "{0.00}%";
                    chart1.Series["Series1"].Points[j].LabelToolTip = $"{resultsDT.Rows[j][3].ToString()}";

                    label2.Text += $"| {resultsDT.Rows[j][1]} = {result[j]} |\n";

                    ResultList += $"{resultsDT.Rows[j][1].ToString()} = {String.Format("{0:f2}", resultPercent)} %;";
                }


                NpgsqlCommand cmd = new NpgsqlCommand($"INSERT INTO \"ResultHistory\"(\"UserID\",\"Date\",\"TestID\",\"Statistics\")" +
                        $" VALUES('{UserID}','{DateTime.Now}',{3},'{ResultList}')", con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }


        private void ButtonA_CheckedChanged(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
        }

        private void ButtonB_CheckedChanged(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
        }

        private void Test3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            PersonalPage form = new PersonalPage(UserID,con);
            form.ShowDialog();
        }

    }
}
