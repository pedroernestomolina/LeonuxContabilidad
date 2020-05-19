using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Report
{

    public interface IReport
    {

        //LIBROS
        void Libro_Diario(OOB.Reportes.Libro.Diario.Ficha data, 
            OOB.Empresa.DatosNegocio.Ficha negocio);
        void Libro_Mayor(OOB.Reportes.Libro.Mayor.Ficha data, 
            OOB.Empresa.DatosNegocio.Ficha negocio);

        //PLAN DE CUENTA
        void PlanCta_MaestroCta(IEnumerable<OOB.Reportes.PlanCta.Maestro.Ficha> data);

        //BALANCES 
        void Balance_Comprobacion(IEnumerable<OOB.Reportes.Balances.Comprobacion.Ficha> data, 
            OOB.Contable.Periodo.Ficha periodo, OOB.Empresa.DatosNegocio.Ficha negocio);
        void Balance_GananciaPerdida(IEnumerable<OOB.Reportes.Balances.GananciaPerdida.Ficha> data,
            OOB.Contable.Periodo.Ficha periodo, OOB.Empresa.DatosNegocio.Ficha negocio);
        void Balance_General(IEnumerable<OOB.Reportes.Balances.General.Ficha> data,
            OOB.Contable.Periodo.Ficha periodo, OOB.Empresa.DatosNegocio.Ficha negocio);

        //COMPROBANTE DIARIO
        void Balance_ComprobanteDiario(OOB.Reportes.Balances.ComprobanteDiario.Ficha data,
             OOB.Empresa.DatosNegocio.Ficha negocio);

    }

}