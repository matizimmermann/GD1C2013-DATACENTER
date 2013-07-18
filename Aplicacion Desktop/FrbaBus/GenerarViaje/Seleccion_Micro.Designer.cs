namespace FrbaBus.GenerarViaje
{
    partial class Seleccion_Micro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.botonConfirmar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.dataGridMicro = new System.Windows.Forms.DataGridView();
            this.comboBoxTipoServ = new System.Windows.Forms.ComboBox();
            this.comboBoxMarca = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPatente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cod_Reco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Serv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciu_Origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciu_Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_Base_Pasaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_Base_Kg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBoxCantBut = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMicro)).BeginInit();
            this.SuspendLayout();
            // 
            // botonConfirmar
            // 
            this.botonConfirmar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.botonConfirmar.Enabled = false;
            this.botonConfirmar.Location = new System.Drawing.Point(615, 5);
            this.botonConfirmar.Name = "botonConfirmar";
            this.botonConfirmar.Size = new System.Drawing.Size(137, 99);
            this.botonConfirmar.TabIndex = 35;
            this.botonConfirmar.Text = "CONFIRMAR SELECCION";
            this.botonConfirmar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(316, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "*Debe primero seleccionar una fila, y luego confirmar la selección.";
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(482, 58);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(108, 47);
            this.botonBuscar.TabIndex = 33;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(482, 5);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(108, 46);
            this.botonLimpiar.TabIndex = 32;
            this.botonLimpiar.Text = "Limpiar:";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // dataGridMicro
            // 
            this.dataGridMicro.AllowUserToAddRows = false;
            this.dataGridMicro.AllowUserToDeleteRows = false;
            this.dataGridMicro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMicro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod_Reco,
            this.Tipo_Serv,
            this.Ciu_Origen,
            this.Ciu_Destino,
            this.Precio_Base_Pasaje,
            this.Precio_Base_Kg,
            this.Estado,
            this.Seleccionar});
            this.dataGridMicro.Location = new System.Drawing.Point(12, 118);
            this.dataGridMicro.Name = "dataGridMicro";
            this.dataGridMicro.ReadOnly = true;
            this.dataGridMicro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMicro.Size = new System.Drawing.Size(846, 291);
            this.dataGridMicro.TabIndex = 31;
            // 
            // comboBoxTipoServ
            // 
            this.comboBoxTipoServ.FormattingEnabled = true;
            this.comboBoxTipoServ.Location = new System.Drawing.Point(105, 52);
            this.comboBoxTipoServ.Name = "comboBoxTipoServ";
            this.comboBoxTipoServ.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoServ.TabIndex = 30;
            // 
            // comboBoxMarca
            // 
            this.comboBoxMarca.FormattingEnabled = true;
            this.comboBoxMarca.Location = new System.Drawing.Point(335, 6);
            this.comboBoxMarca.Name = "comboBoxMarca";
            this.comboBoxMarca.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMarca.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Cantidad Butacas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Marca:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tipo de Servicio:";
            // 
            // textBoxPatente
            // 
            this.textBoxPatente.Location = new System.Drawing.Point(122, 6);
            this.textBoxPatente.Name = "textBoxPatente";
            this.textBoxPatente.Size = new System.Drawing.Size(100, 20);
            this.textBoxPatente.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Patente:";
            // 
            // Cod_Reco
            // 
            this.Cod_Reco.HeaderText = "Patente";
            this.Cod_Reco.Name = "Cod_Reco";
            this.Cod_Reco.ReadOnly = true;
            // 
            // Tipo_Serv
            // 
            this.Tipo_Serv.HeaderText = "Tipo_Serv";
            this.Tipo_Serv.Name = "Tipo_Serv";
            this.Tipo_Serv.ReadOnly = true;
            // 
            // Ciu_Origen
            // 
            this.Ciu_Origen.HeaderText = "Marca";
            this.Ciu_Origen.Name = "Ciu_Origen";
            this.Ciu_Origen.ReadOnly = true;
            // 
            // Ciu_Destino
            // 
            this.Ciu_Destino.HeaderText = "Modelo";
            this.Ciu_Destino.Name = "Ciu_Destino";
            this.Ciu_Destino.ReadOnly = true;
            // 
            // Precio_Base_Pasaje
            // 
            this.Precio_Base_Pasaje.HeaderText = "Nro_Micro";
            this.Precio_Base_Pasaje.Name = "Precio_Base_Pasaje";
            this.Precio_Base_Pasaje.ReadOnly = true;
            this.Precio_Base_Pasaje.Width = 120;
            // 
            // Precio_Base_Kg
            // 
            this.Precio_Base_Kg.HeaderText = "Fecha_Alta";
            this.Precio_Base_Kg.Name = "Precio_Base_Kg";
            this.Precio_Base_Kg.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Cant_Butacas";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccion";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseColumnTextForButtonValue = true;
            // 
            // textBoxCantBut
            // 
            this.textBoxCantBut.Location = new System.Drawing.Point(349, 51);
            this.textBoxCantBut.MaxLength = 3;
            this.textBoxCantBut.Name = "textBoxCantBut";
            this.textBoxCantBut.Size = new System.Drawing.Size(100, 20);
            this.textBoxCantBut.TabIndex = 36;
            this.textBoxCantBut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCantBut_KeyPress);
            // 
            // Seleccion_Micro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 418);
            this.Controls.Add(this.textBoxCantBut);
            this.Controls.Add(this.botonConfirmar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.dataGridMicro);
            this.Controls.Add(this.comboBoxTipoServ);
            this.Controls.Add(this.comboBoxMarca);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPatente);
            this.Controls.Add(this.label1);
            this.Name = "Seleccion_Micro";
            this.Text = "Seleccion_Micro";
            this.Load += new System.EventHandler(this.Seleccion_Micro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMicro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonConfirmar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.DataGridView dataGridMicro;
        private System.Windows.Forms.ComboBox comboBoxTipoServ;
        private System.Windows.Forms.ComboBox comboBoxMarca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPatente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Reco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Serv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciu_Origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciu_Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_Base_Pasaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_Base_Kg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
        public System.Windows.Forms.TextBox textBoxCantBut;
    }
}