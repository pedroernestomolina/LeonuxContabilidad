using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public IProvider.InfraEstructura provider { get; set; }

        public MiServicio(IProvider.InfraEstructura provider)
        {
            this.provider = provider;
        }

    }

}