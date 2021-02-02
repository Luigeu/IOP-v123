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
    public partial class CELogowanie : Form
    {
        private CEokno_Glowne ekran_glowny;

        public CELogowanie()
        {
            InitializeComponent();
        }

        private void CELogowanie_Load(object sender, EventArgs e)
        {
            TID_Kasjera.Text = "Ankowski";
            THaslo.Text = "Elo123";
        }

        private void BLogowanie_Click(object sender, EventArgs e)
        {

            if (Kasjer.sprawdz_dane(TID_Kasjera.Text, THaslo.Text))
            {
                this.Close();
            }
            else
            {
                LInformacje_logowania.Text = "Blad logowania";
            }
        }

        private void LHaslo_Click(object sender, EventArgs e)
        {

        }

        private void ID_kasjera_Click(object sender, EventArgs e)
        {

        }

        private void TID_Kasjera_TextChanged(object sender, EventArgs e)
        {

        }

        private void THaslo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
