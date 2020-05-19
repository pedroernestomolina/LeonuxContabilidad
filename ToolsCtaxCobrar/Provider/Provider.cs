using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public partial class Provider : IProvider
    {

        Servicio.IServicio _servicio;

        public Provider(Servicio.IServicio serv)
        {
            this._servicio = serv;
        }

    }

}