using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        { 
            List<Marca> lista = new List<Marca>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearConsulta("select IDMarca,Descripcion from Marcas");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux= new Marca();
                    aux.ID = (int)datos.Lector["IDMarca"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }


                return lista;
                    
            }
            catch (Exception ex)
            {
                 
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
