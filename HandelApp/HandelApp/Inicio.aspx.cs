﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandelApp
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                
            
        }

        protected void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vender.aspx");
        }

        protected void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaCompra.aspx");
        }

        protected void btnFacturas_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }
    }
}