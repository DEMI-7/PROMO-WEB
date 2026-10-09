<%@ Page Title="" Language="C#" MasterPageFile="~/PromoMaster.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="PROMO_WEB.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor1" runat="server">

    <img src="Imagenes/Venta%20OK_%20Todo%20en%20un%20solo%20lugar.png" class="img-fluid w-100" />

    <div class="d-flex justify-content-center my-3">
        <h2 class="modal-title">Participa por un premio!!</h2>
    </div>



    <asp:TextBox ID="TxtVoucher" runat="server" class="form-control"></asp:TextBox>

    <div>
        <asp:Button ID="BtnAceptar" runat="server" OnClick="BtnAceptar_Click" Text="Aceptar" />
    </div>

    <div>
        <asp:Label ID="LblEjemplo" runat="server" Text="Ingrese un codigo para canjear."></asp:Label>
    </div>

</asp:Content>
