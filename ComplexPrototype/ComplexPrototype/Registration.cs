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
    public partial class Registration : Form
    {
        NpgsqlConnection con = new NpgsqlConnection();
        public Registration(NpgsqlConnection con)
        {
            this.con = con;
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"INSERT INTO \"Users\"(\"Login\",\"Password\")" +
                        $" VALUES('{textBoxLogin.Text}','{textBoxPassword.Text}')", con);

                cmd.ExecuteNonQuery();
                con.Close();

                Hide();
                Autorization A = new Autorization(con);
                A.ShowDialog();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

    }
}
