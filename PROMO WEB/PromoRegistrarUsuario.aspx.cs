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
    public partial class PromoRegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CodVoucher"] == null || Session["IdArticulo"] == null)
            {
                Response.Redirect("Principal.aspx");
                return;
            }

            if (!IsPostBack)
            {
                
            }
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Session.Remove("IdArticulo");
            Response.Redirect("PromoSeleccion.aspx");
        }
    }
}