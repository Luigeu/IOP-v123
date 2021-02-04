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
    public partial class CERealizacja_rezerwacji : Form
    {
        public CERealizacja_rezerwacji()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            ObslugaOkien.idzDo("Okno Glowne Kasjera");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if(Realizacja_rezerwacji.przeszukaj_seanse_dla_danego_klienta(textBox1.Text.ToString()))
            {
                // komunikat_poprwanie zczytano dane klienta
                string[] t = Realizacja_rezerwacji.drukuj_tablice_rezerwacji();
                for (int i = 0; i < t.Length; i++)
                {
                    listBox1.Items.Add(t[i]);                   
                }
                listBox1.SetSelected(0, true);
                Realizacja_rezerwacji.przeszykaj_bilety_dla_danej_rezerwacji(listBox1.SelectedIndex.ToString());
                richTextBox1.Text = Realizacja_rezerwacji.drukuj_tablice_miejsc();         
            }
            else
            {
                label4.Text = "nie pobrao";//to mozna wywalic
                //komunikat - bład wprowadzonych danych lub klient nie ma rezerwacji
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Realizacja_rezerwacji.przeszykaj_bilety_dla_danej_rezerwacji(listBox1.SelectedIndex.ToString());
            if (string.IsNullOrWhiteSpace(listBox1.Text)) richTextBox1.Text = Realizacja_rezerwacji.drukuj_tablice_miejsc();
            richTextBox1.Text = "";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Realizacja_rezerwacji.zrealizuj_rezerwacje())
            {
                //komunikat przeprowadzono
            }
            else
            {
                //komunikat nie udao sie
            }
        }
    }
}
