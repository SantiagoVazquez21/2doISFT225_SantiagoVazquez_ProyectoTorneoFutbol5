namespace _2doISFT225_SantiagoVazquez_ProyectoTorneoFutbol5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDni = new Label();
            txtDni = new TextBox();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            lblEdad = new Label();
            txtEdad = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblSexo = new Label();
            rdbMasculino = new RadioButton();
            rdbFemenino = new RadioButton();
            lblCategoriaTitulo = new Label();
            lblCategoria = new Label();
            chkAbono = new CheckBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            dgvInscripciones = new DataGridView();
            colNumero = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colDni = new DataGridViewTextBoxColumn();
            colEdad = new DataGridViewTextBoxColumn();
            colSexo = new DataGridViewTextBoxColumn();
            colDireccion = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colAbono = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).BeginInit();
            SuspendLayout();
            //
            // lblApellido
            //
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(12, 15);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 0;
            lblApellido.Text = "Apellido:";
            //
            // txtApellido
            //
            txtApellido.Location = new Point(90, 12);
            txtApellido.MaxLength = 50;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(170, 23);
            txtApellido.TabIndex = 1;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(280, 15);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(345, 12);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(170, 23);
            txtNombre.TabIndex = 3;
            //
            // lblDni
            //
            lblDni.AutoSize = true;
            lblDni.Location = new Point(535, 15);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(30, 15);
            lblDni.TabIndex = 4;
            lblDni.Text = "DNI:";
            //
            // txtDni
            //
            txtDni.Location = new Point(600, 12);
            txtDni.MaxLength = 15;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(130, 23);
            txtDni.TabIndex = 5;
            //
            // lblDireccion
            //
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(12, 50);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(60, 15);
            lblDireccion.TabIndex = 6;
            lblDireccion.Text = "Dirección:";
            //
            // txtDireccion
            //
            txtDireccion.Location = new Point(90, 47);
            txtDireccion.MaxLength = 75;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(170, 23);
            txtDireccion.TabIndex = 7;
            //
            // lblEdad
            //
            lblEdad.AutoSize = true;
            lblEdad.Location = new Point(280, 50);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(36, 15);
            lblEdad.TabIndex = 8;
            lblEdad.Text = "Edad:";
            //
            // txtEdad
            //
            txtEdad.Location = new Point(345, 47);
            txtEdad.MaxLength = 3;
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(60, 23);
            txtEdad.TabIndex = 9;
            txtEdad.TextChanged += ActualizarCategoriaAsignada;
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(535, 50);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(55, 15);
            lblTelefono.TabIndex = 10;
            lblTelefono.Text = "Teléfono:";
            //
            // txtTelefono
            //
            txtTelefono.Location = new Point(600, 47);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(130, 23);
            txtTelefono.TabIndex = 11;
            //
            // lblSexo
            //
            lblSexo.AutoSize = true;
            lblSexo.Location = new Point(12, 85);
            lblSexo.Name = "lblSexo";
            lblSexo.Size = new Size(35, 15);
            lblSexo.TabIndex = 12;
            lblSexo.Text = "Sexo:";
            //
            // rdbMasculino
            //
            rdbMasculino.AutoSize = true;
            rdbMasculino.Location = new Point(90, 83);
            rdbMasculino.Name = "rdbMasculino";
            rdbMasculino.Size = new Size(80, 19);
            rdbMasculino.TabIndex = 13;
            rdbMasculino.Text = "Masculino";
            rdbMasculino.UseVisualStyleBackColor = true;
            rdbMasculino.CheckedChanged += ActualizarCategoriaAsignada;
            //
            // rdbFemenino
            //
            rdbFemenino.AutoSize = true;
            rdbFemenino.Location = new Point(180, 83);
            rdbFemenino.Name = "rdbFemenino";
            rdbFemenino.Size = new Size(78, 19);
            rdbFemenino.TabIndex = 14;
            rdbFemenino.Text = "Femenino";
            rdbFemenino.UseVisualStyleBackColor = true;
            rdbFemenino.CheckedChanged += ActualizarCategoriaAsignada;
            //
            // lblCategoriaTitulo
            //
            lblCategoriaTitulo.AutoSize = true;
            lblCategoriaTitulo.Location = new Point(280, 85);
            lblCategoriaTitulo.Name = "lblCategoriaTitulo";
            lblCategoriaTitulo.Size = new Size(61, 15);
            lblCategoriaTitulo.TabIndex = 15;
            lblCategoriaTitulo.Text = "Categoría:";
            //
            // lblCategoria
            //
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategoria.Location = new Point(345, 85);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(15, 15);
            lblCategoria.TabIndex = 16;
            lblCategoria.Text = "—";
            //
            // chkAbono
            //
            chkAbono.AutoSize = true;
            chkAbono.Location = new Point(600, 84);
            chkAbono.Name = "chkAbono";
            chkAbono.Size = new Size(131, 19);
            chkAbono.TabIndex = 17;
            chkAbono.Text = "Abonó la inscripción";
            chkAbono.UseVisualStyleBackColor = true;
            //
            // btnAgregar
            //
            btnAgregar.Location = new Point(12, 120);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(95, 28);
            btnAgregar.TabIndex = 18;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            //
            // btnModificar
            //
            btnModificar.Location = new Point(113, 120);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(95, 28);
            btnModificar.TabIndex = 19;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            //
            // btnEliminar
            //
            btnEliminar.Location = new Point(214, 120);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(95, 28);
            btnEliminar.TabIndex = 20;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            //
            // btnLimpiar
            //
            btnLimpiar.Location = new Point(315, 120);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(95, 28);
            btnLimpiar.TabIndex = 21;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            //
            // dgvInscripciones
            //
            dgvInscripciones.AllowUserToAddRows = false;
            dgvInscripciones.AllowUserToDeleteRows = false;
            dgvInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInscripciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInscripciones.Columns.AddRange(new DataGridViewColumn[] { colNumero, colFecha, colApellido, colNombre, colDni, colEdad, colSexo, colDireccion, colTelefono, colCategoria, colAbono });
            dgvInscripciones.Location = new Point(12, 162);
            dgvInscripciones.MultiSelect = false;
            dgvInscripciones.Name = "dgvInscripciones";
            dgvInscripciones.ReadOnly = true;
            dgvInscripciones.RowHeadersVisible = false;
            dgvInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInscripciones.Size = new Size(1010, 386);
            dgvInscripciones.TabIndex = 22;
            dgvInscripciones.CellClick += dgvInscripciones_CellClick;
            //
            // colNumero
            //
            colNumero.FillWeight = 45F;
            colNumero.HeaderText = "N°";
            colNumero.Name = "colNumero";
            colNumero.ReadOnly = true;
            //
            // colFecha
            //
            colFecha.FillWeight = 80F;
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            //
            // colApellido
            //
            colApellido.HeaderText = "Apellido";
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;
            //
            // colNombre
            //
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            //
            // colDni
            //
            colDni.FillWeight = 85F;
            colDni.HeaderText = "DNI";
            colDni.Name = "colDni";
            colDni.ReadOnly = true;
            //
            // colEdad
            //
            colEdad.FillWeight = 50F;
            colEdad.HeaderText = "Edad";
            colEdad.Name = "colEdad";
            colEdad.ReadOnly = true;
            //
            // colSexo
            //
            colSexo.FillWeight = 50F;
            colSexo.HeaderText = "Sexo";
            colSexo.Name = "colSexo";
            colSexo.ReadOnly = true;
            //
            // colDireccion
            //
            colDireccion.FillWeight = 130F;
            colDireccion.HeaderText = "Dirección";
            colDireccion.Name = "colDireccion";
            colDireccion.ReadOnly = true;
            //
            // colTelefono
            //
            colTelefono.FillWeight = 95F;
            colTelefono.HeaderText = "Teléfono";
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;
            //
            // colCategoria
            //
            colCategoria.FillWeight = 115F;
            colCategoria.HeaderText = "Categoría";
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            //
            // colAbono
            //
            colAbono.FillWeight = 55F;
            colAbono.HeaderText = "Abonó";
            colAbono.Name = "colAbono";
            colAbono.ReadOnly = true;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 560);
            Controls.Add(dgvInscripciones);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(chkAbono);
            Controls.Add(lblCategoria);
            Controls.Add(lblCategoriaTitulo);
            Controls.Add(rdbFemenino);
            Controls.Add(rdbMasculino);
            Controls.Add(lblSexo);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtEdad);
            Controls.Add(lblEdad);
            Controls.Add(txtDireccion);
            Controls.Add(lblDireccion);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            MinimumSize = new Size(1050, 450);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Torneo Fútbol 5 - Inscripciones";
            Shown += Form1_Shown;
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDni;
        private TextBox txtDni;
        private Label lblDireccion;
        private TextBox txtDireccion;
        private Label lblEdad;
        private TextBox txtEdad;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblSexo;
        private RadioButton rdbMasculino;
        private RadioButton rdbFemenino;
        private Label lblCategoriaTitulo;
        private Label lblCategoria;
        private CheckBox chkAbono;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private DataGridView dgvInscripciones;
        private DataGridViewTextBoxColumn colNumero;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colDni;
        private DataGridViewTextBoxColumn colEdad;
        private DataGridViewTextBoxColumn colSexo;
        private DataGridViewTextBoxColumn colDireccion;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewCheckBoxColumn colAbono;
    }
}
