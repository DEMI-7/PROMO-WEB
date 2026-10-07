<%@ Page Title="" Language="C#" MasterPageFile="~/PromoMaster.Master" AutoEventWireup="true" CodeBehind="PromoSeleccion.aspx.cs" Inherits="PROMO_WEB.PromoSeleccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor1" runat="server">
    <h1>Seleccione su premio</h1>

    <div class="row">
        <asp:Repeater ID="RepTarjetasProd" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src='<%#Eval("ImagenPortada") %>' class="card-img-top" style="max-height: 150px; height: 150px; width: 100%; object-fit: contain;" alt="..." />
                        <div class="card-body">
                            <h5 class="card-title"> <%#Eval("Nombre") %> </h5>
                            <asp:Button ID="BtnSeleccionar" class="btn btn-primary w-100 h-3"
                                runat="server" Text="Seleccionar" 
                                OnClick="BtnSeleccionar_Click"
                                CommandArgument='<%# Eval("Id") %>'/>
                        </div>

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
