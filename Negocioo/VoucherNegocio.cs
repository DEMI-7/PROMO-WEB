using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class VoucherNegocio
    {
        // Devuelve null si no encuentra el voucher
        public Voucher BuscarVoucher(string codigoVoucher)
        {
            AccesoDatos conexion = new AccesoDatos();
            codigoVoucher = codigoVoucher.Trim().ToUpper();


            try
            {
                conexion.SetearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE UPPER(CodigoVoucher) = @Codigo");
                conexion.agregarParametro("@Codigo",codigoVoucher);
                Voucher aux = null;
                conexion.EjecutarLectura();

                while (conexion.Lector.Read())
                {
                    aux = new Voucher();

                    aux.Codigo = (string)conexion.Lector["CodigoVoucher"];
                    if (!(conexion.Lector["IdCliente"] is DBNull))
                    {
                        aux.IdCliente = (int)conexion.Lector["IdCliente"];
                    }
                    if (!(conexion.Lector["FechaCanje"] is DBNull))
                    {
                        aux.FechaCanje = (DateTime)conexion.Lector["FechaCanje"];
                    }
                    if (!(conexion.Lector["IdArticulo"] is DBNull))
                    {
                        aux.IdArticulo = (int)conexion.Lector["IdArticulo"];
                    }
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

        public void CanjearVoucher(Cliente cliente, int idArticulo, string CodVoucher)
        {
            //UPDATE Vouchers SET IdCliente = @IdCliente, IdArticulo = @IdArticulo, FechaCanje = GETDATE() WHERE CodigoVoucher = @CodVoucher;
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.SetearConsulta("UPDATE Vouchers SET IdCliente = @IdCliente, IdArticulo = @IdArticulo, FechaCanje = GETDATE() WHERE CodigoVoucher = @CodVoucher;");
                conexion.agregarParametro("@IdCliente", cliente.ID);
                conexion.agregarParametro("@IdArticulo",idArticulo);
                conexion.agregarParametro("@CodVoucher", CodVoucher);

                conexion.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
