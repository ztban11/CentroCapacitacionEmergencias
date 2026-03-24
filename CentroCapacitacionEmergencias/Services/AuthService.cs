using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;

namespace CentroCapacitacionEmergencias.Services
{
    public class AuthService
    {
        public static bool bValidarUsuario(string sElNombreUsuario, string sElPassword, out string sElMensaje, out string sElRol)
        {
            sElRol = "";
            var config = SecurityConfigService.GetConfig();

            using (SqlConnection conn = DBService.GetConnection())
            {
                conn.Open();

                string query = @"SELECT IDUsuario, PasswordHash, IntentosFallidos, EstaBloqueado, FechaBloqueo, Rol
                             FROM Usuarios WHERE NombreUsuario=@sElNombreUsuario";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sElNombreUsuario", sElNombreUsuario);

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    sElMensaje = "Nombre de Usuario o Password Inválidos.";
                    return false;
                }

                int iIDUsuario = Convert.ToInt32(reader["IDUsuario"]);
                string sPasswordAlmacenado = reader["PasswordHash"].ToString();
                string sRol = reader["Rol"].ToString();
                int iIntentosFallidos = Convert.ToInt32(reader["IntentosFallidos"]);
                bool bEstaBloqueado = Convert.ToBoolean(reader["EstaBloqueado"]);
                DateTime? dtFechaBloqueo = reader["FechaBloqueo"] as DateTime?;

                reader.Close();

                if (bEstaBloqueado)
                {
                    if (dtFechaBloqueo.HasValue &&
                       (DateTime.Now - dtFechaBloqueo.Value).TotalMinutes < config.iMinutosBloqueo)
                    {
                        sElMensaje = "Cuenta bloqueada temporalmente.";
                        return false;
                    }
                    else
                    {
                        ResetearBloqueo(conn, iIDUsuario);
                    }
                }

                if (sPasswordAlmacenado == sElPassword)
                {
                    ResetearIntentos(conn, iIDUsuario);
                    sElRol = sRol;
                    sElMensaje = "Autenticación correcta.";
                    return true;
                }

                iIntentosFallidos++;

                if (iIntentosFallidos >= config.iMaxIntentosLogin)
                {
                    BloquearUsuario(conn, iIDUsuario);
                    sElMensaje = "Cuenta bloqueada debido a intentos máximos fallidos.";
                }
                else
                {
                    ActualizarIntentos(conn, iIDUsuario, iIntentosFallidos);
                    sElMensaje = "Nombre de Usuario o Password Inválidos.";
                }
                return false;
            }
        }

        private static void ActualizarIntentos(SqlConnection conn, int iElUserId, int iIntentos)
        {
            string query = "UPDATE Usuarios SET IntentosFallidos=@intentos WHERE IDUsuario=@id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@intentos", iIntentos);
            cmd.Parameters.AddWithValue("@id", iElUserId);

            cmd.ExecuteNonQuery();
        }

        private static void ResetearIntentos(SqlConnection conn, int iElUserId)
        {
            string query = "UPDATE Usuarios SET IntentosFallidos=0 WHERE IDUsuario=@id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", iElUserId);

            cmd.ExecuteNonQuery();
        }

        private static void BloquearUsuario(SqlConnection conn, int iElUserId)
        {
            string query = @"UPDATE Usuarios 
                         SET EstaBloqueado=1, FechaBloqueo=@fecha 
                         WHERE IDUsuario=@id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
            cmd.Parameters.AddWithValue("@id", iElUserId);

            cmd.ExecuteNonQuery();
        }

        private static void ResetearBloqueo(SqlConnection conn, int iElUserId)
        {
            string query = @"UPDATE Usuarios 
                         SET EstaBloqueado=0, IntentosFallidos=0 
                         WHERE IDUsuario=@id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", iElUserId);

            cmd.ExecuteNonQuery();
        }
    }
}