using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable
{

    static class Globals
    {

        public static Provider.IProvider MyData { get; set; }
        public static Report.IReport MyReports { get; set; }

    }
}
