﻿namespace FrbaBus.Abm_Recorrido
{
    partial class Abm_Reco_Modificacion
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
            this.textBoxCodReco = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxTipoServ = new System.Windows.Forms.ComboBox();
            this.comboBoxOrigen = new System.Windows.Forms.ComboBox();
            this.comboBoxDestino = new System.Windows.Forms.ComboBox();
            this.numUpDownPrPas = new System.Windows.Forms.NumericUpDown();
            this.numUpDownPrEnco = new System.Windows.Forms.NumericUpDown();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownPrPas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownPrEnco)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCodReco
            // 
            this.textBoxCodReco.Location = new System.Drawing.Point(125, 19);
            this.textBoxCodReco.Name = "textBoxCodReco";
            this.textBoxCodReco.ReadOnly = true;
            this.textBoxCodReco.Size = new System.Drawing.Size(132, 20);
            this.textBoxCodReco.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo de Recorrido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Servicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ciuedad Origen:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ciudad Destino:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Precio Base Pasaje:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Precio Base Kg:";
            // 
            // comboBoxTipoServ
            // 
            this.comboBoxTipoServ.FormattingEnabled = true;
            this.comboBoxTipoServ.Location = new System.Drawing.Point(125, 57);
            this.comboBoxTipoServ.Name = "comboBoxTipoServ";
            this.comboBoxTipoServ.Size = new System.Drawing.Size(132, 21);
            this.comboBoxTipoServ.TabIndex = 7;
            // 
            // comboBoxOrigen
            // 
            this.comboBoxOrigen.FormattingEnabled = true;
            this.comboBoxOrigen.Location = new System.Drawing.Point(125, 97);
            this.comboBoxOrigen.Name = "comboBoxOrigen";
            this.comboBoxOrigen.Size = new System.Drawing.Size(132, 21);
            this.comboBoxOrigen.TabIndex = 8;
            // 
            // comboBoxDestino
            // 
            this.comboBoxDestino.FormattingEnabled = true;
            this.comboBoxDestino.Location = new System.Drawing.Point(125, 137);
            this.comboBoxDestino.Name = "comboBoxDestino";
            this.comboBoxDestino.Size = new System.Drawing.Size(132, 21);
            this.comboBoxDestino.TabIndex = 9;
            // 
            // numUpDownPrPas
            // 
            this.numUpDownPrPas.DecimalPlaces = 2;
            this.numUpDownPrPas.Location = new System.Drawing.Point(125, 173);
            this.numUpDownPrPas.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            131072});
            this.numUpDownPrPas.Name = "numUpDownPrPas";
            this.numUpDownPrPas.Size = new System.Drawing.Size(120, 20);
            this.numUpDownPrPas.TabIndex = 10;
            // 
            // numUpDownPrEnco
            // 
            this.numUpDownPrEnco.DecimalPlaces = 2;
            this.numUpDownPrEnco.Location = new System.Drawing.Point(125, 207);
            this.numUpDownPrEnco.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            131072});
            this.numUpDownPrEnco.Name = "numUpDownPrEnco";
            this.numUpDownPrEnco.Size = new System.Drawing.Size(120, 20);
            this.numUpDownPrEnco.TabIndex = 11;
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(44, 277);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 12;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonGuardar
            // 
            this.botonGuardar.Location = new System.Drawing.Point(182, 277);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(75, 23);
            this.botonGuardar.TabIndex = 13;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // Abm_Reco_Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 312);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.numUpDownPrEnco);
            this.Controls.Add(this.numUpDownPrPas);
            this.Controls.Add(this.comboBoxDestino);
            this.Controls.Add(this.comboBoxOrigen);
            this.Controls.Add(this.comboBoxTipoServ);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCodReco);
            this.Name = "Abm_Reco_Modificacion";
            this.Text = "Abm_Reco_Modificacion";
            this.Load += new System.EventHandler(this.Abm_Reco_Modificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownPrPas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownPrEnco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonGuardar;
        public System.Windows.Forms.TextBox textBoxCodReco;
        public System.Windows.Forms.ComboBox comboBoxTipoServ;
        public System.Windows.Forms.ComboBox comboBoxOrigen;
        public System.Windows.Forms.ComboBox comboBoxDestino;
        public System.Windows.Forms.NumericUpDown numUpDownPrPas;
        public System.Windows.Forms.NumericUpDown numUpDownPrEnco;
    }
}