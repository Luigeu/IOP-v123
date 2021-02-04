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
    public partial class CEwybor_miejsca_klient : Form
    {
        private Button[] btnKlient;
        private int liczba_miejsc;
        public CEwybor_miejsca_klient(Button[] btnArray,int liczbaMiejsc)
        {
            int size = btnArray.Length;
            btnKlient = new Button[size];
            InitializeComponent();

            this.liczba_miejsc = liczbaMiejsc;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CEwybor_miejsca_klient_Load(object sender, EventArgs e)
        {
            int j = 1;
            char c = 'A';
            for (int i = 0; i <= 49; i++)
            {
                if (j > 10)
                {
                    j = 1;
                    c++;
                }
                btnKlient[i] = new Button();

                this.btnKlient[i].Size = new Size(40, 40);
                this.btnKlient[i].BackColor = System.Drawing.Color.Green;
                this.btnKlient[i].Text = c.ToString() + (j).ToString();
                //this.btnKlient[i].Click += btn_Click;
                this.flowLayoutPanel1.Controls.Add(btnKlient[i]);
                j++;
            }
            label5.Text = liczba_miejsc.ToString();
        }

        public void updateBtnColor(Button[] btnAr)
        {
            int size = btnAr.Length;
            for (int i = 0; i < size; i++)
            {
                this.btnKlient[i].BackColor = btnAr[i].BackColor;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
