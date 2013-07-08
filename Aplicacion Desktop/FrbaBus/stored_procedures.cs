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

        public void insert_recorrido(string cod_ins,string orig_ins,string dest_ins,int serv_ins,decimal pr_paq_ins,decimal pr_enco_ins) //FALTA COMPLETAR!!
        {
            query = "EXECUTE DATACENTER.insert_recorrido "+"'"+cod_ins+"'"+", "+"'"+orig_ins+"'"+", "+"'"+dest_ins+"'"+", "+serv_ins+", "+pr_paq_ins+", "+pr_enco_ins;
            connect.execute_query_only(query);
        }
        
    }
}
