using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class AccesoBD
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get
            {
                return lector;
            }
        }

        public AccesoBD()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=HandelApp_data; integrated security=true;");
            comando = new SqlCommand();
        }

        public void setearConsulta (string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearProcedimiento (string  procedimiento)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = procedimiento;
        }

        public void setearParametro (string consulta, object obj)
        {
            comando.Parameters.AddWithValue(consulta, obj);
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
                conexion.Close();
            }
        }
    }

}
