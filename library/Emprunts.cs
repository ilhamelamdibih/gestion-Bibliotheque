using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library
{
    public partial class Emprunts : Form
    {
        public Emprunts()
        {
            InitializeComponent();
        }

        private void Emprunts_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            CD cd=new CD();
            cd.Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Livre livre = new Livre();
            livre.Show();
            this.Hide();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Periodique periodique = new Periodique();
            periodique.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Ouvrage ouvrage = new Ouvrage();
            ouvrage.Show();
            this.Hide();
        }

        private void Emprunts_Load_1(object sender, EventArgs e)
        {
            label2.Text = Form1.name + "   |   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = Form1.name + "   |   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
