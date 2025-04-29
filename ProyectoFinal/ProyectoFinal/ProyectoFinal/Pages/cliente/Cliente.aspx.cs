using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal.Pages
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session["cliente"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                else
                {
                    int clienteId = Convert.ToInt32(Session["cliente"]);
                    loadReservaciones(clienteId);
                }
                lblCliente.Text = "";
            }
        }

        private void loadReservaciones(int personaId)
        {
            using (var context = new PV_ProyectoFinalEntities2())
            {
                var reservaciones = context.spConsultarReservacionPorIdPersona(personaId).ToList();
                GridViewReservaciones.DataSource = reservaciones;
                GridViewReservaciones.DataBind();

                if (reservaciones != null && reservaciones.Any())
                {
                    
                }
                else
                {
                    lblCliente.Text = "No se encontraron reservaciones para este cliente.";
                }
            }
        }

        

        protected void btnCrearReservacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/CrearReservacion.aspx");
        }

        protected void GridViewReservaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPersona = Convert.ToInt32(GridViewReservaciones.SelectedDataKey.Value);
            Response.Redirect("~/Pages/DetalleReservacion.aspx?id=" + idPersona + "&bEditar=false&Nombre=" + Server.UrlEncode("Coco&Channel"));
        }
    }
}