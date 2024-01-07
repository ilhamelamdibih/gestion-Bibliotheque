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
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        Data db = new Data();
        public void MAJList()
        {
            guna2DataGridView1.DataSource = null;
            DataTable table = db.table("select * from client");
            guna2DataGridView1.DataSource = table;
        }
        void viderChamp()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
        }
        private void Client_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.name + "   |   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            MAJList();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Ouvrage ouvrage = new Ouvrage();
            ouvrage.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Emprunts emprunts = new Emprunts();
            emprunts.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = Form1.name + "   |   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text!=""&&textBox5.Text!=""&&textBox6.Text!="")
            {
                DataTable table = db.table(string.Format("select * from client where CIN='{0}'", textBox1.Text));
                if (table.Rows.Count == 0)
                {
                    int c = db.insert_update_delete(string.Format("insert into client values('{0}','{1}','{2}','{3}','{4}','{5}')", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text));
                    if (c == 0)
                    {
                        MessageBox.Show("Echec d'ajout", "Echec!!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MAJList();
                        viderChamp();
                    }

                }
                else
                {
                    MessageBox.Show("Client déja exister", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Merci de remplir les champs vide", "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            DataTable table = db.table(string.Format("select * from client where CIN='{0}'", textBox1.Text));
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Client n'existe pas!!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                DialogResult m = MessageBox.Show("Voulez-vous vraiment supprimer le client " + textBox3.Text + " " + textBox2.Text, "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == m)
                {
                    int c = db.insert_update_delete(string.Format("DELETE from client where cin='{0}'",textBox1.Text));
                    if (c == 0)
                    {
                        MessageBox.Show("Client non supprimer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Client bien supprimer", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        MAJList();
                        viderChamp();
                    }
                }
            }
              
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                DataTable table = db.table(string.Format("select * from client where CIN='{0}'", textBox1.Text));
                if (table.Rows.Count != 0)
                {
                    int mod = db.insert_update_delete(string.Format("Update client SET nom='{0}',prenom='{1}',telephone='{2}',adresse='{3}',email='{4}' where cin='{5}' ", textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text,textBox1.Text));
                    if (mod == 0)
                    {
                        MessageBox.Show("Client non modifier", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Client bien modifier", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                else
                {
                    MessageBox.Show("Client n'existe pas", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Merci de remplir les champs vide", "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
              
                MAJList();
                viderChamp();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            DataTable table = db.table(string.Format("SELECT * FROM client where CIN = '{0}'", textBox1.Text));
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Client n'existe pas!!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                textBox2.Text = table.Rows[0][1].ToString();
                textBox3.Text = table.Rows[0][2].ToString();
                textBox4.Text = table.Rows[0][3].ToString();
                textBox5.Text = table.Rows[0][4].ToString();
                textBox6.Text = table.Rows[0][5].ToString();
                guna2DataGridView1.DataSource = null;
                guna2DataGridView1.DataSource = table;
            }
            
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
