using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace library
{
    internal class Data
    {
        MySqlConnection cn = new MySqlConnection("SERVER=localhost;DATABASE=biblio;UID=root;PASSWORD=;");
        public DataTable table(string requete)
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand(requete, cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cn.Close();
            return dt;
        }
        public int insert_update_delete(string requete)
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand(requete, cn);
            int a = cmd.ExecuteNonQuery();
            cn.Close();
            return a;
        }
    }
}
