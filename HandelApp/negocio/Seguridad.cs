using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class Seguridad
    {
        public static bool SessionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.Id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static TipoUsuario EsAdmin(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            return usuario.TipoUsuario;
        }

    }
}
