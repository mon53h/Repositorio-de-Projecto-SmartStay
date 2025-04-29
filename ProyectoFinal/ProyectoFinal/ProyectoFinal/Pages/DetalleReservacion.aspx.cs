using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal.Pages
{
    public partial class DetalleReservacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empleado"] == null && Session["cliente"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
            {
                // Obtener ID de la reservación de la URL
                int idReservacion = Convert.ToInt32(Request.QueryString["id"]);
                LoadReservacion(idReservacion);
                LoadBitacora(idReservacion);
            }
        }
        private void LoadReservacion(int idReservacion)
        {
            using (var context = new PV_ProyectoFinalEntities2())
            {
                var reservacion = context.Reservacion.FirstOrDefault(r => r.idReservacion == idReservacion);
                if (reservacion != null)
                {
                    lblIdReservacion.Text = reservacion.idReservacion.ToString();
                    lblFechaEntrada.Text = reservacion.fechaEntrada.ToString("dd/MM/yyyy");
                    lblFechaSalida.Text = reservacion.fechaSalida.ToString("dd/MM/yyyy");
                    lblNumAdultos.Text = reservacion.numeroAdultos.ToString();
                    lblNumNinhos.Text = reservacion.numeroNinhos.ToString();
                    lblCostoTotal.Text = reservacion.costoTotal.ToString("C");
                    lblEstado.Text = reservacion.estado;
                    if (reservacion.estado != "A" || reservacion.fechaEntrada <= DateTime.Now)
                    {
                        btnCancelar.Visible = false;
                    }
                }
                else
                {
                    lblmensaje.Text = "Reservación no encontrada.";
                }
            }
        }

        private void LoadBitacora(int idReservacion)
        {
            using (var context = new PV_ProyectoFinalEntities2())
            {
                var bitacora = context.Bitacora.Where(b => b.idReservacion == idReservacion).ToList();
                GridViewBitacora.DataSource = bitacora;
                GridViewBitacora.DataBind();
            }
        }
       

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int idReservacion = int.Parse(lblIdReservacion.Text);
            Response.Redirect("~/Pages/ModificarReservacion.aspx?id=" + idReservacion);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                int idReservacion = int.Parse(lblIdReservacion.Text);

                using (var context = new PV_ProyectoFinalEntities2())
                {
                    // Obtener la reservación actual
                    var reservacion = context.Reservacion.FirstOrDefault(r => r.idReservacion == idReservacion);

                    if (reservacion != null && reservacion.estado == "A" && reservacion.fechaEntrada > DateTime.Now)
                    {
                        // Actualizar el estado a "I" 
                        context.spEditarReservacion(
                            reservacion.idReservacion,
                            reservacion.idPersona,
                            reservacion.idHabitacion,
                            reservacion.fechaEntrada,
                            reservacion.fechaSalida,
                            reservacion.numeroAdultos,
                            reservacion.numeroNinhos,
                            reservacion.totalDiasReservacion,
                            reservacion.costoPorCadaAdulto,
                            reservacion.costoPorCadaNinho,
                            reservacion.costoTotal,
                            reservacion.fechaCreacion,
                            DateTime.Now, // Actualizar fecha de modificación
                            "I" // Cambiar estado a Inactivo
                        );
                        

                        // Buscar la entrada de la bitácora correspondiente a la reservación
                        var bitacora = context.Bitacora.FirstOrDefault(b => b.idReservacion == idReservacion);
                        if (bitacora != null)
                        {
                            // Actualizar la bitácora
                            context.spEditarBitacora(
                                idBitacora: bitacora.idBitacora,
                                idReservacion: idReservacion,
                                idPersona: reservacion.idPersona,
                                accionRealizada: "CANCELADA",
                                fechaDeLaAccion: DateTime.Now
                            );
                        }
                        else
                        {
                            lblmensaje.Text = "No se encontró la bitácora correspondiente a la reservación.";
                            return;
                        }
                        string mensaje = "Se ha cancelado la reservacion exitosamente.";
                        Response.Redirect($"Confirmacion.aspx?mensaje={HttpUtility.UrlEncode(mensaje)}");

                        // Redirigir según el tipo de usuario
                        if (Session["empleado"] != null)
                        {
                            Response.Redirect("~/Pages/empleado/Empleado.aspx");
                        }
                        else if (Session["cliente"] != null)
                        {
                            Response.Redirect("~/Pages/cliente/Cliente.aspx");
                        }
                    }
                    else
                    {
                        lblmensaje.Text = "No se puede cancelar esta reservación.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblmensaje.Text = "Ocurrió un error al cancelar la reservación: " + ex.Message;
            }
        }

        


    }
}