using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace library
{
    public partial class Ouvrage : Form
    {
        public Ouvrage()
        {
            InitializeComponent();
        }
        void viderChamp()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }
                guna2CustomRadioButton1.Checked = true;
                guna2CustomRadioButton1.Checked = false;
            }
        }

        Data db = new Data();
        
        public void MAJList()
        {
            guna2DataGridView1.DataSource = null;
            DataTable table = db.table("select auteur,titre,quantite,'CD' as type from cd union select auteur,titre,quantite,'Livre' as type from livre union select auteur,titre,quantite,'Periodique' as type from periodique");
            guna2DataGridView1.DataSource = table;
        }
        private void guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (guna2CustomRadioButton1.Checked)
            {
                panel7.Visible = false;
                panel8.Visible = false;
            }
        }

        private void Ouvrage_Load(object sender, EventArgs e)
        {
            label3.Text = Form1.name + "   |   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            panel7.Visible = panel8.Visible = false;
            MAJList();
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2CustomRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CustomRadioButton3.Checked)
            {
                panel7.Visible = true;
                panel8.Visible = false;
            }
        }

        private void guna2CustomRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (guna2CustomRadioButton2.Checked)
            {
                panel7.Visible = false;
                panel8.Visible = true;
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox7.Text != "" && guna2NumericUpDown1.Value>0 && (guna2CustomRadioButton1.Checked == true || guna2CustomRadioButton2.Checked == true || guna2CustomRadioButton3.Checked == true))
            {
                if (guna2CustomRadioButton3.Checked)
                {
                    if (textBox1.Text!="" && textBox2.Text != "" && textBox3.Text != "")
                    {
                        DataTable table = db.table(string.Format("select * from periodique where auteur='{0}' and titre='{1}'", textBox7.Text, textBox5.Text));
                        if (table.Rows.Count == 0)
                        {
                            int c = db.insert_update_delete(string.Format("insert into periodique (auteur,titre,quantite,numero,nom,periodicite) values('{0}','{1}','{2}','{3}','{4}','{5}')", textBox7.Text, textBox5.Text, guna2NumericUpDown1.Value.ToString(),textBox1.Text,textBox2.Text,textBox3.Text));
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
                            MessageBox.Show("Periodique déja exister", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Merci de remplir les champs vide correctement", "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (guna2CustomRadioButton2.Checked)
                {
                    if (textBox6.Text != "")
                    {
                        DataTable table = db.table(string.Format("select * from livre where auteur='{0}' and titre='{1}'", textBox7.Text, textBox5.Text));
                        if (table.Rows.Count == 0)
                        {
                            int c = db.insert_update_delete(string.Format("insert into livre (auteur,titre,quantite,editeur) values('{0}','{1}','{2}','{3}')", textBox7.Text, textBox5.Text, guna2NumericUpDown1.Value.ToString(),textBox6.Text));
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
                            MessageBox.Show("Livre déja exister", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Merci de remplir les champs vide", "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (guna2CustomRadioButton1.Checked)
                {

                    DataTable table = db.table(string.Format("select * from cd where auteur='{0}' and titre='{1}'", textBox7.Text, textBox5.Text));
                    if (table.Rows.Count == 0)
                    {
                        int c = db.insert_update_delete(string.Format("insert into cd (auteur,titre,quantite) values('{0}','{1}','{2}')", textBox7.Text, textBox5.Text,guna2NumericUpDown1.Value.ToString()));
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
                        MessageBox.Show("CD déja exister", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Merci de remplir les champs vide", "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            auteur = titre = type = "";
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            DataTable table = db.table(string.Format("SELECT auteur,titre,quantite,'CD' as type FROM cd where titre like '%{0}%' UNION SELECT auteur,titre,quantite,'livre' as type FROM livre where titre like '%{0}%' UNION SELECT auteur,titre,quantite,'Periodique' as type FROM periodique where titre like '%{0}%'", textBox5.Text));
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = table;
            auteur = titre =type= "";
        }
        string auteur="";
        string titre="";
        string type = "";
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = guna2DataGridView1.CurrentCell.RowIndex;
            if (index >= 0 && index < guna2DataGridView1.Rows.Count - 1)
            {
                DataGridViewRow r = guna2DataGridView1.Rows[index];

                DataTable table = db.table(string.Format("SELECT * FROM `{2}` where auteur='{0}' and titre='{1}'", r.Cells[0].Value.ToString(), r.Cells[1].Value.ToString(), r.Cells[3].Value.ToString()));
                auteur = textBox7.Text = table.Rows[0][1].ToString();
                titre = textBox5.Text = table.Rows[0][2].ToString();
                textBox8.Text = table.Rows[0][3].ToString();
                if (r.Cells[3].Value.ToString() == "CD")
                {
                    guna2CustomRadioButton1.Checked = true;
                    type = "CD";
                }
                if (r.Cells[3].Value.ToString() == "Livre")
                {
                    guna2CustomRadioButton2.Checked = true;
                    textBox6.Text = table.Rows[0][4].ToString();
                    type = "Livre";
                }
                if (r.Cells[3].Value.ToString() == "Periodique")
                {
                    guna2CustomRadioButton3.Checked = true;
                    textBox1.Text = table.Rows[0][4].ToString();
                    textBox2.Text = table.Rows[0][5].ToString();
                    textBox3.Text = table.Rows[0][6].ToString();
                    type = "Periodique";
                }

            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if(auteur==""&&titre==""&&type=="")
            {
                MessageBox.Show("Merci de choisir un ouvrage dans la liste", "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if(type =="CD")
                {
                    int mod = db.insert_update_delete(string.Format("Update cd SET auteur='{0}',titre='{1}',quantite='{2}' where auteur='{3}' and titre='{4}' ", textBox7.Text, textBox5.Text, textBox8.Text, auteur,titre));
                    if (mod == 0)
                    {
                        MessageBox.Show("CD non modifier", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("CD bien modifier", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                if(type=="Livre")
                {
                    int mod = db.insert_update_delete(string.Format("Update livre SET auteur='{0}',titre='{1}',quantite='{2}',editeur='{3}' where auteur='{4}' and titre='{5}' ", textBox7.Text, textBox5.Text, textBox8.Text, textBox6.Text, auteur, titre));
                    if (mod == 0)
                    {
                        MessageBox.Show("Livre non modifier", "Erreur", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Livre bien modifier", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                if(type=="Periodique")
                {
                    int mod = db.insert_update_delete(string.Format("Update periodique SET auteur='{0}',titre='{1}',quantite='{2}',numero='{3}',nom='{4}',periodicite='{5}' where auteur='{6}' and titre='{7}' ", textBox7.Text, textBox5.Text, textBox8.Text, textBox1.Text,textBox2.Text,textBox3.Text, auteur, titre));
                    if (mod == 0)
                    {
                        MessageBox.Show("Periodique non modifier", "Erreur", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Periodique bien modifier", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                MAJList();
                viderChamp();
                auteur = titre = type = "";
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Voulez-vous vraiment supprimer l'ouvrage " + textBox5.Text, "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == m)
            {
                int c = db.insert_update_delete(string.Format("DELETE from {0} where auteur='{1}' and titre='{2}'", type,auteur,titre));
                if (c == 0)
                {
                    MessageBox.Show("Ouvrage non supprimer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ouvrage bien supprimer", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    MAJList();
                    viderChamp();
                    auteur = titre = type = "";
                }
            }
            else
            {
                MAJList();
                viderChamp();
                auteur = titre = type = "";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "LAMDIBIH Ilhame | " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Emprunts emprunts=new Emprunts();
            emprunts.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
