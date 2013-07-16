﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Recorrido
{
    public partial class Abm_Reco_Seleccion : Form
    {
        public Abm_Reco_Seleccion()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            textBoxCodReco.Clear();
            comboBoxOrigen.ResetText();
            comboBoxDestino.ResetText();
            comboBoxTipoServ.ResetText();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {

            if (comboBoxTipoServ.SelectedValue == null) //ESTO CONTROLA QUE NO ME PONGAN UN SERVICIO QUE NO EXISTE EN EL COMBOBOX, PORQ SINO EXPLOTA TODO PQ ESTOY TRABAJANDO CON EL VALUEMEMBER, ENTONCES EL SQL ROMPE AL INTENTAR HACER LA CONVERSION DE TIPO
            {
                MessageBox.Show("ERROR. EL TIPO DE SERVICIO ES INCORRECTO");
                return;
            }

            string query = "SELECT reco_cod, serv_tipo, reco_origen, reco_destino, reco_precio_base_pasaje, reco_precio_base_kg FROM DATACENTER.Recorrido JOIN DATACENTER.Servicio ON reco_serv_id = serv_id WHERE 1 = 1";
            //ESTA QUERY ASI COMO ESTA CORRESPONDE A TODOS LOS CAMPOS VACIOS...
            string condicion = "";

            if (textBoxCodReco.Text != "")
            {
                condicion = condicion + " AND " + "reco_cod = " + "'" + textBoxCodReco.Text.ToString() + "'";
            }

            if (comboBoxTipoServ.Text != "")
            {
                condicion = condicion + " AND " + "serv_tipo = " + "'" + comboBoxTipoServ.Text.ToString() + "'";
            }

            if (comboBoxOrigen.Text != "")
            {
                condicion = condicion + " AND " + "reco_origen = " + "'" + comboBoxOrigen.Text.ToString() + "'";
            }

            if (comboBoxDestino.Text != "")
            {
                condicion = condicion + " AND " + "reco_destino = " + "'" + comboBoxDestino.Text.ToString() + "'";
            }

            if (condicion != "")
            {
                query = query + condicion;
            }

            //ANTES DE ESTO DEBO RESOLVER EL STRING Q LE VOY A MANDAR COMO QUERY A LA CONEXION    
            connection conexion = new connection();
            DataTable tabla_reco_busq = conexion.execute_query(query);
            this.Cod_Reco.DataPropertyName = tabla_reco_busq.Columns[0].ToString();
            this.Tipo_Serv.DataPropertyName = tabla_reco_busq.Columns[1].ToString();
            this.Ciu_Origen.DataPropertyName = tabla_reco_busq.Columns[2].ToString();
            this.Ciu_Destino.DataPropertyName = tabla_reco_busq.Columns[3].ToString();
            this.Precio_Base_Pasaje.DataPropertyName = tabla_reco_busq.Columns[4].ToString();
            this.Precio_Base_Kg.DataPropertyName = tabla_reco_busq.Columns[5].ToString();
            //cargamos el data_grid con el resultado de la busqueda
            this.dataGridReco.DataSource = tabla_reco_busq;
        }

        private void dataGridReco_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { //verificamos que el evento se haya producido en la columna que contiene el boton de seleccionar
            MessageBox.Show(e.ColumnIndex.ToString());
            if (e.ColumnIndex == 0)
            {
                string serv = this.dataGridReco.CurrentRow.Cells[2].Value.ToString();
                string orig = this.dataGridReco.CurrentRow.Cells[3].Value.ToString();
                string dest = this.dataGridReco.CurrentRow.Cells[4].Value.ToString();
                
                Abm_Reco_Modificacion abm_reco_mod = new Abm_Reco_Modificacion(serv,orig,dest);
                
                abm_reco_mod.textBoxCodReco.Text = this.dataGridReco.CurrentRow.Cells[1].Value.ToString();
                abm_reco_mod.numUpDownPrPas.Value = Convert.ToDecimal(this.dataGridReco.CurrentRow.Cells[5].Value);
                abm_reco_mod.numUpDownPrEnco.Value = Convert.ToDecimal(this.dataGridReco.CurrentRow.Cells[6].Value);
                /*
                abm_rol_mod.rol_nomb_mod = this.roles_dataGrid.CurrentRow.Cells[2].Value.ToString();*/
                abm_reco_mod.ShowDialog();
                //cuando retorna de la modificacion refrescamos la pantalla
                this.Close();
            }

        }

        private void Abm_Reco_Seleccion_Load(object sender, EventArgs e)
        {
            connection conexion = new connection();

            string query1 = "SELECT serv_tipo, serv_id FROM DATACENTER.Servicio";
            DataTable tabla_servicios = conexion.execute_query(query1);
            comboBoxTipoServ.DataSource = tabla_servicios;
            comboBoxTipoServ.DisplayMember = "serv_tipo";
            comboBoxTipoServ.ValueMember = "serv_id";


            string query2 = "SELECT ciu_nombre FROM DATACENTER.Ciudad";
            DataTable tabla_origenes = conexion.execute_query(query2);
            comboBoxOrigen.DataSource = tabla_origenes;
            comboBoxOrigen.DisplayMember = "ciu_nombre";
            comboBoxOrigen.ValueMember = "ciu_nombre";
 

            string query3 = "SELECT ciu_nombre FROM DATACENTER.Ciudad";
            DataTable tabla_destinos = conexion.execute_query(query3);
            comboBoxDestino.DataSource = tabla_destinos;
            comboBoxDestino.DisplayMember = "ciu_nombre";
            comboBoxDestino.ValueMember = "ciu_nombre";

            limpiar();
        }



    }
}
