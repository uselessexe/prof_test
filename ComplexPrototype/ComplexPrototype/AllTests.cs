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
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace ComplexPrototype
{
    public partial class AllTests : Form
    {
        List<QuestionsAndAnswers> qaaList;
        List<Results> ResList;
        List<int> Answers = new List<int>();
        NpgsqlConnection con = new NpgsqlConnection();
        //DataTable questions = new DataTable();
        //DataTable resultsDT = new DataTable();
        
        int i;
        int testID;
        int UserID;
        public AllTests(NpgsqlConnection con,int testID, int UserID)
        {
            InitializeComponent();

            this.con = con;
            this.testID = testID;
            this.UserID = UserID;

            label2.Text = ""; 
        }
        private void AllTests_Load(object sender, EventArgs e)
        {
            chart1.Visible = false;
            buttonNext.Enabled = false;
            try
            {
                QuestionsAndAnswers QAA = new QuestionsAndAnswers();
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($" http://localhost:8080/api/TestQuestAns/{testID}");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (result != "")
                    {
                        qaaList = QAA.JsonParse(result);
                        /*if (qaaList[0].QuestionText.ToString() != "NULL") */label1.Text = qaaList[0].QuestionText.ToString();
                        ButtonA.Text =  qaaList[i].AnswerText.ToString();
                        ButtonB.Text = qaaList[i+1].AnswerText.ToString();
                    }

                }
                /*con.Open();
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter($"SELECT * FROM \"Question\" q JOIN \"Answer\" a on (a.\"QuestionID\"=q.\"QuestionID\")" +
                                                             $" WHERE \"TestID\" = {testID} " +
                                                             $"ORDER BY a.\"QuestionID\",\"AnswerID\"", con);
                //SELECT* FROM "Question" q JOIN "Answer" a on (a."QuestionID"=q."QuestionID") WHERE "TestID" = 3
                DA.Fill(questions);

                if(questions.Rows[0][1].ToString()!="NULL") label1.Text = questions.Rows[0][1].ToString();
                ButtonA.Text = questions.Rows[i][5].ToString();
                ButtonB.Text = questions.Rows[i + 1][5].ToString();
                con.Close();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //con.Close();
            }
        }
    
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (i < qaaList.Count - 2)
            {
                AnswerKeep();
                i += 2;
                label1.Text = qaaList[i].QuestionText.ToString();
                ButtonA.Text = qaaList[i].AnswerText.ToString();
                ButtonB.Text = qaaList[i+1].AnswerText.ToString();
            }
            else
            {
                EndTest();
            }
            if (i == qaaList.Count - 2)
            {
                buttonNext.Text = "Завершить";
            }
            ButtonA.Checked = false;
            ButtonB.Checked = false;
            buttonNext.Enabled = false;

        }
        private void AnswerKeep()
        {
            if (ButtonA.Checked == true)
            {
                if (qaaList[i].ResultID.ToString() != "") Answers.Add(Convert.ToInt32(qaaList[i].ResultID));//добавляется id результата, на который повлияет ответ      
            }
            else
            {
                string s = qaaList[i+1].ResultID.ToString();//для проверки в отладке
                if (qaaList[i+1].ResultID.ToString() != "") Answers.Add(Convert.ToInt32(qaaList[i+1].ResultID));
            }

        }
        private void EndTest()
        {
            chart1.Visible = true;
            label1.Text = "Результаты теста представлены на диаграмме. Чтобы отобразить рекомендации, наведите курсор мыши на нужный результат.";
            buttonNext.Visible = false;
            ButtonA.Visible = false;
            ButtonB.Visible = false;
            AnswerKeep();

            try
            {
                Results results = new Results();
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($" http://localhost:8080/api/TestResults/{testID}");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (result != "")
                    {
                        ResList = results.JsonParse(result);

                        List<int> listResID = new List<int>();//список с количеством результатов

                        string stringResultList = "";
                        for (int j = 0; j < ResList.Count; j++)
                        {
                            listResID.Add(0);
                            //int num = Convert.ToInt32(Convert.ToInt32(questions.Rows[j][7]));
                            for (int k = 0; k < Answers.Count; k++)
                            {
                                if (Convert.ToInt32(ResList[j].ResultID) == Answers[k]) listResID[j]++;
                            }
                        }

                        for (int j = 0; j < ResList.Count; j++)
                        {


                            double resultPercent = 100 * Convert.ToDouble(listResID[j]) / Convert.ToDouble(listResID.Sum());//резульат в процентах

                            chart1.Series["Series1"].Points.AddXY(ResList[j].ResultName.ToString(), resultPercent);
                            chart1.Series["Series1"].Points[j].LabelFormat = "{0.00}%";
                            chart1.Series["Series1"].Points[j].LabelToolTip = $"{ResList[j].Description.ToString()}";

                            //label2.Text += $"| {resultsDT.Rows[j][1]} = {result[j]} |\n";

                            stringResultList += $"{ResList[j].ResultName.ToString()} = {String.Format("{0:f2}", resultPercent)} %;";

                        }
                        
                        
                        con.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand($"INSERT INTO \"ResultHistory\"(\"UserID\",\"Date\",\"TestID\",\"Statistics\")" +
                        $" VALUES('{UserID}','{DateTime.Now}',{testID},'{stringResultList}')", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        
                        
                        /*httpWebRequest = (HttpWebRequest)WebRequest.Create($"  http://localhost:8080/api/TestRecResults");
                            httpWebRequest.ContentType = "application/json";
                            httpWebRequest.Method = "POST";

                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {

                                string json = "{\"UserID\":" + UserID + "," +
                                          "\"Date\":\"" + DateTime.Today + "\"," +
                                          "\"TestID\":" + testID + "," +
                                          "\"Statistics\":\"" + stringResultList + "\"}";



                                streamWriter.Write(json);
                            }
                         response = (HttpWebResponse)httpWebRequest.GetResponse();*/
                    }

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //con.Close();
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

        private void AllTests_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            PersonalPage form = new PersonalPage(UserID, con);
            form.ShowDialog();
        }
    }    
}
