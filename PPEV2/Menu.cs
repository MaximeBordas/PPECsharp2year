using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPEV2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            labeltime.Text = DateTime.Now.ToString();
        }

        private void buttonMenu1_Click(object sender, EventArgs e)
        {
            listeChevaux m = new listeChevaux();
            m.Show();
            this.Hide();
        }

        private void buttonMenu2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonMenu3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonMenu4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonMenu5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonMenuQuit6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
