using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2_Scanner_LL1Parser
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        public static ArrayList TablaT = new ArrayList(); //Tabla de Tokens
        public static ArrayList TablaEL = new ArrayList(); //Errores Lexicos
        public static ArrayList TablaES = new ArrayList(); //Errores Lexicos
        public static ArrayList TablaI = new ArrayList(); //Informacion para Grafica
        public static ArrayList TablaS = new ArrayList(); //Tabla de Simbolos

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
