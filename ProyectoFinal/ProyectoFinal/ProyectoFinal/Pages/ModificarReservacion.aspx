<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarReservacion.aspx.cs" Inherits="ProyectoFinal.Pages.ModificarReservacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Modificar Reservación</h2>
        <table>
            <tr>
                <td>Numero de Habitacion:</td>
                <td>
                    <asp:DropDownList ID="ddlHabitaciones" runat="server"></asp:DropDownList>
            </tr>
            <tr>
                <td>Fecha de Entrada:</td>
                <td>
                    <asp:TextBox ID="txtFechaEntrada" runat="server" TextMode="Date" /></td>
            </tr>
            <tr>
                <td>Fecha de Salida:</td>
                <td>
                    <asp:TextBox ID="txtFechaSalida" runat="server" TextMode="Date" /></td>
            </tr>
            <tr>
                <td>Número de Adultos:</td>
                <td>
                    <asp:TextBox ID="txtNumAdultos" runat="server" /></td>
            </tr>
            <tr>
                <td>Número de Niños:</td>
                <td>
                    <asp:TextBox ID="txtNumNinhos" runat="server" /></td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />

        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        <br />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
        <br />
    </div>
</asp:Content>
