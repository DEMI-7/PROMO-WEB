using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROMO_WEB
{
    public partial class PromoSeleccion : System.Web.UI.Page
    {
        List<Articulo> listaArticulos;
        protected void Page_Load(object sender, EventArgs e)
        {
            // verifico que la sesion tenga un voucher no nulo
            // si se intentan meter salteandose la pagina anterior lo lleva de nuevo al principio
            if (Session["CodVoucher"] == null)
            {
                Response.Redirect("Principal.aspx");
                return;
            }

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                listaArticulos = new List<Articulo>();
                listaArticulos = negocio.Listar();

                RepTarjetasProd.DataSource = listaArticulos;
                RepTarjetasProd.DataBind();
            }

        }

        protected void BtnSeleccionar_Click(object sender, EventArgs e)
        {

        }
    }
}