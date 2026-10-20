namespace _2doISFT225_SantiagoVazquez_ProyectoTorneoFutbol5
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public int EdadMin { get; set; }

        public int EdadMax { get; set; }

        // null = categoría mixta (la columna sexo de la tabla acepta NULL).
        public char? Sexo { get; set; }

        public bool Admite(int edad, char sexo)
        {
            bool edadEnRango = edad >= EdadMin && edad <= EdadMax;
            bool sexoCorresponde = Sexo == null || Sexo == sexo;

            return edadEnRango && sexoCorresponde;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
