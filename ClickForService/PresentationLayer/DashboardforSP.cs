using ClickForService.BusinessLogicLayer;
using ClickForService.DatabaseConnectionLayer;
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
    public partial class DashboardforSP : Form
    {

        private GeneralOperations generalOperations;
        private GeneralOperations generalOperations2;
        private AccessPropertySP accessProperty;
        private AccessPropertySP accessProperty2;

        private string spUserName;
        
        public DashboardforSP()
        {
            InitializeComponent();
        }


        public DashboardforSP(string spUserName)
        {
            InitializeComponent();
            this.spUserName = spUserName;

            generalOperations = new GeneralOperations();

            accessProperty = generalOperations.GetServiceProviderRegDetails(spUserName);
            fullnametextBox.Text = accessProperty.FullName;
            divisiontextBox.Text = accessProperty.Division;
            citytextBox.Text = accessProperty.City;
            addresstextBox.Text = accessProperty.Address;
            mobilenumbertextBox.Text = accessProperty.MobileNumber;



            generalOperations2 = new GeneralOperations();
            accessProperty2 = generalOperations2.GetServiceProviderAdditionalDetails(spUserName);


            try
            {
                servicechargetextBox.Text = accessProperty2.ServiceCharge.ToString();
                availabilitytextBox.Text = accessProperty2.AvailStime;
            }
            catch (Exception exp)
            {

            }





        }


        private void DashboardforSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void DashboardforSP_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void buttonMaid_Click(object sender, EventArgs e)
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

                ServiceProviderProfile serviceProviderProfile = new ServiceProviderProfile(spUserName);
                this.Hide();
                serviceProviderProfile.Show();
                connection.Close();

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
