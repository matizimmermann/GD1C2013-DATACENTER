using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FrbaBus.Abm_Rol;
using FrbaBus.Abm_Recorrido;
using FrbaBus.GenerarViaje;

namespace FrbaBus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Alta_Viaje());
            //Application.Run(new Abm_Rol_Busqueda());
            
           
        }
    }
}
