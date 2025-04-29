<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="ProyectoFinal.Pages.Empleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Reservaciones</h2>

    <br />
    <asp:DropDownList ID="ddlClientes" runat="server" OnSelectedIndexChanged="ddlClientes_SelectedIndexChanged"></asp:DropDownList>
    <br />
    <asp:TextBox ID="txtFechaEntrada" runat="server" TextMode="Date"></asp:TextBox>
    
    <asp:TextBox ID="txtFechaSalida" runat="server" TextMode="Date"></asp:TextBox>
    
    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
    <br />
    <asp:Button ID="btnCrearReservacion" runat="server" Text="Button" OnClick="btnCrearReservacion_Click"/>
    <asp:Label ID="lblmensaje" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <asp:GridView ID="GridViewReservacionesEmpl" runat="server" OnSelectedIndexChanged="GridViewReservacionesEmpl_SelectedIndexChanged" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataKeyNames="idReservacion">
        <Columns>
            <asp:BoundField DataField="idReservacion" HeaderText="ID de Reservacion" />
            <asp:BoundField DataField="fechaEntrada" HeaderText="Fecha de Entrada" />
            <asp:BoundField DataField="fechaSalida" HeaderText="Fecha de Salida" />
            <asp:BoundField DataField="costoTotal" HeaderText="Costo Total" />
            <asp:BoundField DataField="estado" HeaderText="Estado" />
        </Columns>
    </asp:GridView>
</asp:Content>
