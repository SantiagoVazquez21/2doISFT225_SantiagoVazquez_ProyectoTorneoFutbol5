namespace _2doISFT225_SantiagoVazquez_ProyectoTorneoFutbol5
{
    public class Inscripcion
    {
        // 0 = todavía no guardada en la base.
        public int Numero { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Today;

        public bool Abono { get; set; }

        public Participante Participante { get; set; }

        public Categoria Categoria { get; set; }

        public Inscripcion(Participante participante, Categoria categoria)
        {
            Participante = participante;
            Categoria = categoria;
        }
    }
}
