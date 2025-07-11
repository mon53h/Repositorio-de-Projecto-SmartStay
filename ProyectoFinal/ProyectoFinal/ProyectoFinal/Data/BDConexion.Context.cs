﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinal.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PV_ProyectoFinalEntities2 : DbContext
    {
        public PV_ProyectoFinalEntities2()
            : base("name=PV_ProyectoFinalEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Reservacion> Reservacion { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<spConsultarBitacora_Result> spConsultarBitacora()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spConsultarBitacora_Result>("spConsultarBitacora");
        }
    
        public virtual ObjectResult<spConsultarBitacoraPorId_Result> spConsultarBitacoraPorId(Nullable<int> idBitacora)
        {
            var idBitacoraParameter = idBitacora.HasValue ?
                new ObjectParameter("idBitacora", idBitacora) :
                new ObjectParameter("idBitacora", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spConsultarBitacoraPorId_Result>("spConsultarBitacoraPorId", idBitacoraParameter);
        }
    
        public virtual ObjectResult<spConsultarHabitacion_Result> spConsultarHabitacion()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spConsultarHabitacion_Result>("spConsultarHabitacion");
        }
    
        public virtual ObjectResult<spConsultarHabitacionPorId_Result> spConsultarHabitacionPorId(Nullable<int> idHabitacion)
        {
            var idHabitacionParameter = idHabitacion.HasValue ?
                new ObjectParameter("idHabitacion", idHabitacion) :
                new ObjectParameter("idHabitacion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spConsultarHabitacionPorId_Result>("spConsultarHabitacionPorId", idHabitacionParameter);
        }
    
        public virtual ObjectResult<spConsultarHotel_Result> spConsultarHotel()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spConsultarHotel_Result>("spConsultarHotel");
        }
    
        public virtual ObjectResult<spConsultarHotelPorId_Result> spConsultarHotelPorId(Nullable<int> idHotel)
        {
            var idHotelParameter = idHotel.HasValue ?
                new ObjectParameter("idHotel", idHotel) :
                new ObjectParameter("idHotel", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spConsultarHotelPorId_Result>("spConsultarHotelPorId", idHotelParameter);
        }
    
        public virtual ObjectResult<spConsultarPersona_Result> spConsultarPersona()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spConsultarPersona_Result>("spConsultarPersona");
        }
    
        public virtual ObjectResult<spConsultarPersonaPorId_Result> spConsultarPersonaPorId(Nullable<int> idPersona)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("idPersona", idPersona) :
                new ObjectParameter("idPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spConsultarPersonaPorId_Result>("spConsultarPersonaPorId", idPersonaParameter);
        }
    
        public virtual ObjectResult<spConsultarReservacion_Result> spConsultarReservacion()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spConsultarReservacion_Result>("spConsultarReservacion");
        }
    
        public virtual ObjectResult<spConsultarReservacionPorId_Result> spConsultarReservacionPorId(Nullable<int> idReservacion)
        {
            var idReservacionParameter = idReservacion.HasValue ?
                new ObjectParameter("idReservacion", idReservacion) :
                new ObjectParameter("idReservacion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spConsultarReservacionPorId_Result>("spConsultarReservacionPorId", idReservacionParameter);
        }
    
        public virtual int spCrearBitacora(Nullable<int> idReservacion, Nullable<int> idPersona, string accionRealizada, Nullable<System.DateTime> fechaDeLaAccion)
        {
            var idReservacionParameter = idReservacion.HasValue ?
                new ObjectParameter("idReservacion", idReservacion) :
                new ObjectParameter("idReservacion", typeof(int));
    
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("idPersona", idPersona) :
                new ObjectParameter("idPersona", typeof(int));
    
            var accionRealizadaParameter = accionRealizada != null ?
                new ObjectParameter("accionRealizada", accionRealizada) :
                new ObjectParameter("accionRealizada", typeof(string));
    
            var fechaDeLaAccionParameter = fechaDeLaAccion.HasValue ?
                new ObjectParameter("fechaDeLaAccion", fechaDeLaAccion) :
                new ObjectParameter("fechaDeLaAccion", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCrearBitacora", idReservacionParameter, idPersonaParameter, accionRealizadaParameter, fechaDeLaAccionParameter);
        }
    
        public virtual int spCrearHabitacion(Nullable<int> idHotel, string numeroHabitacion, Nullable<int> capacidadMaxima, string descripcion)
        {
            var idHotelParameter = idHotel.HasValue ?
                new ObjectParameter("idHotel", idHotel) :
                new ObjectParameter("idHotel", typeof(int));
    
            var numeroHabitacionParameter = numeroHabitacion != null ?
                new ObjectParameter("numeroHabitacion", numeroHabitacion) :
                new ObjectParameter("numeroHabitacion", typeof(string));
    
            var capacidadMaximaParameter = capacidadMaxima.HasValue ?
                new ObjectParameter("capacidadMaxima", capacidadMaxima) :
                new ObjectParameter("capacidadMaxima", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCrearHabitacion", idHotelParameter, numeroHabitacionParameter, capacidadMaximaParameter, descripcionParameter);
        }
    
        public virtual int spCrearHotel(string nombre, string direccion, Nullable<decimal> costoPorCadaAdulto, Nullable<decimal> costoPorCadaNinho)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("direccion", direccion) :
                new ObjectParameter("direccion", typeof(string));
    
            var costoPorCadaAdultoParameter = costoPorCadaAdulto.HasValue ?
                new ObjectParameter("costoPorCadaAdulto", costoPorCadaAdulto) :
                new ObjectParameter("costoPorCadaAdulto", typeof(decimal));
    
            var costoPorCadaNinhoParameter = costoPorCadaNinho.HasValue ?
                new ObjectParameter("costoPorCadaNinho", costoPorCadaNinho) :
                new ObjectParameter("costoPorCadaNinho", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCrearHotel", nombreParameter, direccionParameter, costoPorCadaAdultoParameter, costoPorCadaNinhoParameter);
        }
    
        public virtual int spCrearPersona(string nombreCompleto, string email, string clave, Nullable<bool> esEmpleado)
        {
            var nombreCompletoParameter = nombreCompleto != null ?
                new ObjectParameter("nombreCompleto", nombreCompleto) :
                new ObjectParameter("nombreCompleto", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var claveParameter = clave != null ?
                new ObjectParameter("clave", clave) :
                new ObjectParameter("clave", typeof(string));
    
            var esEmpleadoParameter = esEmpleado.HasValue ?
                new ObjectParameter("esEmpleado", esEmpleado) :
                new ObjectParameter("esEmpleado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCrearPersona", nombreCompletoParameter, emailParameter, claveParameter, esEmpleadoParameter);
        }
    
        public virtual int spCrearReservacion(Nullable<int> idPersona, Nullable<int> idHabitacion, Nullable<System.DateTime> fechaEntrada, Nullable<System.DateTime> fechaSalida, Nullable<int> numeroAdultos, Nullable<int> numeroNinhos, Nullable<int> totalDiasReservacion, Nullable<decimal> costoPorCadaAdulto, Nullable<decimal> costoPorCadaNinho, Nullable<decimal> costoTotal, Nullable<System.DateTime> fechaCreacion, Nullable<System.DateTime> fechaModificacion)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("idPersona", idPersona) :
                new ObjectParameter("idPersona", typeof(int));
    
            var idHabitacionParameter = idHabitacion.HasValue ?
                new ObjectParameter("idHabitacion", idHabitacion) :
                new ObjectParameter("idHabitacion", typeof(int));
    
            var fechaEntradaParameter = fechaEntrada.HasValue ?
                new ObjectParameter("fechaEntrada", fechaEntrada) :
                new ObjectParameter("fechaEntrada", typeof(System.DateTime));
    
            var fechaSalidaParameter = fechaSalida.HasValue ?
                new ObjectParameter("fechaSalida", fechaSalida) :
                new ObjectParameter("fechaSalida", typeof(System.DateTime));
    
            var numeroAdultosParameter = numeroAdultos.HasValue ?
                new ObjectParameter("numeroAdultos", numeroAdultos) :
                new ObjectParameter("numeroAdultos", typeof(int));
    
            var numeroNinhosParameter = numeroNinhos.HasValue ?
                new ObjectParameter("numeroNinhos", numeroNinhos) :
                new ObjectParameter("numeroNinhos", typeof(int));
    
            var totalDiasReservacionParameter = totalDiasReservacion.HasValue ?
                new ObjectParameter("totalDiasReservacion", totalDiasReservacion) :
                new ObjectParameter("totalDiasReservacion", typeof(int));
    
            var costoPorCadaAdultoParameter = costoPorCadaAdulto.HasValue ?
                new ObjectParameter("costoPorCadaAdulto", costoPorCadaAdulto) :
                new ObjectParameter("costoPorCadaAdulto", typeof(decimal));
    
            var costoPorCadaNinhoParameter = costoPorCadaNinho.HasValue ?
                new ObjectParameter("costoPorCadaNinho", costoPorCadaNinho) :
                new ObjectParameter("costoPorCadaNinho", typeof(decimal));
    
            var costoTotalParameter = costoTotal.HasValue ?
                new ObjectParameter("costoTotal", costoTotal) :
                new ObjectParameter("costoTotal", typeof(decimal));
    
            var fechaCreacionParameter = fechaCreacion.HasValue ?
                new ObjectParameter("fechaCreacion", fechaCreacion) :
                new ObjectParameter("fechaCreacion", typeof(System.DateTime));
    
            var fechaModificacionParameter = fechaModificacion.HasValue ?
                new ObjectParameter("fechaModificacion", fechaModificacion) :
                new ObjectParameter("fechaModificacion", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCrearReservacion", idPersonaParameter, idHabitacionParameter, fechaEntradaParameter, fechaSalidaParameter, numeroAdultosParameter, numeroNinhosParameter, totalDiasReservacionParameter, costoPorCadaAdultoParameter, costoPorCadaNinhoParameter, costoTotalParameter, fechaCreacionParameter, fechaModificacionParameter);
        }
    
        public virtual int spEditarBitacora(Nullable<int> idBitacora, Nullable<int> idReservacion, Nullable<int> idPersona, string accionRealizada, Nullable<System.DateTime> fechaDeLaAccion)
        {
            var idBitacoraParameter = idBitacora.HasValue ?
                new ObjectParameter("idBitacora", idBitacora) :
                new ObjectParameter("idBitacora", typeof(int));
    
            var idReservacionParameter = idReservacion.HasValue ?
                new ObjectParameter("idReservacion", idReservacion) :
                new ObjectParameter("idReservacion", typeof(int));
    
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("idPersona", idPersona) :
                new ObjectParameter("idPersona", typeof(int));
    
            var accionRealizadaParameter = accionRealizada != null ?
                new ObjectParameter("accionRealizada", accionRealizada) :
                new ObjectParameter("accionRealizada", typeof(string));
    
            var fechaDeLaAccionParameter = fechaDeLaAccion.HasValue ?
                new ObjectParameter("fechaDeLaAccion", fechaDeLaAccion) :
                new ObjectParameter("fechaDeLaAccion", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEditarBitacora", idBitacoraParameter, idReservacionParameter, idPersonaParameter, accionRealizadaParameter, fechaDeLaAccionParameter);
        }
    
        public virtual int spEditarHabitacion(Nullable<int> idHabitacion, Nullable<int> idHotel, string numeroHabitacion, Nullable<int> capacidadMaxima, string descripcion, string estado)
        {
            var idHabitacionParameter = idHabitacion.HasValue ?
                new ObjectParameter("idHabitacion", idHabitacion) :
                new ObjectParameter("idHabitacion", typeof(int));
    
            var idHotelParameter = idHotel.HasValue ?
                new ObjectParameter("idHotel", idHotel) :
                new ObjectParameter("idHotel", typeof(int));
    
            var numeroHabitacionParameter = numeroHabitacion != null ?
                new ObjectParameter("numeroHabitacion", numeroHabitacion) :
                new ObjectParameter("numeroHabitacion", typeof(string));
    
            var capacidadMaximaParameter = capacidadMaxima.HasValue ?
                new ObjectParameter("capacidadMaxima", capacidadMaxima) :
                new ObjectParameter("capacidadMaxima", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEditarHabitacion", idHabitacionParameter, idHotelParameter, numeroHabitacionParameter, capacidadMaximaParameter, descripcionParameter, estadoParameter);
        }
    
        public virtual int spEditarHotel(Nullable<int> idHotel, string nombre, string direccion, Nullable<decimal> costoPorCadaAdulto, Nullable<decimal> costoPorCadaNinho)
        {
            var idHotelParameter = idHotel.HasValue ?
                new ObjectParameter("idHotel", idHotel) :
                new ObjectParameter("idHotel", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("direccion", direccion) :
                new ObjectParameter("direccion", typeof(string));
    
            var costoPorCadaAdultoParameter = costoPorCadaAdulto.HasValue ?
                new ObjectParameter("costoPorCadaAdulto", costoPorCadaAdulto) :
                new ObjectParameter("costoPorCadaAdulto", typeof(decimal));
    
            var costoPorCadaNinhoParameter = costoPorCadaNinho.HasValue ?
                new ObjectParameter("costoPorCadaNinho", costoPorCadaNinho) :
                new ObjectParameter("costoPorCadaNinho", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEditarHotel", idHotelParameter, nombreParameter, direccionParameter, costoPorCadaAdultoParameter, costoPorCadaNinhoParameter);
        }
    
        public virtual int spEditarPersona(Nullable<int> idPersona, string nombreCompleto, string email, string clave, Nullable<bool> esEmpleado, string estado)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("idPersona", idPersona) :
                new ObjectParameter("idPersona", typeof(int));
    
            var nombreCompletoParameter = nombreCompleto != null ?
                new ObjectParameter("nombreCompleto", nombreCompleto) :
                new ObjectParameter("nombreCompleto", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var claveParameter = clave != null ?
                new ObjectParameter("clave", clave) :
                new ObjectParameter("clave", typeof(string));
    
            var esEmpleadoParameter = esEmpleado.HasValue ?
                new ObjectParameter("esEmpleado", esEmpleado) :
                new ObjectParameter("esEmpleado", typeof(bool));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEditarPersona", idPersonaParameter, nombreCompletoParameter, emailParameter, claveParameter, esEmpleadoParameter, estadoParameter);
        }
    
        public virtual int spEditarReservacion(Nullable<int> idReservacion, Nullable<int> idPersona, Nullable<int> idHabitacion, Nullable<System.DateTime> fechaEntrada, Nullable<System.DateTime> fechaSalida, Nullable<int> numeroAdultos, Nullable<int> numeroNinhos, Nullable<int> totalDiasReservacion, Nullable<decimal> costoPorCadaAdulto, Nullable<decimal> costoPorCadaNinho, Nullable<decimal> costoTotal, Nullable<System.DateTime> fechaCreacion, Nullable<System.DateTime> fechaModificacion, string estado)
        {
            var idReservacionParameter = idReservacion.HasValue ?
                new ObjectParameter("idReservacion", idReservacion) :
                new ObjectParameter("idReservacion", typeof(int));
    
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("idPersona", idPersona) :
                new ObjectParameter("idPersona", typeof(int));
    
            var idHabitacionParameter = idHabitacion.HasValue ?
                new ObjectParameter("idHabitacion", idHabitacion) :
                new ObjectParameter("idHabitacion", typeof(int));
    
            var fechaEntradaParameter = fechaEntrada.HasValue ?
                new ObjectParameter("fechaEntrada", fechaEntrada) :
                new ObjectParameter("fechaEntrada", typeof(System.DateTime));
    
            var fechaSalidaParameter = fechaSalida.HasValue ?
                new ObjectParameter("fechaSalida", fechaSalida) :
                new ObjectParameter("fechaSalida", typeof(System.DateTime));
    
            var numeroAdultosParameter = numeroAdultos.HasValue ?
                new ObjectParameter("numeroAdultos", numeroAdultos) :
                new ObjectParameter("numeroAdultos", typeof(int));
    
            var numeroNinhosParameter = numeroNinhos.HasValue ?
                new ObjectParameter("numeroNinhos", numeroNinhos) :
                new ObjectParameter("numeroNinhos", typeof(int));
    
            var totalDiasReservacionParameter = totalDiasReservacion.HasValue ?
                new ObjectParameter("totalDiasReservacion", totalDiasReservacion) :
                new ObjectParameter("totalDiasReservacion", typeof(int));
    
            var costoPorCadaAdultoParameter = costoPorCadaAdulto.HasValue ?
                new ObjectParameter("costoPorCadaAdulto", costoPorCadaAdulto) :
                new ObjectParameter("costoPorCadaAdulto", typeof(decimal));
    
            var costoPorCadaNinhoParameter = costoPorCadaNinho.HasValue ?
                new ObjectParameter("costoPorCadaNinho", costoPorCadaNinho) :
                new ObjectParameter("costoPorCadaNinho", typeof(decimal));
    
            var costoTotalParameter = costoTotal.HasValue ?
                new ObjectParameter("costoTotal", costoTotal) :
                new ObjectParameter("costoTotal", typeof(decimal));
    
            var fechaCreacionParameter = fechaCreacion.HasValue ?
                new ObjectParameter("fechaCreacion", fechaCreacion) :
                new ObjectParameter("fechaCreacion", typeof(System.DateTime));
    
            var fechaModificacionParameter = fechaModificacion.HasValue ?
                new ObjectParameter("fechaModificacion", fechaModificacion) :
                new ObjectParameter("fechaModificacion", typeof(System.DateTime));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEditarReservacion", idReservacionParameter, idPersonaParameter, idHabitacionParameter, fechaEntradaParameter, fechaSalidaParameter, numeroAdultosParameter, numeroNinhosParameter, totalDiasReservacionParameter, costoPorCadaAdultoParameter, costoPorCadaNinhoParameter, costoTotalParameter, fechaCreacionParameter, fechaModificacionParameter, estadoParameter);
        }
    
        public virtual int spEliminarBitacora(Nullable<int> idBitacora)
        {
            var idBitacoraParameter = idBitacora.HasValue ?
                new ObjectParameter("idBitacora", idBitacora) :
                new ObjectParameter("idBitacora", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEliminarBitacora", idBitacoraParameter);
        }
    
        public virtual int spEliminarHabitacion(Nullable<int> idHabitacion)
        {
            var idHabitacionParameter = idHabitacion.HasValue ?
                new ObjectParameter("idHabitacion", idHabitacion) :
                new ObjectParameter("idHabitacion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEliminarHabitacion", idHabitacionParameter);
        }
    
        public virtual int spEliminarHotel(Nullable<int> idHotel)
        {
            var idHotelParameter = idHotel.HasValue ?
                new ObjectParameter("idHotel", idHotel) :
                new ObjectParameter("idHotel", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEliminarHotel", idHotelParameter);
        }
    
        public virtual int spEliminarPersona(Nullable<int> idPersona)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("idPersona", idPersona) :
                new ObjectParameter("idPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEliminarPersona", idPersonaParameter);
        }
    
        public virtual int spEliminarReservacion(Nullable<int> idReservacion)
        {
            var idReservacionParameter = idReservacion.HasValue ?
                new ObjectParameter("idReservacion", idReservacion) :
                new ObjectParameter("idReservacion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEliminarReservacion", idReservacionParameter);
        }
    
        public virtual ObjectResult<spConsultarReservacionPorIdPersona_Result> spConsultarReservacionPorIdPersona(Nullable<int> idPersona)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("idPersona", idPersona) :
                new ObjectParameter("idPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spConsultarReservacionPorIdPersona_Result>("spConsultarReservacionPorIdPersona", idPersonaParameter);
        }
    }
}
