using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal.Pages.habitacion
{
    public partial class Habitaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["empleado"] == null && Session["cliente"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                loadHabitaciones();
                lblHabitacion.Text = "";
            }
        }
        private void loadHabitaciones()
        {
            using (var context = new PV_ProyectoFinalEntities2())
            {
                var habitaciones = context.spConsultarHabitacion().ToList();
                GridViewHabitaciones.DataSource = habitaciones;
                GridViewHabitaciones.DataBind();
                

                if (habitaciones != null && habitaciones.Any())
                {

                }
                else
                {
                    lblHabitacion.Text = "No se encontraron reservaciones para este cliente.";
                }
            }
        }
        protected void GridViewHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idHabitacion = Convert.ToInt32(GridViewHabitaciones.SelectedDataKey.Value);
            Response.Redirect("~/Pages/habitacion/EditarHabitacion.aspx?id=" + idHabitacion + "&bEditar=false&Nombre=" + Server.UrlEncode("Coco&Channel"));
        }

        protected void btnCrearHabitacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/habitacion/CrearHabitacion.aspx");
        }
    }
}