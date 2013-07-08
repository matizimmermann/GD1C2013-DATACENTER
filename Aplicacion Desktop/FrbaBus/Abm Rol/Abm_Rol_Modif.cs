using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Rol
{
    public partial class Abm_Rol_Modif : Form
    {

        /*-----------ATRIBUTOS--------------------*/
        public string rol_a_modificar;
        public string id_rol_a_mod;

        /*----------------------------------------*/
        public Abm_Rol_Modif()
        {
            InitializeComponent();

            
        }

        private void list_funcionalidades_Load(object sender, EventArgs e)
        {
            if (this.rol_a_modificar != null)
            {
                this.rol_select_tbox.Text = this.rol_a_modificar;
                this.rol_select_tbox.ReadOnly = true;

                //cargamos lista segun corresponde

                string query = "SELECT func_id, func_nombre FROM DATACENTER.Funcionalidad";
                connection connect = new connection();
                DataTable tabla_todas_func = connect.execute_query(query);
                list_funcionalidades.DataSource = tabla_todas_func;
                list_funcionalidades.DisplayMember = "func_nombre";
                list_funcionalidades.ValueMember = "func_id";

                // falta: tildamos las funciones que ya tiene 

              
            }
            else
            {
                this.rol_select_tbox.Enabled = false;
            }

            
        }

        private void aplicar_boton_Click(object sender, EventArgs e)
        {

        }

        private void select_boton_Click(object sender, EventArgs e)
        {
           
            Abm_Rol_Busqueda buscar_rol = new Abm_Rol_Busqueda();
            buscar_rol.ShowDialog();
            this.Close();
            
            
            
        }

        private void rol_select_tbox_TextChanged(object sender, EventArgs e)
        {

        }

 
          
   

            

        

       
    }
}
