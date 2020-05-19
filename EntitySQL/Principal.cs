using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntitySQL
{

    public partial class dbEntities : DbContext
    {

        public dBEntities(string cn)
            : base(cn)
        {
        }

    }


}
