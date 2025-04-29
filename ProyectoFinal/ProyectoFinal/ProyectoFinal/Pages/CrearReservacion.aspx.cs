using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal.Pages
{
    public partial class CrearReservacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["empleado"] == null && Session["cliente"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                lblmensaje.Text = "";
                if (Session["cliente"] != null)
                {
                    ddlClientes.Visible = false;
                }
                else
                {
                    ddlClientes.Visible=true;
                }
                try
                {
                    PV_ProyectoFinalEntities2 _oContext = new PV_ProyectoFinalEntities2();
                    // Cargar hoteles
                    var hoteles = _oContext.Hotel.ToList();
                    ddlHoteles.DataSource = hoteles;
                    ddlHoteles.DataTextField = "nombre";
                    ddlHoteles.DataValueField = "idHotel";
                    ddlHoteles.DataBind();
                    ddlHoteles.Items.Insert(0, new ListItem("-- Seleccione un Hotel --", "0"));

                    // Obtener solo las personas que no son empleados (clientes)
                    var clientes = _oContext.Persona.Where(l => l.esEmpleado == false && l.estado == "A").ToList();

                    if (clientes.Any())
                    {
                        // Si hay clientes, cargar el dropdown
                        ddlClientes.DataSource = clientes;
                        ddlClientes.DataTextField = "nombreCompleto";
                        ddlClientes.DataValueField = "idPersona";
                        ddlClientes.DataBind();
                        ddlClientes.Items.Insert(0, new ListItem("-- Seleccione un Cliente --", "0"));
                    }
                    else
                    {
                        // Manejar el caso cuando no hay clientes
                        lblmensaje.Text = "No hay clientes registrados.";
                    }

                    var habitaciones = _oContext.Habitacion.ToList();
                    ddlHabitacion.DataSource = habitaciones;
                    ddlHabitacion.DataTextField = "numeroHabitacion";
                    ddlHabitacion.DataValueField = "idHabitacion";
                    ddlHabitacion.DataBind();
                    ddlHabitacion.Items.Insert(0, new ListItem("-- Seleccione una habitacion --", "0"));

                }
                catch (Exception ex)
                {
                    // Manejar la excepción y mostrar un mensaje de error
                    lblmensaje.Text = "Ocurrió un error al cargar los clientes: " + ex.Message;
                    // Opcional: Registrar el error para su análisis
                    // Log.Error("Error al cargar clientes", ex);
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    // Validar campos requeridos
                    if (string.IsNullOrWhiteSpace(txtFechaEntrada.Text) ||
                        string.IsNullOrWhiteSpace(txtFechaSalida.Text) ||
                        string.IsNullOrWhiteSpace(txtNumAdultos.Text) ||
                        string.IsNullOrWhiteSpace(txtNumNinhos.Text))

                    {
                        lblmensaje.Text = "Todos los campos son requeridos.";
                        return;
                    }
                    // Convertir y validar fechas
                    DateTime fechaEntrada;
                    DateTime fechaSalida;
                    if (!DateTime.TryParse(txtFechaEntrada.Text, out fechaEntrada))
                    {
                        lblmensaje.Text = "La fecha de entrada no es válida.";
                        return;
                    }
                    if (!DateTime.TryParse(txtFechaSalida.Text, out fechaSalida))
                    {
                        lblmensaje.Text = "La fecha de salida no es válida.";
                        return;
                    }

                    // Convertir y validar números
                    int numeroAdultos;
                    int numeroNinhos;
                    if (!int.TryParse(txtNumAdultos.Text, out numeroAdultos))
                    {
                        lblmensaje.Text = "El número de adultos no es válido.";
                        return;
                    }
                    if (!int.TryParse(txtNumNinhos.Text, out numeroNinhos))
                    {
                        lblmensaje.Text = "El número de niños no es válido.";
                        return;
                    }

                    using (var context = new PV_ProyectoFinalEntities2())
                    {
                        int idHabitacion = Convert.ToInt32(ddlHabitacion.SelectedValue);
                        int totalPersonas = numeroAdultos + numeroNinhos;

                        // Verificar la capacidad de la habitación
                        var habitacion = context.Habitacion.FirstOrDefault(h => h.idHabitacion == idHabitacion);
                        if (habitacion == null)
                        {
                            lblmensaje.Text = "La habitación seleccionada no existe.";
                            return;
                        }

                        if (habitacion.capacidadMaxima < totalPersonas)
                        {
                            lblmensaje.Text = "La habitación no tiene suficiente espacio para el número de personas.";
                            return;
                        }

                        // Verificar disponibilidad de la habitación
                        if (habitacion.estado != "A")
                        {
                            lblmensaje.Text = "La habitación no está disponible.";
                            return;
                        }

                        // Consultar el costo por adulto y niño del hotel
                        int idHotel = Convert.ToInt32(ddlHoteles.SelectedValue);
                        var hotel = context.spConsultarHotelPorId(idHotel).FirstOrDefault();
                        if (hotel == null)
                        {
                            lblmensaje.Text = "El hotel seleccionado no existe.";
                            return;
                        }

                        decimal costoAdulto = hotel.costoPorCadaAdulto;
                        decimal costoNinho = hotel.costoPorCadaNinho;

                        // Calcular el total de días de la reservación
                        int totalDiasReservacion = (fechaSalida - fechaEntrada).Days;

                        // Calcular el costo total de la reservación
                        decimal costoTotal = (costoAdulto * numeroAdultos + costoNinho * numeroNinhos) * totalDiasReservacion;

                        // Obtener el id del cliente
                        int idCliente;
                        if (Session["cliente"] != null)
                        {
                            idCliente = Convert.ToInt32(Session["cliente"]);
                        }
                        else
                        {
                            idCliente = Convert.ToInt32(ddlClientes.SelectedValue);
                        }

                        // Guardar en la base de datos usando el procedimiento almacenado
                        context.spCrearReservacion(
                            idCliente, 
                            idHabitacion, 
                            fechaEntrada, 
                            fechaSalida, 
                            numeroAdultos, 
                            numeroNinhos, 
                            totalDiasReservacion,
                            costoAdulto,
                            costoNinho,
                            costoTotal, 
                            DateTime.Now, 
                            DateTime.Now 
                        );
                        int idReservacion = context.Reservacion.Max(r => r.idReservacion);
                        // Crear la bitácora
                        context.spCrearBitacora(
                            idReservacion,
                            idCliente,
                            "CREADA",
                            DateTime.Now
                        );
                        
                        string mensaje = "Reservación guardada exitosamente.";
                        Response.Redirect($"Confirmacion.aspx?mensaje={HttpUtility.UrlEncode(mensaje)}");
                    }
                }
                catch (Exception ex)
                {
                    // Manejar excepciones y mostrar un mensaje de error
                    lblmensaje.Text = "Ocurrió un error al guardar la reservación: " + ex.Message;
                    // Opcional: Registrar el error para su análisis
                    // Log.Error("Error al guardar la reservación", ex);
                }
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            if (Session["cliente"] != null)
            {
                Response.Redirect("~/Pages/cliente/Cliente.aspx");
            }
            else if (Session["empleado"] != null)
            {
                Response.Redirect("~/Pages/empleado/Empleado.aspx");
            }
        }

        protected void ddlHoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idHotel = Convert.ToInt32(ddlHoteles.SelectedValue);

                // Verificar que se haya seleccionado un hotel válido
                if (idHotel == 0)
                {
                    lblmensaje.Text = "Debe seleccionar un hotel.";
                    return;
                }

                using (var context = new PV_ProyectoFinalEntities2())
                {
                    // Consultar los costos del hotel seleccionado
                    var hotel = context.spConsultarHotelPorId(idHotel).FirstOrDefault();

                    if (hotel != null)
                    {
                        // Guardar los costos en la sesión para usar en la lógica de guardado
                        Session["CostoPorAdulto"] = hotel.costoPorCadaAdulto;
                        Session["CostoPorNinho"] = hotel.costoPorCadaNinho;
                    }
                    else
                    {
                        lblmensaje.Text = "No se encontraron detalles del hotel seleccionado.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblmensaje.Text = "Ocurrió un error al consultar el hotel: " + ex.Message;
                // Opcional: Registrar el error para su análisis
                // Log.Error("Error al consultar el hotel", ex);
            }
        }
    }
}