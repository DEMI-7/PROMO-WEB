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
    public partial class PromoCanjeTerminado : System.Web.UI.Page
    {
        public Articulo premio;
        public Cliente ganador;
        public string codVoucher;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CodVoucher"] == null || Session["IdArticulo"] == null || Session["Cliente"] == null)
            {
                Response.Redirect("Principal.aspx");
                return;
            }

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                premio = negocio.BuscarArticulo((int)Session["IdArticulo"]);
                ganador = (Cliente)Session["Cliente"];
                codVoucher = (string)Session["CodVoucher"];
            }
        }
    }
}