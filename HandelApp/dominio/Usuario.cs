using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public enum UserType
        {
            NORMAL = 1,
            ADMIN = 2,
        }
        public int Id { get; set; }
        public string User { get; set; }

        public string Pass { get; set; }

        public UserType TipoUsuario { get; set; }
        public Usuario(string user, string pass, bool admin)
        {
            User = user;
            Pass = pass;
            TipoUsuario = admin ? UserType.ADMIN : UserType.NORMAL;
        }

    }
}
