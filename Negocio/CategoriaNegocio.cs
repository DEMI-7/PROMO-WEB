using System;
using System.Collections.Generic;
using System.Text;
using Dominio;

namespace Negocio
{ //use de referencia la clase ArticuloNegocio
    public class CategoriaNegocio
    {
      
        public List<Categoria> Listar()
        {  //creo lista vacia para guardar categorias
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos conexion = new AccesoDatos();  // conectamos a bd
            conexion.SetearConsulta(
                "SELECT Id, Descripcion FROM CATEGORIAS"); //traigo solo id y descripcion desde categorias
            try
            {
                conexion.EjecutarLectura();
                while (conexion.Lector.Read()) //recorremos los resultados y guaradmos en aux para convertirlos y agregarlos a la lista
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)conexion.Lector["Id"];
                    aux.Nombre = (string)conexion.Lector["Descripcion"]; //este es el nombre, en sql esta nombrado como descripcion
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
                conexion.CerrarConexion(); //cerramos conxion con la bd
            }
        }

        public void Agregar (Categoria nueva)
        {
            AccesoDatos conexion = new AccesoDatos();  // conectamos a bd
            try
            {
                conexion.SetearConsulta("INSERT INTO CATEGORIAS (Descripcion) VALUES (@Descripcion)");

                conexion.agregarParametro("@Descripcion", nueva.Nombre);
                conexion.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.CerrarConexion(); //cerramos conxion con la bd
            }
        }
        public bool CategoriaEnUso(int idCategoria)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.SetearConsulta("SELECT Id FROM ARTICULOS WHERE IdCategoria = @IdCategoria");
                conexion.agregarParametro("@IdCategoria", idCategoria);
                conexion.EjecutarLectura();
                if (conexion.Lector.Read())
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
        public void Eliminar(int idCategoria)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.SetearConsulta("DELETE FROM CATEGORIAS WHERE Id = @IdCategoria");
                conexion.agregarParametro("@IdCategoria", idCategoria);
                conexion.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
    }
}
