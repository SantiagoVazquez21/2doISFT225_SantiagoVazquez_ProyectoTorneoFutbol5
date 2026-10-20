using MySql.Data.MySqlClient;

namespace _2doISFT225_SantiagoVazquez_ProyectoTorneoFutbol5
{
    public class CategoriaRepositorio
    {
        public List<Categoria> ObtenerTodas()
        {
            List<Categoria> categorias = new List<Categoria>();

            using MySqlConnection conexion = new MySqlConnection(Conexion.CadenaConexion);
            conexion.Open();

            const string sql =
                "SELECT id_categoria, nombre_categoria, edad_min, edad_max, sexo " +
                "FROM categorias " +
                "ORDER BY id_categoria;";

            using MySqlCommand comando = new MySqlCommand(sql, conexion);
            using MySqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                categorias.Add(new Categoria
                {
                    Id = lector.GetInt32("id_categoria"),
                    Nombre = lector.GetString("nombre_categoria"),
                    EdadMin = lector.GetInt32("edad_min"),
                    EdadMax = lector.GetInt32("edad_max"),
                    Sexo = lector.IsDBNull(lector.GetOrdinal("sexo"))
                        ? null
                        : lector.GetString("sexo")[0],
                });
            }

            return categorias;
        }
    }
}
