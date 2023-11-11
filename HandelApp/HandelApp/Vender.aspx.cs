using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandelApp
{
    public partial class Vender : System.Web.UI.Page
    {
        int contador;
        public void Page_Load(object sender, EventArgs e)
        {
        }
        protected void dgvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            var id = dgvVentas.SelectedDataKey.Value.ToString();
            Producto aux = new Producto();

            List<Producto> ventas = (List<Producto>)Session["listadeventa"];
            aux = ventas.Find(x => x.IdProducto == int.Parse(id));
            if (aux != null)
            {
                ventas.Remove(aux);
                Session["listadeventa"] = ventas;



                if (ventas != null)
                {
                    foreach (Producto item in ventas)
                    {
                       
                        contador = ventas.Count();
                    }
                    


                }
                dgvVentas.DataSource = ventas;
                dgvVentas.DataBind();
            }


        }
    }
}