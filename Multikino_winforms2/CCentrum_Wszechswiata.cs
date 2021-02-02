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
        static private int wartosc_znizki = 10; //procent

        public CCentrum_Wszechswiata()
        {
            
        }
        ~CCentrum_Wszechswiata()
        {

        }
        public void run()
        {
            Application.Run(new CELogowanie());
            if(Kasjer.czy_kasjer_zalogowany())
            {
                Application.Run(new CEokno_Glowne());
            }
        }
        static public int wypisz_id_kina()
        {
            return ID_kina;
        }
        static public int podaj_znizke_dla_seniora()
        {
            return znizka_dla_seniora;
        }
        static public int podaj_znizke_dla_studenta()
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
    }
}
