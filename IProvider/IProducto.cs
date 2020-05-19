using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IProvider
{

    public interface IProducto
    {

        ResultadoLista<DTO.Productos.Producto.Resumen> Producto_Lista(DTO.Productos.Producto.Filtro filtro);
        ResultadoEntidad<DTO.Productos.Producto.Ficha> Producto_GetById(string Id);


        //REPORTES
        ResultadoLista<DTO.Productos.LibroInventario.Ficha> Producto_LibroInventario(DTO.Productos.LibroInventario.Filtro filtro);

    }

}