using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Multikino_Winforms
{
    static public class Kasjer
    {
        static public string constring = "Data Source=LAPTOP-92TU9U73\\SDCO;Initial Catalog=multikino;Integrated Security=True";
        static bool zalogowany_kasjer = false;
        static string login, ID_kasjera;

        internal  static bool sprawdz_dane(string TID_Kasjera, string THaslo)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "select LoginK,Haslo, ID from Kasjerzy where LoginK=" + "'" + TID_Kasjera + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count == 1 && THaslo.Equals(table.Rows[0][1].ToString()))
            {
                zalogowany_kasjer = true;
                login = TID_Kasjera;
                ID_kasjera = table.Rows[0][1].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static bool czy_kasjer_zalogowany()
        {
            if (zalogowany_kasjer) return true;
            else return false;
        }
    }
}
