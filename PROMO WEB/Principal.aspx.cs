using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace PROMO_WEB
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            VoucherNegocio negocio = new VoucherNegocio();
            string codIngresado = TxtVoucher.Text;

            try
            {
                Voucher voucher = negocio.BuscarVoucher(codIngresado);
                if (voucher != null && (voucher.IdCliente != 0))
                {
                    Session["CodVoucher"] = voucher.Codigo;

                    Response.Redirect("PromoSeleccion.aspx");
                }
                else
                {
                    LblEjemplo.Text = "Código Incorrecto o no válido";
                }
            }
            catch (Exception)
            {
                LblEjemplo.Text = "Ocurrio un error al verificar el codigo";
            }
        }
    }
}