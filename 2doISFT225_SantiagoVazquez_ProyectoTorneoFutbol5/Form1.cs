using MySql.Data.MySqlClient;

namespace _2doISFT225_SantiagoVazquez_ProyectoTorneoFutbol5
{
    public partial class Form1 : Form
    {
        private readonly InscripcionRepositorio inscripcionRepositorio = new InscripcionRepositorio();
        private readonly CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio();

        private List<Categoria> categorias = new List<Categoria>();

        // Inscripción elegida en la grilla; null = no hay ninguna seleccionada.
        private Inscripcion? seleccionada;

        public Form1()
        {
            InitializeComponent();

            CargarCategorias();
            CargarInscripciones();
        }

        private void CargarCategorias()
        {
            try
            {
                categorias = categoriaRepositorio.ObtenerTodas();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar las categorías.\n\n{ex.Message}\n\n" +
                    "Verificá que MySQL esté iniciado en XAMPP.");
            }
        }

        // Se vuelve a leer todo de la base después de cada cambio: así la grilla
        // muestra siempre lo que realmente quedó guardado.
        private void CargarInscripciones()
        {
            dgvInscripciones.Rows.Clear();

            List<Inscripcion> inscripciones;

            try
            {
                inscripciones = inscripcionRepositorio.ObtenerTodas();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"No se pudo conectar a la base de datos.\n\n{ex.Message}\n\n" +
                    "Verificá que MySQL esté iniciado en XAMPP.");
                return;
            }

            foreach (Inscripcion inscripcion in inscripciones)
            {
                Participante p = inscripcion.Participante;

                int fila = dgvInscripciones.Rows.Add(
                    inscripcion.Numero,
                    inscripcion.Fecha.ToString("dd/MM/yyyy"),
                    p.Apellido,
                    p.Nombre,
                    p.Dni ?? "",
                    p.Edad,
                    p.Sexo.ToString(),
                    p.Direccion,
                    p.Telefono ?? "",
                    inscripcion.Categoria.Nombre,
                    inscripcion.Abono);

                // Tag guarda el objeto completo para recuperarlo al hacer clic en la fila.
                dgvInscripciones.Rows[fila].Tag = inscripcion;
            }

            dgvInscripciones.ClearSelection();
        }

        private Categoria? BuscarCategoria(int edad, char sexo)
        {
            return categorias.Find(c => c.Admite(edad, sexo));
        }

        private char? SexoElegido()
        {
            if (rdbMasculino.Checked)
            {
                return 'M';
            }

            if (rdbFemenino.Checked)
            {
                return 'F';
            }

            return null;
        }

        // Muestra en vivo qué categoría le va a tocar según edad y sexo.
        private void ActualizarCategoriaAsignada(object? sender, EventArgs e)
        {
            char? sexo = SexoElegido();

            if (!int.TryParse(txtEdad.Text, out int edad) || sexo == null)
            {
                lblCategoria.Text = "—";
                lblCategoria.ForeColor = SystemColors.ControlText;
                return;
            }

            Categoria? categoria = BuscarCategoria(edad, sexo.Value);

            if (categoria == null)
            {
                lblCategoria.Text = "Sin categoría para esa edad";
                lblCategoria.ForeColor = Color.Firebrick;
            }
            else
            {
                lblCategoria.Text = categoria.Nombre;
                lblCategoria.ForeColor = Color.DarkGreen;
            }
        }

        // Valida la planilla y arma el participante con su categoría.
        // Devuelve false (y ya avisó al usuario) si algo no está bien.
        private bool TryLeerPlanilla(out Participante participante, out Categoria categoria)
        {
            participante = new Participante();
            categoria = new Categoria();

            string apellido = txtApellido.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string dni = txtDni.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            if (apellido == "" || nombre == "" || direccion == "" || txtEdad.Text.Trim() == "")
            {
                MessageBox.Show("Complete apellido, nombre, dirección y edad.");
                return false;
            }

            if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 0)
            {
                MessageBox.Show("La edad debe ser un número entero mayor a 0.");
                return false;
            }

            char? sexo = SexoElegido();

            if (sexo == null)
            {
                MessageBox.Show("Seleccione el sexo.");
                return false;
            }

            if (dni != "" && !dni.All(char.IsDigit))
            {
                MessageBox.Show("El DNI debe contener solo números.");
                return false;
            }

            Categoria? encontrada = BuscarCategoria(edad, sexo.Value);

            if (encontrada == null)
            {
                string sexoTexto = sexo == 'M' ? "masculino" : "femenino";
                MessageBox.Show(
                    $"No hay una categoría {sexoTexto} para {edad} años.\n\n" +
                    $"Las categorías del torneo van de {categorias.Min(c => c.EdadMin)} " +
                    $"a {categorias.Max(c => c.EdadMax)} años.");
                return false;
            }

            participante = new Participante
            {
                Apellido = apellido,
                Nombre = nombre,
                Dni = dni == "" ? null : dni,
                Direccion = direccion,
                Edad = edad,
                Telefono = telefono == "" ? null : telefono,
                Sexo = sexo.Value,
            };
            categoria = encontrada;

            return true;
        }

        private bool DniRepetido(Participante participante)
        {
            if (participante.Dni == null)
            {
                return false;
            }

            if (inscripcionRepositorio.ExisteDni(participante.Dni, participante.Id))
            {
                MessageBox.Show($"Ya hay una persona inscripta con el DNI {participante.Dni}.");
                return true;
            }

            return false;
        }

        private void LimpiarCampos()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDni.Clear();
            txtDireccion.Clear();
            txtEdad.Clear();
            txtTelefono.Clear();
            rdbMasculino.Checked = false;
            rdbFemenino.Checked = false;
            chkAbono.Checked = false;

            seleccionada = null;
            dgvInscripciones.ClearSelection();

            txtApellido.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!TryLeerPlanilla(out Participante participante, out Categoria categoria))
            {
                return;
            }

            try
            {
                if (DniRepetido(participante))
                {
                    return;
                }

                Inscripcion inscripcion = new Inscripcion(participante, categoria)
                {
                    Abono = chkAbono.Checked,
                };

                inscripcionRepositorio.Insertar(inscripcion);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"No se pudo guardar en la base de datos.\n\n{ex.Message}");
                return;
            }

            CargarInscripciones();
            LimpiarCampos();

            MessageBox.Show($"Inscripción guardada en la categoría {categoria.Nombre}.");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccione una inscripción de la grilla.");
                return;
            }

            if (!TryLeerPlanilla(out Participante participante, out Categoria categoria))
            {
                return;
            }

            // Mismo participante y misma inscripción, con los datos nuevos de la planilla.
            participante.Id = seleccionada.Participante.Id;

            Inscripcion modificada = new Inscripcion(participante, categoria)
            {
                Numero = seleccionada.Numero,
                Fecha = seleccionada.Fecha,
                Abono = chkAbono.Checked,
            };

            try
            {
                if (DniRepetido(participante))
                {
                    return;
                }

                inscripcionRepositorio.Actualizar(modificada);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"No se pudo actualizar en la base de datos.\n\n{ex.Message}");
                return;
            }

            CargarInscripciones();
            LimpiarCampos();

            MessageBox.Show("Inscripción modificada correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccione una inscripción de la grilla.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Eliminar la inscripción de {seleccionada.Participante}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                inscripcionRepositorio.Eliminar(seleccionada);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"No se pudo eliminar en la base de datos.\n\n{ex.Message}");
                return;
            }

            CargarInscripciones();
            LimpiarCampos();

            MessageBox.Show("Inscripción eliminada correctamente.");
        }

        // Al mostrarse, la grilla marca sola la primera fila; se limpia para que
        // no parezca seleccionada una inscripción que el usuario no eligió.
        private void Form1_Shown(object sender, EventArgs e)
        {
            dgvInscripciones.ClearSelection();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvInscripciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvInscripciones.Rows[e.RowIndex].Tag is not Inscripcion inscripcion)
            {
                return;
            }

            seleccionada = inscripcion;
            Participante p = inscripcion.Participante;

            txtApellido.Text = p.Apellido;
            txtNombre.Text = p.Nombre;
            txtDni.Text = p.Dni;
            txtDireccion.Text = p.Direccion;
            txtEdad.Text = p.Edad.ToString();
            txtTelefono.Text = p.Telefono;
            rdbMasculino.Checked = p.Sexo == 'M';
            rdbFemenino.Checked = p.Sexo == 'F';
            chkAbono.Checked = inscripcion.Abono;
        }
    }
}
