using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listarconSp() 
        {
            List<Proveedor> listaaux = new List<Proveedor>();
            AccesoBD datos = new AccesoBD();

            try
            {
                //datos.setearProcedimiento("SP_PrlistarProveedor");
                datos.setearConsulta("select IDCliente as IDProveedor, NombreFantasia as Nombre,Cuil as Cuil,Telefono as Tel ,Mail as Mail from Proveedor" );
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Proveedor ProvAux = new Proveedor();
                   

                    ProvAux.IdProveedor = (long)datos.Lector["IDProveedor"];
                    ProvAux.NombreFantasia = (string)datos.Lector["Nombre"];
                    ProvAux.Cuil = (string)datos.Lector["Cuil"];
                    ProvAux.Telefono = (string)datos.Lector["Tel"];
                    ProvAux.Mail = (string)datos.Lector["Mail"];                   

                    listaaux.Add(ProvAux);

                }
                return listaaux;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void alta(Proveedor nuevo)
        {
            AccesoBD accesoBD = new AccesoBD();
            List<Proveedor> listanueva = new List<Proveedor>();

            try
            {
                accesoBD.setearConsulta("Insert into Proveedor (NombreFantasia,Cuil,Telefono,Mail) values (@NombreFantasia, @Cuil, @Telefono, @Mail)");
                accesoBD.setearParametro("@NombreFantasia", nuevo.NombreFantasia);
                accesoBD.setearParametro("@Cuil",nuevo.Cuil);
                accesoBD.setearParametro("@Telefono", nuevo.Telefono);
                accesoBD.setearParametro("@Mail", nuevo.Mail);

                accesoBD.ejecutarAccion();

                listanueva = listarconSp();
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                accesoBD.cerrarConexion();
            }
        }

        public Proveedor buscar (int id)
        {
            Proveedor ProveedorBuscado = new Proveedor();
            ProveedorNegocio Pnegocio = new ProveedorNegocio();
            List<Proveedor> ListaFitro = new List<Proveedor> ();
            AccesoBD accesoBD = new AccesoBD();

            try
            {
                ListaFitro = Pnegocio.listarconSp();
                foreach (var Proveedor in ListaFitro)
                {
                    if (id == (int)Proveedor.IdProveedor)
                    {
                        ProveedorBuscado = Proveedor;
                    }
                }
                
                return ProveedorBuscado;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoBD.cerrarConexion();
            }
        }


        public void modificar(Proveedor nuevo)
        {
            /// selecciono el row o el id del dgv 
        }

        public void baja(int id)
        {
            try
            {
                AccesoBD accesoBD = new AccesoBD ();

                accesoBD.setearConsulta("delete from Proveedor where IDProveedor = @id");
                accesoBD.setearParametro("@id", id);
                accesoBD.ejecutarAccion();

                accesoBD.cerrarConexion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                
            }
        }
    }
}
