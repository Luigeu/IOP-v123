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


        public CEwybierz_miejsca ekran_wyb_kasjer;
        
        public CEokno_Glowne()
        {
            InitializeComponent();
            
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
            for (int i = 1; i <= 50; i++)
            {
                comboNormalne.Items.Add(i.ToString());
            }
            
            
        }

        private void Bwybor_miejsc_Click(object sender, EventArgs e)
        {
            ekran_wyb_kasjer = new CEwybierz_miejsca();
            ekran_wyb_kasjer.Show();
            
            this.Visible = false;
            

            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Bwyloguj_Click(object sender, EventArgs e)
        {
            ObiektZarzadzania.idzDo("Logowanie");
        }
    }
}
