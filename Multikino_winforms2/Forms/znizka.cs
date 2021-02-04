using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multikino_Winforms.Forms
{
    public partial class okno_znizki : Form
    {
        public okno_znizki()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            this.Close();
            ObslugaOkien.idzDo("Okno Glowne Kasjera");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(textBox1.Text) & string.IsNullOrWhiteSpace(comboBox1.Text)))
            {
                if (Aktualizacja_zn.zaktualizuj(textBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm"), comboBox1.SelectedIndex))
                {
                    MessageBox.Show("Pomyslnie dodano znizke", "Informacje o znizce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nie pomyslnie dodano znizke", "Informacje o znizce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Dodawanie znizki nie powiodlo sie", "Informacje o znizce", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Console.WriteLine(comboBox1.SelectedIndex.ToString());
        }

        private void okno_znizki_Load(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            dateTimePicker1.Text = time.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");

            comboBox1.Items.Add("Seniorski");
            comboBox1.Items.Add("Studencki");
            comboBox1.Items.Add("Normalny");
        }
    }
}
