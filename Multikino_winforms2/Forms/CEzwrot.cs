using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multikino_Winforms.Forms
{
    public partial class CEzwrot : Form
    {
        public CEzwrot()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            ObslugaOkien.idzDo("Okno Glowne Kasjera");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            odswierz_liste_biletow();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(listBox1.Text))
            {
                // komunikat - nie wybrano biletu
            }
            else if(Zwrot.zrealizuj_zwrot_biletu(listBox1.SelectedIndex))
            {
                odswierz_liste_biletow();
                //komunikat -- poprawnie zrealizowano zwrot

            }
            else
            {
                // komunikat -- blad realizacji zwroti
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
                    }

        private void odswierz_liste_biletow()
        {
            string[] tab;

            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                Zwrot.znajdz_bilet_o_danym_ID(textBox2.Text.ToString());
                tab = Zwrot.przedstaw_tablice_seanow_jako_string();
                if (tab.Length <= 0)
                {
                    listBox1.Items.Clear();
                    //jakieś powiadnomienie - nie znaleziono biletu o podanym ID
                }
                else
                {
                    listBox1.Items.Clear();
                    for (int i = 0; i < tab.Length; i++) listBox1.Items.Add(tab[i]);
                    listBox1.SetSelected(0, true);
                }
            }
            else if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {

                Zwrot.przeszukaj_niezrealizowane_bilety_po_ID_klienta(textBox1.Text.ToString());
                tab = Zwrot.przedstaw_tablice_seanow_jako_string();
                if (tab.Length <= 0)
                {
                    listBox1.Items.Clear();
                    //jakieś powiadnomienie - nie znaleziono klienta o podanym ID
                }
                else
                {
                    listBox1.Items.Clear();
                    for (int i = 0; i < tab.Length; i++) listBox1.Items.Add(tab[i]);
                    listBox1.SetSelected(0, true);
                }
            }
            else
            {
                //komunikat - nie podano Id klienta ani Id biletu
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
