using MySqlX.XDevAPI.Relational;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        Data db=new Data();
        private void Dashboard_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.name+"   |   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

            DataTable tableClient = db.table("select * from client");
            label1.Text = tableClient.Rows.Count.ToString();

            DataTable tableEmprunt = db.table("select cin from emprunt");
            label3.Text = tableEmprunt.Rows.Count.ToString();

            DataTable tableCD = db.table("select * from cd");
            DataTable tablePeriodique = db.table("select * from periodique");
            DataTable tableLivre = db.table("select * from livre");
            label4.Text= (tableCD.Rows.Count + tablePeriodique.Rows.Count + tableLivre.Rows.Count).ToString();

            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = tableCD;

            guna2ProgressBar3.Value = (tableCD.Rows.Count * 100) / int.Parse(label4.Text);
            guna2ProgressBar1.Value = (tableLivre.Rows.Count * 100) / int.Parse(label4.Text);
            guna2ProgressBar2.Value = (tablePeriodique.Rows.Count * 100) / int.Parse(label4.Text);

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "LAMDIBIH Ilhame | " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            Ouvrage ouvrage = new Ouvrage();
            ouvrage.Show();
            this.Hide();
        }

        private void guna2Button2_Click_2(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Emprunts emprunts = new Emprunts();
            emprunts.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
