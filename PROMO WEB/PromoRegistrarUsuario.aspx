<%@ Page Title="" Language="C#" MasterPageFile="~/PromoMaster.Master" AutoEventWireup="true" CodeBehind="PromoRegistrarUsuario.aspx.cs" Inherits="PROMO_WEB.PromoRegistrarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor1" runat="server">

    <div class="mb-3">
        <label for="exampleFormControlInput1" class="form-label">Email address</label>
        <asp:TextBox ID="TxtDNI" class="form-control" runat="server"></asp:TextBox>
    </div>
     
    <asp:Button ID="BtnVolver" runat="server"
                Text="← Cambiar Producto"
                class="btn btn-secondary"
                OnClick="BtnVolver_Click" />
</asp:Content>
