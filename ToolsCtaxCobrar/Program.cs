using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ToolsCtaxCobrar
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IProvider.InfraEstructura _provider = new ProviderMySql.Provider();
            var r1 = _provider.Inicializa();
            if (r1.Result == DTO.EnumResult.isError)
            {
                Helpers.Msg.Error(r1.Mensaje);
                Application.Exit();
            }
            else
            {
                Servicio.IServicio _servicio = new Servicio.MiServicio(_provider);
                Globals.MyData = new Provider.Provider(_servicio);
                Globals.MyReports = new Reports.Reports();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }

}