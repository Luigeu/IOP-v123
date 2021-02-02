using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multikino_Winforms
{
    static class ObiektZarzadzania
    {



        public static void idzDo(string form)
        {
            for (int i = Application.OpenForms.Count-1; i >=0; i--)
            {
                if (Application.OpenForms[i].Equals(form))
                {
                    Application.OpenForms[i].Show();
                }
                else
                {
                    Application.OpenForms[i].Hide();
                }
            }
        }


    }
}
