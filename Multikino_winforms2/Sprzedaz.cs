using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Multikino_Winforms
{
    public static class Sprzedaz
    {
        static public string constring = "Data Source=LAPTOP-92TU9U73\\SDCO;Initial Catalog=multikino;Integrated Security=True";
        static private string[] tabela_seansow; //Informacje o seansach w danym dniu w postaci ciągu string
        static private int[] tabela_ID_seansow; // Tablica ID_senasow opisywanych w tabeli wyzej
        static int ID_seansu; //ID aktualnego seansu
        static DataTable status_miejsc_na_seans;
        static int cena_podstawowa_miejsca;
        static int ID_klienta;
        static bool Klient_jest_aktywny;
        static DataTable dane_aktywnego_klienta;
        static bool przysluguje_znizka;
 
        internal static string[] przeszukaj_seanse(string data)
        {
            string d = data;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "select * from  Seanse  " +
                "inner join WersjeFilmów on  WersjeFilmów.ID = Seanse.ID_WersjiFilmu " +
                "inner join Filmy on Filmy.ID = WersjeFilmów.ID_Filmu " +
                "where Seanse.ID_Kina =  " + CCentrum_Wszechswiata.wypisz_id_kina() +
                "AND CONVERT(VARCHAR(25), Seanse.DataS, 126) LIKE '" + d + "%' ";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable set = new DataTable();
            //adapter.ToString();
            //return adapter.ToString();
            adapter.Fill(set);

            string[] t = Sprzedaz.laczenie_tablicy(set);
            Sprzedaz.tabela_seansow = t;
            tabela_ID_seansow = Sprzedaz.tworzenie_tablicy_ID_seansow(set);
            con.Close();

            return t;
        }

        internal static string[] laczenie_tablicy(DataTable table)
        {
            string[] t;
            string s;

            if (table.Rows.Count <= 1)
            {
                t = new string[1];
                t[0] = "Brak seansów w wybranum dniu";
                return t;
            }
            else
            {
                t = new string[table.Rows.Count];
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    string s2 = table.Rows[i][5].ToString();
                    string s3 = s2.Substring(11);
                    s = s3 + " " + table.Rows[i][8].ToString() + " " + table.Rows[i][12].ToString();
                    t[i] = s;
                }
                return t;
            }
        }

        internal static int[] tworzenie_tablicy_ID_seansow(DataTable table)
        {
            tabela_ID_seansow = new int[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
               tabela_ID_seansow[i] = (int) table.Rows[i][0];
            }
            return tabela_ID_seansow;
        }

        internal static bool pobierz_dane_o_seansie(string wybrany_seans_z_listy, string l_nor, string l_sen, string l_stu)
        {
            int ID=0;
            for(int i=0; i< tabela_ID_seansow.Length; i++)
            {
                if(tabela_ID_seansow[i]== (int.Parse(wybrany_seans_z_listy)+1))
                {
                    ID = i;
                }
            }

            ID_seansu = tabela_ID_seansow[ID];
            int suma_miejsc = int.Parse(l_nor) + int.Parse(l_sen) + int.Parse(l_stu);

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "select * from Miejsca where ID_Seansu = " + ID_seansu;
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable set = new DataTable();
            adapter.Fill(set);
            Sprzedaz.status_miejsc_na_seans = set;
            if (sprawdzenie_ilosc_dostepnych_miejsc_na_seans(set) < suma_miejsc) return false;
            con.Close();
            return true;
        }

        internal static int sprawdzenie_ilosc_dostepnych_miejsc_na_seans(DataTable table)
        {
            int counter = 0;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i][7].ToString() == "wolne") counter++;
            }
            return counter;
        }

        internal static bool czy_miejsce_wolne(int i)
        {
            int pom1 = i % 10;
            int pom2 = (i-pom1) / 10;
            int pom3 = pom2 + pom1 * 5;
            if (status_miejsc_na_seans.Rows[pom3][7].ToString().Equals("wolne")) 
             {
                return true;
             }
            return false;
        }

        internal static string oblicz_cene(string l_nor, string l_sen, string l_stu)
        {
            string text;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "select * from Seanse where Seanse.ID = " + ID_seansu;
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable set = new DataTable();
            adapter.Fill(set);
            cena_podstawowa_miejsca = int.Parse(set.Rows[0][4].ToString());

            int procent_znizki; //ile procent ceny trzeba zaplacic

            if(Klient_jest_aktywny)
            {
                procent_znizki = oblicz_znizke();
            }
            else
            {
                procent_znizki = 100;
            }

            int cena_za_normalny = cena_podstawowa_miejsca * procent_znizki/100;
            int cena_za_seniorski = cena_podstawowa_miejsca * CCentrum_Wszechswiata.podaj_znizke_dla_seniora() / 100 * procent_znizki / 100;
            int cena_za_studencki = cena_podstawowa_miejsca * CCentrum_Wszechswiata.podaj_znizke_dla_studenta() / 100 * procent_znizki / 100;
            
            text = "Wybrano:" + Environment.NewLine;
            if(int.Parse(l_nor) != 0)
            {
                text = text + "Normalne: " + l_nor + " x " + cena_za_normalny + "  Razem: " + cena_za_normalny * int.Parse(l_nor) + "PLN" + Environment.NewLine;
            }
            if (int.Parse(l_sen) != 0)
            {
                text = text + "Seniorskie: " + l_sen + " x " + cena_za_seniorski + "  Razem: " + cena_za_seniorski * int.Parse(l_sen) + "PLN" + Environment.NewLine;
            }
            if (int.Parse(l_stu) != 0)
            {
                text = text + "Ulgowe: " + l_stu + " x " + cena_za_studencki + "  Razem: " + cena_za_normalny * int.Parse(l_stu) + "PLN" + Environment.NewLine;
            }

            text = text + Environment.NewLine + "Razem do zaplaty: " + ((cena_za_normalny * int.Parse(l_nor)) + (cena_za_seniorski * int.Parse(l_sen))+ (cena_za_normalny * int.Parse(l_stu)))
                + "PLN" +Environment.NewLine;
            con.Close();

            return text;
        }

        internal static bool sprawdz_poprawnosc_podanego_id(string ID)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "select * from Klienci where ID = " + ID;
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable set = new DataTable();
            adapter.Fill(set);
            dane_aktywnego_klienta = set;

            if (set.Rows.Count > 0)
            {
                ID_klienta = int.Parse(ID);
                Klient_jest_aktywny = true;
                return true;
            }
            else
            {
                return false;
            } 
        }

        internal static bool sprawdz_czy_przysluguje_znizka(bool seni, bool stud)
        {
            if(seni)
            {
                if( !dane_aktywnego_klienta.Rows[0][3].ToString().Equals("1") )
                {
                    przysluguje_znizka = false;
                    return false;
                }
            }
            if(stud)
            {
                if( !dane_aktywnego_klienta.Rows[0][4].ToString().Equals("1") )
                {
                    przysluguje_znizka = false;
                    return false;
                }
            }
            przysluguje_znizka = true;
            return true;
        }

        internal static int oblicz_znizke()
        {
            int ile_biletow_zakupiono = podaj_ile_biletow_zakupil_aktywny_klient_w_przedziale_czasu_ustawionym_w_CCentrum_Wszechswiata();

            if(ile_biletow_zakupiono >= CCentrum_Wszechswiata.podaj_ile_biltow_nabyc_na_znizke())
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
            string q = "select * from Bilety where ID_Klienta = " + ID_klienta + "and DataZakupu > '" + StartDayS + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable set = new DataTable();
            adapter.Fill(set);

            return set.Rows.Count;
        }

        internal static bool sprzedaj_bilety(Button[] btn, string l_nor, string l_sen, string l_stu)
        {
            int suma_m = int.Parse(l_nor) + int.Parse(l_sen) + int.Parse(l_stu);
            int suma2 = int.Parse(l_nor) + int.Parse(l_sen);

            if (Klient_jest_aktywny)
            {
                 if(!przysluguje_znizka) return false;
            }

            if(Sprawdz_czy_wybrano_wszystkie_miejsca(btn, suma_m))
            {
                int pom1 = 1;
                for (int i = 0; i < btn.Length; i++)
                {
                    if (btn[i].BackColor == System.Drawing.Color.Blue)
                    {
                        if (Klient_jest_aktywny)
                        {
                            if(pom1 <= int.Parse(l_nor) && int.Parse(l_nor) > 0) tworz_bilet_dla_znanego_klienta(i,"normalne");
                            if(pom1 <= suma2 && int.Parse(l_sen) > 0) tworz_bilet_dla_znanego_klienta(i, "seniorski");
                            if(pom1 <= suma_m && int.Parse(l_stu) > 0) tworz_bilet_dla_znanego_klienta(i, "studencki");
                        }
                        else
                        {
                            if (pom1 <= int.Parse(l_nor) && int.Parse(l_nor) > 0) tworz_bilet_dla_nieznanego_klienta(i, "normalne");
                            if (pom1 <= suma2 && int.Parse(l_sen) > 0) tworz_bilet_dla_nieznanego_klienta(i, "seniorski");
                            if (pom1 <= suma_m && int.Parse(l_stu) > 0) tworz_bilet_dla_nieznanego_klienta(i, "studencki");
                        }
                        pom1++;
                    }
                }
                ID_seansu = 0;
                status_miejsc_na_seans = null;
                ID_klienta = 0;
                Klient_jest_aktywny = false;
                dane_aktywnego_klienta = null;
                return true;
            }
            else
            {
                return false;
            }  
        }

        internal static bool Sprawdz_czy_wybrano_wszystkie_miejsca(Button[] btn, int l_miejsc)
        {
            int pom = 0;
            for(int i=0; i<btn.Length; i++)
            {
                if (btn[i].BackColor == System.Drawing.Color.Blue) pom++;
            }
            if (pom == l_miejsc) return true;
            else return false;
        }

        internal static void tworz_bilet_dla_znanego_klienta(int nr_miejsca, string typ_miej)
        {
            DateTime thisDay = DateTime.Now;
            string thisDayS = thisDay.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "insert into Bilety (ID_Klienta, ID_Kina, ID_Seansu, DataZakupu) " +
                "values ("+ ID_klienta+ " ," + CCentrum_Wszechswiata.wypisz_id_kina()+ " ," + ID_seansu + " ,'" + thisDayS + "') " +
                "select ID from Bilety " +
                "where ID_Klienta = "+ ID_klienta + "and DataZakupu = '" + thisDayS + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable set = new DataTable();
            adapter.Fill(set);
            int pom2 = set.Rows.Count - 1;
            string ID_biletu = set.Rows[pom2][0].ToString();
            q = "update Miejsca " +
                "Set ID_Biletu = " +  ID_biletu + ", StatusMiejsca = 'zajete', TypMiejsca = '"+  typ_miej +"' " +
                "where ID_Seansu = "+  ID_seansu +" AND (WspolMiejscaY * 10 + WspolMiejscaX - 11) = " + nr_miejsca;
            cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal static void tworz_bilet_dla_nieznanego_klienta(int nr_miejsca, string typ_miej)
        {
            DateTime thisDay = DateTime.Now;
            string thisDayS = thisDay.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "insert into Bilety (ID_Klienta, ID_Kina, ID_Seansu, DataZakupu) " +
                "values (" + 0 + " ," + CCentrum_Wszechswiata.wypisz_id_kina() + " ," + ID_seansu + " ,'" + thisDayS + "') " +
                "select ID from Bilety " +
                "where ID_Klienta = " + 0 + "and DataZakupu = '" + thisDayS + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable set = new DataTable();
            adapter.Fill(set);
            int pom2 = set.Rows.Count - 1;
            string ID_biletu = set.Rows[pom2][0].ToString();
            q = "update Miejsca " +
                "Set ID_Biletu = " + ID_biletu + ", StatusMiejsca = 'zajete', TypMiejsca = '" + typ_miej + "' " +
                "where ID_Seansu = " + ID_seansu + " AND(WspolMiejscaY * 10 + WspolMiejscaX - 11) = " + nr_miejsca;
            cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
