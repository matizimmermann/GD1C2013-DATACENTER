﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.GenerarViaje
{
    public partial class Alta_Viaje : Form
    {
        string serv_reco = "";

        public Alta_Viaje()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            dateTimePickerSalida.ResetText();
            dateTimePickerLlegada.ResetText();
            textBoxReco.Clear();
            textBoxMicro.Clear();
        }


        private void botonSelReco_Click(object sender, EventArgs e)
        {
            Seleccion_Reco sel_reco = new Seleccion_Reco();
            DialogResult cod = sel_reco.ShowDialog(); //abrimos el formulario 2 como cuadro de dialogo para poder retornar el codigo

            if (cod == DialogResult.OK)
            {
                //recuperando la variable publica (codigo de recorrido) del formulario sel_reco
                textBoxReco.Text = sel_reco.cod_y_serv[0]; //asignamos al texbox el dato de la variable
                serv_reco = sel_reco.cod_y_serv[1]; // Se lo voy a pasar como parametro al sel_micro
            }
        }

        private void botonSelMicro_Click(object sender, EventArgs e)
        {
            string dia_prox = dateTimePickerSalida.Value.AddDays(1).ToString("yyyy-MM-dd HH:mm");
            string dia_ant = dateTimePickerSalida.Value.AddDays(-1).ToString("yyyy-MM-dd HH:mm");
            string fecha_sal = dateTimePickerSalida.Value.ToString("yyyy-MM-dd HH:mm");
            Seleccion_Micro sel_micro = new Seleccion_Micro(serv_reco, fecha_sal, dia_ant, dia_prox);
            DialogResult pat = sel_micro.ShowDialog(); //abrimos el formulario sel_micro como cuadro de dialogo para poder retornar el codigo

            if (pat == DialogResult.OK)
            {
                //recuperando la variable publica (codigo de recorrido) del formulario sel_reco
                textBoxMicro.Text = sel_micro.patente; //asignamos al texbox el dato de la variable
            }
        }

        private void textBoxReco_TextChanged(object sender, EventArgs e)
        {
            botonSelMicro.Enabled = true; // Me habilita el boton para seleccionar el micro, luego de seleccionar el recorrido.
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
            botonSelMicro.Enabled = false;
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            int codigo_error = 0; // el 0 es que no tiene errores y el 1 es que SI tiene errores!

            if (textBoxReco.Text == "")
            {
                codigo_error = 1;
                MessageBox.Show("ERROR: DEBE SELECCIONAR UN RECORRIDO");
            }

            if(textBoxMicro.Text == "")
            {
                codigo_error = 1;
                MessageBox.Show("ERROR: DEBE SELECCIONAR UN MICRO");
            }

            /*
             * ACA TENDRIA QUE VALIDAR EL TEMA
             * DE LAS FECHAS, PARA QUE INGRESE
             * CORRECTAMENTE TODO Y NO SE INSERTE
             * NADA INCORRECTO EN LA BASE.
             */

            if (codigo_error == 1)
            {
                return;
            }

            string fecha_sal_ins = dateTimePickerSalida.Text.ToString();
            string fehca_lleg_ins = dateTimePickerLlegada.Text.ToString();
            string cod_reco_ins = textBoxReco.Text.ToString();
            string pat_mic_ins = textBoxMicro.Text.ToString();
            stored_procedures procedure = new stored_procedures();
            procedure.insert_viaje(fecha_sal_ins,fehca_lleg_ins,cod_reco_ins,pat_mic_ins);
            MessageBox.Show("¡VIAJE AGREGADO CORRECTAMENTE!");
            limpiar();
            return;
        }

        private void dateTimePickerSalida_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerLlegada.MaxDate = dateTimePickerSalida.Value.AddDays(1);
            dateTimePickerLlegada.MinDate = dateTimePickerSalida.Value;
        }
    }
}
