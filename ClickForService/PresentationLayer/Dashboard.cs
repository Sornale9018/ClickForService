using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClickForService.PresentationLayer
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();


            SendNotification.ABC();
        }

        

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);

            connection.Open();

            string sql1 = "SELECT *FROM userpermissions WHERE userName= '" + Login.UserName + "'AND Block='" + "yes" + "'";
            SqlCommand command = new SqlCommand(sql1, connection);
            SqlDataReader reader = command.ExecuteReader();



            if (reader.Read())
            {
                MessageBox.Show("You cannot do this Operation. Please Contact Support Center. ");

                connection.Close();

            }
            else
            {


                HouseHoldService h1 = new HouseHoldService();
                this.Hide();
                h1.Show();
                connection.Close();

            }

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }


        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profile pp = new Profile();
            this.Hide();
            pp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangePass CP = new ChangePass();
            this.Hide();
            CP.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();


            DialogResult d;

            d = MessageBox.Show("Do you want to Go LOGOUT?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                login.Show();
            }
            else if (d == DialogResult.No)
            {
                this.Show();
            }
            else
                Close();
        }
    }
}
