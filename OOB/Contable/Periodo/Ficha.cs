using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Contable.Periodo
{

    public class Ficha
    {
        public int Id { get; set; }
        public int MesActual { get; set; }
        public int AnoActual { get; set; }

        public string Ano 
        {
            get 
            {
                return AnoActual.ToString().Trim();
            }
        }

        public string Mes 
        {
            get 
            {
                return MesActual.ToString().Trim().PadLeft(2, '0');
            }
        }

        public string AnoActualDesc
        {
            get { return AnoActual.ToString(); }
        }

        public string MesActualDesc
        { 
            get
            {
                var desc = "";
                switch (MesActual) 
                { 
                    case 1:
                        desc = "ENERO";
                        break;
                    case 2:
                        desc = "FEBRERO";
                        break;
                    case 3:
                        desc = "MARZO";
                        break;
                    case 4:
                        desc = "ABRIL";
                        break;
                    case 5:
                        desc = "MAYO";
                        break;
                    case 6:
                        desc = "JUNIO";
                        break;
                    case 7:
                        desc = "JULIO";
                        break;
                    case 8:
                        desc = "AGOSTO";
                        break;
                    case 9:
                        desc = "SEPTIEMBRE";
                        break;
                    case 10:
                        desc = "OCTUBRE";
                        break;
                    case 11:
                        desc = "NOVIEMBRE";
                        break;
                    case 12:
                        desc = "DICIEMBRE";
                        break;
                }
                return desc;
            } 
        }

        public string Periodo 
        {
            get 
            {
                return MesActualDesc + ", " + Ano;
            }
        }


    }

}