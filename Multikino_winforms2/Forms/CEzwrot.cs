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
            if(!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                string[] tab;
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
                    for (int i = 0; i < tab.Length; i++)
                    {
                        listBox1.Items.Add(tab[i]);
                    }
                    listBox1.SetSelected(0, true);
                }
            }
            else
            {
                //komunikat - nie podano Id klienta
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = listBox1.SelectedIndex.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Zwrot.zrealizuj_zwrot_biletu(listBox1.SelectedIndex))
            {
                //komunikat -- poprawnie zrealizowano zwrot
                string[] tab;
                Zwrot.przeszukaj_niezrealizowane_bilety_po_ID_klienta(textBox1.Text.ToString());
                tab = Zwrot.przedstaw_tablice_seanow_jako_string();
                listBox1.Items.Clear();
                for (int i = 0; i < tab.Length; i++)
                {
                    listBox1.Items.Add(tab[i]);
                }
                listBox1.SetSelected(0, true);
            }
            else
            {
                // komunikat -- blad realizacji zwroti
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
