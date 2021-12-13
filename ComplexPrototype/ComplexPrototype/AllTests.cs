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
    public partial class AllTests : Form
    {
        NpgsqlConnection con = new NpgsqlConnection();
        DataTable questions = new DataTable();
        DataTable resultsDT = new DataTable();
        List<int> Answers = new List<int>();
        int i;
        int testID;
        public AllTests(NpgsqlConnection con,int testID)
        {
            InitializeComponent();

            buttonEnd.Enabled = false;
            this.con = con;
            this.testID = testID;

            label2.Text = ""; 
        }
        private void AllTests_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter($"SELECT * FROM \"Question\" q JOIN \"Answer\" a on (a.\"QuestionID\"=q.\"QuestionID\") WHERE \"TestID\" = {testID}", con);
                //SELECT* FROM "Question" q JOIN "Answer" a on (a."QuestionID"=q."QuestionID") WHERE "TestID" = 3
                DA.Fill(questions);

                if(questions.Rows[0][1].ToString()!="NULL") label1.Text = questions.Rows[0][1].ToString();
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
            buttonNext.Enabled = false;
            AnswerKeep();
            ButtonA.Checked = false;
            ButtonB.Checked = false;
        }
        private void AnswerKeep()
        {
            if (ButtonA.Checked == true) Answers.Add(Convert.ToInt32(questions.Rows[i][7]));//добавляется id результата, на который повлияет ответ
            else Answers.Add(Convert.ToInt32(questions.Rows[i + 1][7]));

            if (i < questions.Rows.Count - 2)
            {
                i += 2;
                if (questions.Rows[0][1].ToString() != "NULL") label1.Text = questions.Rows[i][1].ToString();
                ButtonA.Text = questions.Rows[i][5].ToString();
                ButtonB.Text = questions.Rows[i + 1][5].ToString();
            }
            if (i == questions.Rows.Count - 2)
            {

                buttonNext.Enabled = false;
                buttonEnd.Enabled = true;
            }
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            AnswerKeep();
            buttonEnd.Enabled = false;
            try
            {
                con.Open();
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter($"SELECT * FROM \"Result\" WHERE \"TestID\" = {testID} ", con);//вывод списка результатов
                DA.Fill(resultsDT);

                List<int> result = new List<int>();//список с количеством результатов
                for (int j = 0; j < resultsDT.Rows.Count; j++)//заполнение массива result
                {
                    result.Add(0);
                    int num = Convert.ToInt32(Convert.ToInt32(questions.Rows[j][7]));
                    for (int k = 0; k < Answers.Count; k++)
                    {
                        if (Convert.ToInt32(resultsDT.Rows[j][0]) == Answers[k]) result[j]++;
                    }
                    
                    chart1.Series["Series1"].Points.AddXY(resultsDT.Rows[j][1].ToString(), result[j]);//заполнение диаграммы
                    label2.Text += $"| {resultsDT.Rows[j][1]} = {result[j]} |\n";
                }   
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }


        }
    }    
}
