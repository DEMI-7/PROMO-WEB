<%@ Page Title="" Language="C#" MasterPageFile="~/PromoMaster.Master" AutoEventWireup="true" CodeBehind="PromoRegistrarUsuario.aspx.cs" Inherits="PROMO_WEB.PromoRegistrarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor1" runat="server">

    <div class="row">
        <div class="col-6">

            <div class="mb-3">
                <label for="TxtDNI" class="form-label">Ingrese su DNI:</label>
                <div class="input-group">
                    <asp:TextBox ID="TxtDNI" CssClass="form-control"
                        runat="server"
                        oninput="validarTexto(this,7)" ></asp:TextBox>
                    <asp:Button ID="BtnValidarDNI" CssClass="btn btn-primary"
                                runat="server" Text="Validar DNI"
                                OnClick="BtnValidarDNI_Click" />
                </div>
            </div>

            <div class="mb-3">
                <label for="TxtNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="TxtNombre" CssClass="form-control"
                    Enabled="false" runat="server"
                    oninput="validarTexto(this, 2);" ></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TxtApellido" class="form-label">Apellido:</label>
                <asp:TextBox ID="TxtApellido" CssClass="form-control"
                    Enabled="false" runat="server"
                    oninput="validarTexto(this, 2);" ></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TxtEmail" class="form-label">Email:</label>
                <asp:TextBox ID="TxtEmail" CssClass="form-control"
                    Enabled="false" runat="server"
                    oninput="validarEmail(this)" ></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TxtDireccion" class="form-label">Dirección:</label>
                <asp:TextBox ID="TxtDireccion" CssClass="form-control"
                    Enabled="false" runat="server"
                    oninput="validarTexto(this, 2);" ></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TxtCiudad" class="form-label">Ciudad:</label>
                <asp:TextBox ID="TxtCiudad" CssClass="form-control"
                    Enabled="false" runat="server"
                    oninput="validarTexto(this, 2);" ></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TxtCodPostal" class="form-label">Código Postal:</label>
                <asp:TextBox ID="TxtCodPostal" CssClass="form-control"
                    Enabled="false" runat="server"
                    oninput="validarTexto(this, 2);" ></asp:TextBox>
            </div>


        </div>
    </div>

    <div class="text-center my-2">
        <asp:Label ID="LblMensajeError" runat="server"
            CssClass="text-danger fw-bold d-block"
            Visible="true"></asp:Label>
    </div>

    <div class="d-flex justify-content-center my-3">
            <!-- Botón Confirmar Canje (deshabilitado por defecto) -->
            <asp:Button ID="BtnConfirmar" runat="server" 
                        Text="Confirmar Canje" 
                        CssClass="btn btn-success w-50 disabled" 
                        Enabled="false" 
                        OnClick="BtnConfirmar_Click" />
    </div>
     
    <asp:Button ID="BtnVolver" runat="server"
                Text="← Cambiar Producto"
                class="btn btn-secondary"
                OnClick="BtnVolver_Click" />


    <script type="text/javascript">

    // Validar Texto simple (Nombre / Apellido)
    function validarTexto(input, minLongitud) {
        var valor = input.value.trim();
        
        if (valor.length >= minLongitud) {
            marcarValido(input);
        } else {
            marcarInvalido(input);
        }
    }

    // Validar Teléfono (Exactamente 10 números)
    function validarTelefono(input) {
        // Expresión regular: solo dígitos, exactamente 10
        var regexTelefono = /^[0-9]{10}$/;
        
        if (regexTelefono.test(input.value.trim())) {
            marcarValido(input);
        } else {
            marcarInvalido(input);
        }
    }

    // Validar Email con Expresión Regular
    function validarEmail(input) {
        var regexEmail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        
        if (regexEmail.test(input.value.trim())) {
            marcarValido(input);
        } else {
            marcarInvalido(input);
        }
    }

    // Funciones auxiliares para cambiar las clases de Bootstrap
function verificarFormulario() {
    var btnConfirmar = document.getElementById('<%= BtnConfirmar.ClientID %>');

    // Buscamos los inputs obligatorios
    var txtDNI = document.getElementById('<%=TxtDNI.ClientID %>');
    var txtNombre = document.getElementById('<%= TxtNombre.ClientID %>');
    var txtApellido = document.getElementById('<%= TxtApellido.ClientID %>');
    var txtEmail = document.getElementById('<%= TxtEmail.ClientID %>');
    var txtDireccion = document.getElementById('<%= TxtDireccion.ClientID %>');
    var txtCiudad = document.getElementById('<%= TxtCiudad.ClientID %>');
    var txtCodPostal = document.getElementById('<%= TxtCodPostal.ClientID %>');

    // Comprobamos si TODOS tienen la clase 'is-valid'
    var dniValido = txtDNI.classList.contains('is-valid');
    var nombreValido = txtNombre.classList.contains('is-valid');
    var apellidoValido = txtApellido.classList.contains('is-valid');
    var emailValido = txtEmail.classList.contains('is-valid');
    var direccionValido = txtDireccion.classList.contains('is-valid');
    var ciudadValido = txtCiudad.classList.contains('is-valid');
    var codPostalValido = txtCodPostal.classList.contains('is-valid');


    if (dniValido && nombreValido && apellidoValido && emailValido
        && direccionValido && ciudadValido && codPostalValido) {
        // Habilitamos el botón
        btnConfirmar.disabled = false;
        btnConfirmar.classList.remove('disabled');
    } else {
        // Si alguno falla o se borra, lo volvemos a deshabilitar
        btnConfirmar.disabled = true;
        btnConfirmar.classList.add('disabled');
    }
}

// Actualizamos las funciones individuales para que llamen a 'verificarFormulario()' al final
function marcarValido(input) {
    input.classList.remove('is-invalid');
    input.classList.add('is-valid');
    verificarFormulario(); // <-- Llama a la verificación global
}

function marcarInvalido(input) {
    input.classList.remove('is-valid');
    input.classList.add('is-invalid');
    verificarFormulario(); // <-- Llama a la verificación global
}

    </script>
</asp:Content>
