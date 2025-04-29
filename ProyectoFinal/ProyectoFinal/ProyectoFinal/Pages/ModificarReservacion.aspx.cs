using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal.Pages
{
    public partial class ModificarReservacion : System.Web.UI.Page
    {
        private static int idPersona;
        private static int idHabitacion;
        private static int idHotel;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["empleado"] == null && Session["cliente"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }

                int idReservacion = int.Parse(Request.QueryString["id"]);
                PV_ProyectoFinalEntities2 _oContext = new PV_ProyectoFinalEntities2();

                // Cargar la reservación para obtener el ID del hotel
                var reservacion = _oContext.spConsultarReservacionPorId(idReservacion).FirstOrDefault();

                if (reservacion != null)
                {
                    // Obtener el ID del hotel de la habitación
                    var habitacionReservada = _oContext.Habitacion.FirstOrDefault(h => h.idHabitacion == reservacion.idHabitacion);

                    if (habitacionReservada != null)
                    {
                        int idHotel = habitacionReservada.idHotel;

                        // Filtrar habitaciones solo de ese hotel
                        var habitaciones = _oContext.Habitacion.Where(h => h.idHotel == idHotel).ToList();

                        // Cargar habitaciones en el DropDownList
                        ddlHabitaciones.DataSource = habitaciones;
                        ddlHabitaciones.DataTextField = "numeroHabitacion";
                        ddlHabitaciones.DataValueField = "idHabitacion";
                        ddlHabitaciones.DataBind();
                        ddlHabitaciones.Items.Insert(0, new ListItem("-- Seleccione una Habitacion --", "0"));

                        // Cargar los datos de la reservación en los controles correspondientes
                        CargarReservacion(idReservacion);
                    }
                    else
                    {
                        lblMensaje.Text = "No se encontró la habitación de la reservación.";
                    }
                }
                else
                {
                    lblMensaje.Text = "No se encontró la reservación especificada.";
                }
            }
        }

        private void CargarReservacion(int idReservacion)
        {
            using (var context = new PV_ProyectoFinalEntities2())
            {
                var reservacion = context.spConsultarReservacionPorId(idReservacion).FirstOrDefault();
                if (reservacion != null)
                {
                    var hotel = context.spConsultarHabitacionPorId(reservacion.idHabitacion).FirstOrDefault();

                    // Verificación y redirección según el estado de la reservación, como ya lo tienes

                    // Establecer el valor del DropDownList si el valor existe en la lista
                    if (hotel != null && ddlHabitaciones.Items.FindByValue(hotel.idHabitacion.ToString()) != null)
                    {
                        ddlHabitaciones.SelectedValue = hotel.idHabitacion.ToString();
                    }
                    else
                    {
                        ddlHabitaciones.SelectedIndex = 0; // Seleccionar el valor predeterminado
                    }

                    // Asignar el resto de los valores
                    txtFechaEntrada.Text = ((DateTime)reservacion.fechaEntrada).ToString("yyyy-MM-dd");
                    txtFechaSalida.Text = ((DateTime)reservacion.fechaSalida).ToString("yyyy-MM-dd");
                    txtNumAdultos.Text = reservacion.numeroAdultos.ToString();
                    txtNumNinhos.Text = reservacion.numeroNinhos.ToString();

                    // Obtener los IDs necesarios para el guardado
                    idPersona = reservacion.idPersona;
                    idHabitacion = ddlHabitaciones.SelectedIndex;
                    idHotel = context.Habitacion.Where(h => h.idHabitacion == idHabitacion).Select(h => h.idHotel).FirstOrDefault();
                }
                else
                {
                    lblMensaje.Text = "No se encontró la reservación especificada.";
                }
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos requeridos
                if (string.IsNullOrWhiteSpace(txtFechaEntrada.Text) ||
                    string.IsNullOrWhiteSpace(txtFechaSalida.Text) ||
                    string.IsNullOrWhiteSpace(txtNumAdultos.Text) ||
                    string.IsNullOrWhiteSpace(txtNumNinhos.Text) ||
                    ddlHabitaciones.SelectedIndex == 0)
                {
                    lblMensaje.Text = "Todos los campos son requeridos.";
                    return;
                }

                // Validar campos
                int idReservacion = int.Parse(Request.QueryString["id"]);
                if (!DateTime.TryParse(txtFechaEntrada.Text, out DateTime fechaEntrada))
                {
                    lblMensaje.Text = "Fecha de entrada no válida.";
                    return;
                }
                if (!DateTime.TryParse(txtFechaSalida.Text, out DateTime fechaSalida))
                {
                    lblMensaje.Text = "Fecha de salida no válida.";
                    return;
                }
                if (!int.TryParse(txtNumAdultos.Text, out int numeroAdultos) || numeroAdultos <= 0)
                {
                    lblMensaje.Text = "Número de adultos no válido.";
                    return;
                }
                if (!int.TryParse(txtNumNinhos.Text, out int numeroNinhos) || numeroNinhos < 0)
                {
                    lblMensaje.Text = "Número de niños no válido.";
                    return;
                }

                // Obtener idHabitacion del DropDownList
                int idHabitacion = int.Parse(ddlHabitaciones.SelectedValue);

                using (var context = new PV_ProyectoFinalEntities2())
                {
                    var hotel = context.spConsultarHotelPorId(idHotel).FirstOrDefault();
                    if (hotel == null)
                    {
                        lblMensaje.Text = "No se encontró el hotel especificado.";
                        return;
                    }

                    decimal costoPorCadaAdulto = hotel.costoPorCadaAdulto;
                    decimal costoPorCadaNinho = hotel.costoPorCadaNinho;

                    var reservacion = context.spConsultarReservacionPorId(idReservacion).FirstOrDefault();
                    if (reservacion == null)
                    {
                        lblMensaje.Text = "No se encontró la reservación especificada.";
                        return;
                    }

                    string estado = reservacion.estado;
                    int totalDiasReservacion = (fechaSalida - fechaEntrada).Days;
                    decimal costoTotal = (numeroAdultos * costoPorCadaAdulto + numeroNinhos * costoPorCadaNinho) * totalDiasReservacion;
                    DateTime fechaCreacion = reservacion.fechaCreacion;
                    DateTime fechaModificacion = DateTime.Now;

                    // Llamar al procedimiento almacenado
                    context.spEditarReservacion(
                        idReservacion,
                        idPersona,
                        idHabitacion,  // Aquí pasas el idHabitacion obtenido del DropDownList
                        fechaEntrada,
                        fechaSalida,
                        numeroAdultos,
                        numeroNinhos,
                        totalDiasReservacion,
                        costoPorCadaAdulto,
                        costoPorCadaNinho,
                        costoTotal,
                        fechaCreacion,
                        fechaModificacion,
                        estado
                    );

                    // Actualizar la bitácora
                    var bitacora = context.Bitacora.FirstOrDefault(b => b.idReservacion == idReservacion);
                    if (bitacora != null)
                    {
                        context.spEditarBitacora(
                            idBitacora: bitacora.idBitacora,
                            idReservacion: idReservacion,
                            idPersona: idPersona,
                            accionRealizada: "CORREGIDA",
                            fechaDeLaAccion: fechaModificacion
                        );
                    }
                    else
                    {
                        lblMensaje.Text = "No se encontró la bitácora correspondiente a la reservación.";
                        return;
                    }

                    // Guardar los cambios en la base de datos
                    context.SaveChanges();
                }

                // Redirigir después de guardar
                Response.Redirect("~/Pages/DetalleReservacion.aspx?id=" + idReservacion);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error al guardar la reservación: " + ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Session["cliente"] != null)
            {
                // Código para cancelar la acción y redirigir
                Response.Redirect("~/Pages/cliente/Cliente.aspx");
            }
            else if (Session["empleado"] != null)
            {
                // Código para cancelar la acción y redirigir
                Response.Redirect("~/Pages/empleado/Empleado.aspx");
            }
            
        }
    }
}