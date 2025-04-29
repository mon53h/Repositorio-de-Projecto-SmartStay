using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal.Pages.habitacion
{
    public partial class EditarHabitacion : System.Web.UI.Page
    {
        private static int idHotel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["empleado"] == null && Session["cliente"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                int idHabitacion = int.Parse(Request.QueryString["id"]);
                CargarHabitacion(idHabitacion);
            }
        }

        private void CargarHabitacion(int idHabitacion)
        {
            using (var context = new PV_ProyectoFinalEntities2())
            {
                var habitacion = context.spConsultarHabitacionPorId(idHabitacion).FirstOrDefault();
                var hotel = context.Hotel.Where(h => h.idHotel == habitacion.idHotel).FirstOrDefault();
                if (habitacion != null)
                {
                    // Verificar si la habitacion está inactiva
                    if (habitacion.estado == "I")
                    {
                        // Verificar si el usuario es un empleado
                        bool esEmpleado = Session["empleado"] != null;
                        if (esEmpleado)
                        {
                            Response.Redirect("~/Pages/empleado/empleado.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Pages/cliente/Cliente.aspx");
                        }
                        return;
                    }

                    txtHotel.Text = hotel.nombre.ToString();
                    txtNumHabitacion.Text = habitacion.numeroHabitacion.ToString();
                    txtCapacidadMaxima.Text = habitacion.capacidadMaxima.ToString();
                    txtDescripcion.Text = habitacion.descripcion.ToString();
                    idHotel = context.Habitacion.Where(h => h.idHabitacion == idHabitacion).Select(h => h.idHotel).FirstOrDefault();
                }
                else
                {
                    lblMensajeError.Text = "No se encontró la reservación especificada.";
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos requeridos
                if (string.IsNullOrWhiteSpace(txtNumHabitacion.Text) ||
                    string.IsNullOrWhiteSpace(txtCapacidadMaxima.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    lblMensajeError.Text = "Todos los campos son requeridos.";
                    return;
                }

                int idHabitacion = int.Parse(Request.QueryString["id"]);

                // Validar capacidad máxima
                if (!int.TryParse(txtCapacidadMaxima.Text, out int capacidadMaxima) || capacidadMaxima < 0 || capacidadMaxima >= 8)
                {
                    lblMensajeError.Text = "Número de adultos no válido. Debe estar entre 0 y 8.";
                    return;
                }

                using (var context = new PV_ProyectoFinalEntities2())
                {
                    var hotel = context.spConsultarHotelPorId(idHotel).FirstOrDefault();
                    if (hotel == null)
                    {
                        lblMensajeError.Text = "No se encontró el hotel especificado.";
                        return;
                    }

                    var habitacion = context.spConsultarHabitacionPorId(idHabitacion).FirstOrDefault();
                    if (habitacion == null)
                    {
                        lblMensajeError.Text = "No se encontró la reservación especificada.";
                        return;
                    }

                    string descripcion = txtDescripcion.Text;
                    string estado = habitacion.estado;
                    string numHabitacion = txtNumHabitacion.Text;

                    // Llamar al procedimiento almacenado
                    context.spEditarHabitacion(
                        idHabitacion,
                        idHotel,
                        numHabitacion,
                        capacidadMaxima,
                        descripcion,
                        estado
                    );

                    // Guardar los cambios en la base de datos
                    context.SaveChanges();
                }

                // Redireccionar y mostrar mensaje de éxito
                string mensaje = "Habitacion editada exitosamente.";
                Response.Redirect($"Confirmacion.aspx?mensaje={HttpUtility.UrlEncode(mensaje)}");
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Ocurrió un error al guardar la habitación: " + ex.Message;
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                int idHabitacion = int.Parse(Request.QueryString["id"]);

                using (var context = new PV_ProyectoFinalEntities2())
                {
                    var hotel = context.spConsultarHotelPorId(idHotel).FirstOrDefault();
                    if (hotel == null)
                    {
                        lblMensajeError.Text = "No se encontró el hotel especificado.";
                        return;
                    }

                    var habitacion = context.spConsultarHabitacionPorId(idHabitacion).FirstOrDefault();
                    if (habitacion == null)
                    {
                        lblMensajeError.Text = "No se encontró la reservación especificada.";
                        return;
                    }

                    string descripcion = txtDescripcion.Text;
                    string estado = "I";
                    string numHabitacion = txtNumHabitacion.Text;

                    // Llamar al procedimiento almacenado para inactivar la habitación
                    context.spEditarHabitacion(
                        idHabitacion,
                        idHotel,
                        numHabitacion,
                        habitacion.capacidadMaxima,
                        descripcion,
                        estado
                    );

                    // Guardar los cambios en la base de datos
                    context.SaveChanges();
                }

                string mensaje = "Se ha Inactivado la Habitacion.";
                Response.Redirect($"Confirmacion.aspx?mensaje={HttpUtility.UrlEncode(mensaje)}");
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Ocurrió un error al inactivar la habitación: " + ex.Message;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/habitacion/Habitaciones.aspx");
        }
    }
}
