using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FrbaBus
{
    class stored_procedures
    {
        /*clase que tiene metodos que hacen de interfaz con los stored procedures que estan en la BD sql server*/
        
        //atributo
        connection connect = new connection();
        string query;

        public DataTable update_cant_intentos_fallidos(string username, int cant_intentos)
        {
            
            string query = "EXECUTE DATACENTER.update_cant_intentos_fallidos "+
                           "'"+username+"',"+
                           cant_intentos.ToString();
            
            DataTable retorno_update = connect.execute_query(query);
            
            return retorno_update;
        }

        public void insert_Rol(string nombre_rol)
        {
            query = "EXECUTE DATACENTER.insert_Rol '" + nombre_rol + "'";

            connect.execute_query_only(query);
        }

        public void insert_funcxrol(string nombre_rol, int func_id)
        {
            //hallamos Id_Rol
            query = "SELECT rol_id FROM DATACENTER.Rol WHERE rol_nombre = '" + nombre_rol + "'";
            DataTable table_rol = connect.execute_query(query);
            string rol_id = table_rol.Rows[0].ItemArray[0].ToString();

            query = "EXECUTE DATACENTER.insert_funcxrol " + rol_id + ", " + func_id.ToString();
            connect.execute_query_only(query);

        }

        public void insert_recorrido(string cod_ins,string orig_ins,string dest_ins,int serv_ins,decimal pr_paq_ins,decimal pr_enco_ins)
        {
            connection connect = new connection();
            SqlConnection conexion = connect.connector();

            string query = "EXECUTE DATACENTER.insert_recorrido @cod_ins, @orig_ins, @dest_ins, @serv_ins, @pr_pas_ins, @pr_enco_ins";
            
            //query = "EXECUTE DATACENTER.insert_recorrido "+"'"+cod_ins+"'"+", "+"'"+orig_ins+"'"+", "+"'"+dest_ins+"'"+", "+serv_ins+", "+pr_paq_ins+", "+pr_enco_ins;
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@cod_ins", cod_ins);
            comando.Parameters.AddWithValue("@orig_ins", orig_ins);
            comando.Parameters.AddWithValue("@dest_ins", dest_ins);
            comando.Parameters.AddWithValue("@serv_ins", serv_ins);
            comando.Parameters.AddWithValue("@pr_pas_ins", pr_paq_ins);
            comando.Parameters.AddWithValue("@pr_enco_ins", pr_enco_ins);
            conexion.Close();


        }

        public void insert_viaje(string fecha_sal, string fehca_lleg, string cod_reco_ins, string pat_mic_ins)
        {
            connection conexion = new connection();

            query = "EXECUTE DATACENTER.insert_viaje " + fecha_sal + ", " + fehca_lleg + ", " + cod_reco_ins + ", " + pat_mic_ins;
        }

        public string insert_compra(string comprador_dni, string tipo_tarj_id, string cant_pasajes, string cant_total_kg, decimal costo_total)
        {
            connection connect = new connection();
            SqlConnection conexion = connect.connector();
            string query = "EXECUTE DATACENTER.insert_compra @comprador_dni, @tipo_tarj_id, @cant_pasajes, @cant_total_kg, @costo_total";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@comprador_dni", comprador_dni);
            comando.Parameters.AddWithValue("@tipo_tarj_id", tipo_tarj_id);
            comando.Parameters.AddWithValue("@cant_pasajes", cant_pasajes);
            comando.Parameters.AddWithValue("@cant_total_kg", cant_total_kg);
            comando.Parameters.AddWithValue("@costo_total", costo_total);
            string cod_compra = comando.ExecuteScalar().ToString();
            conexion.Close();
            return cod_compra;
        }

        public void update_recorrido(string cod_act, string orig_act, string dest_act, int serv_act, decimal pr_paq_act, decimal pr_enco_act)
        {
            query = "EXECUTE DATACENTER.update_recorrido " + "'" + cod_act + "'" + ", " + "'" + orig_act + "'" + ", " + "'" + dest_act + "'" + ", " + serv_act + ", " + pr_paq_act + ", " + pr_enco_act;
            connect.execute_query_only(query);
        }

        public void update_estado_reco(string cod, char estado_act)
        {
            query = "EXECUTE DATACENTER.update_estado_reco " + "'" + cod + "'" + "," + "'" + estado_act + "'";
            connect.execute_query_only(query);
        }
    }
}
