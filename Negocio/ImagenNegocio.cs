using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Dominio;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> Listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos conexion = new AccesoDatos();
            conexion.SetearConsulta("SELECT Id, IdArticulo, ImagenUrl as Url from IMAGENES");

            try
            {
                conexion.EjecutarLectura();

                while (conexion.Lector.Read())
                {
                    Imagen aux = new Imagen();

                    aux.Id = (int)conexion.Lector["Id"];
                    aux.IdArticulo = (int)conexion.Lector["IdArticulo"];
                    aux.Url = (string) conexion.Lector["Url"];

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
                conexion.CerrarConexion();
            }
        }

        public void GuardarImagen(int idArticulo, string url)
        {
            AccesoDatos conexion = new AccesoDatos();

            try
            {
                conexion.SetearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo,@ImagenUrl)");
                conexion.agregarParametro("@IdArticulo", idArticulo);
                conexion.agregarParametro("@ImagenUrl", url);
                conexion.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Imagen> ListarPorIdArticulo(int idArticulo)
        {
            List<Imagen> listado = new List<Imagen>();
            AccesoDatos conexion = new AccesoDatos();

            try
            {
                conexion.SetearConsulta("Select Id, IdArticulo, ImagenUrl as Url from Imagenes where IdArticulo = @IdArticulo");
                conexion.agregarParametro("@IdArticulo", idArticulo);
                conexion.EjecutarLectura();

                while (conexion.Lector.Read())
                {
                    Imagen aux = new Imagen();

                    aux.Id = (int)conexion.Lector["Id"];
                    aux.IdArticulo = (int)conexion.Lector["IdArticulo"];
                    aux.Url = (string)conexion.Lector["Url"];

                    listado.Add(aux);
                }

                return listado;
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

        private void EliminarImagen(int id)
        {
            AccesoDatos conexion = new AccesoDatos();

            try
            {
                conexion.SetearConsulta("DELETE FROM Imagenes WHERE Id = @Id");
                conexion.agregarParametro("@Id", id);
                conexion.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Modificar(int idArticulo, List<Imagen> listaImagenesModificada)
        {
            try
            {
                // Obtengo la lista de imagenes que ya tenia cargadas de antes para ese articulo
                List<Imagen> listadoBase = ListarPorIdArticulo(idArticulo);

                // Busco las que ya no estan y las borro de la BDD
                foreach (Imagen img in listadoBase)
                {
                    if (!listaImagenesModificada.Exists(x => x.Id == img.Id))
                    {
                        EliminarImagen(img.Id);
                    }
                }

                // Hacer los insert
                foreach (Imagen img in listaImagenesModificada)
                {
                    if (img.Id == 0)
                    {
                        GuardarImagen(idArticulo, img.Url);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarImagenPorArticulo(int idArticulo)
        {
            AccesoDatos conexion = new AccesoDatos();

            try
            {
                conexion.SetearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                conexion.agregarParametro("@IdArticulo", idArticulo);

                conexion.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
