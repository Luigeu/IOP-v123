using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multikino_Winforms
{
    public static class Zwrot
    {
        static public string constring = "Data Source=LAPTOP-92TU9U73\\SDCO;Initial Catalog=multikino;Integrated Security=True";
        static private DataTable lista_niezrealizowanych_seansow_danego_klienta;
        static private string ID_klientaZwr;
        static private bool KlientJestAktywnyZwrot;

        internal static void przeszukaj_niezrealizowane_bilety_po_ID_klienta(string ID)
        {
            ID_klientaZwr = ID;
            DateTime TimeNow = DateTime.Today;
            string TimeNowS = TimeNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "select * from Miejsca " +
                "inner join Seanse on Miejsca.ID_Seansu = Seanse.ID " +
                "inner join Bilety on  Bilety.ID = Miejsca.ID_Biletu " +
                "inner join WersjeFilmów on WersjeFilmów.ID = Seanse.ID_WersjiFilmu " +
                "inner join Filmy on Filmy.ID = WersjeFilmów.ID_Filmu " + 
                "where ID_Klienta = " + ID + " AND DataS >= '" + TimeNowS + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable set = new DataTable();
            adapter.Fill(set);
            lista_niezrealizowanych_seansow_danego_klienta = set;
            KlientJestAktywnyZwrot = true;
        }
        internal static string[] przedstaw_tablice_seanow_jako_string()
        {
            string[] tab = new string[lista_niezrealizowanych_seansow_danego_klienta.Rows.Count];
           
            for (int i = 0; i < tab.Length; i++)
            {
                string s2 = lista_niezrealizowanych_seansow_danego_klienta.Rows[i][14].ToString();
                string s = s2 + "    " + lista_niezrealizowanych_seansow_danego_klienta.Rows[i][26].ToString() + "    " 
                    + lista_niezrealizowanych_seansow_danego_klienta.Rows[i][22].ToString() + "    "
                    + lista_niezrealizowanych_seansow_danego_klienta.Rows[i][8].ToString();
                tab[i] = s;
            }
            return tab;
        }
        internal static bool zrealizuj_zwrot_biletu(int i)
        {
            if(KlientJestAktywnyZwrot && i>=0)
            {
                string ID_Biletu = lista_niezrealizowanych_seansow_danego_klienta.Rows[i][2].ToString();
                usun_bilet_z_konta_klienta(ID_Biletu);
                return true;
            }
            return false;
        }
        internal static void usun_bilet_z_konta_klienta(string ID)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "UPDATE Miejsca " +
                "SET Miejsca.ID_Biletu = 0, StatusMiejsca = 'wolne' " +
                "WHERE Miejsca.ID_Biletu = " + ID + "; " +
                "DELETE FROM Bilety " +
                "WHERE Bilety.ID = " + ID + "; ";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
        }
    }
}
