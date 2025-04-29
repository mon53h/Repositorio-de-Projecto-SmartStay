<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarHabitacion.aspx.cs" Inherits="ProyectoFinal.Pages.habitacion.EditarHabitacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Modificar Reservación</h2>
        <table>
            <tr>
                <td>Hotel:</td>
                <td>
                    <asp:TextBox ID="txtHotel" runat="server" TextMode="Date" /></td>
            </tr>
            <tr>
                <td>Numero de Habitacion:</td>
                <td>
                    <asp:TextBox ID="txtNumHabitacion" runat="server" MaxLength="10" />
                </td>
            </tr>

            <tr>
                <td>Capacidad Maxima:</td>
                <td>
                    <asp:TextBox ID="txtCapacidadMaxima" runat="server" TextMode="Number" MaxLength="8" /></td>
            </tr>
            <tr>
                <td>Descripcion:</td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" MaxLength="500" /></td>
            </tr>

        </table>
        <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />

        <asp:Button ID="btnInactivar" runat="server" Text="Inactivar" OnClick="btnInactivar_Click" />
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
        <br />
        <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red" />
        <br />
    </div>
</asp:Content>
