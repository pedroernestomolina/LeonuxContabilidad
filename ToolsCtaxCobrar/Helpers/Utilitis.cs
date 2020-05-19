using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Helpers
{

    public class Utilitis
    {

        static public void Calculadora()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"calc.exe";
            p.Start();
            //p.WaitForExit();
        }

    }

}