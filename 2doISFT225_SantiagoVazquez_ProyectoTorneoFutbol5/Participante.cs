namespace _2doISFT225_SantiagoVazquez_ProyectoTorneoFutbol5
{
    public class Participante
    {
        // 0 = todavía no guardado en la base.
        public int Id { get; set; }

        public string Apellido { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        // DNI y teléfono son opcionales en la tabla (aceptan NULL).
        public string? Dni { get; set; }

        public string Direccion { get; set; } = string.Empty;

        private int edad;

        public int Edad
        {
            get => edad;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("La edad debe ser mayor a 0.");
                }

                edad = value;
            }
        }

        public string? Telefono { get; set; }

        // 'M' o 'F', igual que el ENUM de la tabla.
        public char Sexo { get; set; }

        public override string ToString()
        {
            return $"{Apellido}, {Nombre}";
        }
    }
}
