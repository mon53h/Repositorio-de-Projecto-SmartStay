using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal.Pages
{
    public partial class Empleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empleado"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
            {
                loadReservaciones();
                loadClientes();
            }
        }
        private void loadReservaciones()
        {
            using (var context = new PV_ProyectoFinalEntities2())
            {
                var reservaciones = context.spConsultarReservacion().ToList();
                GridViewReservacionesEmpl.DataSource = reservaciones;
                GridViewReservacionesEmpl.DataBind();
            }
        }

        private void loadClientes()
        {
            using (var context = new PV_ProyectoFinalEntities2())
            {
                var personas = context.Persona.ToList();
                ddlClientes.DataSource = personas;
                ddlClientes.DataTextField = "nombreCompleto";
                ddlClientes.DataValueField = "idPersona";
                ddlClientes.DataBind();
                ddlClientes.Items.Insert(0, new ListItem("-- Seleccione un cliente --", "0"));
            }
        }

        protected void GridViewReservacionesEmpl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridViewReservacionesEmpl.SelectedDataKey != null)
            {
                int idReservacion = Convert.ToInt32(GridViewReservacionesEmpl.SelectedDataKey.Value);
                Response.Redirect("~/Pages/DetalleReservacion.aspx?id=" + idReservacion + "&bEditar=false&Nombre=" + Server.UrlEncode("Coco&Channel"));
            }
            else
            {
                // Manejar el caso donde SelectedDataKey es null
                lblmensaje.Text = "No se pudo obtener la ID de la reservación seleccionada.";
            }
        }

        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new PV_ProyectoFinalEntities2())
                {
                    int idCliente = Convert.ToInt32(ddlClientes.SelectedValue);
                    DateTime? fechaEntrada = null;
                    DateTime? fechaSalida = null;

                    if (!string.IsNullOrEmpty(txtFechaEntrada.Text))
                    {
                        if (DateTime.TryParse(txtFechaEntrada.Text, out DateTime tempFechaEntrada))
                        {
                            fechaEntrada = tempFechaEntrada;
                        }
                        else
                        {
                            lblmensaje.Text = "La fecha de entrada no es válida.";
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(txtFechaSalida.Text))
                    {
                        if (DateTime.TryParse(txtFechaSalida.Text, out DateTime tempFechaSalida))
                        {
                            fechaSalida = tempFechaSalida;
                        }
                        else
                        {
                            lblmensaje.Text = "La fecha de salida no es válida.";
                            return;
                        }
                    }

                    var reservaciones = context.spConsultarReservacion().AsQueryable();

                    if (idCliente != 0)
                    {
                        reservaciones = reservaciones.Where(r => r.idPersona == idCliente);
                    }

                    if (fechaEntrada.HasValue)
                    {
                        reservaciones = reservaciones.Where(r => r.fechaEntrada >= fechaEntrada.Value);
                    }

                    if (fechaSalida.HasValue)
                    {
                        reservaciones = reservaciones.Where(r => r.fechaSalida <= fechaSalida.Value);
                    }

                    GridViewReservacionesEmpl.DataSource = reservaciones.ToList();
                    GridViewReservacionesEmpl.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblmensaje.Text = "Ocurrió un error al buscar las reservaciones: " + ex.Message;
            }
        }

        protected void btnCrearReservacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CrearReservacion.aspx");
        }
    }
}