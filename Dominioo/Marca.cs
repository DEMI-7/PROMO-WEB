using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public override string ToString()
        {
            return Nombre;
        }
    }
}
