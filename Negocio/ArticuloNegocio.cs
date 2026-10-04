using System;
using System.Collections.Generic;
using System.Text;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
		// Accede a la BDD mediante la clase AccesoDatos, setea una consulta y la ejecuta en el try catch
        public List<Articulo> Listar()
        {
			List<Articulo> lista = new List<Articulo>();
			AccesoDatos conexion = new AccesoDatos();
			conexion.SetearConsulta("SELECT Art.Id, Art.Codigo, Art.Nombre, Art.Descripcion, Art.IdMarca, Mar.Descripcion AS Marca, Art.IdCategoria, Cat.Descripcion AS Categoria, Art.Precio FROM ARTICULOS Art INNER JOIN MARCAS Mar ON Art.IdMarca = Mar.Id INNER JOIN CATEGORIAS Cat ON Art.IdCategoria = Cat.Id");

			try
			{
				conexion.EjecutarLectura();

				while (conexion.Lector.Read())
				{
					Articulo aux = new Articulo();

					aux.Id = (int)conexion.Lector["Id"];

					if (!(conexion.Lector["Codigo"] is DBNull))
					{
						aux.Codigo = (string)conexion.Lector["Codigo"];
					}

					aux.Nombre = (string)conexion.Lector["Nombre"];

					if (!(conexion.Lector["Descripcion"] is DBNull))
					{
						aux.Descripcion = (string)conexion.Lector["Descripcion"];
					}

					aux.MarcaProducto.Id = (int)conexion.Lector["IdMarca"];
					aux.MarcaProducto.Nombre = (string)conexion.Lector["Marca"];

					aux.CategoriaProducto.Id = (int)conexion.Lector["IdCategoria"];
					aux.CategoriaProducto.Nombre = (string)conexion.Lector["Categoria"];

					if (!(conexion.Lector["Precio"] is DBNull))
					{
						aux.Precio = (decimal)conexion.Lector["Precio"];
					}

					lista.Add(aux);

                }

				// esta parte recupera las imagenes y las asigna a los productos
				ImagenNegocio negocio = new ImagenNegocio();
				AsignarImagenes(lista, negocio.Listar());

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

		public void NuevoRegistro(Articulo nuevo)
		{
			AccesoDatos conexion = new AccesoDatos();

			try
			{
				conexion.SetearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@Precio)");
				conexion.agregarParametro("@Codigo", nuevo.Codigo);
                conexion.agregarParametro("@Nombre", nuevo.Nombre);

				if (string.IsNullOrWhiteSpace(nuevo.Descripcion))
				{
					conexion.agregarParametro("@Descripcion", DBNull.Value);
				}
				else
				{
					conexion.agregarParametro("@Descripcion", nuevo.Descripcion);
				}

                conexion.agregarParametro("@IdMarca", nuevo.MarcaProducto.Id);
                conexion.agregarParametro("@IdCategoria", nuevo.CategoriaProducto.Id);
                conexion.agregarParametro("@Precio", nuevo.Precio);

                conexion.ejecutarAccion();
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void AsignarImagenes(List<Articulo> listaArticulos, List<Imagen> listaImagenes)
		{
			foreach (var articulo in listaArticulos)
			{
				foreach(var imagen in listaImagenes)
				{
					if (articulo.Id == imagen.IdArticulo)
					{
						articulo.listaImagenes.Add(imagen);
					}
				}
			}
		}

		public int ObtenerIdPorCodigo(string codigo)
		{
			AccesoDatos conexion = new AccesoDatos();

			int idArticulo = 0;

			try
			{
				conexion.SetearConsulta("SELECT Id FROM ARTICULOS WHERE Codigo = @Codigo");
				conexion.agregarParametro("@Codigo", codigo);
				conexion.EjecutarLectura();

				while (conexion.Lector.Read())
				{
					idArticulo = (int)conexion.Lector["Id"];
				}

				return idArticulo;
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

		public void Modificar(Articulo articulo)
		{
			AccesoDatos conexion = new AccesoDatos();

			try
			{
				conexion.SetearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id");

				conexion.agregarParametro("@Id", articulo.Id);
                conexion.agregarParametro("@Codigo", articulo.Codigo);
                conexion.agregarParametro("@Nombre", articulo.Nombre);
                conexion.agregarParametro("@Descripcion", articulo.Descripcion);
                conexion.agregarParametro("@IdMarca", articulo.MarcaProducto.Id);
                conexion.agregarParametro("@IdCategoria", articulo.CategoriaProducto.Id);
                conexion.agregarParametro("@Precio", articulo.Precio);

				conexion.ejecutarAccion();
            }
			catch (Exception)
			{

				throw;
			}
		}

		public void EliminarArticulo(Articulo articulo)
		{
			AccesoDatos conexion = new AccesoDatos();

			try
			{
				conexion.SetearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
				conexion.agregarParametro("@Id", articulo.Id);

				conexion.ejecutarAccion();

			}
			catch (Exception)
			{

				throw;
			}
		}
    }
}
