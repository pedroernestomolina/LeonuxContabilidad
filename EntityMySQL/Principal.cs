using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMySQL
{

    public partial class dBEntities : DbContext
    {
        public dBEntities(string cn)
            : base(cn)
        {
        }
    }

}
