using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidades;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class daPersonajes
    {
        public List<bePersonajes> ListarPersonajes(SqlConnection con)
        {
            List<bePersonajes> lbePersonajes = null;
            SqlCommand cmd = new SqlCommand("SPS_ListaPersonajes", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if(drd !=null)
            {
                lbePersonajes = new List<bePersonajes>();
                bePersonajes obePersonajes;
                int pos_IdPersonaje = drd.GetOrdinal("IdPersonaje");
                int pos_IdTipo = drd.GetOrdinal("IdTipo");
                int pos_NombrePersonaje = drd.GetOrdinal("NombrePersonaje");
                int pos_Nacionalidad = drd.GetOrdinal("Nacionalidad");
                int pos_FechaNac = drd.GetOrdinal("FechaNac");
                int pos_BreveHistoria = drd.GetOrdinal("BreveHistoria");

                while(drd.Read())
                {
                    obePersonajes = new bePersonajes();
                    obePersonajes.IdPersonaje = drd.GetInt32(pos_IdPersonaje);
                    obePersonajes.IdTipo = drd.GetInt32(pos_IdTipo);
                    obePersonajes.NombrePersonaje = drd.GetString(pos_NombrePersonaje);
                    obePersonajes.Nacionalidad = drd.GetString(pos_Nacionalidad);
                    obePersonajes.FechaNac = drd.GetDateTime(pos_FechaNac);
                    obePersonajes.BreveHistoria = drd.GetString(pos_BreveHistoria);

                    lbePersonajes.Add(obePersonajes);
                }
                drd.Close();

            }
            cmd.Dispose();
            return lbePersonajes;
        }

        public List<bePersonajes> ListarTipo(SqlConnection con)
        {
            List<bePersonajes> lbeTipo = null;
            SqlCommand cmd = new SqlCommand("SPS_ListaTipo", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                lbeTipo = new List<bePersonajes>();
                bePersonajes obePersonajes;
                int pos_IdTipo = drd.GetOrdinal("IdTipo");
                int pos_NombreTipo = drd.GetOrdinal("NombreTipo");
             
                while (drd.Read())
                {
                    obePersonajes = new bePersonajes();
                    obePersonajes.IdTipo = drd.GetInt32(pos_IdTipo);
                    obePersonajes.NombreTipo = drd.GetString(pos_NombreTipo);

                    lbeTipo.Add(obePersonajes);
                }
                drd.Close();

            }
            cmd.Dispose();
            return lbeTipo;
        }

        public bool RegistrarPersonajes(SqlConnection con, SqlTransaction trx, bePersonajes obePersonajes)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand("SPI_RegistrarPersonaje", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Transaction = trx;

            SqlParameter par1 = cmd.Parameters.Add("@IdPersonaje", SqlDbType.Int);
            par1.Direction = ParameterDirection.Output;
            par1.Value = obePersonajes.IdPersonaje;

            SqlParameter par2 = cmd.Parameters.Add("@IdTipo", SqlDbType.Int);
            par2.Direction = ParameterDirection.Input;
            par2.Value = obePersonajes.IdTipo;

            SqlParameter par3 = cmd.Parameters.Add("@NombrePersonaje", SqlDbType.VarChar, 50);
            par3.Direction = ParameterDirection.Input;
            par3.Value = obePersonajes.NombrePersonaje;

            SqlParameter par4 = cmd.Parameters.Add("@Nacionalidad", SqlDbType.VarChar, 50);
            par4.Direction = ParameterDirection.Input;
            par4.Value = obePersonajes.Nacionalidad;

            SqlParameter par5 = cmd.Parameters.Add("@FechaNac", SqlDbType.DateTime);
            par5.Direction = ParameterDirection.Input;
            par5.Value = obePersonajes.FechaNac;

            SqlParameter par6 = cmd.Parameters.Add("@BreveHistoria", SqlDbType.VarChar,300);
            par6.Direction = ParameterDirection.Input;
            par6.Value = obePersonajes.BreveHistoria;

            int i = cmd.ExecuteNonQuery();
            result = true;
            cmd.Dispose();
            return result;
        }

        public bool ActualizarPersonaje(SqlConnection con, SqlTransaction trx, bePersonajes obePersonajes)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand("SPU_ActualizarPersonaje", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Transaction = trx;

            SqlParameter par1 = cmd.Parameters.Add("@IdPersonaje", SqlDbType.Int);
            par1.Direction = ParameterDirection.Input;
            par1.Value = obePersonajes.IdPersonaje;

            SqlParameter par2 = cmd.Parameters.Add("@IdTipo", SqlDbType.Int);
            par2.Direction = ParameterDirection.Input;
            par2.Value = obePersonajes.IdTipo;

            SqlParameter par3 = cmd.Parameters.Add("@NombrePersonaje", SqlDbType.VarChar, 50);
            par3.Direction = ParameterDirection.Input;
            par3.Value = obePersonajes.NombrePersonaje;

            SqlParameter par4 = cmd.Parameters.Add("@Nacionalidad", SqlDbType.VarChar, 50);
            par4.Direction = ParameterDirection.Input;
            par4.Value = obePersonajes.Nacionalidad;

            SqlParameter par5 = cmd.Parameters.Add("@FechaNac", SqlDbType.DateTime);
            par5.Direction = ParameterDirection.Input;
            par5.Value = obePersonajes.FechaNac;

            SqlParameter par6 = cmd.Parameters.Add("@BreveHistoria", SqlDbType.VarChar, 300);
            par6.Direction = ParameterDirection.Input;
            par6.Value = obePersonajes.BreveHistoria;

            int i = cmd.ExecuteNonQuery();
            result = true;
            cmd.Dispose();
            return result;
        }

        public bool EliminarPersonaje(SqlConnection con, SqlTransaction trx, bePersonajes obePersonajes)
        {
            bool act = false;
            SqlCommand cmd = new SqlCommand("SPD_EliminarPersonaje", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Transaction = trx;

            SqlParameter par1 = cmd.Parameters.Add("@IdPersonaje", SqlDbType.Int);
            par1.Direction = ParameterDirection.Input;
            par1.Value = obePersonajes.IdPersonaje;

            int i = cmd.ExecuteNonQuery();
            act = true;
            cmd.Dispose();
            return (act);
        }
    }
}
