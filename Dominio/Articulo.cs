using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dominio
{
    public class Articulo
    {
        [Browsable(false)]
        public int Id { get; set; } = 0;
        [DisplayName("Código")]
        public string Codigo { get; set; } = string.Empty;
        public string Nombre {  get; set; } = string.Empty;
        [Browsable(false)]
        public string Descripcion {  get; set; } = string.Empty;
        [DisplayName("Marca")]
        public Marca MarcaProducto { get; set; } = new Marca();
        [DisplayName("Categoría")]
        public Categoria CategoriaProducto { get; set; } = new Categoria();
        public decimal Precio { get; set; }
        public List<Imagen> listaImagenes { get; set; }= new List<Imagen>();
    }
}
