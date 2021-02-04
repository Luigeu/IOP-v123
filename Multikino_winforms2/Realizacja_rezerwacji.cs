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
                "where Seanse.ID_Kina = " + CCentrum_Wszechswiata.wypisz_id_kina() + " and ID_Klienta = " + ID_klienta +
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
                string s = "  " + ch + "" + tabela_miejsc_dla_przypisanego_seansu.Rows[i][5].ToString() + "    " +
                    tabela_miejsc_dla_przypisanego_seansu.Rows[i][8].ToString();
                t = t + s + Environment.NewLine;
            }

            int l_n = 0, l_sen = 0, l_stu = 0;
            float procent_znizki;
            for (int i = 0; i < tabela_miejsc_dla_przypisanego_seansu.Rows.Count; i++)
            {
                if (tabela_miejsc_dla_przypisanego_seansu.Rows[i][8].ToString() == "normalne") l_n++;
                if (tabela_miejsc_dla_przypisanego_seansu.Rows[i][8].ToString() == "seniorskie") l_sen++;
                if (tabela_miejsc_dla_przypisanego_seansu.Rows[i][8].ToString() == "studenckie") l_stu++;
            }


            procent_znizki = oblicz_znizke();

            float suma_znizek = procent_znizki / 100 *
                CCentrum_Wszechswiata.podaj_procent_ceny_w_dniu(tabela_danych_o_rezerwacjach_danego_klienta.Rows[0][10]) / 100 *
                CCentrum_Wszechswiata.podaj_procent_ceny_za_kategorie_filmy(tabela_danych_o_rezerwacjach_danego_klienta.Rows[0][18].ToString()) / 100 *
                CCentrum_Wszechswiata.podaj_procent_ceny_za_wersje_filmy(tabela_danych_o_rezerwacjach_danego_klienta.Rows[0][13].ToString()) / 100;

            float cena_za_normalny = CCentrum_Wszechswiata.podaj_cene_podstawowa() * suma_znizek;
            float cena_za_seniorski = CCentrum_Wszechswiata.podaj_cene_podstawowa() * CCentrum_Wszechswiata.podaj_znizke_dla_seniora() / 100 * suma_znizek;
            float cena_za_studencki = CCentrum_Wszechswiata.podaj_cene_podstawowa() * CCentrum_Wszechswiata.podaj_znizke_dla_studenta() / 100 * suma_znizek;

            t = t + Environment.NewLine + "Cena:" + Environment.NewLine;
            if ((l_n) != 0)
            {
                t = t + "Normalne: " + l_n + " x " + cena_za_normalny + "  Razem: " + cena_za_normalny * (l_n) + "PLN" + Environment.NewLine;
            }
            if ((l_sen) != 0)
            {
                t = t + "Seniorskie: " + l_sen + " x " + cena_za_seniorski + "  Razem: " + cena_za_seniorski * (l_sen) + "PLN" + Environment.NewLine;
            }
            if ((l_stu) != 0)
            {
                t = t + "Ulgowe: " + l_stu + " x " + cena_za_studencki + "  Razem: " + cena_za_normalny * (l_stu) + "PLN" + Environment.NewLine;
            }

            t = t + Environment.NewLine + "Razem do zaplaty: " + ((cena_za_normalny * (l_n)) + (cena_za_seniorski * (l_sen)) + (cena_za_normalny * (l_stu)))
                + "PLN" + Environment.NewLine;


            return t;
        }
        internal static float oblicz_znizke()
        {
            int ile_biletow_zakupiono = podaj_ile_biletow_zakupil_aktywny_klient_w_przedziale_czasu_ustawionym_w_CCentrum_Wszechswiata();

            if (ile_biletow_zakupiono >= CCentrum_Wszechswiata.podaj_ile_biltow_nabyc_na_znizke())
            {
                return CCentrum_Wszechswiata.podaj_wartosc_znizki();
            }
            return 100;
        }
        internal static int podaj_ile_biletow_zakupil_aktywny_klient_w_przedziale_czasu_ustawionym_w_CCentrum_Wszechswiata()
        {
            DateTime thisDay = DateTime.Now;
            DateTime StartDay = thisDay.AddDays(-CCentrum_Wszechswiata.podaj_w_jakim_przedziale_czasu_nalezy_nabyc_bilety_na_znizke());
            string StartDayS = StartDay.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = " select * from Bilety " +
                            "inner join Seanse on Bilety.ID_Seansu = Seanse.ID" +
                            " where ID_Klienta = " + ID_Kli + "and DataS > '" + StartDayS + "'"; SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable set = new DataTable();
            adapter.Fill(set);

            return set.Rows.Count;
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
                q = " WITH UpdateList_view AS ( " +
                    "SELECT TOP 1 * from Miejsca " +
                    "WHERE Miejsca.ID_Rezerwacji = " + ID_rezerwacji + "  and Miejsca.ID_Biletu = 0 " +
                    ") " +
                    "update UpdateList_view " +
                    "set ID_Rezerwacji = 0, ID_Biletu = " + set.Rows[i][0];
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