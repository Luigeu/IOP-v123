using Multikino_Winforms.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multikino_Winforms
{
    public partial class CEokno_Glowne : Form
    {

        private int totalSeats;
        private CEwybierz_miejsca ekran_wyb_kasjer;
        private CEzwrot ekran_zwrotu;
        private CERealizacja_rezerwacji ekran_rezerwacji;
        private okno_znizki ekran_znizki;
        
        public CEokno_Glowne()
        {
            InitializeComponent();
            this.FormClosing += Form_FormClosing;
            totalSeats = 50;

            string[] t = Sprzedaz.przeszukaj_seanse(DateTime.Now.ToString("yyyy-MM-dd"));

            for (int i = 0; i < t.Length; i++)
            {
                Lista_seansow.Items.Add(t[i]);
            }
            Lista_seansow.SetSelected(0,true);

        }
        ~CEokno_Glowne()
        {
            
        }

        private void Czmien_dzien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Lista_seansow_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void CEokno_Glowne_Load(object sender, EventArgs e)
        {
            labelDzien.Text = "Todays Date: " + dateTimePicker1.Text;

            comboNormalne.Text = "1";
            for (int i = 0; i <= totalSeats; i++)
            {
                comboNormalne.Items.Add(i.ToString());
            }
            for (int i = 0; i <= totalSeats-int.Parse(comboNormalne.Text); i++)
            {
                comboStudenckie.Items.Add(i.ToString());
            }
            for (int i = 0; i <= totalSeats- int.Parse(comboNormalne.Text); i++)
            {
                comboSeniorskie.Items.Add(i.ToString());
            }

        }

        private void Bwybor_miejsc_Click(object sender, EventArgs e)
        {
            if (Lista_seansow.SelectedItem.ToString().Equals("Brak seansów w wybranum dniu"))
            {
                MessageBox.Show("Nie wybrano seansów", "Informacje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Sprzedaz.pobierz_dane_o_seansie(Lista_seansow.SelectedIndex.ToString(), (comboNormalne.Text.ToString()),
                (comboSeniorskie.Text.ToString()), (comboStudenckie.Text.ToString())) == false)
            {
                MessageBox.Show("Nie ma wystarczającej ilosci miejsc", "Informacje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.ekran_wyb_kasjer = new CEwybierz_miejsca(int.Parse(comboNormalne.Text), int.Parse(comboSeniorskie.Text), int.Parse(comboStudenckie.Text));
                this.Visible = false;
                ekran_wyb_kasjer.Show();
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Lista_seansow.Items.Clear();
            string[] t = Sprzedaz.przeszukaj_seanse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));

            for (int i = 0; i < t.Length; i++)
            {
                Lista_seansow.Items.Add(t[i]);
            }
            if(t.Length<=0) Lista_seansow.Items.Add(t[0]);
            Lista_seansow.SetSelected(0, true);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Bwyloguj_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            ObslugaOkien.idzDo("Logowanie");
            
        }
        void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Bprzyjmij_zwrot_Click(object sender, EventArgs e)
        {
            ekran_zwrotu = new CEzwrot();
            ekran_zwrotu.ShowDialog();
        }

        private void Bzrealizuj_rezerwacje_Click(object sender, EventArgs e)
        {
            ekran_rezerwacji = new CERealizacja_rezerwacji();
            ekran_rezerwacji.ShowDialog();
        }

        private void comboStudenckie_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboNormalne.Items.Clear();
            comboSeniorskie.Items.Clear();
            for (int i = 0; i <= totalSeats-int.Parse(comboStudenckie.Text)-int.Parse(comboSeniorskie.Text); i++)
            {
                comboNormalne.Items.Add(i.ToString());
            }

            for (int i = 0; i <= totalSeats - int.Parse(comboStudenckie.Text) - int.Parse(comboNormalne.Text); i++)
            {
                comboSeniorskie.Items.Add(i.ToString());
            }

        }

        private void comboNormalne_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboStudenckie.Items.Clear();
            comboSeniorskie.Items.Clear();
            for (int i = 0; i <= totalSeats - int.Parse(comboNormalne.Text) - int.Parse(comboSeniorskie.Text); i++)
            {
                comboStudenckie.Items.Add(i.ToString());
            }

            for (int i = 0; i <= totalSeats - int.Parse(comboStudenckie.Text) - int.Parse(comboNormalne.Text); i++)
            {
                comboSeniorskie.Items.Add(i.ToString());
            }

        }

        private void comboSeniorskie_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboNormalne.Items.Clear();
            comboStudenckie.Items.Clear();
            for (int i = 0; i <= totalSeats - int.Parse(comboSeniorskie.Text) - int.Parse(comboStudenckie.Text); i++)
            {
                comboNormalne.Items.Add(i.ToString());
            }

            for (int i = 0; i <= totalSeats - int.Parse(comboSeniorskie.Text) - int.Parse(comboNormalne.Text); i++)
            {
                comboStudenckie.Items.Add(i.ToString());
            }

        }

        private void labelDzien_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAktualizuj_znizke_Click(object sender, EventArgs e)
        {
            ekran_znizki = new okno_znizki();
            ekran_znizki.ShowDialog();
        }
    }


    
}
