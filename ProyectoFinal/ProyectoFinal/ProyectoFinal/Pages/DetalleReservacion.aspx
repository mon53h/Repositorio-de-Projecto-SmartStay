<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleReservacion.aspx.cs" Inherits="ProyectoFinal.Pages.DetalleReservacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Detalle de Reservación</h2>
        <asp:Label ID="lblmensaje" runat="server" Text="Label"></asp:Label>

        <!-- Tabla de detalles de la reservación -->
        <table>
            <tr>
                <td>ID Reservación:</td>
                <td>
                    <asp:Label ID="lblIdReservacion" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Fecha de Entrada:</td>
                <td>
                    <asp:Label ID="lblFechaEntrada" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Fecha de Salida:</td>
                <td>
                    <asp:Label ID="lblFechaSalida" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Número de Adultos:</td>
                <td>
                    <asp:Label ID="lblNumAdultos" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Número de Niños:</td>
                <td>
                    <asp:Label ID="lblNumNinhos" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Costo Total:</td>
                <td>
                    <asp:Label ID="lblCostoTotal" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Estado:</td>
                <td>
                    <asp:Label ID="lblEstado" runat="server"></asp:Label></td>
            </tr>
            <!-- Agrega más filas según sea necesario -->
        </table>

        <br />

        <!-- Botones -->
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClientClick="window.history.back(); return false;" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />

        <br />
        <br />

        <!-- Tabla de bitácora -->
        <h3>Bitácora de Reservación</h3>
        <asp:GridView ID="GridViewBitacora" runat="server" AutoGenerateColumns="True">
        </asp:GridView>

    </div>
</asp:Content>
