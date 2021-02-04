using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multikino_Winforms
{
    static class Realizacja_rezerwacji
    {
        static DataTable tabela_danych_o_rezerwacjach_danego_klienta;
        static DataTable tabela_miejsc_dla_przypisanego_seansu;
        private static int ID_rezerwacji;
        private static string ID_Kli;

        static public string constring = "Data Source=LAPTOP-92TU9U73\\SDCO;Initial Catalog=multikino;Integrated Security=True";
        internal static bool przeszukaj_seanse_dla_danego_klienta(string ID_klienta)
        {
            DateTime TimeNow = DateTime.Now;
            string d = TimeNow.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "select * from  Rezerwacje " +
                "inner join Seanse on  Seanse.ID = Rezerwacje.ID_Seansu " +
                "inner join WersjeFilmów on  WersjeFilmów.ID = Seanse.ID_WersjiFilmu " +
                "inner join Filmy on Filmy.ID = WersjeFilmów.ID_Filmu " +
                "where Seanse.ID_Kina = "+ CCentrum_Wszechswiata.wypisz_id_kina() +" and ID_Klienta = "+ ID_klienta +
                " and DataS >= '" + d + "' ";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable set = new DataTable();
            adapter.Fill(set);
            if (set.Rows.Count <= 0) return false;
            tabela_danych_o_rezerwacjach_danego_klienta = set;
            con.Close();
            ID_Kli = ID_klienta;
            return true;
        }
        internal static string[] drukuj_tablice_rezerwacji()
        {
            string[] t = new string[tabela_danych_o_rezerwacjach_danego_klienta.Rows.Count];

            for (int i = 0; i < tabela_danych_o_rezerwacjach_danego_klienta.Rows.Count; i++)
            {

                string s3 = tabela_danych_o_rezerwacjach_danego_klienta.Rows[i][10].ToString();
                string s = s3 + " " + tabela_danych_o_rezerwacjach_danego_klienta.Rows[i][17].ToString() + " " + 
                    tabela_danych_o_rezerwacjach_danego_klienta.Rows[i][13].ToString();
                t[i] = s;
            }
            return t;
        }
        internal static void przeszykaj_bilety_dla_danej_rezerwacji(string i)
        {
            ID_rezerwacji = int.Parse(tabela_danych_o_rezerwacjach_danego_klienta.Rows[int.Parse(i)][0].ToString());
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "select * from  Miejsca " +
                "where ID_Rezerwacji = " + ID_rezerwacji;
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable set = new DataTable();
            adapter.Fill(set);
            tabela_miejsc_dla_przypisanego_seansu = set;
            con.Close();
        }
        internal static string drukuj_tablice_miejsc()
        {
            string t = "";

            for (int i = 0; i < tabela_miejsc_dla_przypisanego_seansu.Rows.Count; i++)
            {
                string s3 = tabela_miejsc_dla_przypisanego_seansu.Rows[i][6].ToString();
                char ch = s3[0];
                ch = (Char)(Convert.ToUInt16(ch) + 16);
                string s ="  " + ch + "" + tabela_miejsc_dla_przypisanego_seansu.Rows[i][5].ToString() + "    " +
                    tabela_miejsc_dla_przypisanego_seansu.Rows[i][8].ToString();
                t = t   + s + Environment.NewLine;
            }
            return t;
        }
        internal static bool zrealizuj_rezerwacje()
        {
            if (ID_rezerwacji == 0) return false;
            DateTime TimeNow = DateTime.Now;
            string d = TimeNow.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd;
            string q;
            for (int i = 0; i < tabela_miejsc_dla_przypisanego_seansu.Rows.Count; i++)
            {
                q = "insert into Bilety (ID_Klienta, ID_Kina, ID_Seansu, DataZakupu) " +
                    "values (" + ID_Kli + "," + CCentrum_Wszechswiata.wypisz_id_kina() + "," + tabela_miejsc_dla_przypisanego_seansu.Rows[0][1] + ",'" + d + "')";


                cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
            }

            q = "select * from  Bilety " +
                "where DataZakupu = '" + d + "' and ID_Klienta = " + ID_Kli;
            cmd = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable set = new DataTable();
            adapter.Fill(set);

            for (int i = 0; i < set.Rows.Count; i++)
            {
                q = "UPDATE Miejsca SET Miejsca.ID_Rezerwacji = 0 , Miejsca.ID_Biletu = " + set.Rows[i][0].ToString() +
                " WHERE Miejsca.ID_Rezerwacji = " + ID_rezerwacji;
                cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
            }

            q = "DELETE FROM Rezerwacje " +
                "WHERE ID = " + ID_rezerwacji;
            cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();

            con.Close();

            tabela_danych_o_rezerwacjach_danego_klienta = null;
            tabela_miejsc_dla_przypisanego_seansu = null;
            ID_rezerwacji = 0;
            ID_Kli = null;
            return true;
        }
    }
}
