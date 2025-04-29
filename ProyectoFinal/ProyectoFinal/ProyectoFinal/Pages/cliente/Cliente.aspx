<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="ProyectoFinal.Pages.Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Mis Reservaciones</h2>
        <br />
        <asp:Button ID="btnCrearReservacion" runat="server" Text="Nueva Reservacion" OnClick="btnCrearReservacion_Click" CssClass="btn btn-outline-primary"/>
        <asp:HiddenField ID="hfReservacionId" runat="server" />
        <asp:Label ID="lblCliente" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="GridViewReservaciones" runat="server" DataKeyNames="idReservacion" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridViewReservaciones_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="idReservacion" HeaderText="ID de Reservacion" />
                <asp:BoundField DataField="fechaEntrada" HeaderText="Fecha de Entrada" />
                <asp:BoundField DataField="fechaSalida" HeaderText="Fecha de Salida" />
                <asp:BoundField DataField="estado" HeaderText="Estado" />

            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
