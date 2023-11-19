using System;
using dominio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        public bool loguear(Usuario usuario)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearConsulta("Select ID, Usuario,Pass,TipoUser from Usuarios where Usuario = @User  AND Pass = @Pass");
                datos.setearParametro("@User", usuario.User);
                datos.setearParametro("@Pass", usuario.Pass);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    usuario.Id = (int)datos.Lector["ID"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUser"]) == 2 ? Usuario.UserType.ADMIN : Usuario.UserType.NORMAL;
                    return true;
                }
                return false;
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
