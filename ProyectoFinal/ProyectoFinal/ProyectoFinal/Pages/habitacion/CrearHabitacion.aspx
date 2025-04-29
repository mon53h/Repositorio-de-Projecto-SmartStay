<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearHabitacion.aspx.cs" Inherits="ProyectoFinal.Pages.habitacion.CrearHabitacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Crear Reservacion</h2>
        <asp:Label ID="lblmensaje" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlHoteles" runat="server"></asp:DropDownList>
        <br />
        <p>Numero de Habitacion</p>
        <asp:TextBox ID="txtNumeroHabitacion" runat="server" ></asp:TextBox>
        <p>Capacidad Maxima</p>
        <asp:TextBox ID="txtCapacidadMaxima" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <p>Descripcion</p>
        <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="500"></asp:TextBox>
        <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
    </div>
</asp:Content>
