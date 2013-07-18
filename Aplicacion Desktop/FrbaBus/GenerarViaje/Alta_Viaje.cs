using System;
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
        public Alta_Viaje()
        {
            InitializeComponent();
        }

        private void botonSelReco_Click(object sender, EventArgs e)
        {
            Seleccion_Reco sel_reco = new Seleccion_Reco();
            DialogResult cod = sel_reco.ShowDialog(); //abrimos el formulario 2 como cuadro de dialogo para poder retornar el codigo

            if (cod == DialogResult.OK)
            {
                //recuperando la variable publica (codigo de recorrido) del formulario sel_reco
                textBoxReco.Text = sel_reco.codigo; //asignamos al texbox el dato de la variable
            }
        }

        private void botonSelMicro_Click(object sender, EventArgs e)
        {
            Seleccion_Micro sel_micro = new Seleccion_Micro();
            DialogResult pat = sel_micro.ShowDialog(); //abrimos el formulario sel_micro como cuadro de dialogo para poder retornar el codigo

            if (pat == DialogResult.OK)
            {
                //recuperando la variable publica (codigo de recorrido) del formulario sel_reco
                textBoxReco.Text = sel_micro.patente; //asignamos al texbox el dato de la variable
            }
        }

        private void textBoxReco_TextChanged(object sender, EventArgs e)
        {
            botonSelMicro.Enabled = true; // Me habilita el boton para seleccionar el micro, luego de seleccionar el recorrido.
        }
    }
}
