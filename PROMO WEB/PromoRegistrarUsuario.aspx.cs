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
                LblMensajeError.Visible = false;
                LblMensajeError.Text = string.Empty;
            }
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Session.Remove("IdArticulo");
            Response.Redirect("PromoSeleccion.aspx");
        }

        protected void BtnValidarDNI_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente aux = negocio.BuscarCliente(TxtDNI.Text.Trim());

            if (aux != null)
            {

                TxtNombre.Enabled = false;
                TxtApellido.Enabled = false;
                TxtCiudad.Enabled = false;
                TxtDireccion.Enabled = false;
                TxtCodPostal.Enabled = false;
                TxtEmail.Enabled = false;

                TxtNombre.Text = aux.Nombre;
                TxtApellido.Text = aux.Apellido;
                TxtCodPostal.Text = aux.CodPostal.ToString();
                TxtDireccion.Text = aux.Direccion;
                TxtEmail.Text = aux.Email;
                TxtCiudad.Text = aux.Ciudad;

                TxtDNI.CssClass = "form-control is-valid";

                BtnConfirmar.Enabled = true;
                BtnConfirmar.CssClass = "btn btn-success w-50";
            }
            else
            {

                TxtNombre.Text = "";
                TxtApellido.Text = "";
                TxtCodPostal.Text = "";
                TxtDireccion.Text = "";
                TxtEmail.Text = "";
                TxtCiudad.Text = "";

                TxtNombre.Enabled = true;
                TxtApellido.Enabled = true;
                TxtCiudad.Enabled = true;
                TxtDireccion.Enabled = true;
                TxtCodPostal.Enabled = true;
                TxtEmail.Enabled = true;

                BtnConfirmar.Enabled = false;
                BtnConfirmar.CssClass = "btn btn-success w-50 disabled";
            }

        }

        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            int idArticulo = (int)Session["IdArticulo"];
            string codVoucher = (string)Session["CodVoucher"];

            ClienteNegocio negocio = new ClienteNegocio();
            Cliente aux = negocio.BuscarCliente(TxtDNI.Text.Trim());

            LblMensajeError.Visible = true;

            if (aux == null)
            {
                try
                {
                    aux = new Cliente();

                    aux.DNI = TxtDNI.Text.Trim();
                    aux.Nombre = TxtNombre.Text.Trim();
                    aux.Apellido = TxtApellido.Text.Trim();
                    aux.Email = TxtEmail.Text.Trim();
                    aux.Ciudad = TxtCiudad.Text.Trim();
                    aux.Direccion = TxtDireccion.Text.Trim();
                    aux.CodPostal = int.Parse(TxtCodPostal.Text.Trim());

                    negocio.AltaCliente(aux);

                    aux.ID = negocio.BuscarCliente(aux.DNI).ID;
                }
                catch (Exception)
                {
                    LblMensajeError.Text = "Error al hacer validar la confirmacion.";
                }
            }

            try
            {
                VoucherNegocio negocioVoucher = new VoucherNegocio();
                negocioVoucher.CanjearVoucher(aux,idArticulo, codVoucher);
            }
            catch (Exception)
            {
                LblMensajeError.Text = "Error al hacer validar la confirmacion.";
            }

            Session["Cliente"] = aux;
            Response.Redirect("PromoCanjeTerminado.aspx");

        }
    }
}