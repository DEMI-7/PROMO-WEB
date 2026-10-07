<%@ Page Title="" Language="C#" MasterPageFile="~/PromoMaster.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="PROMO_WEB.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor1" runat="server">
    <h1>VentaOk</h1>
    <h2>Participa por un premio!!</h2>

    <asp:TextBox ID="TxtVoucher" runat="server"></asp:TextBox>

    <div>
        <asp:Button ID="BtnAceptar" runat="server" OnClick="BtnAceptar_Click" Text="Aceptar" />
    </div>

    <div>
        <asp:Label ID="LblEjemplo" runat="server" Text="Ingrese un codigo para canjear."></asp:Label>
    </div>

</asp:Content>
