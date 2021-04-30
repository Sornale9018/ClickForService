using System;
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
    public partial class ComputerServicing : Form
    {
        public ComputerServicing()
        {
            InitializeComponent();
        }

        private void ComputerServicing_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
