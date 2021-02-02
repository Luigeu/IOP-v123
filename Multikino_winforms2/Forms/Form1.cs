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
            this.ekran_glowny = new CEokno_Glowne();
            ekran_glowny.Visible = false;
            InitializeComponent();
            this.Show();
        }

        private void CELogowanie_Load(object sender, EventArgs e)
        {

        }

        private void BLogowanie_Click(object sender, EventArgs e)
        {
            if (TID_Kasjera.Text == "pawel" & THaslo.Text == "lekan")
            {
                

                this.Visible = false;

                ekran_glowny.ShowDialog();

                if (ekran_glowny.IsDisposed)
                {
                    this.Dispose(true);
                }
            }
            else
            {
                LInformacje_logowania.Text = "Bledne wprowadzone haslo lub ID kasjera. Sprobuj Ponownie!";
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
