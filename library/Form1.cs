using System.Data;

namespace library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        Data db = new Data();
        public static string name = "";

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""||textBox2.Text=="")
            {
                MessageBox.Show("un champs est vide", "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataTable table = db.table(string.Format("select * from utilisateur where userName='{0}' and password='{1}'", textBox1.Text, textBox2.Text));
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Login et mot de passe incorrecte", "Echec!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataRow dr = table.Rows[0];
                    name = dr[2].ToString();
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                }
            }
        }
    }
}