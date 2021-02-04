using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multikino_Winforms
{
    static class Aktualizacja_zn
    {
        static public string constring = "Data Source=LAPTOP-92TU9U73\\SDCO;Initial Catalog=multikino;Integrated Security=True";
        internal static bool zaktualizuj(string ID_Klienta, string data, int typ_znizki)
        {
            

                SqlConnection con = new SqlConnection(constring);
                con.Open();
                string q = "select * from  Klienci  " +
                    "where ID =  " + ID_Klienta;
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable set = new DataTable();
                adapter.Fill(set);
                if (set.Rows.Count == 0) return false;

                if (typ_znizki == 0)
                {
                    q = "UPDATE Klienci " +
                                    "SET Zniz_Seniorska = 1, Zniz_Studencka = 0, DataWazZniz = '" + data +
                                    "' WHERE ID = " + ID_Klienta + "; ";
                    cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                else if (typ_znizki == 1)
                {
                    q = "UPDATE Klienci " +
                                    "SET Zniz_Seniorska = 0, Zniz_Studencka = 1, DataWazZniz = '" + data +
                                    "' WHERE ID = " + ID_Klienta + "; ";
                    cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                else
                {
                    return false;
                }
                
            
        }


    }
}
