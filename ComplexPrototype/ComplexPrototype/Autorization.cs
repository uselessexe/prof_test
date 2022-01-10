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
    public partial class Autorization : Form
    {
        NpgsqlConnection con = new NpgsqlConnection();
        DataTable User = new DataTable();
        public Autorization(NpgsqlConnection con)
        {
            this.con = con;
            InitializeComponent();
        }

        private void Autorization_Load(object sender, EventArgs e)
        {

        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter($"SELECT * FROM \"Users\" WHERE \"Login\"=\'{textBoxLogin.Text}\' " +
                                                             $"AND \"Password\" = \'{textBoxPassword.Text}\'", con);
               
                DA.Fill(User);
                con.Close();


                PersonalPage PP = new PersonalPage(Convert.ToInt32(User.Rows[0].ItemArray[0].ToString()), con);
                Hide();
                PP.ShowDialog();            
                Close();             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            Hide();
            Registration R = new Registration(con);
            R.ShowDialog();
            Close();
        }

    }
}
