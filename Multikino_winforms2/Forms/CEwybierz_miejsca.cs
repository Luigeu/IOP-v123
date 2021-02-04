using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multikino_Winforms;


namespace Multikino_Winforms.Forms
{
    public partial class CEwybierz_miejsca : Form
    {
        private CEwybor_miejsca_klient ekran_wyb_klient;
        private int liczbaBiletow;
        private int aktualnaLiczbaBiletow;
        private Button[] btn = new Button[50];
        private bool wybrano_stu, wybrano_sen;
        private string l_nor,  l_sen,  l_stu;

        public CEwybierz_miejsca(int l_nor, int l_sen, int l_stu)
        {
            InitializeComponent();
            this.l_nor = l_nor.ToString();
            this.l_sen = l_sen.ToString();
            this.l_stu = l_stu.ToString();

            if (l_sen != 0) wybrano_sen = true;
            else wybrano_sen = false;
            if (l_stu != 0) wybrano_stu = true;
            else wybrano_stu = false;

            this.liczbaBiletow = l_nor + l_sen + l_stu;
            this.aktualnaLiczbaBiletow = l_nor + l_sen + l_stu;
            richTextBox1.AppendText(Sprzedaz.oblicz_cene(this.l_nor, this.l_sen, this.l_stu));

            this.FormClosing += btn_cofnij_Click;
        }

        ~CEwybierz_miejsca()
        {
            //this.ekran_wyb_klient.Close();
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CEwybierz_miejsca_Load(object sender, EventArgs e)
        {
            buttonArray();

            ekran_wyb_klient = new CEwybor_miejsca_klient(this.btn,liczbaBiletow);

            ekran_wyb_klient.Visible = true;

            label5.Text = liczbaBiletow.ToString();

            ekran_wyb_klient.updateBtnColor(this.btn);

        }

        public void buttonArray()
        {
            int j = 1;
            char c = 'A';
            for (int i = 0; i <= 49; i++)
            {
                if (j >10)
                {
                    j = 1;
                    c++;
                }
                btn[i] = new Button();
                btn[i].Size = new Size(40,40);

                if (Sprzedaz.czy_miejsce_wolne(i))
                {
                    btn[i].Enabled = true;
                    btn[i].BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    btn[i].BackColor = System.Drawing.Color.Red;
                    btn[i].Enabled = false;
                }
                btn[i].Text = c.ToString()+(j).ToString();
                btn[i].Click += btn_Click;
                
                flowLayoutPanel1.Controls.Add(btn[i]);
                j++;
            }   
        }

        public void btn_Click(object sender, EventArgs e)
        {
            

                Button btn1 = (Button)sender;
                if (btn1.BackColor == System.Drawing.Color.Green & aktualnaLiczbaBiletow >0)
                {
                    btn1.BackColor = System.Drawing.Color.Blue;
                    aktualnaLiczbaBiletow--;
                }
                else if (btn1.BackColor == System.Drawing.Color.Blue & aktualnaLiczbaBiletow < liczbaBiletow)
                {
                    btn1.BackColor = System.Drawing.Color.Green;
                    aktualnaLiczbaBiletow++;
                }
                ekran_wyb_klient.updateBtnColor(this.btn);

                label5.Text = aktualnaLiczbaBiletow.ToString();

        }
    
        private void btn_cofnij_Click(object sender, EventArgs e)
        {
            
            ekran_wyb_klient.Close();
            this.Dispose();
            this.Close();
            ObslugaOkien.idzDo("Okno Glowne Kasjera");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_dalej_Click(object sender, EventArgs e)
        {
            if(Sprzedaz.sprzedaj_bilety(btn,l_nor,l_sen,l_stu))
            {
                MessageBox.Show("Dokonano zakupu", "Informacje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label6.Text = "";
                this.Close();
                ekran_wyb_klient.Close();
                ObslugaOkien.idzDo("Okno Glowne Kasjera");
            }
            else
            {
                MessageBox.Show("Błąd rezerwacji. \r\n \r\n  Mozliwa przyczyna: \r\n - nie wybrano wszystkich miejsc \r\n  - klientowi nie przysluguje znizka \r\n - bilety nie są już dostępne)", "Informacje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void btnWprowadzIDklienta_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (Sprzedaz.sprawdz_poprawnosc_podanego_id(textBox1.Text.ToString()))
                {
                    label6.Text = "Pomyslnie pobrano dane klienta";
                    if (Sprzedaz.sprawdz_czy_przysluguje_znizka(wybrano_sen, wybrano_stu))
                    {
                        richTextBox1.Clear();
                        richTextBox1.AppendText(Sprzedaz.oblicz_cene(this.l_nor, this.l_sen, this.l_stu));

                        label6.Text += "\r\nGratulacje!! Przysluguje ci znizka.";
                        
                    }
                    else
                    {
                        MessageBox.Show("Nie przysluguje znizka, wypad", "Informacje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Nie ma takiego klienta", "Informacje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else { MessageBox.Show("Nie podano id klienta", "Informacje", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

    }
}
