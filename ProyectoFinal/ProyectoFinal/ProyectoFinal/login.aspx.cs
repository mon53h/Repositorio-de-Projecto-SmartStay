using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session.Remove("idUser");
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                string username = Login1.UserName;
                string password = Login1.Password;

                PV_ProyectoFinalEntities2 _oContext = new PV_ProyectoFinalEntities2();
                var infoCliente = _oContext.Persona.Where(l => l.email == username && 
                                                            l.clave == password &&
                                                            l.estado == "A")
                                                   .ToList();

                if (infoCliente.Count > 0)
                {
                    e.Authenticated = true;
                    

                    bool esEmpleado = infoCliente[0].esEmpleado; 

                    if (esEmpleado == true)
                    {
                        Session.Add("empleado", infoCliente[0].idPersona.ToString());
                        Response.Redirect("~/Pages/empleado/Empleado.aspx");
                    }
                    else
                    {
                        Session.Add("cliente", infoCliente[0].idPersona.ToString());
                        Response.Redirect("~/Pages/cliente/Cliente.aspx");
                    }
                }
                else
                {
                    e.Authenticated = false;
                }



            }
            catch (ThreadAbortException)
            { }
            catch (Exception)
            {
                Session.Remove("idUser");
                throw;
            }
        }
    }
}