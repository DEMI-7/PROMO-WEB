using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteNegocio
    {
        public Cliente BuscarCliente(string DNI)
        {
            AccesoDatos conexion = new AccesoDatos();
            DNI = DNI.Trim();

            try
            {
                conexion.SetearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @DNI");
                conexion.agregarParametro("@DNI", DNI);
                Cliente aux = null;
                conexion.EjecutarLectura();

                while (conexion.Lector.Read())
                {
                    aux = new Cliente();

                    aux.ID = (int)conexion.Lector["Id"];
                    aux.DNI = (string)conexion.Lector["Documento"];
                    aux.Nombre = (string)conexion.Lector["Nombre"];
                    aux.Apellido = (string)conexion.Lector["Apellido"];
                    aux.Email = (string)conexion.Lector["Email"];
                    aux.Direccion = (string)conexion.Lector["Direccion"];
                    aux.Ciudad = (string)conexion.Lector["Ciudad"];
                    aux.CodPostal = (int)conexion.Lector["CP"];
                }

                return aux;
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

        //INSERT INTO CLIENTES (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES (@DNI, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CodPostal)
        public bool AltaCliente(Cliente nuevoCliente)
        {
            AccesoDatos conexion = new AccesoDatos();

            try
            {
                conexion.SetearConsulta("INSERT INTO CLIENTES (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES (@DNI, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CodPostal)");
                
                conexion.agregarParametro("@DNI",nuevoCliente.DNI);
                conexion.agregarParametro("@Nombre", nuevoCliente.Nombre);
                conexion.agregarParametro("@Apellido", nuevoCliente.Apellido);
                conexion.agregarParametro("@Email", nuevoCliente.Email);
                conexion.agregarParametro("@Direccion", nuevoCliente.Direccion);
                conexion.agregarParametro("@Ciudad", nuevoCliente.Ciudad);
                conexion.agregarParametro("@CodPostal", nuevoCliente.CodPostal);

                conexion.ejecutarAccion();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
