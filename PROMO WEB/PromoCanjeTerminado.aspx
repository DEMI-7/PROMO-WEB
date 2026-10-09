<%@ Page Title="" Language="C#" MasterPageFile="~/PromoMaster.Master" AutoEventWireup="true" CodeBehind="PromoCanjeTerminado.aspx.cs" Inherits="PROMO_WEB.PromoCanjeTerminado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor1" runat="server">

    <div class="d-flex justify-content-center my-3">
        <h1 runat="server">Felicidades <%=ganador.Nombre %>, te ganaste lo siguiente:</h1>
    </div>
    
    <div class="d-flex justify-content-center my-3">
        <section class="card" style="max-width: 320px">
            <img src="<%=premio.ImagenPortada %>" class="card-img-top" style="max-height: 250px; height: 250px; width: 100%; object-fit: contain;" alt="...">

            <div class="card-body">
                <h4 class="card-title"><%=premio.Nombre %></h4>
                <p class="card-text">COD - <%=premio.Codigo %></p>
                <p class="card-text">Voucher - <%=codVoucher %></p>
                <a href="#" class="btn-solid theme-primary">Como retiro mi premio</a>
            </div>
        </section>
    </div>

</asp:Content>
