using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Helpers
{

    public class Cuenta
    {

        static public string ValidarCodigoCuenta(string tb)
        {
            string codigo = "";

            if (tb.Length == 1)
            {
                codigo = tb;
            }
            else if (tb.Length == 2)
            {
                codigo = tb.Substring(0, 1) + '.' + tb.Substring(1, 1);
            }
            else if (tb.Length == 3)
            {
                codigo = tb.Substring(0, 1) + '.' + tb.Substring(1, 1) + '.' + tb.Substring(2, 1);
            }
            else if (tb.Length == 5)
            {
                codigo = tb.Substring(0, 1) + '.' + tb.Substring(1, 1) + '.' + tb.Substring(2, 1) + '.' + tb.Substring(3, 2);
            }
            else if (tb.Length == 7)
            {
                codigo = tb.Substring(0, 1) + '.' + tb.Substring(1, 1) + '.' + tb.Substring(2, 1) + '.' + tb.Substring(3, 2) + '.' + tb.Substring(5, 2);
            }
            else if (tb.Length == 10)
            {
                codigo = tb.Substring(0, 1) + '.' + tb.Substring(1, 1) + '.' + tb.Substring(2, 1) + '.' + tb.Substring(3, 2) + '.' + tb.Substring(5, 2) + '.' + tb.Substring(7, 3);
            }
            else
            {
                return "";
            }

            return codigo;
        }

    }
}