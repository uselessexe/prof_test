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
    public partial class PersonalPage : Form
    {
        NpgsqlConnection con = new NpgsqlConnection();
        //DataTable history = new DataTable();
        //DataTable tests = new DataTable();
        int id;

        public PersonalPage(int id,NpgsqlConnection con)
        {
            this.id = id;
            this.con = con;
            InitializeComponent();
        }
        public PersonalPage(NpgsqlConnection con)
        {
            this.con = con;
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            comboBox1.Items.Clear();
            comboBox1.Refresh();

            NickName login = new NickName();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($" http://localhost:8080/api/loginPP/{id}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if (result != "")
                {
                    NickName nickname = login.JsonParse(result);
                    labelNickName.Text = $"Имя пользователя: {nickname.Login}";
                }

            }


            Tests tests = new Tests();
            httpWebRequest = (HttpWebRequest)WebRequest.Create($" http://localhost:8080/api/testsPP");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if (result != "")
                {
                    List<Tests> testList = tests.JsonParse(result);
                    foreach (Tests test in testList)
                    {
                        comboBox1.Items.Add(test.TestName);
                    }
                }
            }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label1.Text = comboBox1.Text;
            fillTable(comboBox1.Text);
        }

        private void fillTable(string testName)//выбор конкретного теста(нужен combobox)
        {
            try 
            {
               // history.Rows.Clear();
                dgvHistoryResults.Rows.Clear();
                dgvHistoryResults.Refresh();


                TestHistory TH = new TestHistory();
                var httpWebRequest = (HttpWebRequest)WebRequest.Create($"  http://localhost:8080/api/resultsPP");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {

                    string json = "{\"UserId\":" + id + "," +
                              "\"TestName\":\"" + testName + "\"}";

                    streamWriter.Write(json);
                }

                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (result != "")
                    {
                        List<TestHistory> HistList = TH.JsonParse(result);
                        dgvHistoryResults.RowCount = 1;
                        int rowNum = 0;
                        foreach (TestHistory hist in HistList)
                        {
                            dgvHistoryResults.RowCount++;
                            dgvHistoryResults.Rows[rowNum].Cells[0].Value = hist.Date.ToString();
                            dgvHistoryResults.Rows[rowNum].Cells[1].Value = hist.Statistics.ToString();

                            rowNum++;
                        }
                    }
                }
                /* con.Open();

                NpgsqlDataAdapter DA = new NpgsqlDataAdapter($"SELECT \"Date\",\"Statistics\" FROM \"Users\" u JOIN \"ResultHistory\" rh on(u.\"UserID\"=rh.\"UserID\")" +
                     $"JOIN \"Test\" t on (rh.\"TestID\"=t.\"TestId\")" +
                     $"WHERE u.\"UserID\"={id} AND \"TestName\"='{testName}'" +
                     $"ORDER BY \"ID\" DESC", con);
                 DA.Fill(history);

                 //dgvHistoryResults.DataSource = history.DefaultView;
                 dgvHistoryResults.RowCount = 1;
                 int rowNum = 0;
                 foreach (DataRow row in history.Rows)
                 {
                     dgvHistoryResults.RowCount++;
                     dgvHistoryResults.Rows[rowNum].Cells[0].Value = row.ItemArray[0].ToString();
                     dgvHistoryResults.Rows[rowNum].Cells[1].Value = row.ItemArray[1].ToString();

                     rowNum++;
                 }

                 con.Close();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
       
        }
        private void button1_Click(object sender, EventArgs e)
        {
 
            //рабочий вариант
              /*Hide();
               Test1 test1 = new Test1(con,id);
               test1.ShowDialog();
               Close();*/

            //попытка теста в универсальной форме
            Hide();
            AllTests alltests = new AllTests(con, 1,id);
            alltests.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //рабочий вариант

            /*Hide();
             Test2 test2 = new Test2(con,id);
             test2.ShowDialog();
             Close();*/



            //попытка теста в универсальной форме
            Hide();
            AllTests alltests = new AllTests(con, 2,id);
            alltests.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //рабочий вариант
            /*Hide();
            Test3 test3 = new Test3(con,id);
            test3.ShowDialog();
            Close();*/


            //попытка теста в универсальной форме
            Hide();
            AllTests alltests = new AllTests(con,3,id);
            alltests.ShowDialog();
            Close();
        }

    }
}
