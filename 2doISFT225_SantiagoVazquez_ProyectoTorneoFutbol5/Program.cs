namespace _2doISFT225_SantiagoVazquez_ProyectoTorneoFutbol5
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (!Conexion.TryCargar(out string error))
            {
                MessageBox.Show(error, "Falta configurar la conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new Form1());
        }
    }
}