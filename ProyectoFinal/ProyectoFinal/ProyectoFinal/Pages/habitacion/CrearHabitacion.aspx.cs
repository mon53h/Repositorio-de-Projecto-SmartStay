using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal.Pages.habitacion
{
    public partial class CrearHabitacion : System.Web.UI.Page
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
            try
            {
                // Validar que un hotel esté seleccionado
                if (ddlHoteles.SelectedValue == "0")
                {
                    lblmensaje.Text = "Debe seleccionar un hotel.";
                    return;
                }

                // Validar el campo de Número de Habitación
                string numeroHabitacion = txtNumeroHabitacion.Text.Trim();
                if (string.IsNullOrEmpty(numeroHabitacion) || numeroHabitacion.Length > 10)
                {
                    lblmensaje.Text = "El número de habitación es requerido y debe tener como máximo 10 caracteres.";
                    return;
                }

                // Validar Capacidad Máxima
                if (!int.TryParse(txtCapacidadMaxima.Text, out int capacidadMaxima) || capacidadMaxima <= 0 || capacidadMaxima > 8)
                {
                    lblmensaje.Text = "La capacidad máxima debe ser un número entero entre 1 y 8.";
                    return;
                }

                // Validar el campo de Descripción
                string descripcion = txtDescripcion.Text.Trim();
                if (string.IsNullOrEmpty(descripcion) || descripcion.Length > 500)
                {
                    lblmensaje.Text = "La descripción es requerida y debe tener como máximo 500 caracteres.";
                    return;
                }

                using (var context = new PV_ProyectoFinalEntities2())
                {
                    int idHotel = Convert.ToInt32(ddlHoteles.SelectedValue);

                    // Verificar si el hotel existe
                    var hotel = context.spConsultarHotelPorId(idHotel).FirstOrDefault();
                    if (hotel == null)
                    {
                        lblmensaje.Text = "El hotel seleccionado no existe.";
                        return;
                    }

                    // Verificar si el número de habitación ya existe para el hotel seleccionado
                    var habitacionExistente = context.Habitacion.FirstOrDefault(h => h.idHotel == idHotel && h.numeroHabitacion == numeroHabitacion);
                    if (habitacionExistente != null)
                    {
                        lblmensaje.Text = "Ya existe una habitación con ese número en el hotel seleccionado.";
                        return;
                    }

                    // Guardar en la base de datos usando el procedimiento almacenado
                    context.spCrearHabitacion(
                        idHotel,
                        numeroHabitacion,
                        capacidadMaxima,
                        descripcion
                    );

                    // Redirigir a la página de confirmación con mensaje de éxito
                    string mensaje = "Habitación guardada exitosamente.";
                    Response.Redirect($"Confirmacion.aspx?mensaje={HttpUtility.UrlEncode(mensaje)}");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones y mostrar un mensaje de error
                lblmensaje.Text = "Ocurrió un error al guardar la habitación: " + ex.Message;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/habitacion/Habitaciones.aspx");
        }
    }
}
