using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Reports
{

    public class FiltroLibroVenta:IFiltro
    {

        public FiltroLibroVenta()
        {
            IsDesdeHabilitado = true;
            IsHastaHabilitado = true;
            IsClienteHabilitado = false;
            IsVendedorHabilitado = false;
            IsDocumentoHabilitado = false;
        }

        private bool _isDesdeHabilitado;
        public bool IsDesdeHabilitado
        {
            get
            {
                return _isDesdeHabilitado;
            }
            set
            {
                _isDesdeHabilitado = value;
            }
        }

        private bool _isHastaHabilitado;
        public bool IsHastaHabilitado
        {
            get
            {
                return _isHastaHabilitado;
            }
            set
            {
                _isHastaHabilitado = value;
            }
        }

        private bool _isClienteHabilitado;
        public bool IsClienteHabilitado
        {
            get
            {
                return _isClienteHabilitado;
            }
            set
            {
                _isClienteHabilitado = value;
            }
        }

        private bool _isVendedorHabilitado;
        public bool IsVendedorHabilitado
        {
            get
            {
                return _isVendedorHabilitado;
            }
            set
            {
                _isVendedorHabilitado = value;
            }
        }

        private bool _isDocumentoHabilitado;
        public bool IsDocumentoHabilitado
        {
            get
            {
                return _isDocumentoHabilitado;
            }
            set
            {
                _isDocumentoHabilitado = value;
            }
        }

    }

}
