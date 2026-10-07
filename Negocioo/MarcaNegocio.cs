using System;
using System.Collections.Generic;
using System.Text;
using Dominio; 
using System.Linq;


namespace Negocio
{
    public class MarcaNegocio
    {
        //metodo listar : devuelve las marcas de la base de datos. 

        public List <Marca> Listar ()
        {
            // se crea la lista vacia 
            List<Marca> lista = new List<Marca>();

            AccesoDatos datos = new AccesoDatos();

           try
            {
                datos.SetearConsulta ("Select Id, Descripcion From Marcas");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Descripcion"];

                    //agregamos el objeto a la lista ; 
                    lista.Add(aux);
                }
                return lista; 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }
        // inserta una nueva marca en la b de datos ; 
        public void Agregar (Marca nueva )
        {
            AccesoDatos datos = new AccesoDatos(); 

            try
            {
                datos.limpiarParametros();
                datos.SetearConsulta("Insert into Marcas (Descripcion) values (@Descripcion)");
                datos.agregarParametro("@Descripcion", nueva.Nombre);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {
                
                throw;
            }
            // no hace falta finally porque el metodo ejecutarAccion ya cierra la conexion.


        }

        public bool Existe (string nombre)
        {
            List <Marca> lista = Listar();

            
            return lista.Any(x => x.Nombre.ToLower() == nombre.ToLower  ());
        }

        public void Eliminar (int id )
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.limpiarParametros();
                datos.SetearConsulta("Delete from Marcas where Id = @Id");
                datos.agregarParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }

        }

        // Devuelve true si la marca tiene al menos un artículo asociado
        public bool tieneArticulosAsociados(int idMarca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.limpiarParametros();
                datos.SetearConsulta("SELECT COUNT(*) FROM ARTICULOS WHERE IdMarca = @idMarca");
                datos.agregarParametro("@idMarca", idMarca);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = (int)datos.Lector[0];
                    return cantidad > 0;  // true si hay al menos 1
                }
                return false;
            }
            catch (Exception) 
            {
                throw;
            }
            finally 
            {
                datos.CerrarConexion();
            }
        }


    }
}
