namespace _2doISFT225_SantiagoVazquez_ProyectoTorneoFutbol5
{
    // La cadena de conexión se lee de conexion.local.txt y no está escrita acá:
    // tiene la contraseña de la base en la nube y el repo es público.
    // Ese archivo está en el .gitignore; conexion.ejemplo.txt muestra el formato.
    internal static class Conexion
    {
        private const string NombreArchivo = "conexion.local.txt";

        public static string CadenaConexion { get; private set; } = string.Empty;

        // Se llama una vez al iniciar la app. Las líneas vacías o que empiezan
        // con # se ignoran; la primera línea restante es la cadena de conexión.
        public static bool TryCargar(out string error)
        {
            string ruta = Path.Combine(AppContext.BaseDirectory, NombreArchivo);

            if (!File.Exists(ruta))
            {
                error = $"No se encontró el archivo {NombreArchivo}.\n\n" +
                        "Copiá conexion.ejemplo.txt con ese nombre, completá los datos " +
                        "de la base y volvé a compilar.";
                return false;
            }

            string? cadena = File.ReadAllLines(ruta)
                .Select(linea => linea.Trim())
                .FirstOrDefault(linea => linea != "" && !linea.StartsWith('#'));

            if (cadena == null)
            {
                error = $"El archivo {NombreArchivo} no tiene ninguna cadena de conexión.";
                return false;
            }

            CadenaConexion = cadena;
            error = string.Empty;
            return true;
        }
    }
}
