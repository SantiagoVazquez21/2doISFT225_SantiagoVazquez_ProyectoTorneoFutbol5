using MySql.Data.MySqlClient;

namespace _2doISFT225_SantiagoVazquez_ProyectoTorneoFutbol5
{
    // Cada inscripción toca dos tablas (participantes + inscripciones), por eso
    // Insertar/Actualizar/Eliminar usan una transacción: o se guardan las dos
    // cosas o ninguna, nunca queda un participante sin inscripción.
    public class InscripcionRepositorio
    {
        public List<Inscripcion> ObtenerTodas()
        {
            List<Inscripcion> inscripciones = new List<Inscripcion>();

            using MySqlConnection conexion = new MySqlConnection(Conexion.CadenaConexion);
            conexion.Open();

            const string sql =
                "SELECT i.num_inscripcion, i.fecha_insc, i.abono_inscrip, " +
                "       p.id_participante, p.apellido_part, p.nombre_part, p.dni, " +
                "       p.direccion, p.edad, p.telefono, p.sexo, " +
                "       c.id_categoria, c.nombre_categoria, c.edad_min, c.edad_max, " +
                "       c.sexo AS sexo_categoria " +
                "FROM inscripciones i " +
                "JOIN participantes p ON p.id_participante = i.participante " +
                "JOIN categorias c ON c.id_categoria = i.categoria " +
                "ORDER BY i.num_inscripcion;";

            using MySqlCommand comando = new MySqlCommand(sql, conexion);
            using MySqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Participante participante = new Participante
                {
                    Id = lector.GetInt32("id_participante"),
                    Apellido = lector.GetString("apellido_part"),
                    Nombre = lector.GetString("nombre_part"),
                    Dni = LeerTextoOpcional(lector, "dni"),
                    Direccion = lector.GetString("direccion"),
                    Edad = lector.GetInt32("edad"),
                    Telefono = LeerTextoOpcional(lector, "telefono"),
                    Sexo = lector.GetString("sexo")[0],
                };

                Categoria categoria = new Categoria
                {
                    Id = lector.GetInt32("id_categoria"),
                    Nombre = lector.GetString("nombre_categoria"),
                    EdadMin = lector.GetInt32("edad_min"),
                    EdadMax = lector.GetInt32("edad_max"),
                    Sexo = LeerTextoOpcional(lector, "sexo_categoria")?[0],
                };

                inscripciones.Add(new Inscripcion(participante, categoria)
                {
                    Numero = lector.GetInt32("num_inscripcion"),
                    Fecha = lector.GetDateTime("fecha_insc"),
                    Abono = !lector.IsDBNull(lector.GetOrdinal("abono_inscrip")) &&
                            lector.GetBoolean("abono_inscrip"),
                });
            }

            return inscripciones;
        }

        public void Insertar(Inscripcion inscripcion)
        {
            using MySqlConnection conexion = new MySqlConnection(Conexion.CadenaConexion);
            conexion.Open();
            using MySqlTransaction transaccion = conexion.BeginTransaction();

            const string sqlParticipante =
                "INSERT INTO participantes " +
                "(apellido_part, nombre_part, dni, direccion, edad, telefono, sexo) " +
                "VALUES (@apellido, @nombre, @dni, @direccion, @edad, @telefono, @sexo); " +
                "SELECT LAST_INSERT_ID();";

            using (MySqlCommand comando = new MySqlCommand(sqlParticipante, conexion, transaccion))
            {
                CargarParametrosParticipante(comando, inscripcion.Participante);
                inscripcion.Participante.Id = Convert.ToInt32(comando.ExecuteScalar());
            }

            const string sqlInscripcion =
                "INSERT INTO inscripciones (fecha_insc, abono_inscrip, categoria, participante) " +
                "VALUES (@fecha, @abono, @categoria, @participante); " +
                "SELECT LAST_INSERT_ID();";

            using (MySqlCommand comando = new MySqlCommand(sqlInscripcion, conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@fecha", inscripcion.Fecha);
                comando.Parameters.AddWithValue("@abono", inscripcion.Abono);
                comando.Parameters.AddWithValue("@categoria", inscripcion.Categoria.Id);
                comando.Parameters.AddWithValue("@participante", inscripcion.Participante.Id);
                inscripcion.Numero = Convert.ToInt32(comando.ExecuteScalar());
            }

            // Si algo falla antes de llegar acá, el using descarta la transacción
            // y MySQL deshace el INSERT del participante.
            transaccion.Commit();
        }

        public void Actualizar(Inscripcion inscripcion)
        {
            using MySqlConnection conexion = new MySqlConnection(Conexion.CadenaConexion);
            conexion.Open();
            using MySqlTransaction transaccion = conexion.BeginTransaction();

            const string sqlParticipante =
                "UPDATE participantes SET apellido_part = @apellido, nombre_part = @nombre, " +
                "dni = @dni, direccion = @direccion, edad = @edad, telefono = @telefono, " +
                "sexo = @sexo " +
                "WHERE id_participante = @id;";

            using (MySqlCommand comando = new MySqlCommand(sqlParticipante, conexion, transaccion))
            {
                CargarParametrosParticipante(comando, inscripcion.Participante);
                comando.Parameters.AddWithValue("@id", inscripcion.Participante.Id);
                comando.ExecuteNonQuery();
            }

            // La fecha de inscripción no se toca: es la del día en que se anotó.
            const string sqlInscripcion =
                "UPDATE inscripciones SET abono_inscrip = @abono, categoria = @categoria " +
                "WHERE num_inscripcion = @numero;";

            using (MySqlCommand comando = new MySqlCommand(sqlInscripcion, conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@abono", inscripcion.Abono);
                comando.Parameters.AddWithValue("@categoria", inscripcion.Categoria.Id);
                comando.Parameters.AddWithValue("@numero", inscripcion.Numero);
                comando.ExecuteNonQuery();
            }

            transaccion.Commit();
        }

        public void Eliminar(Inscripcion inscripcion)
        {
            using MySqlConnection conexion = new MySqlConnection(Conexion.CadenaConexion);
            conexion.Open();
            using MySqlTransaction transaccion = conexion.BeginTransaction();

            // Primero la inscripción: la FK no deja borrar un participante
            // que todavía tiene una inscripción apuntándole.
            using (MySqlCommand comando = new MySqlCommand(
                "DELETE FROM inscripciones WHERE num_inscripcion = @numero;", conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@numero", inscripcion.Numero);
                comando.ExecuteNonQuery();
            }

            using (MySqlCommand comando = new MySqlCommand(
                "DELETE FROM participantes WHERE id_participante = @id;", conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@id", inscripcion.Participante.Id);
                comando.ExecuteNonQuery();
            }

            transaccion.Commit();
        }

        // idParticipanteExcluido: al modificar, el propio participante no cuenta como duplicado.
        public bool ExisteDni(string dni, int idParticipanteExcluido)
        {
            using MySqlConnection conexion = new MySqlConnection(Conexion.CadenaConexion);
            conexion.Open();

            const string sql =
                "SELECT COUNT(*) FROM participantes " +
                "WHERE dni = @dni AND id_participante <> @id;";

            using MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@dni", dni);
            comando.Parameters.AddWithValue("@id", idParticipanteExcluido);

            return Convert.ToInt32(comando.ExecuteScalar()) > 0;
        }

        private static void CargarParametrosParticipante(MySqlCommand comando, Participante participante)
        {
            comando.Parameters.AddWithValue("@apellido", participante.Apellido);
            comando.Parameters.AddWithValue("@nombre", participante.Nombre);
            comando.Parameters.AddWithValue("@dni", (object?)participante.Dni ?? DBNull.Value);
            comando.Parameters.AddWithValue("@direccion", participante.Direccion);
            comando.Parameters.AddWithValue("@edad", participante.Edad);
            comando.Parameters.AddWithValue("@telefono", (object?)participante.Telefono ?? DBNull.Value);
            comando.Parameters.AddWithValue("@sexo", participante.Sexo.ToString());
        }

        private static string? LeerTextoOpcional(MySqlDataReader lector, string columna)
        {
            int posicion = lector.GetOrdinal(columna);
            return lector.IsDBNull(posicion) ? null : lector.GetString(posicion);
        }
    }
}
