using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multikino_Winforms.Forms;

namespace Multikino_Winforms
{
    class CCentrum_Wszechswiata 
    {
        const int ID_kina = 1;
        static private int znizka_dla_seniora = 40; //w procentach (ile procent ceny trzeba zaplacic)
        static private int znizka_dla_studenta = 50; //w procentach

        //dane do wyliczania znizki
        static private int ile_biletow_nalezy_nabyc = 10;
        static private int w_jakim_przedziale_czasu = 30; //(dni)
        static private int wartosc_znizki = 90; //procent
        static private int cena_podstawowa_biletow = 30;
        static private int procent_ceny_w_tygodniu = 100; //w %
        static private int procent_ceny_w_weekend = 130; //w %

        static private int procent_ceny_za_wersje_Napisy = 100;
        static private int procent_ceny_za_wersje_Lektor = 100;
        static private int procent_ceny_za_wersje_Dubbing = 100;
        static private int procent_ceny_za_wersje_Polski = 100;

        static private int procent_ceny_za_kategorie_Fantasy = 100;
        static private int procent_ceny_za_kategorie_Animacja = 100;
        static private int procent_ceny_za_kategorie_Katastroficzny = 100;
        static private int procent_ceny_za_kategorie_Komedia = 100;
        static private int procent_ceny_za_kategorie_Przygodowy = 100;

        public CCentrum_Wszechswiata()
        {
            
        }
        ~CCentrum_Wszechswiata()
        {

        }
        public void run()
        {
            Application.Run(new CELogowanie());
            
        }
        static public int wypisz_id_kina()
        {
            return ID_kina;
        }
        static public float podaj_znizke_dla_seniora()
        {
            return znizka_dla_seniora;
        }
        static public float podaj_znizke_dla_studenta()
        {
            return znizka_dla_studenta;
        }
        static public int podaj_ile_biltow_nabyc_na_znizke()
        {
            return ile_biletow_nalezy_nabyc;
        }
        static public int podaj_w_jakim_przedziale_czasu_nalezy_nabyc_bilety_na_znizke()
        {
            return w_jakim_przedziale_czasu;
        }
        static public int podaj_wartosc_znizki()
        {
            return wartosc_znizki;
        }

        public bool stop_this()
        {
            return true;
        }
        static public int podaj_cene_podstawowa()
        {
            return cena_podstawowa_biletow;
        }
        static public int podaj_procent_ceny_w_dniu(object d)
        {
            DateTime date = (DateTime)d;
            if (date.DayOfWeek == DayOfWeek.Monday | date.DayOfWeek == DayOfWeek.Tuesday | date.DayOfWeek == DayOfWeek.Wednesday
                | date.DayOfWeek == DayOfWeek.Thursday | date.DayOfWeek == DayOfWeek.Friday) return procent_ceny_w_tygodniu;
            if (date.DayOfWeek == DayOfWeek.Sunday | date.DayOfWeek == DayOfWeek.Saturday) return procent_ceny_w_weekend;
            else return 100;
        }
        static public int podaj_procent_ceny_za_wersje_filmy(string s)
        {
            if (s.Equals("Napisy")) return procent_ceny_za_wersje_Napisy;
            if (s.Equals("Lektor")) return procent_ceny_za_wersje_Lektor;
            if (s.Equals("Dubbing")) return procent_ceny_za_wersje_Dubbing;
            if (s.Equals("Polski")) return procent_ceny_za_wersje_Polski;
            return 100;
        }
        static public int podaj_procent_ceny_za_kategorie_filmy(string s)
        {
            if (s.Equals("Fantasy")) return procent_ceny_za_kategorie_Fantasy;
            if (s.Equals("Animacja")) return procent_ceny_za_kategorie_Animacja;
            if (s.Equals("Katastroficzny")) return procent_ceny_za_kategorie_Katastroficzny;
            if (s.Equals("Komedia")) return procent_ceny_za_kategorie_Komedia;
            if (s.Equals("Przygodowy")) return procent_ceny_za_kategorie_Przygodowy;
            return 100;
        }
    }
}
