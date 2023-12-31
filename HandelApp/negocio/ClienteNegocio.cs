﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listarconSp() 
        {
            List<Cliente> listaaux = new List<Cliente>();
            AccesoBD datos = new AccesoBD();

            try
            {
                //datos.setearProcedimiento("SP_ClilistarCliente");
                datos.setearConsulta("select IDCliente as IDCliente, NombreFantasia as Nombre,Cuil as Cuil,Telefono as Tel ,Mail as Mail from Cliente");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente CliAux = new Cliente();


                    CliAux.IdCliente = (long)datos.Lector["IDCliente"];
                    CliAux.NombreFantasia = (string)datos.Lector["Nombre"];
                    CliAux.Cuil = (string)datos.Lector["Cuil"];
                    CliAux.Telefono = (string)datos.Lector["Tel"];
                    CliAux.Mail = (string)datos.Lector["Mail"];


                    listaaux.Add(CliAux);

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

        public void alta(Cliente nuevo)
        {
            AccesoBD accesoBD = new AccesoBD();
            List<Cliente> listanueva = new List<Cliente> ();  

            try
            {
                accesoBD.setearConsulta("Insert into Cliente (NombreFantasia,Cuil,Telefono,Mail) values (@NombreFantasia, @Cuil, @Telefono, @Mail)");
                accesoBD.setearParametro("@Nombrefantasia",nuevo.NombreFantasia);
                accesoBD.setearParametro("@Cuil",nuevo.Cuil);
                accesoBD.setearParametro("@Telefono",nuevo.Telefono);
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


        public Cliente buscar (int Id)
        {
            Cliente ClienteBuscado = new Cliente();
            ClienteNegocio Cnegocio = new ClienteNegocio();
            List<Cliente> ListaFiltro = new List<Cliente>();
            AccesoBD accesoBD = new AccesoBD();

            try
            {
                ListaFiltro = Cnegocio.listarconSp();

                foreach (var Cliente in ListaFiltro)
                {
                    if (Id == (int)Cliente.IdCliente)
                    {
                        ClienteBuscado = Cliente;
                    }
                }

                return ClienteBuscado;
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

        public Cliente buscarCuitBD(string cuil)
        {
            Cliente ClienteBuscado = new Cliente();
            AccesoBD accesoBD = new AccesoBD();

            try
            {
                accesoBD.setearConsulta("SELECT NombreFantasia, Cuil, Telefono, Mail FROM Cliente where Cuil = @Cuil");
                accesoBD.setearParametro("@Cuil", cuil);
                accesoBD.ejecutarLectura();

                if (accesoBD.Lector.Read())
                {
                    ClienteBuscado.NombreFantasia = (string)accesoBD.Lector["NombreFantasia"];
                    ClienteBuscado.Cuil = (string)accesoBD.Lector["Cuil"];
                    ClienteBuscado.Telefono = (string)accesoBD.Lector["Telefono"];
                    ClienteBuscado.Mail = (string)accesoBD.Lector["Mail"];
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                accesoBD.cerrarConexion();
            }
            return ClienteBuscado;
        }

        public void modificar(Cliente nuevo)
        {
            AccesoBD accesoBD = new AccesoBD();
            List<Cliente> listaClienteModificado = new List<Cliente>();

            try
            {
                accesoBD.setearConsulta("Update Cliente set NombreFantasia = @Nombre, Cuil = @Cuil, Telefono = @Telefono, Mail = @Mail where IDCliente=@id");
                accesoBD.setearParametro("@Nombre", nuevo.NombreFantasia);
                accesoBD.setearParametro("@Cuil", nuevo.Cuil);
                accesoBD.setearParametro("@Telefono", nuevo.Telefono);
                accesoBD.setearParametro("@Mail", nuevo.Mail);
                accesoBD.setearParametro("@id", nuevo.IdCliente);

                accesoBD.ejecutarAccion();

                listaClienteModificado = listarconSp();
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

        public void baja(int id)
        {
            try
            {
                AccesoBD accesoBD = new AccesoBD();

                accesoBD.setearConsulta("delete from Cliente where IDCliente = @id");
                accesoBD.setearParametro("@id", id);
                accesoBD.ejecutarAccion();

                accesoBD.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
