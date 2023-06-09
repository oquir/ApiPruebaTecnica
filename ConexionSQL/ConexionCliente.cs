﻿using pruebaApiFinal.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace pruebaApiFinal.ConexionSQL
{
    public class ConexionCliente
    {
        private SqlConnection GetSqlConnetion()
        {
            string ConnectionString = "server=DESKTOP-9LL3N3J;database=ConexionApiFinal;integrated security=true";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public List<Usuario> MostrarUsuarios()
        {
            var connection = GetSqlConnetion();
            var command = new SqlCommand("spMostrarUsuarios", connection);
            command.CommandType = CommandType.StoredProcedure;
            var reader = command.ExecuteReader();

            var lista = new List<Usuario>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var User = new Usuario();
                    User.Id = reader.GetInt32(0);
                    User.Nombre = reader.GetString(1);
                    User.Apellido = reader.GetString(2);
                    User.Edad = reader.GetInt32(3);
                    User.Telefono = reader.GetInt32(4);
                    User.Pais = reader.GetString(5);
                    lista.Add(User);
                }
            }
            connection.Close();
            return lista;
        }

        public string AgregarUsuario(Usuario usuario)
        {
            try
            {
                var connection = GetSqlConnetion();
                var command = new SqlCommand("spAgregarUsuarios", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@Edad", usuario.Edad);
                command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                command.Parameters.AddWithValue("@Pais", usuario.Pais);
                command.ExecuteNonQuery();
                return "Usuario Agregado Correctamente";
            }
            catch (Exception ex)
            {
                string texto = "Este es el mensaje que quiere guardar en un archivo de texto.";
                string rutaArchivo = @"c:/mi/directrio/archivo.txt";

                using (StreamWriter escritor = new StreamWriter(rutaArchivo))
                {
                    escritor.WriteLine(texto);
                }
                return ex.Message + rutaArchivo;
            }
        }

        public string CambiarUsuario(Usuario usuario) 
        {
            try
            {
                var connection = GetSqlConnetion();
                var command = new SqlCommand("spCambiarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", usuario.Id);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@Edad", usuario.Edad);
                command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                command.Parameters.AddWithValue("@Pais", usuario.Pais);
                command.ExecuteNonQuery();
                return "Usuario Cambiado Correctamente";
            }
            catch (Exception ex)
            {
                string texto = "Este es el mensaje que quiere guardar en un archivo de texto.";
                string rutaArchivo = @"c:/mi/directrio/archivo.txt";

                using (StreamWriter escritor = new StreamWriter(rutaArchivo))
                {
                    escritor.WriteLine(texto);
                }
                return ex.Message + rutaArchivo;
            }
        }

        public string EliminarUsuarios()
        {
            try
            {
                var connection = GetSqlConnetion();
                var command = new SqlCommand("spEliminarUsuarios", connection);
                command.CommandType = CommandType.StoredProcedure;
                return "Usuarios Eliminados correctamente";
            }
            catch(Exception ex)
            {
                string texto = "Este es el mensaje que quiere guardar en un archivo de texto.";
                string rutaArchivo = @"c:/mi/directrio/archivo.txt";

                using (StreamWriter escritor = new StreamWriter(rutaArchivo))
                {
                    escritor.WriteLine(texto);
                }
                return ex.Message + rutaArchivo;
            }
        }

        public string EliminarUsuarioUnico(int Id)
        {
            try
            {
                var connection = GetSqlConnetion();
                var command = new SqlCommand("spEliminarUsuarioUnico", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();
                return "Dos perro comen piano en un estadio";

            }
            catch (Exception ex)
            {
                string texto = "Este es el mensaje que quiere guardar en un archivo de texto.";
                string rutaArchivo = @"c:/mi/directrio/archivo.txt";

                using (StreamWriter escritor = new StreamWriter(rutaArchivo))
                {
                    escritor.WriteLine(texto);
                }
                return ex.Message + rutaArchivo;
            }
        }
    }
}
