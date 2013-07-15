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
    public partial class Abm_Reco_Seleccion : Form
    {
        public Abm_Reco_Seleccion()
        {
            InitializeComponent();
            this.limpiar();
        }

        private void limpiar()
        {
            textBoxCodReco.Clear();
            comboBoxOrigen.ResetText();
            comboBoxDestino.ResetText();
            comboBoxTipoServ.ResetText();
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

        private void comboBoxOrigen_Load(object sender, EventArgs e)
        {
            //consulta a ejecutar para mostrar todas las ciudades posibles a seleccionar en el comboBox
            string query = "SELECT ciu_nombre FROM DATACENTER.Ciudad";

            //instanciamos obj de la clase connection y le enviamos la query para que la ejecute
            connection conexion = new connection();
            DataTable tabla_origenes = conexion.execute_query(query);

            //el resultado de la query lo cargamos en un data table
            //DataSource es el origen de los datos en nuestro caso la tabla que alberga el resultado de la query
            comboBoxOrigen.DataSource = tabla_origenes;

            //Displaymember es la columna de la tabla que se va a mostrar en nuestro caso hay una sola
            comboBoxOrigen.DisplayMember = "ciu_nombre";

            //ValueMembermember es el valor que tiene el campo seleccionado en nuestro caso ponemos la PK
            comboBoxOrigen.ValueMember = "ciu_nombre";
        }

        private void comboBoxDestino_Load(object sender, EventArgs e)
        {
            string query = "SELECT ciu_nombre FROM DATACENTER.Ciudad";

            connection conexion = new connection();
            DataTable tabla_destinos = conexion.execute_query(query);

            comboBoxDestino.DataSource = tabla_destinos;

            comboBoxDestino.DisplayMember = "ciu_nombre";

            comboBoxDestino.ValueMember = "ciu_nombre";
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
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




    }
}
