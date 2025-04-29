<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearReservacion.aspx.cs" Inherits="ProyectoFinal.Pages.CrearReservacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Crear Reservacion</h2>
        <asp:Label ID="lblmensaje" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlHabitacion" runat="server"></asp:DropDownList>
        <br />
        <asp:DropDownList ID="ddlHoteles" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHoteles_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <asp:DropDownList ID="ddlClientes" runat="server" ></asp:DropDownList>
        <br />
        <p>Fecha de entrada</p>
        <asp:TextBox ID="txtFechaEntrada" runat="server" TextMode="Date"></asp:TextBox>
        <p>Fecha de salida</p>
        <asp:TextBox ID="txtFechaSalida" runat="server" TextMode="Date"></asp:TextBox>
        <br />
        <p>Numero de adultos</p>
        <asp:TextBox ID="txtNumAdultos" runat="server" TextMode="Number"></asp:TextBox>
        <p>numero de niños</p>
        <asp:TextBox ID="txtNumNinhos" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
    </div>
</asp:Content>
