using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Recorrido
{
    public partial class Abm_Reco_Alta : Form
    {
        public Abm_Reco_Alta()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            textBoxCodReco.Clear();
            numUpDownPrPas.Value = 0;
            numUpDownPrEnco.Value = 0;
            comboBoxCiuOrigen.ResetText();
            comboBoxCiuDestino.ResetText();
            comboBoxTipoServ.ResetText();
        }

        private void comboBoxCiuOrigen_Load(object sender, EventArgs e)
        {
            //consulta a ejecutar para mostrar todas las ciudades posibles a seleccionar en el comboBox
            string query = "SELECT ciu_nombre FROM DATACENTER.Ciudad";

            //instanciamos obj de la clase connection y le enviamos la query para que la ejecute
            connection conexion = new connection();
            DataTable tabla_origenes = conexion.execute_query(query);

            //el resultado de la query lo cargamos en un data table
            //DataSource es el origen de los datos en nuestro caso la tabla que alberga el resultado de la query
            comboBoxCiuOrigen.DataSource = tabla_origenes;

            //Displaymember es la columna de la tabla que se va a mostrar en nuestro caso hay una sola
            comboBoxCiuOrigen.DisplayMember = "ciu_nombre";

            //ValueMembermember es el valor que tiene el campo seleccionado en nuestro caso ponemos la PK
            comboBoxCiuOrigen.ValueMember = "ciu_nombre";

        }

        private void comboBoxCiuDestino_Load(object sender, EventArgs e)
        {
            string query = "SELECT ciu_nombre FROM DATACENTER.Ciudad";

            connection conexion = new connection();
            DataTable tabla_destinos = conexion.execute_query(query);

            comboBoxCiuDestino.DataSource = tabla_destinos;

            comboBoxCiuDestino.DisplayMember = "ciu_nombre";

            comboBoxCiuDestino.ValueMember = "ciu_nombre";

        }

        private void comboBoxTipoServ_Load(object sender, EventArgs e)
        {
            string query = "SELECT serv_tipo, serv_id FROM DATACENTER.Servicio";

            connection conexion = new connection();
            DataTable tabla_servicios = conexion.execute_query(query);

            comboBoxTipoServ.DataSource = tabla_servicios;

            comboBoxTipoServ.DisplayMember = "serv_tipo";

            comboBoxTipoServ.ValueMember = "serv_id";

        }

        private void botonRefrescar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            int codigo_error = 0; // el 0 es que no tiene errores y el 1 es que SI tiene errores!
            int cant_caract = textBoxCodReco.Text.Length;

            if (cant_caract < 1 || cant_caract > 18)
            {
                MessageBox.Show("ERROR: El codigo de recorrido debe tener entre 1 y 18 caracteres");
                codigo_error = 1;
                //return;
            }
            else
            {
                funciones funcion = new funciones();
                string cod_reco = textBoxCodReco.Text.ToString();
                if (funcion.son_todos_numeros(cod_reco) == false)
                {
                    MessageBox.Show("ERROR: EL CODIGO DEBE SER NUMERICO");
                    limpiar();
                    codigo_error = 1;
                }
            }

            if ((textBoxCodReco.Text == "") || (comboBoxCiuDestino.Text == "") || (comboBoxCiuOrigen.Text == "") || (comboBoxTipoServ.Text == ""))
            {
                MessageBox.Show("ERROR: Debe ingresar todos los campos obligatorios");
                codigo_error = 1;
                //return;
            }

            if (comboBoxCiuOrigen.Text == comboBoxCiuDestino.Text)
            {
                MessageBox.Show("Error: La ciudad de origen y la ciudad de destino deben ser distintas");
                codigo_error = 1;
                //return;
            }

            /*
             * ESTA VALIDACION NO SIRVE PQ YA LO RESTRINGE EL NUMERICUPDOWN
            if ((numUpDownPrPas.Value.ToString != "") || (numUpDownPrEnco.Value != ""))
            {
                MessageBox.Show(" EL CHABON NO ME MUESTRA Q CARAJO ME INGRESAAAA!!!!!");
                codigo_error = 1;
                return;
            }
            */

            //SE INGRESARON LOS CAMPOS CORRECTAMENTE, AHORA CONTROLAMOS CONTRA LA BASE DE DATOS

            if (codigo_error == 1)
            {
                return;
            }

            connection conexion = new connection();

            DataTable tablaRecorridos = conexion.execute_query("SELECT 1 FROM DATACENTER.Recorrido WHERE reco_cod ="+"'"+textBoxCodReco.Text+"'");

            if (tablaRecorridos.Rows.Count == 1) // Se cumple cuando el codigo ingresado ya esta en la BD
            {
                MessageBox.Show("ERROR: EL CODIGO DE RECORRIDO QUE INGRESASTE YA EXISTE");
                limpiar();
                codigo_error = 1;
                //return;
            }
            else //EL codigo es correcto
            {
                tablaRecorridos.Clear();
                tablaRecorridos = conexion.execute_query("SELECT 1 FROM DATACENTER.Recorrido WHERE reco_origen ="+"'"+comboBoxCiuOrigen.Text+"'"+" AND "+"reco_destino ="+"'"+comboBoxCiuDestino.Text+"'"+" AND "+"reco_serv_id ="+comboBoxTipoServ.SelectedValue);
                if (tablaRecorridos.Rows.Count == 1) // Se cumple cuando el recorrido ingresado ya esta en la BD
                {
                    MessageBox.Show("ERROR: YA EXISTE ESTE RECORRIDO CON ESTE SERVICIO");
                    limpiar();
                    codigo_error = 1;
                    //return;
                }
            }

            if (codigo_error == 1)
            {
                return;
            }
            else // Paso todas las restricciones, se puede insertar.
            {
                string cod_ins = textBoxCodReco.Text.ToString();
                string orig_ins = comboBoxCiuOrigen.Text.ToString();
                string dest_ins = comboBoxCiuDestino.Text.ToString();
                int serv_ins = (int)comboBoxTipoServ.SelectedValue;
                decimal pr_paq_ins = numUpDownPrPas.Value;
                decimal pr_enco_ins = numUpDownPrEnco.Value;
                stored_procedures procedure = new stored_procedures();
                procedure.insert_recorrido(cod_ins,orig_ins,dest_ins,serv_ins,pr_paq_ins,pr_enco_ins); //FALTA AGREGAR TODO LO NECESARIO
                MessageBox.Show("¡RECORRIDO AGREGADO CORRECTAMENTE!");
                limpiar();
                return;
            }

           // if (textBoxCodReco.Text == "0")
        
        }






    }
}
