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
    public partial class PersonalPage : Form
    {
        NpgsqlConnection con = new NpgsqlConnection();
        DataTable history = new DataTable();
        DataTable tests = new DataTable();
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

            DataTable User = new DataTable();
            con.Open();
            NpgsqlDataAdapter DA = new NpgsqlDataAdapter($"SELECT \"Login\" FROM \"Users\" " +
                                                        $"WHERE \"UserID\"={id}", con);//
            DA.Fill(User);
            labelNickName.Text = $"Имя пользователя: {User.Rows[0][0].ToString()}";
            
            DA = new NpgsqlDataAdapter($"SELECT \"TestName\"FROM \"Test\"", con);
            DA.Fill(tests);
            foreach (DataRow row in tests.Rows)
            {     
                comboBox1.Items.Add(row.ItemArray[0].ToString());
            }
            /*comboBox1.DataSource = tests;
            comboBox1.DisplayMember = "TestName";*/
            
            con.Close();
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
                history.Rows.Clear();
                dgvHistoryResults.Rows.Clear();
                dgvHistoryResults.Refresh();
                
                con.Open();
                 
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

                con.Close();
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
