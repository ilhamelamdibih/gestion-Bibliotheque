using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace library
{
    public partial class CD : Form
    {
        public CD()
        {
            InitializeComponent();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }
        public void MAJList()
        {
            guna2DataGridView1.DataSource = null;
            DataTable table = db.table("select * from cd");
            guna2DataGridView1.DataSource = table;
        }
        private void CD_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.name + "   |   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            MAJList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = Form1.name + "   |   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

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

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            Emprunts emprunts = new Emprunts();
            emprunts.Show();
            this.Hide();
        }
        Data db = new Data();
        private void guna2Button7_Click(object sender, EventArgs e)
        {
           
        }
        bool client = false;
        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                DataTable tableClient = db.table(string.Format("SELECT * FROM client where CIN = '{0}'", textBox1.Text));
                if (tableClient.Rows.Count != 0)
                {
                    client = true;
                }
                if(code=="")
                {
                    DialogResult m = MessageBox.Show("Merci de selecionner un CD dans la liste", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    if (client == false)
                    {
                        DialogResult m = MessageBox.Show("Client n'esxite pas !!!! voulez-vous ajouter ce client", "Echec d'emprunt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (DialogResult.Yes == m)
                        {
                            Client clt = new Client();
                            clt.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        DataTable blackliste = db.table(string.Format("select * from blackListe where cin='{0}'", textBox1.Text));
                        if (blackliste.Rows.Count != 0)
                        {
                            MessageBox.Show("Client est bloqués", "Erreur", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            int c = db.insert_update_delete(string.Format("insert into Emprunt (cin,code,type) values('{0}','{1}','{2}')", textBox1.Text, code, "CD"));
                            if (c == 0)
                            {
                                MessageBox.Show("Emprunt non accorder", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                DateTime now = DateTime.Now;
                                db.insert_update_delete(string.Format("UPDATE CD set quantite=quantite-1 where code='{0}'", code));
                                MessageBox.Show("Emprunt ajouter", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MessageBox.Show("Date de retour est : " + now.AddDays(30).ToShortDateString(), "Succee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                textBox1.Text = textBox2.Text = "";
                                MAJList();
                            }

                        }
                    }
                }
                

            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {

        }
        string code = "";
        private void guna2Button9_Click(object sender, EventArgs e)
        {
            DataTable table = db.table(string.Format("SELECT * FROM cd where titre like '%{0}%' and quantite>0", textBox2.Text));
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = table;
            code = "";
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = guna2DataGridView1.CurrentCell.RowIndex;
            if (index >= 0 && index < guna2DataGridView1.Rows.Count - 1)
            {
                DataGridViewRow r = guna2DataGridView1.Rows[index];
                DataTable table = db.table(string.Format("SELECT * FROM cd where code='{0}' and quantite>0", r.Cells[0].Value.ToString()));
                textBox2.Text = table.Rows[0][2].ToString();
                code= table.Rows[0][0].ToString();
            }


        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = "";
            MAJList();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Form1 form=new Form1();
            form.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
