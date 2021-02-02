using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multikino_Winforms
{
    static class ObslugaOkien
    {
        public static void idzDo(string form)
        {
            for (int i = Application.OpenForms.Count-1; i >= 0 ; i--)
            {
                if (Application.OpenForms[i].Text.Equals(form)) 
                {
                    Application.OpenForms[i].Show();
                    break;
                }
                else
                {
                    Application.OpenForms[i].Hide();
                }
                Console.WriteLine(i);
                Console.WriteLine(Application.OpenForms[i].Text);
            }
        }
        public static void zamknijWSZYSTKO()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                
                Console.WriteLine(i);
                Console.WriteLine(Application.OpenForms[i].Text);
                Application.OpenForms[i].Close();
            }
        }

    }
}
