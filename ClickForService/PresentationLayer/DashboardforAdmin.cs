﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickForService.PresentationLayer
{
    public partial class DashboardforAdmin : Form
    {
        public DashboardforAdmin()
        {
            InitializeComponent();
        }

        private void DashboardforAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void DashboardforAdmin_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
