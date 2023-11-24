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

        public void actualizar(Usuario user)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearConsulta("Update Usuarios set Imagen= @Imagen,Nombre = @Nombre,Apellido =@Apellido,Email= @Mail where Usuario = @User");
                datos.setearParametro("@Imagen", user.ImagenPerfil);
                datos.setearParametro("@Apellido", user.Apellido);
                datos.setearParametro("@Nombre", user.Nombre);
                datos.setearParametro("@Mail", user.Mail);
                // datos.setearParametro("@Imagen", user.FechaNacimiento);
                datos.setearParametro("@User", user.User);
                datos.ejecutarAccion();

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

        public int InsertarNuevoLogin(Usuario nuevo)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearProcedimiento("InsertarNuevo");
                datos.setearParametro("@Usuario", nuevo.User);
                datos.setearParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();
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

        public bool loguear(Usuario usuario)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearConsulta("Select ID,TipoUser from Usuarios where Usuario = @User  AND Pass = @Pass");
                datos.setearParametro("@User", usuario.User);
                datos.setearParametro("@Pass", usuario.Pass);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    usuario.Id = (int)datos.Lector["ID"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUser"]) == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
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
