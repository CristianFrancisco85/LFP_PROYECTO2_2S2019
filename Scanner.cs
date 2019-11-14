using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proyecto2_Scanner_LL1Parser
{
    class Scanner
    {

        String[] Reservadas = new String[24]{ "int","float","char","String","bool","class","void","args","false","true","Console","WriteLine",
        "graficarVector","switch","case","break","default","if","else","for","while","new","static","Main"};
        enum OTROS
        {
            PUNTO =46,
            COMA =44,
            PUNTO_COMA =59,
            DOS_PUNTOS=58,
            ABRE_PARENTESIS=40,
            CIERRA_PARENTESIS=41,
            ABRE_LLAVE=123,
            CIERRA_LLAVE=125,
            ABRE_CORCHETE=91,
            CIERRA_CORCHETE=93,
            COMILLAS_SIMPLES=39,
            COMILLAS_DOBLES=34,
            SIGNO_IGUAL=61,
            SIGNO_MAS=43,
            SIGNO_MENOS=45,
            SIGNO_DIVISION=47,
            SIGNO_MULTIPLICACION=42,
            SIGNO_MAYOR = 62,
            SIGNO_MENOR = 60,
            SIGNO_EXCLAMATIVO = 33
        }

        String[] auxVectorS = new String[5]; //Para Tokens
        String[] auxVectorE = new String[5]; //Para Errores Lexicos
        public Boolean Errores, Cadena;

        public Scanner()
        {

        }

        public void Analysis(RichTextBox Code)
        {
            int MyByte = 0;                       //Guarda valor ASCII
            int Correlativo = 0;                //Para Simbolos
            int CorrelativoE = 1;               //Para Errores
            int NCaracteres = Code.Text.Length; //Cantidad de Caracteres
            Cadena = false;                     //Indica si se esta leyendo una cadena
            Errores = false;                    //Indica si hay errores lexicos

            // INICIA ANALISIS LEXICO
            for (int i = 0; i < NCaracteres; i++)
            {
                MyByte = (int)Code.Text[i];
                // SE VERIFICA SI ES UN CARACTER "OTROS"
                if (Verificador((int[]) Enum.GetValues(typeof(OTROS)),MyByte))
                {
                    auxVectorS[0] = Correlativo.ToString();
                    Correlativo++;
                    auxVectorS[1] = Char.ToString((char)MyByte);
                    switch (MyByte)
                    {
                        case (int)OTROS.PUNTO:
                            auxVectorS[2] = "PUNTO"; break;
                        case (int)OTROS.COMA:
                            auxVectorS[2] = "COMA"; break;
                        case (int)OTROS.PUNTO_COMA:
                            auxVectorS[2] = "PUNTO_COMA"; break;
                        case (int)OTROS.DOS_PUNTOS:
                            auxVectorS[2] = "DOS_PUNTOS"; break;
                        case (int)OTROS.ABRE_PARENTESIS:
                            auxVectorS[2] = "ABRE_PARENTESIS"; break;
                        case (int)OTROS.CIERRA_PARENTESIS:
                            auxVectorS[2] = "CIERRA_PARENTESIS"; break;
                        case (int)OTROS.ABRE_CORCHETE:
                            auxVectorS[2] = "ABRE_CORCHETE"; break;
                        case (int)OTROS.CIERRA_CORCHETE:
                            auxVectorS[2] = "CIERRA_CORCHETE"; break;
                        case (int)OTROS.ABRE_LLAVE:
                            auxVectorS[2] = "ABRE_LLAVE"; break;
                        case (int)OTROS.CIERRA_LLAVE:
                            auxVectorS[2] = "CIERRA_LLAVE"; break;
                        case (int)OTROS.COMILLAS_SIMPLES:
                            auxVectorS[2] = "COMILLAS_SIMPLES"; break;
                        case (int)OTROS.COMILLAS_DOBLES:
                            auxVectorS[2] = "COMILLAS_DOBLES"; Cadena = !Cadena; break;
                        case (int)OTROS.SIGNO_IGUAL:
                            auxVectorS[2] = "SIGNO_IGUAL"; break;
                        case (int)OTROS.SIGNO_MAS:
                            auxVectorS[2] = "SIGNO_MAS"; break;
                        case (int)OTROS.SIGNO_MENOS:
                            auxVectorS[2] = "SIGNO_MENOS"; break;
                        case (int)OTROS.SIGNO_MULTIPLICACION:
                            auxVectorS[2] = "SIGNO_MULTIPLICACION"; break;
                        case (int)OTROS.SIGNO_DIVISION:
                            auxVectorS[2] = "SIGNO_DIVISION"; break;
                        case (int)OTROS.SIGNO_MAYOR:
                            auxVectorS[2] = "SIGNO_MAYOR"; break;
                        case (int)OTROS.SIGNO_MENOR:
                            auxVectorS[2] = "SIGNO_MENOR"; break;
                        case (int)OTROS.SIGNO_EXCLAMATIVO:
                            auxVectorS[2] = "SIGNO_EXCLAMATIVO"; break;
                    }
                    int fila = Code.GetLineFromCharIndex(i) + 1;
                    auxVectorS[3] = fila.ToString();
                    int columna = i - Code.GetFirstCharIndexFromLine(fila - 1);
                    auxVectorS[4] = columna.ToString();
                    Program.TablaT.Add(auxVectorS);
                }

                //SE VERIFICA SI ES UNA LETRA
                else if ((MyByte >= 65 && MyByte <= 90) || (MyByte >= 97 && MyByte <= 122) || (MyByte == 241 || MyByte == 209) || (Cadena))
                {
                    auxVectorS[0] = Correlativo.ToString();
                    Correlativo++;
                    auxVectorS[1] = Char.ToString((char)MyByte);
                    int fila = Code.GetLineFromCharIndex(i) + 1;
                    auxVectorS[3] = fila.ToString();
                    int columna = i - Code.GetFirstCharIndexFromLine(fila - 1);
                    auxVectorS[4] = columna.ToString(); ;
                    //SE LEEN LOS CARACTERES SIGUIENTES
                    for (int j = i + 1; j < NCaracteres; j++)
                    {
                        MyByte = (int)Code.Text[j];
                        if (MyByte == 34)
                        {
                            Cadena = false;
                        }
                        //SE VERIFICA SI ES UNA LETRA O UN NUMERO 
                        if ((MyByte >= 65 && MyByte <= 90) || (MyByte >= 97 && MyByte <= 122) || (MyByte >= 48 && MyByte <= 57) || (MyByte == 241 || MyByte == 209 || MyByte == 95) || (Cadena))
                        {
                            //SE CONCATENAN LO CARACTERES
                            auxVectorS[1] = auxVectorS[1] + Char.ToString((char)MyByte);
                        }
                        //SE TERMINO DE LEER UN ID O UNA RESERVADA
                        else
                        {
                            i = j - 1;
                            if (MyByte == 34) { Cadena = true; }
                            //SE ESTABLECE EL TIPO DE TOKEN
                            switch (Verificador(Reservadas, auxVectorS[1]))
                            {                           
                                case 0: auxVectorS[2] = "INT"; break;
                                case 1: auxVectorS[2] = "FLOAT"; break;
                                case 2: auxVectorS[2] = "CHAR"; break;
                                case 3: auxVectorS[2] = "STRING"; break;
                                case 4: auxVectorS[2] = "BOOL"; break;
                                case 5: auxVectorS[2] = "CLASS"; break;
                                case 6: auxVectorS[2] = "VOID"; break;
                                case 7: auxVectorS[2] = "ARGS"; break;
                                case 8: auxVectorS[2] = "FALSE"; break;
                                case 9: auxVectorS[2] = "TRUE"; break;
                                case 10: auxVectorS[2] = "CONSOLE"; break;
                                case 11: auxVectorS[2] = "WRITELINE"; break;
                                case 12: auxVectorS[2] = "GRAFICARVECTOR"; break;
                                case 13: auxVectorS[2] = "SWITCH"; break;
                                case 14: auxVectorS[2] = "CASE"; break;
                                case 15: auxVectorS[2] = "BREAK"; break;
                                case 16: auxVectorS[2] = "DEFAULT"; break;
                                case 17: auxVectorS[2] = "IF"; break;
                                case 18: auxVectorS[2] = "ELSE"; break;
                                case 19: auxVectorS[2] = "FOR"; break;
                                case 20: auxVectorS[2] = "WHILE"; break;
                                case 21: auxVectorS[2] = "NEW"; break;
                                case 22: auxVectorS[2] = "STATIC"; break;
                                case 23: auxVectorS[2] = "MAIN"; break;
                                default: auxVectorS[2] = "ID";
                                //SE VERIFCA SI EL ID ES CADENA
                                if (MyByte == 34) { auxVectorS[2] = "CADENA"; }
                                if (MyByte == 39) { auxVectorS[2] = "CARACTER"; }
                                break;
                            }                           
                            //SE DEJA DE LEER EL SIGUIENTE CARACTER
                            break;
                        }

                    }
                    Program.TablaT.Add(auxVectorS);
                }

                //SE VERFICA SI ES UN NUMERO
                else if (MyByte >= 48 && MyByte <= 57)
                {
                    auxVectorS[0] = Correlativo.ToString();
                    Correlativo++;
                    auxVectorS[1] = Char.ToString((char)MyByte);
                    auxVectorS[2] = "NUMERO";
                    int fila = Code.GetLineFromCharIndex(i) + 1;
                    auxVectorS[3] = fila.ToString();
                    int columna = i - Code.GetFirstCharIndexFromLine(fila - 1);
                    auxVectorS[4] = columna.ToString();
                    //SE LEEN LOS CARACTERES SIGUIENTES
                    for (int j = i + 1; j < NCaracteres; j++)
                    {
                        MyByte = (int)Code.Text[j];
                        //SE VERIFICA SI ES UN NUMERO 
                        if (MyByte >= 48 && MyByte <= 57)
                        {
                            //SE CONCATENAN LO CARACTERES
                            auxVectorS[1] = auxVectorS[1] + Char.ToString((char)MyByte);
                        }
                        else if (MyByte==46)
                        {
                            auxVectorS[2] = "NUMERO_DECIMAL";
                            //SE CONCATENAN LO CARACTERES
                            auxVectorS[1] = auxVectorS[1] + Char.ToString((char)MyByte);
                        }
                        //SE TERMINO DE LEER UN NUMERO
                        else
                        {
                            i = j - 1;
                            Program.TablaT.Add(auxVectorS);
                            //SE DEJA DE LEER EL SIGUIENTE CARACTER
                            break;
                        }

                    }

                }

                //SINO SE ESTABLECE COMO UN CARACTER DESCONOCIDO
                else if (MyByte <= 127 && MyByte > 35)
                {
                    Errores = true;
                    auxVectorE[0] = CorrelativoE.ToString();
                    CorrelativoE++;
                    auxVectorE[1] = Char.ToString((char)MyByte);
                    auxVectorE[2] = "Desconocido";
                    int fila = Code.GetLineFromCharIndex(i) + 1;
                    auxVectorE[3] = fila.ToString();
                    int columna = i - Code.GetFirstCharIndexFromLine(fila - 1);
                    auxVectorE[4] = columna.ToString();
                    Program.TablaEL.Add(auxVectorE);
                }

                //SE RESTABLECEN LOS VECTORES
                auxVectorE = new String[5];
                auxVectorS = new String[5];
            }
            // TERMINA EL ANALISIS LEXICO
        }

        public void GenerateHTMLToken()
        {
            String RutaH = Path.GetDirectoryName(Form1.Ruta) + "\\" + Path.GetFileNameWithoutExtension(Form1.Ruta)+"TablaTokens" + ".html";
            FileStream MyStream = new FileStream(RutaH, FileMode.Create, FileAccess.Write, FileShare.None);
            StreamWriter MyWriter = new StreamWriter(MyStream);
            MyWriter.WriteLine("<font size=\"2\" face=\"Segoe UI Emoji\" >");
            MyWriter.WriteLine("<h2 style=\"text - align: center; \"><strong>TABLA DE TOKENS</strong></h2>");

            MyWriter.WriteLine("<h4><strong>Hora y Fecha: " + DateTime.Now.ToString() + "</strong></h4>");
            MyWriter.WriteLine("<h4><strong>Ruta Archivo HTML: " + RutaH + "</strong></h4>");
            MyWriter.WriteLine("<h4><strong>Ruta Archivo C#: " + Form1.RutaC + "</strong></h4>");
            MyWriter.WriteLine("<h4><strong>Ruta Archivo Python: " + Form1.RutaP + "</strong></h4>");

            MyWriter.WriteLine("<table align=\"center\" border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"width: 500px;\">");
            MyWriter.WriteLine("<thead>");
            MyWriter.WriteLine("<tr>");
            MyWriter.WriteLine("<th scope=\"col\">#</th>");
            MyWriter.WriteLine("<th scope=\"col\">LEXEMA</th>");
            MyWriter.WriteLine("<th scope=\"col\">TIPO</th>");
            MyWriter.WriteLine("<th scope=\"col\">FILA</th>");
            MyWriter.WriteLine("<th scope=\"col\">COLUMNA</th>");
            MyWriter.WriteLine("</tr>");
            MyWriter.WriteLine("</thead>");
            MyWriter.WriteLine("<tbody>");
            for (int p = 0; p < Program.TablaT.Count; p++)
            {
                String[] auxVector3 = (String[])Program.TablaT[p];
                MyWriter.WriteLine("<tr>");
                MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[0] + "</th>");
                MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[1] + "</th>");
                MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[2] + "</th>");
                MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[3] + "</th>");
                MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[4] + "</th>");
                MyWriter.WriteLine("</tr>");
            }
            MyWriter.WriteLine("</tbody>");
            MyWriter.WriteLine("</font>");
            MyWriter.Close();
            MyStream.Close();
            MessageBox.Show("Reporte de Tokens Generado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("chrome.exe", RutaH);



        }

        public void GenerateHTMLError()
        {
            String RutaH = Path.GetDirectoryName(Form1.Ruta) + "\\" + Path.GetFileNameWithoutExtension(Form1.Ruta) + "ErroresLexicos" + ".html";
            if (Errores)
            {

                FileStream MyStream = new FileStream(RutaH, FileMode.Create, FileAccess.Write, FileShare.None);
                StreamWriter MyWriter = new StreamWriter(MyStream);
                MyWriter.WriteLine("<font size=\"2\" face=\"Segoe UI Emoji\" >");
                MyWriter.WriteLine("<h2 style=\"text - align: center; \"><strong>TABLA DE ERRORES LEXICOS</strong></h2>");

                MyWriter.WriteLine("<h4><strong>Hora y Fecha: " + DateTime.Now.ToString() + "</strong></h4>");
                MyWriter.WriteLine("<h4><strong>Ruta Archivos HTML: " + RutaH + "</strong></h4>");
                MyWriter.WriteLine("<h4><strong>Ruta Archivo C#: " + Form1.RutaC + "</strong></h4>");
                MyWriter.WriteLine("<h4><strong>Ruta Archivo Python: " + Form1.RutaP + "</strong></h4>");

                MyWriter.WriteLine("<table align=\"center\" border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"width: 500px;\">");
                MyWriter.WriteLine("<thead>");
                MyWriter.WriteLine("<tr>");
                MyWriter.WriteLine("<th scope=\"col\">#</th>");
                MyWriter.WriteLine("<th scope=\"col\">ERROR</th>");
                MyWriter.WriteLine("<th scope=\"col\">DESCRIPCION</th>");
                MyWriter.WriteLine("<th scope=\"col\">FILA</th>");
                MyWriter.WriteLine("<th scope=\"col\">COLUMNA</th>");
                MyWriter.WriteLine("</tr>");
                MyWriter.WriteLine("</thead>");
                MyWriter.WriteLine("<tbody>");
                for (int p = 0; p < Program.TablaEL.Count; p++)
                {
                    String[] auxVector3 = (String[])Program.TablaEL[p];
                    MyWriter.WriteLine("<tr>");
                    MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[0] + "</th>");
                    MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[1] + "</th>");
                    MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[2] + "</th>");
                    MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[3] + "</th>");
                    MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[4] + "</th>");
                    MyWriter.WriteLine("</tr>");
                }
                MyWriter.WriteLine("</tbody>");
                MyWriter.WriteLine("</font>");
                MyWriter.Close();
                MyStream.Close();
                MessageBox.Show("Reporte de Errores Lexicos Generado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start("chrome.exe", RutaH);
                
            }
            else
            {
                MessageBox.Show("No hay errores Lexicos que mostrar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void PaintText(RichTextBox Code)
        {
            if (!Errores)
            {
                int tabs = 0;
                Code.Clear();
                foreach (String[] Vector in Program.TablaT)
                {
                    if (Vector[2].Contains("Reservada"))
                    {
                        Code.AppendText(Tabulador(tabs) + Vector[1], Color.DodgerBlue);
                    }
                    else if (Vector[2].Contains("Numero"))
                    {
                        Code.AppendText(Vector[1], Color.Green);
                    }
                    else if (Vector[2].Contains("Cadena"))
                    {
                        Code.AppendText(Vector[1], Color.Goldenrod);
                    }
                    else if (Vector[2].Contains("Abre Llave"))
                    {
                        Code.AppendText(Vector[1] + "\n", Color.Red);
                        tabs++;
                    }
                    else if (Vector[2].Contains("Cierra Llave"))
                    {
                        Code.AppendText(Tabulador(tabs) + Vector[1] + "\n", Color.Red);
                        tabs--;
                    }
                    else if (Vector[2].Contains("Punto y Coma"))
                    {
                        Code.AppendText(Vector[1] + "\n", Color.DarkOrange);
                    }
                    else
                    {
                        Code.AppendText(Vector[1], Color.Black);
                    }
                }

            }
        }

        //Verfica que un valor exista en MyArray y regresara el indice, si no regresara -1
        private int Verificador(String[] MyArray, String MyString)
        {
            int contador = 0;
            foreach (String Cadena in MyArray)
            {
                if (MyString.Equals(Cadena, StringComparison.OrdinalIgnoreCase))
                {
                    return contador;
                }
                contador++;
            }
            return -1;
        }
        // Sobrecarga para usar con enteros
        private Boolean Verificador(int[] MyArray, int MyInt)
        {
            foreach (int Num in MyArray)
            {
                if (MyInt==Num)
                {
                    return true;
                }
            }
            return false;
        }

        //Me regresa una string con n tabulaciones
        private String Tabulador(int n)
        {
            String aux = "";
            for (int i = 0; i < n; i++)
            {
                aux = aux + "\t";
            }
            return aux;
        }
    }

    public static class RichTextBoxExtensions
    {
        //SE SOBRECARGAR EL METODO APPENDTEXT PARA PODER PINTAR EL TEXTO
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
