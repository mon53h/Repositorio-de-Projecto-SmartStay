<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Habitaciones.aspx.cs" Inherits="ProyectoFinal.Pages.habitacion.Habitaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Habitaciones</h2>
        <br />
        <asp:Button ID="btnCrearHabitacion" runat="server" Text="Nueva Reservacion" CssClass="btn btn-outline-primary" OnClick="btnCrearHabitacion_Click" />
        <asp:HiddenField ID="hfHbitacionId" runat="server" />
        <asp:Label ID="lblHabitacion" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="GridViewHabitaciones" runat="server" DataKeyNames="idHabitacion" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridViewHabitaciones_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="idHabitacion" HeaderText="ID" />
                <asp:BoundField DataField="idHotel" HeaderText="Hotel" />
                <asp:BoundField DataField="numeroHabitacion" HeaderText="Numero de habitacion" />
                <asp:BoundField DataField="capacidadMaxima" HeaderText="Capacidad maxima" />
                <asp:BoundField DataField="estado" HeaderText="Estado" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
