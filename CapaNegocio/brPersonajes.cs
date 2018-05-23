using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaNegocio
{
    public class brPersonajes
    {
        public List<bePersonajes> ListarPersonajes(ref string Error)
        {

            List<bePersonajes> lbePersonajes = null;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
            {
                try
                {
                    con.Open();
                    daPersonajes odaPersonajes = new daPersonajes();
                    lbePersonajes = odaPersonajes.ListarPersonajes(con);
                }
                catch (SqlException sqlex)
                {
                    Error = sqlex.Message;
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                }

                return lbePersonajes;
            }
        }

        public List<bePersonajes> ListarTipo(ref string Error)
        {

            List<bePersonajes> lbeTipo = null;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
            {
                try
                {
                    con.Open();
                    daPersonajes odatipo = new daPersonajes();
                    lbeTipo = odatipo.ListarTipo(con);
                }
                catch (SqlException sqlex)
                {
                    Error = sqlex.Message;
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                }

                return lbeTipo;
            }
        }

        public bool RegistrarPersonaje(bePersonajes obePersonajes, ref string Error)
        {
            bool result = false;
            SqlTransaction trx = null;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
            {
                try
                {
                    con.Open();
                    trx = con.BeginTransaction();
                    daPersonajes odaPersonajes = new daPersonajes();
                    result = odaPersonajes.RegistrarPersonajes(con, trx, obePersonajes);
                    if (result == true) trx.Commit(); else trx.Rollback();
                }
                catch (SqlException sqlex)
                {
                    Error = sqlex.Message;
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                }

                return result;
            }
        }

        public bool ActualizarPersonaje(bePersonajes obePersonajes, ref string msgError)
        {
            bool act = false;
            SqlTransaction trx = null;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
            {
                try
                {
                    con.Open();
                    trx = con.BeginTransaction();
                    daPersonajes odaPersonajes = new daPersonajes();
                    act = odaPersonajes.ActualizarPersonaje(con, trx, obePersonajes);
                    if (act) trx.Commit(); else trx.Rollback();
                }
                catch (SqlException sqlex)
                {
                    act = false;
                    msgError = sqlex.Message;
                }
                catch (Exception ex)
                {
                    act = false;
                    msgError = ex.Message;
                }
                return act;
            }
        }

        public bool EliminarPersonaje(bePersonajes obePersonajes, ref string msgError)
        {
            bool act = false;
            SqlTransaction trx = null;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
            {
                try
                {
                    con.Open();
                    trx = con.BeginTransaction();
                    daPersonajes odaPersonajes = new daPersonajes();
                    act = odaPersonajes.EliminarPersonaje(con, trx, obePersonajes);
                    if (act) trx.Commit(); else trx.Rollback();
                }
                catch (SqlException sqlex)
                {
                    act = false;
                    msgError = sqlex.Message;
                }
                catch (Exception ex)
                {
                    act = false;
                    msgError = ex.Message;
                }
                return act;
            }
        }
    }
}
