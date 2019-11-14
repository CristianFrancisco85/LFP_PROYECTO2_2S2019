using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2_Scanner_LL1Parser
{
    class Parser
    {
        //PARA ANALISIS SINTACTICO
        int MainPointer;
        public Boolean Errores;
        String[] ErrorVector = new String[5]; //Vector a usar para un error sintactico;
        String[] SimboloVector  = new String[3]; //Vector a usar para un error sintactico;
        int CorrelativoE = 1;
        String PythonCode = "";
        String ConsoleOutPut="";
        int Tabulaciones = 0;
        public static String RutaImg, DirImg; //Guarda Imagen de Grafica de Vector

        public Parser()
        {

        }

        public void Parsing()
        {
            MainPointer = 0;
            Errores = false;
            Program.TablaT.Add(new String[] { null, null, "Final", "Ultima", "Ultima" });
            BloqueMainClass();
            //if (!Errores)
            //{
            //    MessageBox.Show("Ok", "Syntax Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            //String[] aux2i = (String[])Program.TablaI[0];
            //Console.WriteLine(" ");
            //Console.WriteLine(aux2i[0]);
            //for (int i=1;i<Program.TablaI.Count;i++)
            //{
            //    String[] auxi = (String[])Program.TablaI[i];
            //    Console.Write(auxi[0] + " ");
            //    Console.Write(auxi[1] + " ");
            //    Console.Write(auxi[2] + " ");
            //    Console.Write(auxi[3] + " ");
            //    Console.Write(auxi[4] + " ");
            //    Console.WriteLine(" ");
            //}

        }

        //DEVUELVE UN ERROR SINTACTICO
        private void ErrorProvider(String linea, String columna,String Token)
        {
            ErrorVector[0] = CorrelativoE.ToString();
            CorrelativoE++;
            ErrorVector[1] = "Se esperaba " + Token;
            ErrorVector[2] = linea;
            ErrorVector[3] = columna;
            Program.TablaES.Add(ErrorVector);
            ErrorVector = new String[5];
            MessageBox.Show("Error en linea " + linea + " y columna " + columna, "Syntax Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //DEFINE EL SIGUIENTE TOKEN A LEER
        private void NextToken(String Token1, int Pointer)
        {
            String[] Token2 = (String[])Program.TablaT[Pointer];

            if (Token1.Equals(Token2[2]))
            {
                MainPointer++;
            }
            else
            {
                Errores = true;
                ErrorProvider(Token2[3], Token2[4], Token1);
            }
        }

        //CONCATENA LAS INSTRUCCIONES EN PYTHON
        private void AppendPythonCode(String Code)
        {
            PythonCode = PythonCode +Tabulador(Tabulaciones)+ Code+ Environment.NewLine;
        }

        //REGRESA EL CODIGO PYTHON
        public String GetPythonCode()
        {
            return PythonCode;
        }

        //CONCATENA LAS SALIDAS A CONSOLA
        private void AppendConsoleOutPut(String OutPut)
        {
            ConsoleOutPut = ConsoleOutPut + ">>> " + OutPut + Environment.NewLine;
        }

        //REGRESA LA SALIDA DE LA CONSOLA
        public String GetConsoleOutPut()
        {
            return ConsoleOutPut;
        }

        //REGRESA UN STRING CON n TABULACIONES
        private String Tabulador(int n)
        {
            if (n==0)
            {
                return "";
            }
            String aux = "";
            for (int i = 0; i < n; i++)
            {
                aux = aux + "\t";
            }
            return aux;
        }

        //HACE UNA COMPARACON CON EL SIGUIENTE TOKEN
        private Boolean CompareToken(String Token1, int Pointer)
        {
            String[] Token2 = (String[])Program.TablaT[Pointer];
            if (!Token2[2].Equals("Final"))
            {
                if (Token1.Equals(Token2[2]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else { return false; }

        }

        //DEVUELVE EL LEXUMA DEL TOKEN
        private String ReturnLexeme(int Pointer)
        {
            String[] aux = (String[])Program.TablaT[Pointer];
            return aux[1];
        }

        //INSERTA UN SIMBOLO EN LA TABLA DE SIMBOLOS
        private void InsertarSimbolo(String ID, String Tipo, String Valor)
        {
            Boolean Control=true;

            for (int p = 0; p < Program.TablaS.Count; p++)
            {
                String[] auxVector = (String[])Program.TablaS[p];
                if (ID.Equals(auxVector[0]))
                {
                    SimboloVector[0] = ID;
                    SimboloVector[1] = Tipo;
                    SimboloVector[2] = Valor;
                    Program.TablaS[p] = SimboloVector;
                    Control = false;
                    SimboloVector = new String[3];
                }
            }
            if (Control) {
            SimboloVector[0] = ID;
            SimboloVector[1] = Tipo;
            SimboloVector[2] = Valor;
            Program.TablaS.Add(SimboloVector);
            SimboloVector = new String[3];
            }
        }

        //REGRESA EL VALOR DE UN SIMBOLO
        private String ValorSimbolo(String ID)
        {
            for (int p = 0; p < Program.TablaS.Count; p++)
            {
                String[] auxVector = (String[])Program.TablaS[p];
                if(ID.Equals(auxVector[0])){                 
                    return auxVector[2];
                }
            }
            return null;

        }

        //REGRESA EL TIPO DE SIMBOLO
        private String TipoSimbolo(String ID)
        {
            for (int p = 0; p < Program.TablaS.Count; p++)
            {
                String[] auxVector = (String[])Program.TablaS[p];
                if (ID.Equals(auxVector[0]))
                {
                    return auxVector[1];
                }
            }
            return null;

        }


        //INICIAN FUNCIONES PARA SENTENCIAS Y BLOQUES 

        private void BloqueMainClass()
        {

            NextToken("CLASS", MainPointer);
            NextToken("ID", MainPointer);
            NextToken("ABRE_LLAVE", MainPointer);
            NextToken("STATIC", MainPointer);
            NextToken("VOID", MainPointer);
            NextToken("MAIN", MainPointer);
            NextToken("ABRE_PARENTESIS", MainPointer);
            NextToken("STRING", MainPointer);
            NextToken("ABRE_CORCHETE", MainPointer);
            NextToken("CIERRA_CORCHETE", MainPointer);
            NextToken("ARGS", MainPointer);
            NextToken("CIERRA_PARENTESIS", MainPointer);
            NextToken("ABRE_LLAVE", MainPointer);
            SetNextBlock();
            NextToken("CIERRA_LLAVE", MainPointer);
            NextToken("CIERRA_LLAVE", MainPointer);

        }

        private void SentenciaDeclaracionAsignacion(String Tipo)
        {
            String IDTEMP;

           //DECLARACION DE VECTOR
            if (CompareToken("ABRE_CORCHETE", MainPointer))
            {
                NextToken("ABRE_CORCHETE", MainPointer);
                NextToken("CIERRA_CORCHETE", MainPointer);
                NextToken("ID", MainPointer);
                IDTEMP = ReturnLexeme(MainPointer-1);
                NextToken("SIGNO_IGUAL", MainPointer);
                if (CompareToken("ABRE_LLAVE", MainPointer))
                {
                    NextToken("ABRE_LLAVE", MainPointer);
                    Boolean Control = true;
                    String ValorTemp = "";
                    while (Control) {
                        NextToken("NUMERO", MainPointer);
                        ValorTemp = ValorTemp + ReturnLexeme(MainPointer - 1);
                        if (CompareToken("COMA", MainPointer))
                        {
                            NextToken("COMA", MainPointer);
                            ValorTemp = ValorTemp + ",";
                        }
                        else
                        {
                            Control = false;
                            InsertarSimbolo(IDTEMP, Tipo+"[]", ValorTemp);
                            AppendPythonCode(IDTEMP + " = " + "[" + ValorTemp+ "]");
                        }
                    }
                    NextToken("CIERRA_LLAVE", MainPointer);
                }
                else if (CompareToken("NEW", MainPointer))
                {
                    NextToken("NEW", MainPointer);
                    NextToken(Tipo, MainPointer);
                    NextToken("ABRE_CORCHETE", MainPointer);
                    NextToken("CIERRA_CORCHETE", MainPointer);
                    InsertarSimbolo(IDTEMP, Tipo+"[]", " ");
                    AppendPythonCode(IDTEMP + " = []");
                }
                else if (CompareToken("ID", MainPointer))
                {
                    NextToken("ID", MainPointer);
                    InsertarSimbolo(IDTEMP, Tipo + "[]",ValorSimbolo(ReturnLexeme(MainPointer-1)));
                    AppendPythonCode(IDTEMP + " = " + ReturnLexeme(MainPointer - 1));
                }
                NextToken("PUNTO_COMA", MainPointer);
                SetNextBlock();
            }


            //DECLARACION NORMAL
            else {

                NextToken("ID", MainPointer);
                IDTEMP = ReturnLexeme(MainPointer-1);
                if (CompareToken("SIGNO_IGUAL", MainPointer))
                {
                    NextToken("SIGNO_IGUAL", MainPointer);
                    switch (Tipo)
                    {
                        case "INT":
                            NextToken("NUMERO", MainPointer);
                            InsertarSimbolo(IDTEMP, Tipo, ReturnLexeme(MainPointer - 1));
                            AppendPythonCode(IDTEMP+ "= "+ ReturnLexeme(MainPointer - 1));
                            break;
                        case "FLOAT":
                            NextToken("NUMERO_DECIMAL", MainPointer);
                            InsertarSimbolo(IDTEMP, Tipo, ReturnLexeme(MainPointer - 1));
                            AppendPythonCode(IDTEMP + " = " + ReturnLexeme(MainPointer - 1));
                            break;
                        case "CHAR":
                            NextToken("COMILLAS_SIMPLES", MainPointer);
                            NextToken("CARACTER", MainPointer);
                            InsertarSimbolo(IDTEMP, Tipo, ReturnLexeme(MainPointer - 1));
                            AppendPythonCode(IDTEMP + " = " +"\'"+ReturnLexeme(MainPointer - 1)+"\'");
                            NextToken("COMILLAS_SIMPLES", MainPointer);
                            break;
                        case "STRING":
                            NextToken("COMILLAS_DOBLES", MainPointer);
                            NextToken("CADENA", MainPointer);
                            InsertarSimbolo(IDTEMP, Tipo, ReturnLexeme(MainPointer - 1));
                            AppendPythonCode(IDTEMP + " = " +"\""+ ReturnLexeme(MainPointer - 1)+"\"");
                            NextToken("COMILLAS_DOBLES", MainPointer);
                            break;
                        case "BOOL":
                            if (CompareToken("FALSE", MainPointer))
                            {
                                NextToken("FALSE", MainPointer);
                                InsertarSimbolo(IDTEMP, Tipo, ReturnLexeme(MainPointer - 1));
                                AppendPythonCode(IDTEMP + " = " + "False");
                                break;
                            }
                            else if (CompareToken("TRUE", MainPointer))
                            {
                                NextToken("TRUE", MainPointer);
                                InsertarSimbolo(IDTEMP, Tipo, ReturnLexeme(MainPointer - 1));
                                AppendPythonCode(IDTEMP + " = " + "True");
                                break;
                            }
                            else
                            {
                                NextToken("BOOLEANO", MainPointer); break;
                            }
                    }

                    if (CompareToken("COMA", MainPointer))
                    {                     
                        NextToken("COMA", MainPointer);
                        SentenciaDeclaracionAsignacion(Tipo);
                    }

                    else if (CompareToken("PUNTO_COMA", MainPointer))
                    {
                        NextToken("PUNTO_COMA", MainPointer);
                        SetNextBlock();
                    }
                }

                else if (CompareToken("COMA", MainPointer))
                {
                    InsertarSimbolo(IDTEMP, Tipo, " ");
                    NextToken("COMA", MainPointer);
                    SentenciaDeclaracionAsignacion(Tipo);
                }
                else if (CompareToken("PUNTO_COMA", MainPointer))
                {
                    InsertarSimbolo(IDTEMP, Tipo, " ");
                    NextToken("PUNTO_COMA", MainPointer);
                    SetNextBlock();
                }
            }
        }

        private void SentenciaAsignacion()
        {
            //VARIABLES PARA VALORES SECUNDARIOS
            String Tipo2,TempValor2,TempID1,TempID2,Tipo3;
            int TempValor3;
            float TempValor4;
            Boolean TempValor5;

            NextToken("ID", MainPointer);
            String IDTEMP = ReturnLexeme(MainPointer - 1);
            String Tipo = TipoSimbolo(IDTEMP);
            NextToken("SIGNO_IGUAL", MainPointer);
            if (CompareToken("ID",MainPointer))
            {
                NextToken("ID", MainPointer);
                TempID1 = ReturnLexeme(MainPointer - 1);
                String TempValor = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                Tipo3 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                switch (Tipo)
                {
                    case "INT":
                        if (Tipo3.Equals("INT")|| Tipo3.Equals("FLOAT")) { 
                            if (CompareToken("SIGNO_MAS", MainPointer))
                        {
                            NextToken("SIGNO_MAS", MainPointer);
                            if (CompareToken("ID", MainPointer))
                            {
                                NextToken("ID", MainPointer);
                                Tipo2 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                                if (Tipo2.Equals("INT") || Tipo2.Equals("FLOAT"))
                                {
                                    TempValor2 = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                                    TempValor3 = Int32.Parse(TempValor) + Int32.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor3.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " + " + ReturnLexeme(MainPointer - 1));
                                }
                                else
                                {
                                    NextToken("INT o FLOAT", MainPointer);
                                }
                            }
                            else if (CompareToken("NUMERO", MainPointer))
                            {
                                NextToken("NUMERO", MainPointer);
                                TempValor2 = ReturnLexeme(MainPointer - 1);
                                TempValor3 = Int32.Parse(TempValor) + Int32.Parse(TempValor2);
                                InsertarSimbolo(IDTEMP, Tipo, TempValor3.ToString());
                                AppendPythonCode(IDTEMP + " = " + TempID1 + " + " + ReturnLexeme(MainPointer - 1));
                            }
                            else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                            {
                                NextToken("NUMERO_DECIMAL", MainPointer);
                                TempValor2 = ReturnLexeme(MainPointer - 1);
                                TempValor3 = Int32.Parse(TempValor) + Int32.Parse(TempValor2);
                                InsertarSimbolo(IDTEMP, Tipo, TempValor3.ToString());
                                AppendPythonCode(IDTEMP + " = " + TempID1 + " + " + ReturnLexeme(MainPointer - 1));
                            }
                            else
                            {
                                NextToken("INT o FLOAT", MainPointer);
                            }
                        }
                            else if (CompareToken("SIGNO_MENOS", MainPointer))
                        {
                            NextToken("SIGNO_MENOS", MainPointer);
                            if (CompareToken("ID", MainPointer))
                            {
                                NextToken("ID", MainPointer);
                                Tipo2 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                                if (Tipo2.Equals("INT") || Tipo2.Equals("FLOAT"))
                                {
                                    TempValor2 = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                                    TempValor3 = Int32.Parse(TempValor) - Int32.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor3.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " - " + ReturnLexeme(MainPointer - 1));
                                }
                                else
                                {
                                    NextToken("INT o FLOAT", MainPointer);
                                }
                            }
                            else if (CompareToken("NUMERO", MainPointer))
                            {
                                NextToken("NUMERO", MainPointer);
                                TempValor2 = ReturnLexeme(MainPointer - 1);
                                TempValor3 = Int32.Parse(TempValor) - Int32.Parse(TempValor2);
                                InsertarSimbolo(IDTEMP, Tipo, TempValor3.ToString());
                                AppendPythonCode(IDTEMP + " = " + TempID1 + " - " + ReturnLexeme(MainPointer - 1));
                            }
                            else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                            {
                                NextToken("NUMERO_DECIMAL", MainPointer);
                                TempValor2 = ReturnLexeme(MainPointer - 1);
                                TempValor3 = Int32.Parse(TempValor) - Int32.Parse(TempValor2);
                                InsertarSimbolo(IDTEMP, Tipo, TempValor3.ToString());
                                AppendPythonCode(IDTEMP + " = " + TempID1 + " - " + ReturnLexeme(MainPointer - 1));
                            }
                            else
                            {
                                NextToken("INT o FLOAT", MainPointer);
                            }
                        }
                            else if (CompareToken("SIGNO_DIVISION", MainPointer))
                        {
                            NextToken("SIGNO_DIVISION", MainPointer);
                            if (CompareToken("ID", MainPointer))
                            {
                                NextToken("ID", MainPointer);
                                Tipo2 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                                if (Tipo2.Equals("INT") || Tipo2.Equals("FLOAT"))
                                {
                                    TempValor2 = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                                    TempValor3 = Int32.Parse(TempValor) / Int32.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor3.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " / " + ReturnLexeme(MainPointer - 1));
                                }
                                else
                                {
                                    NextToken("INT o FLOAT", MainPointer);
                                }
                            }
                            else if (CompareToken("NUMERO", MainPointer))
                            {
                                NextToken("NUMERO", MainPointer);
                                TempValor2 = ReturnLexeme(MainPointer - 1);
                                TempValor3 = Int32.Parse(TempValor) / Int32.Parse(TempValor2);
                                InsertarSimbolo(IDTEMP, Tipo, TempValor3.ToString());
                                AppendPythonCode(IDTEMP + " = " + TempID1 + " / " + ReturnLexeme(MainPointer - 1));
                            }
                            else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                            {
                                NextToken("NUMERO_DECIMAL", MainPointer);
                                TempValor2 = ReturnLexeme(MainPointer - 1);
                                TempValor3 = Int32.Parse(TempValor) / Int32.Parse(TempValor2);
                                InsertarSimbolo(IDTEMP, Tipo, TempValor3.ToString());
                                AppendPythonCode(IDTEMP + " = " + TempID1 + " / " + ReturnLexeme(MainPointer - 1));
                            }
                            else
                            {
                                NextToken("INT o FLOAT", MainPointer);
                            }
                        }
                            else if (CompareToken("SIGNO_MULTIPLICACION", MainPointer))
                        {
                            NextToken("SIGNO_MULTIPLICACION", MainPointer);
                            if (CompareToken("ID", MainPointer))
                            {
                                NextToken("ID", MainPointer);
                                Tipo2 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                                if (Tipo2.Equals("INT") || Tipo2.Equals("FLOAT"))
                                {
                                    TempValor2 = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                                    TempValor3 = Int32.Parse(TempValor) * Int32.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor3.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " * " + ReturnLexeme(MainPointer - 1));
                                }
                                else
                                {
                                    NextToken("INT o FLOAT", MainPointer);
                                }
                            }
                            else if (CompareToken("NUMERO", MainPointer))
                            {
                                NextToken("NUMERO", MainPointer);
                                TempValor2 = ReturnLexeme(MainPointer - 1);
                                TempValor3 = Int32.Parse(TempValor) * Int32.Parse(TempValor2);
                                InsertarSimbolo(IDTEMP, Tipo, TempValor3.ToString());
                                AppendPythonCode(IDTEMP + " = " + TempID1 + " * " + ReturnLexeme(MainPointer - 1));
                            }
                            else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                            {
                                NextToken("NUMERO_DECIMAL", MainPointer);
                                TempValor2 = ReturnLexeme(MainPointer - 1);
                                TempValor3 = Int32.Parse(TempValor) * Int32.Parse(TempValor2);
                                InsertarSimbolo(IDTEMP, Tipo, TempValor3.ToString());
                                AppendPythonCode(IDTEMP + " = " + TempID1 + " * " + ReturnLexeme(MainPointer - 1));
                            }
                            else
                            {
                                NextToken("INT o FLOAT", MainPointer);
                            }
                        }
                            else
                            {
                                NextToken("SIGNO ARITMETICO", MainPointer);
                            }
                        }
                        else
                        {
                            NextToken("INT o FLOAT", MainPointer-1);
                        }
                    break;
                    case "FLOAT":
                        if (Tipo3.Equals("INT") || Tipo3.Equals("FLOAT"))
                        {
                            if (CompareToken("SIGNO_MAS", MainPointer))
                            {
                                NextToken("SIGNO_MAS", MainPointer);
                                if (CompareToken("ID", MainPointer))
                                {
                                    NextToken("ID", MainPointer);
                                    Tipo2 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                                    if (Tipo2.Equals("INT") || Tipo2.Equals("FLOAT"))
                                    {
                                        TempValor2 = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                                        TempValor4 = float.Parse(TempValor) + float.Parse(TempValor2);
                                        InsertarSimbolo(IDTEMP, Tipo, TempValor4.ToString());
                                        AppendPythonCode(IDTEMP + " = " + TempID1 + " + " + ReturnLexeme(MainPointer - 1));
                                    }
                                    else
                                    {
                                        NextToken("INT o FLOAT", MainPointer);
                                    }
                                }
                                else if (CompareToken("NUMERO", MainPointer))
                                {
                                    NextToken("NUMERO", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor4 = float.Parse(TempValor) + float.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor4.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " + " + ReturnLexeme(MainPointer - 1));
                                }
                                else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                                {
                                    NextToken("NUMERO_DECIMAL", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor4 = float.Parse(TempValor) + float.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor4.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " + " + ReturnLexeme(MainPointer - 1));
                                }
                                else
                                {
                                    NextToken("INT o FLOAT", MainPointer);
                                }
                            }
                            else if (CompareToken("SIGNO_MENOS", MainPointer))
                            {
                                NextToken("SIGNO_MENOS", MainPointer);
                                if (CompareToken("ID", MainPointer))
                                {
                                    NextToken("ID", MainPointer);
                                    Tipo2 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                                    if (Tipo2.Equals("INT") || Tipo2.Equals("FLOAT"))
                                    {
                                        TempValor2 = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                                        TempValor4 = float.Parse(TempValor) - float.Parse(TempValor2);
                                        InsertarSimbolo(IDTEMP, Tipo, TempValor4.ToString());
                                        AppendPythonCode(IDTEMP + " = " + TempID1 + " - " + ReturnLexeme(MainPointer - 1));
                                    }
                                    else
                                    {
                                        NextToken("INT o FLOAT", MainPointer);
                                    }
                                }
                                else if (CompareToken("NUMERO", MainPointer))
                                {
                                    NextToken("NUMERO", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor4 = float.Parse(TempValor) - float.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor4.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " - " + ReturnLexeme(MainPointer - 1));
                                }
                                else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                                {
                                    NextToken("NUMERO_DECIMAL", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor4 = float.Parse(TempValor) - float.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor4.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " - " + ReturnLexeme(MainPointer - 1));
                                }
                                else
                                {
                                    NextToken("INT o FLOAT", MainPointer);
                                }
                            }
                            else if (CompareToken("SIGNO_DIVISION", MainPointer))
                            {
                                NextToken("SIGNO_DIVISION", MainPointer);
                                if (CompareToken("ID", MainPointer))
                                {
                                    NextToken("ID", MainPointer);
                                    Tipo2 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                                    if (Tipo2.Equals("INT") || Tipo2.Equals("FLOAT"))
                                    {
                                        TempValor2 = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                                        TempValor4 = float.Parse(TempValor) / float.Parse(TempValor2);
                                        InsertarSimbolo(IDTEMP, Tipo, TempValor4.ToString());
                                        AppendPythonCode(IDTEMP + " = " + TempID1 + " / " + ReturnLexeme(MainPointer - 1));
                                    }
                                    else
                                    {
                                        NextToken("INT o FLOAT", MainPointer);
                                    }
                                }
                                else if (CompareToken("NUMERO", MainPointer))
                                {
                                    NextToken("NUMERO", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor4 = float.Parse(TempValor) / float.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor4.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " / " + ReturnLexeme(MainPointer - 1));
                                }
                                else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                                {
                                    NextToken("NUMERO_DECIMAL", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor4 = float.Parse(TempValor) / float.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor4.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " / " + ReturnLexeme(MainPointer - 1));
                                }
                                else
                                {
                                    NextToken("INT o FLOAT", MainPointer);
                                }
                            }
                            else if (CompareToken("SIGNO_MULTIPLICACION", MainPointer))
                            {
                                NextToken("SIGNO_MULTIPLICACION", MainPointer);
                                if (CompareToken("ID", MainPointer))
                                {
                                    NextToken("ID", MainPointer);
                                    Tipo2 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                                    if (Tipo2.Equals("INT") || Tipo2.Equals("FLOAT"))
                                    {
                                        TempValor2 = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                                        TempValor4 = float.Parse(TempValor) * float.Parse(TempValor2);
                                        InsertarSimbolo(IDTEMP, Tipo, TempValor4.ToString());
                                        AppendPythonCode(IDTEMP + " = " + TempID1 + " * " + ReturnLexeme(MainPointer - 1));
                                    }
                                    else
                                    {
                                        NextToken("INT o FLOAT", MainPointer);
                                    }
                                }
                                else if (CompareToken("NUMERO", MainPointer))
                                {
                                    NextToken("NUMERO", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor4 = float.Parse(TempValor) * float.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor4.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " * " + ReturnLexeme(MainPointer - 1));
                                }
                                else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                                {
                                    NextToken("NUMERO_DECIMAL", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor4 = float.Parse(TempValor) * float.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor4.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " * " + ReturnLexeme(MainPointer - 1));
                                }
                                else
                                {
                                    NextToken("INT o FLOAT", MainPointer);
                                }
                            }
                            else
                            {
                                NextToken("SIGNO ARITMETICO", MainPointer);
                            }
                        }
                        else
                        {
                            NextToken("INT o FLOAT", MainPointer - 1);
                        }
                    break;
                    case "BOOL":
                        if (Tipo3.Equals("INT") || Tipo3.Equals("FLOAT"))
                        {
                            if (CompareToken("SIGNO_IGUAL", MainPointer))
                            {
                                NextToken("SIGNO_IGUAL", MainPointer);
                                NextToken("SIGNO_IGUAL", MainPointer);
                                if (CompareToken("ID", MainPointer))
                                {
                                    NextToken("ID", MainPointer);
                                    Tipo2 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                                    if (Tipo2.Equals("INT") || Tipo2.Equals("FLOAT"))
                                    {
                                        TempValor2 = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                                        TempValor5 = TempValor.Equals(TempValor2);
                                        InsertarSimbolo(IDTEMP, Tipo, TempValor5.ToString());
                                        AppendPythonCode(IDTEMP + " = " + TempID1 + " == " + ReturnLexeme(MainPointer - 1));
                                    }
                                    else
                                    {
                                        NextToken("INT o FLOAT", MainPointer);
                                    }
                                }
                                else if (CompareToken("NUMERO", MainPointer))
                                {
                                    NextToken("NUMERO", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor5 = TempValor.Equals(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor5.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " == " + ReturnLexeme(MainPointer - 1));
                                }
                                else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                                {
                                    NextToken("NUMERO_DECIMAL", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor5 = TempValor.Equals(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor5.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " == " + ReturnLexeme(MainPointer - 1));
                                }
                                else
                                {
                                    NextToken("INT o FLOAT", MainPointer);
                                }
                            }
                            else if (CompareToken("SIGNO_MAYOR", MainPointer))
                            {
                                NextToken("SIGNO MAYOR", MainPointer);
                                if (CompareToken("ID", MainPointer))
                                {
                                    NextToken("ID", MainPointer);
                                    Tipo2 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                                    if (Tipo2.Equals("INT") || Tipo2.Equals("FLOAT"))
                                    {
                                        TempValor2 = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                                        TempValor5 = float.Parse(TempValor) > float.Parse(TempValor2);
                                        InsertarSimbolo(IDTEMP, Tipo, TempValor5.ToString());
                                        AppendPythonCode(IDTEMP + " = " + TempID1 + " > " + ReturnLexeme(MainPointer - 1));
                                    }
                                    else
                                    {
                                        NextToken("INT o FLOAT", MainPointer);
                                    }
                                }
                                else if (CompareToken("NUMERO", MainPointer))
                                {
                                    NextToken("NUMERO", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor5 = float.Parse(TempValor) > float.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor5.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " > " + ReturnLexeme(MainPointer - 1));
                                }
                                else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                                {
                                    NextToken("NUMERO_DECIMAL", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor5 = float.Parse(TempValor) > float.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor5.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " > " + ReturnLexeme(MainPointer - 1));
                                }
                                else
                                {
                                    NextToken("INT o FLOAT", MainPointer);
                                }

                            }
                            else if (CompareToken("SIGNO_MENOR", MainPointer))
                            {
                                NextToken("SIGNO MENOR", MainPointer);
                                if (CompareToken("ID", MainPointer))
                                {
                                    NextToken("ID", MainPointer);
                                    Tipo2 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                                    if (Tipo2.Equals("INT") || Tipo2.Equals("FLOAT"))
                                    {
                                        TempValor2 = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                                        TempValor5 = float.Parse(TempValor) < float.Parse(TempValor2);
                                        InsertarSimbolo(IDTEMP, Tipo, TempValor5.ToString());
                                        AppendPythonCode(IDTEMP + " = " + TempID1 + " < " + ReturnLexeme(MainPointer - 1));
                                    }
                                    else
                                    {
                                        NextToken("INT o FLOAT", MainPointer);
                                    }
                                }
                                else if (CompareToken("NUMERO", MainPointer))
                                {
                                    NextToken("NUMERO", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor5 = float.Parse(TempValor) < float.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor5.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " < " + ReturnLexeme(MainPointer - 1));
                                }
                                else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                                {
                                    NextToken("NUMERO_DECIMAL", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor5 = float.Parse(TempValor) < float.Parse(TempValor2);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor5.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " < " + ReturnLexeme(MainPointer - 1));
                                }
                                else
                                {
                                    NextToken("INT o FLOAT", MainPointer);
                                }
                            }
                            else if (CompareToken("SIGNO_EXCLAMATIVO", MainPointer))
                            {
                                NextToken("SIGNO_EXCLAMATIVO", MainPointer);
                                NextToken("SIGNO_IGUAL", MainPointer);
                                if (CompareToken("ID", MainPointer))
                                {
                                    NextToken("ID", MainPointer);
                                    Tipo2 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                                    if (Tipo2.Equals("INT") || Tipo2.Equals("FLOAT"))
                                    {
                                        TempValor2 = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                                        TempValor5 = TempValor.Equals(TempValor2);
                                        TempValor5 = !TempValor5;
                                        InsertarSimbolo(IDTEMP, Tipo, TempValor5.ToString());
                                        AppendPythonCode(IDTEMP + " = " + TempID1 + " == " + ReturnLexeme(MainPointer - 1));
                                    }
                                    else
                                    {
                                        NextToken("INT o FLOAT", MainPointer);
                                    }
                                }
                                else if (CompareToken("NUMERO", MainPointer))
                                {
                                    NextToken("NUMERO", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor5 = TempValor.Equals(TempValor2);
                                    TempValor5 = !TempValor5;
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor5.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " == " + ReturnLexeme(MainPointer - 1));
                                }
                                else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                                {
                                    NextToken("NUMERO_DECIMAL", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    TempValor5 = TempValor.Equals(TempValor2);
                                    TempValor5 = !TempValor5;
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor5.ToString());
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " == " + ReturnLexeme(MainPointer - 1));
                                }
                                else
                                {
                                    NextToken("INT o FLOAT", MainPointer);
                                }
                            }
                            else
                            {
                                NextToken("OPERADOR BOOLEANO", MainPointer - 1);
                            }
                        }
                        else
                        {
                            NextToken("INT o FLOAT", MainPointer - 1);
                        }
                     break;
                    case "CHAR":

                    break;
                    case "STRING":
                        if (Tipo3.Equals("INT") || Tipo3.Equals("FLOAT") || Tipo3.Equals("BOOL") || Tipo3.Equals("CHAR") || Tipo3.Equals("STRING"))
                        {
                            if (CompareToken("SIGNO_MAS", MainPointer))
                            {
                                NextToken("SIGNO_MAS", MainPointer);
                                if (CompareToken("ID", MainPointer))
                                {
                                    NextToken("ID", MainPointer);
                                    Tipo2 = TipoSimbolo(ReturnLexeme(MainPointer - 1));
                                    TempValor2 = ValorSimbolo(ReturnLexeme(MainPointer - 1));
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor+TempValor2);
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " + " + ReturnLexeme(MainPointer - 1));
                                }
                                else if (CompareToken("NUMERO", MainPointer))
                                {
                                    NextToken("NUMERO", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor + TempValor2);
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " + " + ReturnLexeme(MainPointer - 1));
                                }
                                else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                                {
                                    NextToken("NUMERO_DECIMAL", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor + TempValor2);
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " + " + ReturnLexeme(MainPointer - 1));
                                }
                                else if (CompareToken("COMILLAS_SIMPLES", MainPointer))
                                {
                                    NextToken("COMILLAS_SIMPLES", MainPointer);
                                    NextToken("CARACTER", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor + TempValor2);
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " + " +"\'"+ ReturnLexeme(MainPointer - 1)+"\'");
                                    NextToken("COMILLAS_SIMPLES", MainPointer);
                                }
                                else if (CompareToken("COMILLAS_DOBLES", MainPointer))
                                {
                                    NextToken("COMILLAS_DOBLES", MainPointer);
                                    NextToken("CADENA", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor + TempValor2);
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " + " +"\""+ ReturnLexeme(MainPointer - 1)+"\"");
                                    NextToken("COMILLAS_DOBLES", MainPointer);
                                }
                                else if (CompareToken("FALSE", MainPointer))
                                {
                                    NextToken("FALSE", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor + TempValor2);
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " + " + "False");
                                }
                                else if (CompareToken("TRUE", MainPointer))
                                {
                                    NextToken("TRUE", MainPointer);
                                    TempValor2 = ReturnLexeme(MainPointer - 1);
                                    InsertarSimbolo(IDTEMP, Tipo, TempValor + TempValor2);
                                    AppendPythonCode(IDTEMP + " = " + TempID1 + " + " + "True");
                                }
                            }
                            else
                            {
                                NextToken("SIGO ARITMETICO MAS", MainPointer - 1);
                            }
                        }
                        else
                        {
                            NextToken("INT,FLOAT,BOOL,CHAR O STRING", MainPointer - 1);
                        }
                        break;
                }
            }
            else {  
                switch (Tipo)
                {
                    case "INT":
                        NextToken("NUMERO", MainPointer);
                        InsertarSimbolo(IDTEMP, Tipo, ReturnLexeme(MainPointer - 1));
                        AppendPythonCode(IDTEMP + " = " + ReturnLexeme(MainPointer - 1));
                        break;
                    case "INT[]":
                        NextToken("ID", MainPointer);
                        InsertarSimbolo(IDTEMP, Tipo, ValorSimbolo(ReturnLexeme(MainPointer - 1)));
                        AppendPythonCode(IDTEMP + " = " + ReturnLexeme(MainPointer - 1));
                        break;
                    case "FLOAT":
                        NextToken("NUMERO_DECIMAL", MainPointer);
                        InsertarSimbolo(IDTEMP, Tipo, ReturnLexeme(MainPointer - 1));
                        AppendPythonCode(IDTEMP + " = " + ReturnLexeme(MainPointer - 1));
                        break;
                    case "CHAR":
                        NextToken("COMILLAS_SIMPLES", MainPointer);
                        NextToken("CARACTER", MainPointer);
                        InsertarSimbolo(IDTEMP, Tipo, ReturnLexeme(MainPointer - 1));
                        AppendPythonCode(IDTEMP + " = " + "\'" + ReturnLexeme(MainPointer - 1) + "\'");
                        NextToken("COMILLAS_SIMPLES", MainPointer);
                        break;
                    case "STRING":
                        NextToken("COMILLAS_DOBLES", MainPointer);
                        NextToken("CADENA", MainPointer);
                        InsertarSimbolo(IDTEMP, Tipo, ReturnLexeme(MainPointer - 1));
                        AppendPythonCode(IDTEMP + " = " + "\"" + ReturnLexeme(MainPointer - 1) + "\"");
                        NextToken("COMILLAS_DOBLES", MainPointer);
                        break;
                    case "BOOL":
                        if (CompareToken("FALSE", MainPointer))
                        {
                            NextToken("FALSE", MainPointer);
                            InsertarSimbolo(IDTEMP, Tipo, ReturnLexeme(MainPointer - 1));
                            AppendPythonCode(IDTEMP + " = " + ReturnLexeme(MainPointer - 1));
                            break;
                        }
                        else if (CompareToken("TRUE", MainPointer))
                        {
                            NextToken("TRUE", MainPointer);
                            InsertarSimbolo(IDTEMP, Tipo, ReturnLexeme(MainPointer - 1));
                            AppendPythonCode(IDTEMP + " = " + ReturnLexeme(MainPointer - 1));
                            break;
                        }
                        else
                        {
                            NextToken("BOOLEANO", MainPointer); break;
                        }
                }
            }
            NextToken("PUNTO_COMA", MainPointer);
            SetNextBlock();


        }

        private void SentenciaWriteLine()
        {
            Boolean Control=true;
            String TempString = "";
            String TempParam = "";
            NextToken("CONSOLE", MainPointer);
            NextToken("PUNTO", MainPointer);
            NextToken("WRITELINE", MainPointer);
            NextToken("ABRE_PARENTESIS", MainPointer);
            while (Control)
            {
                if (CompareToken("COMILLAS_DOBLES",MainPointer))
                {
                    NextToken("COMILLAS_DOBLES", MainPointer);
                    NextToken("CADENA", MainPointer);
                    TempString = TempString + ReturnLexeme(MainPointer - 1);
                    TempParam = TempParam +"\"" +ReturnLexeme(MainPointer - 1)+"\"";
                    NextToken("COMILLAS_DOBLES", MainPointer);
                }
                else if (CompareToken("ID", MainPointer))
                {
                    NextToken("ID", MainPointer);
                    TempString = TempString + ValorSimbolo(ReturnLexeme(MainPointer - 1));
                    if (TipoSimbolo(ReturnLexeme(MainPointer - 1)).Equals("STRING"))
                    {
                        TempParam = TempParam + ReturnLexeme(MainPointer - 1);
                    }
                    else
                    {
                        TempParam = TempParam + " str("+ReturnLexeme(MainPointer - 1)+") ";
                    }
                    
                }
                else if (CompareToken("NUMERO", MainPointer))
                {
                    NextToken("NUMERO", MainPointer);
                    TempString = TempString + ReturnLexeme(MainPointer - 1);
                    TempParam = TempParam + ReturnLexeme(MainPointer - 1);
                }
                else if (CompareToken("NUMERO_DECIMAL", MainPointer))
                {
                    NextToken("NUMERO_DECIMAL", MainPointer);
                    TempString = TempString + ReturnLexeme(MainPointer - 1);
                    TempParam = TempParam + ReturnLexeme(MainPointer - 1);
                }

                //PARA SEGUIR CONCATENANDO
                if (CompareToken("SIGNO_MAS", MainPointer))
                {
                    NextToken("SIGNO_MAS", MainPointer);
                    TempParam = TempParam + " + ";
                }
                else{ Control = false;}
            }
            NextToken("CIERRA_PARENTESIS", MainPointer);
            NextToken("PUNTO_COMA", MainPointer);
            AppendConsoleOutPut(TempString);
            AppendPythonCode("print( "+TempParam+" )");
            SetNextBlock();
        }

        private void BloqueIF()
        {
            ArrayList TempTablaS = (ArrayList)Program.TablaS.Clone();
            String TempConsoleOutPut = GetConsoleOutPut();
            String TempPyhtonCode = "";

            float Param1=0, Param2=0;
            String Parametro1="",Operador="",Parametro2="";
            int BeginIF, EndIF;
            int BeginELSE = 0, EndELSE = 0;

            NextToken("IF", MainPointer);
            NextToken("ABRE_PARENTESIS", MainPointer);

            //LEYENDO PARAM1
            if (CompareToken("ID", MainPointer))
            {
                NextToken("ID", MainPointer);
                Param1 = float.Parse(ValorSimbolo(ReturnLexeme(MainPointer-1)));
                Parametro1 = ReturnLexeme(MainPointer - 1);
            }
            else if (CompareToken("NUMERO", MainPointer))
            {
                NextToken("NUMERO", MainPointer);
                Param1 = float.Parse(ReturnLexeme(MainPointer - 1));
                Parametro1 = ReturnLexeme(MainPointer - 1);
            }
            else if (CompareToken("NUMERO_DECIMAL", MainPointer))
            {
                NextToken("NUMERO_DECIMAL", MainPointer);
                Param1 = float.Parse(ReturnLexeme(MainPointer - 1));
                Parametro1 = ReturnLexeme(MainPointer - 1);
            }
            //LEYENDO OPERADOR
            if (CompareToken("SIGNO_IGUAL",MainPointer))
            {
                NextToken("SIGNO_IGUAL",MainPointer);
                NextToken("SIGNO_IGUAL", MainPointer);
                Operador = "==";
            }
            else if(CompareToken("SIGNO_MAYOR", MainPointer))
            {
                NextToken("SIGNO_MAYOR", MainPointer);
                Operador = ">";
            }
            else if (CompareToken("SIGNO_MENOR", MainPointer))
            {
                NextToken("SIGNO_MENOR", MainPointer);
                Operador = "<";
            }
            else if (CompareToken("SIGNO_EXCLAMATIVO", MainPointer))
            {
                NextToken("SIGNO_EXCLAMATIVO", MainPointer);
                NextToken("SIGNO_IGUAL", MainPointer);
                Operador = "!=";
            }
            //LEYENDO PARAM2
            if (CompareToken("ID", MainPointer))
            {
                NextToken("ID", MainPointer);
                Param2 = float.Parse(ReturnLexeme(MainPointer - 1));
                Parametro2 = ReturnLexeme(MainPointer - 1);
            }
            else if (CompareToken("NUMERO", MainPointer))
            {
                NextToken("NUMERO", MainPointer);
                Param2 = float.Parse(ReturnLexeme(MainPointer - 1));
                Parametro2 = ReturnLexeme(MainPointer - 1);
            }
            else if (CompareToken("NUMERO_DECIMAL", MainPointer))
            {
                NextToken("NUMERO_DECIMAL", MainPointer);
                Param2 = float.Parse(ReturnLexeme(MainPointer - 1));
                Parametro2 = ReturnLexeme(MainPointer - 1);
            }

            NextToken("CIERRA_PARENTESIS", MainPointer);
            AppendPythonCode("if "+Parametro1+Operador+Parametro2+":");
            Tabulaciones++;
            NextToken("ABRE_LLAVE", MainPointer);
            BeginIF = MainPointer;
            SetNextBlock();
            EndIF = MainPointer;
            NextToken("CIERRA_LLAVE", MainPointer);
            Tabulaciones--;

            if (CompareToken("ELSE",MainPointer))
            {
                NextToken("ELSE", MainPointer);
                AppendPythonCode("else:");
                Tabulaciones++;
                NextToken("ABRE_LLAVE", MainPointer);
                BeginELSE = MainPointer;
                SetNextBlock();
                EndELSE = MainPointer;
                NextToken("CIERRA_LLAVE", MainPointer);
                Tabulaciones--;
            }

            switch (Operador)
            {
                case "==":
                    if (Param1==Param2)
                    {
                        MainPointer = BeginIF;
                        Program.TablaS = TempTablaS;
                        ConsoleOutPut = TempConsoleOutPut;
                        TempPyhtonCode = PythonCode;
                        SetNextBlock();
                        PythonCode = TempPyhtonCode;
                        if (BeginELSE > 0)
                        {
                            MainPointer = EndELSE + 1;
                            SetNextBlock();
                        }
                        else
                        {
                            MainPointer = EndIF + 1;
                            SetNextBlock();
                        }
                    }
                    else
                    {
                        if (BeginELSE>0)
                        {
                            MainPointer = BeginELSE;
                            Program.TablaS = TempTablaS;
                            ConsoleOutPut = TempConsoleOutPut;
                            TempPyhtonCode = PythonCode;
                            SetNextBlock();
                            PythonCode = TempPyhtonCode;
                            MainPointer = EndELSE + 1;
                            SetNextBlock();                          
                        }
                        else
                        {
                            MainPointer = EndIF + 1;
                            SetNextBlock();
                        }
                    }
                    break;
                case ">":
                    if (Param1 > Param2)
                    {
                        MainPointer = BeginIF;
                        Program.TablaS = TempTablaS;
                        ConsoleOutPut = TempConsoleOutPut;
                        TempPyhtonCode = PythonCode;
                        SetNextBlock();
                        PythonCode = TempPyhtonCode;
                        if (BeginELSE > 0)
                        {
                            MainPointer = EndELSE + 1;
                            SetNextBlock();
                        }
                        else
                        {
                            MainPointer = EndIF + 1;
                            SetNextBlock();
                        }
                    }
                    else
                    {
                        if (BeginELSE > 0)
                        {
                            MainPointer = BeginELSE;
                            Program.TablaS = TempTablaS;
                            ConsoleOutPut = TempConsoleOutPut;
                            TempPyhtonCode = PythonCode;
                            SetNextBlock();
                            PythonCode = TempPyhtonCode;
                            MainPointer = EndELSE + 1;
                            SetNextBlock();
                        }
                        else
                        {
                            MainPointer = EndIF + 1;
                            SetNextBlock();
                        }
                    }
                    break;
                case "<":
                    if (Param1 < Param2)
                    {
                        MainPointer = BeginIF;
                        Program.TablaS = TempTablaS;
                        ConsoleOutPut = TempConsoleOutPut;
                        TempPyhtonCode = PythonCode;
                        SetNextBlock();
                        PythonCode = TempPyhtonCode;
                        if (BeginELSE > 0)
                        {
                            MainPointer = EndELSE + 1;
                            SetNextBlock();
                        }
                        else
                        {
                            MainPointer = EndIF + 1;
                            SetNextBlock();
                        }
                    }
                    else
                    {
                        if (BeginELSE > 0)
                        {
                            MainPointer = BeginELSE;
                            Program.TablaS = TempTablaS;
                            ConsoleOutPut = TempConsoleOutPut;
                            TempPyhtonCode = PythonCode;
                            SetNextBlock();
                            PythonCode = TempPyhtonCode;
                            MainPointer = EndELSE + 1;
                            SetNextBlock();
                        }
                        else
                        {
                            MainPointer = EndIF + 1;
                            SetNextBlock();
                        }
                    }
                    break;
                case "!=":
                    if (Param1 != Param2)
                    {
                        MainPointer = BeginIF;
                        Program.TablaS = TempTablaS;
                        ConsoleOutPut = TempConsoleOutPut;
                        TempPyhtonCode = PythonCode;
                        SetNextBlock();
                        PythonCode = TempPyhtonCode;
                        if (BeginELSE > 0)
                        {
                            MainPointer = EndELSE + 1;
                            SetNextBlock();
                        }
                        else
                        {
                            MainPointer = EndIF + 1;
                            SetNextBlock();
                        }
                    }
                    else
                    {
                        if (BeginELSE > 0)
                        {
                            MainPointer = BeginELSE;
                            Program.TablaS = TempTablaS;
                            ConsoleOutPut = TempConsoleOutPut;
                            TempPyhtonCode = PythonCode;
                            SetNextBlock();
                            PythonCode = TempPyhtonCode;
                            MainPointer = EndELSE + 1;
                            SetNextBlock();
                        }
                        else
                        {
                            MainPointer = EndIF + 1;
                            SetNextBlock();
                        }
                    }
                    break;
            }

        }

        private void BloqueSWITCH()
        {
            ArrayList TempTablaS = (ArrayList)Program.TablaS.Clone();
            String TempConsoleOutPut = GetConsoleOutPut();
            String TempPyhtonCode = "";
            String Parametro;
            float Param,TempCase;
            int BeginCase = 0, EndSwitch = 0;
            Boolean Control=true;

            NextToken("SWITCH",MainPointer);
            NextToken("ABRE_PARENTESIS", MainPointer);
            NextToken("ID", MainPointer);
            Parametro = ReturnLexeme(MainPointer - 1);
            Param = float.Parse(ValorSimbolo(ReturnLexeme(MainPointer-1)));
            NextToken("CIERRA_PARENTESIS", MainPointer);
            NextToken("ABRE_LLAVE", MainPointer);
            NextToken("CASE", MainPointer);
            //PRIME CASE
            if (CompareToken("NUMERO", MainPointer))
            {
                NextToken("NUMERO", MainPointer);
                TempCase = float.Parse(ReturnLexeme(MainPointer - 1));
                NextToken("DOS_PUNTOS", MainPointer);
                AppendPythonCode("if " + Parametro + " == " + ReturnLexeme(MainPointer - 2) + ":");
                if (TempCase == Param) { BeginCase = MainPointer; }
                Tabulaciones++;
                SetNextBlock();
                Tabulaciones--;
                NextToken("BREAK", MainPointer);
                NextToken("PUNTO_COMA", MainPointer);
            }
            else if (CompareToken("NUMERO_DECIMAL", MainPointer))
            {
                NextToken("NUMERO_DECIMAL", MainPointer);
                TempCase = float.Parse(ReturnLexeme(MainPointer - 1));
                NextToken("DOS_PUNTOS", MainPointer);
                AppendPythonCode("if " + Parametro + " == " + ReturnLexeme(MainPointer - 2) + ":");
                if (TempCase == Param) { BeginCase = MainPointer; }
                Tabulaciones++;
                SetNextBlock();
                Tabulaciones--;
                NextToken("BREAK", MainPointer);
                NextToken("PUNTO_COMA", MainPointer);
            }

            //SIGUIENTES CASE
            while (Control)
            {              
                if (CompareToken("NUMERO",MainPointer+1))
                {
                    NextToken("CASE", MainPointer);
                    NextToken("NUMERO", MainPointer);
                    TempCase = float.Parse(ReturnLexeme(MainPointer - 1));
                    NextToken("DOS_PUNTOS", MainPointer);
                    AppendPythonCode("elif " + Parametro + " == " + ReturnLexeme(MainPointer - 2) + ":");
                    if (TempCase == Param) { BeginCase = MainPointer; }
                    Tabulaciones++;
                    SetNextBlock();
                    Tabulaciones--;
                    NextToken("BREAK", MainPointer);
                    NextToken("PUNTO_COMA", MainPointer);
                }
                else if (CompareToken("NUMERO_DECIMAL", MainPointer+1))
                {
                    NextToken("CASE", MainPointer);
                    NextToken("NUMERO_DECIMAL", MainPointer);
                    TempCase = float.Parse(ReturnLexeme(MainPointer - 1));
                    NextToken("DOS_PUNTOS", MainPointer);
                    AppendPythonCode("elif " + Parametro + " == " + ReturnLexeme(MainPointer - 2) + ":");
                    if (TempCase == Param) { BeginCase = MainPointer; }
                    Tabulaciones++;
                    SetNextBlock();
                    Tabulaciones--;
                    NextToken("BREAK", MainPointer);
                    NextToken("PUNTO_COMA", MainPointer);
                }
                else if (CompareToken("DEFAULT", MainPointer))
                {
                    Control = false;
                    NextToken("DEFAULT", MainPointer);
                    NextToken("DOS_PUNTOS", MainPointer);
                    AppendPythonCode("else: ");
                    if (BeginCase == 0) { BeginCase = MainPointer; }
                    Tabulaciones++;
                    SetNextBlock();
                    Tabulaciones--;
                    NextToken("BREAK", MainPointer);
                    NextToken("PUNTO_COMA", MainPointer);
                }
                else if (CompareToken("CIERRA_LLAVE", MainPointer))
                {
                    Control = false;
                }

            }
            EndSwitch = MainPointer + 1;
            NextToken("CIERRA_LLAVE", MainPointer);

            Program.TablaS = TempTablaS;
            TempPyhtonCode = PythonCode;
            ConsoleOutPut = TempConsoleOutPut;
            MainPointer = BeginCase;
            SetNextBlock();
            PythonCode = TempPyhtonCode;
            MainPointer = EndSwitch;
            SetNextBlock();
            
        }

        private void BloqueFOR()
        {
            String IDParam, Operador = "", Accion, TempPythonCode;
            int Param, Param2, BeginFOR = 0, EndFOR = 0;
            Boolean Control = true;

            NextToken("FOR", MainPointer);
            NextToken("ABRE_PARENTESIS", MainPointer);
            NextToken("INT", MainPointer);
            NextToken("ID", MainPointer);
            IDParam = ReturnLexeme(MainPointer - 1);
            NextToken("SIGNO_IGUAL", MainPointer);
            NextToken("NUMERO", MainPointer);
            Param = Int32.Parse(ReturnLexeme(MainPointer - 1));
            InsertarSimbolo(IDParam, "INT", Param.ToString());
            NextToken("PUNTO_COMA", MainPointer);
            NextToken("ID", MainPointer);
            if (CompareToken("SIGNO_MENOR", MainPointer))
            {
                NextToken("SIGNO_MENOR", MainPointer);
                if (CompareToken("SIGNO_IGUAL", MainPointer))
                {
                    NextToken("SIGNO_IGUAL", MainPointer);
                    Operador = "<=";
                }
                else
                {
                    Operador = "<";
                }
            }
            else if (CompareToken("SIGNO_MAYOR", MainPointer))
            {
                NextToken("SIGNO_MAYOR", MainPointer);
                if (CompareToken("SIGNO_IGUAL", MainPointer))
                {
                    NextToken("SIGNO_IGUAL", MainPointer);
                    Operador = ">=";
                }
                else
                {
                    Operador = ">";
                }
            }
            NextToken("NUMERO", MainPointer);
            Param2 = Int32.Parse(ReturnLexeme(MainPointer - 1));
            NextToken("PUNTO_COMA", MainPointer);
            NextToken("ID", MainPointer);
            if (CompareToken("SIGNO_MENOS", MainPointer))
            {
                NextToken("SIGNO_MENOS", MainPointer);
                NextToken("SIGNO_MENOS", MainPointer);
                Accion = "--";
            }
            else if (CompareToken("SIGNO_MAS", MainPointer))
            {
                NextToken("SIGNO_MAS", MainPointer);
                NextToken("SIGNO_MAS", MainPointer);
                Accion = "++";
            }
            else
            {
                NextToken("OPERADOR RELACIONAL", MainPointer);
                Accion = "";
            }
            NextToken("CIERRA_PARENTESIS", MainPointer);
            AppendPythonCode(IDParam + " = " + Param);
            AppendPythonCode("while " + IDParam + " " + Operador + " " + Param2.ToString() + ":");
            Tabulaciones++;
            NextToken("ABRE_LLAVE", MainPointer);
            BeginFOR = MainPointer;
            SetNextBlock();           
            if (Accion.Equals("++"))
            {
                Param++;
                InsertarSimbolo(IDParam, "INT", Param.ToString());
                AppendPythonCode(IDParam + "+=1");
            }
            else if (Accion.Equals("--"))
            {
                Param--;
                InsertarSimbolo(IDParam, "INT", Param.ToString());
                AppendPythonCode(IDParam + "-=1");
            }
            Tabulaciones--;
            EndFOR = MainPointer;
            TempPythonCode = PythonCode;
            NextToken("CIERRA_LLAVE", MainPointer);

            while (Control) { 
                switch (Operador)
                {
                    case "<":
                        if (Param<Param2)
                        {
                            MainPointer = BeginFOR;
                            SetNextBlock();
                            if (Accion.Equals("++"))
                            {
                                Param++;
                                InsertarSimbolo(IDParam, "INT", Param.ToString());
                            }
                            else if (Accion.Equals("--"))
                            {
                                Param--;
                                InsertarSimbolo(IDParam, "INT", Param.ToString());
                            }
                            else { break; }
                        }
                        else
                        {
                            Control = false;
                            PythonCode = TempPythonCode;
                        }
                        break;
                    case "<=":
                        if (Param <= Param2)
                        {
                            MainPointer = BeginFOR;
                            SetNextBlock();
                            if (Accion.Equals("++"))
                            {
                                Param++;
                                InsertarSimbolo(IDParam, "INT", Param.ToString());
                            }
                            else if (Accion.Equals("--"))
                            {
                                Param--;
                                InsertarSimbolo(IDParam, "INT", Param.ToString());
                            }
                            else { break; }
                        }
                        else
                        {
                            Control = false;
                            PythonCode = TempPythonCode;
                        }
                        break;
                    case ">":
                        if (Param > Param2)
                        {
                            MainPointer = BeginFOR;
                            SetNextBlock();
                            if (Accion.Equals("++"))
                            {
                                Param++;
                                InsertarSimbolo(IDParam, "INT", Param.ToString());
                            }
                            else if (Accion.Equals("--"))
                            {
                                Param--;
                                InsertarSimbolo(IDParam, "INT", Param.ToString());
                            }
                            else { break; }
                        }
                        else
                        {
                            Control = false;
                            PythonCode = TempPythonCode;
                        }
                        break;
                    case ">=":
                        if (Param >= Param2)
                        {
                            MainPointer = BeginFOR;
                            SetNextBlock();
                            if (Accion.Equals("++"))
                            {
                                Param++;
                                InsertarSimbolo(IDParam, "INT", Param.ToString());
                            }
                            else if (Accion.Equals("--"))
                            {
                                Param--;
                                InsertarSimbolo(IDParam, "INT", Param.ToString());
                            }
                            else { break; }
                        }
                        else
                        {
                            Control = false;
                            PythonCode = TempPythonCode;
                        }
                        break;
                }
            }

            MainPointer = EndFOR+1;
            SetNextBlock();
        }

        private void BloqueWHILE()
        {
            String IDParam, Operador = "", Accion, TempPythonCode;
            int Param,Param2,BeginWHILE = 0, EndWHILE = 0;
            Boolean Control = true;

            NextToken("WHILE",MainPointer);
            NextToken("ABRE_PARENTESIS", MainPointer);
            NextToken("ID", MainPointer);
            IDParam = ReturnLexeme(MainPointer - 1);
            Param = Int32.Parse(ValorSimbolo(IDParam));
            if (CompareToken("SIGNO_MENOR", MainPointer))
            {
                NextToken("SIGNO_MENOR", MainPointer);
                if (CompareToken("SIGNO_IGUAL", MainPointer))
                {
                    NextToken("SIGNO_IGUAL", MainPointer);
                    Operador = "<=";
                }
                else
                {
                    Operador = "<";
                }
            }
            else if (CompareToken("SIGNO_MAYOR", MainPointer))
            {
                NextToken("SIGNO_MAYOR", MainPointer);
                if (CompareToken("SIGNO_IGUAL", MainPointer))
                {
                    NextToken("SIGNO_IGUAL", MainPointer);
                    Operador = ">=";
                }
                else
                {
                    Operador = ">";
                }
            }
            NextToken("NUMERO", MainPointer);
            Param2 = Int32.Parse(ReturnLexeme(MainPointer - 1));
            NextToken("CIERRA_PARENTESIS", MainPointer);
            AppendPythonCode("while " + IDParam + Operador + Param2 + ":");
            Tabulaciones++;
            NextToken("ABRE_LLAVE", MainPointer);
            BeginWHILE = MainPointer;
            SetNextBlock();
            Tabulaciones--;
            EndWHILE = MainPointer;
            TempPythonCode = PythonCode;
            NextToken("CIERRA_LLAVE", MainPointer);

            while (Control)
            {
                Param = Int32.Parse(ValorSimbolo(IDParam));
                switch (Operador)
                {
                    case "<":
                        if (Param < Param2)
                        {
                            MainPointer = BeginWHILE;
                            SetNextBlock();
                        }
                        else
                        {
                            Control = false;
                            PythonCode = TempPythonCode;
                        }
                        break;
                    case "<=":
                        if (Param <= Param2)
                        {
                            MainPointer = BeginWHILE;
                            SetNextBlock();
                        }
                        else
                        {
                            Control = false;
                            PythonCode = TempPythonCode;
                        }
                        break;
                    case ">":
                        if (Param > Param2)
                        {
                            MainPointer = BeginWHILE;
                            SetNextBlock();
                        }
                        else
                        {
                            Control = false;
                            PythonCode = TempPythonCode;
                        }
                        break;
                    case ">=":
                        if (Param >= Param2)
                        {
                            MainPointer = BeginWHILE;
                            SetNextBlock();
                        }
                        else
                        {
                            Control = false;
                            PythonCode = TempPythonCode;
                        }
                        break;
                }
            }

            MainPointer = EndWHILE + 1;
            SetNextBlock();

        }

        private void GraficarVector()
        {
            String TempValor;
            String TempID;
            String TempString;

            NextToken("GRAFICARVECTOR", MainPointer);
            NextToken("ABRE_PARENTESIS",MainPointer);
            NextToken("ID",MainPointer);
            TempID = ReturnLexeme(MainPointer-1);
            TempValor = ValorSimbolo(TempID);
            NextToken("COMA",MainPointer);
            NextToken("COMILLAS_DOBLES",MainPointer);
            NextToken("CADENA",MainPointer);
            TempString = ReturnLexeme(MainPointer-1);
            NextToken("COMILLAS_DOBLES", MainPointer);
            NextToken("CIERRA_PARENTESIS", MainPointer);
            NextToken("PUNTO_COMA",MainPointer);
            AppendPythonCode("graficarVector("+TempID+", "+"\""+TempString+"\")");
            GenerateVectorGraph(TempValor,TempString);
        }


        //FUNCION QUE DEFINE QUE BLOQUE O SENTENCIA SE ANALIZARA DESPUES
        private void SetNextBlock()
        {
            if (CompareToken("ID", MainPointer))
            {
                SentenciaAsignacion();
            }
            else if (CompareToken("INT", MainPointer))
            {
                NextToken("INT", MainPointer);
                SentenciaDeclaracionAsignacion("INT");
            }
            else if (CompareToken("FLOAT", MainPointer))
            {
                NextToken("FLOAT", MainPointer);
                SentenciaDeclaracionAsignacion("FLOAT");
            }
            else if (CompareToken("CHAR", MainPointer))
            {
                NextToken("CHAR", MainPointer);
                SentenciaDeclaracionAsignacion("CHAR");
            }
            else if (CompareToken("STRING", MainPointer))
            {
                NextToken("STRING", MainPointer);
                SentenciaDeclaracionAsignacion("STRING");
            }
            else if (CompareToken("BOOL", MainPointer))
            {
                NextToken("BOOL", MainPointer);
                SentenciaDeclaracionAsignacion("BOOL");
            }
            else if (CompareToken("CONSOLE", MainPointer))
            {
                SentenciaWriteLine();
            }
            else if (CompareToken("IF", MainPointer))
            {
                BloqueIF();
            }
            else if (CompareToken("SWITCH",MainPointer) )
            {
                BloqueSWITCH();
            } 
            else if (CompareToken("FOR", MainPointer))
            {
                BloqueFOR();
            }
            else if (CompareToken("WHILE", MainPointer))
            {
                BloqueWHILE();
            }
            else if (CompareToken("GRAFICARVECTOR", MainPointer))
            {
                GraficarVector();
            }


        }

        public void GenerateHTMLSymbol()
        {
            String RutaH = Path.GetDirectoryName(Form1.Ruta) + "\\" + Path.GetFileNameWithoutExtension(Form1.Ruta) + "TablaSimbolos" + ".html";

            FileStream MyStream = new FileStream(RutaH, FileMode.Create, FileAccess.Write, FileShare.None);
            StreamWriter MyWriter = new StreamWriter(MyStream);

            MyWriter.WriteLine("<font size=\"2\" face=\"Segoe UI Emoji\" >");
            MyWriter.WriteLine("<h2 style=\"text - align: center; \"><strong>TABLA DE SIMBOLOS</strong></h2>");

            MyWriter.WriteLine("<h4><strong>Hora y Fecha: "+DateTime.Now.ToString()+"</strong></h4>");
            MyWriter.WriteLine("<h4><strong>Ruta Archivos HTML: "+ RutaH + "</strong></h4>");
            MyWriter.WriteLine("<h4><strong>Ruta Archivo C#: "+Form1.RutaC+"</strong></h4>");
            MyWriter.WriteLine("<h4><strong>Ruta Archivo Python: " + Form1.RutaP + "</strong></h4>");

            MyWriter.WriteLine("<table align=\"center\" border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"width: 500px;\">");
            MyWriter.WriteLine("<thead>");
            MyWriter.WriteLine("<tr>");
            MyWriter.WriteLine("<th scope=\"col\">ID</th>");
            MyWriter.WriteLine("<th scope=\"col\">Tipo</th>");
            MyWriter.WriteLine("<th scope=\"col\">Valor</th>");
            MyWriter.WriteLine("</tr>");
            MyWriter.WriteLine("</thead>");
            MyWriter.WriteLine("<tbody>");
            for (int p = 0; p < Program.TablaS.Count; p++)
            {
                String[] auxVector3 = (String[])Program.TablaS[p];
                MyWriter.WriteLine("<tr>");
                MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[0] + "</th>");
                MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[1] + "</th>");
                MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[2] + "</th>");
                MyWriter.WriteLine("</tr>");
            }
            MyWriter.WriteLine("</tbody>");
            MyWriter.WriteLine("</font>");
            MyWriter.Close();
            MyStream.Close();
            MessageBox.Show("Reporte de Simbolos Generado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("chrome.exe", RutaH);
          

        }

        public void GenerateHTMLError()
        {
            String RutaH = Path.GetDirectoryName(Form1.Ruta) + "\\" + Path.GetFileNameWithoutExtension(Form1.Ruta) + "ErroresSintacticos" + ".html";

            if (Errores)
            {

                FileStream MyStream = new FileStream(RutaH, FileMode.Create, FileAccess.Write, FileShare.None);
                StreamWriter MyWriter = new StreamWriter(MyStream);
                MyWriter.WriteLine("<font size=\"2\" face=\"Segoe UI Emoji\" >");
                MyWriter.WriteLine("<h2 style=\"text - align: center; \"><strong>TABLA DE ERRORES SINTACTICOS </strong></h2>");

                MyWriter.WriteLine("<h4><strong>Hora y Fecha: " + DateTime.Now.ToString() + "</strong></h4>");
                MyWriter.WriteLine("<h4><strong>Ruta Archivos HTML: " + RutaH + "</strong></h4>");
                MyWriter.WriteLine("<h4><strong>Ruta Archivo C#: " + Form1.RutaC + "</strong></h4>");
                MyWriter.WriteLine("<h4><strong>Ruta Archivo Python: " + Form1.RutaP + "</strong></h4>");

                MyWriter.WriteLine("<table align=\"center\" border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"width: 500px;\">");
                MyWriter.WriteLine("<thead>");
                MyWriter.WriteLine("<tr>");
                MyWriter.WriteLine("<th scope=\"col\">#</th>");
                MyWriter.WriteLine("<th scope=\"col\">ERROR</th>");
                MyWriter.WriteLine("<th scope=\"col\">FILA</th>");
                MyWriter.WriteLine("<th scope=\"col\">COLUMNA</th>");
                MyWriter.WriteLine("</tr>");
                MyWriter.WriteLine("</thead>");
                MyWriter.WriteLine("<tbody>");
                for (int p = 0; p < Program.TablaES.Count; p++)
                {
                    String[] auxVector3 = (String[])Program.TablaES[p];
                    MyWriter.WriteLine("<tr>");
                    MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[0] + "</th>");
                    MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[1] + "</th>");
                    MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[2] + "</th>");
                    MyWriter.WriteLine("<th scope=\"col\">" + auxVector3[3] + "</th>");
                    MyWriter.WriteLine("</tr>");
                }
                MyWriter.WriteLine("</tbody>");
                MyWriter.WriteLine("</font>");
                MyWriter.Close();
                MyStream.Close();
                MessageBox.Show("Reporte de Errores Sintacticos Generado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start("chrome.exe", RutaH);

            }
            else
            {
                MessageBox.Show("No hay errores sintacticos que mostrar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void GenerateVectorGraph(String PlainVector,String Name)
        {
            if (!Errores)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Archivo DOT (*.dot)|*.dot";
                saveFile.DefaultExt = "dot";
                saveFile.AddExtension = true;
                saveFile.FileName = Name;

                saveFile.Title = "Guardar Grafico";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    FileStream MyStream = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                    StreamWriter MyWriter = new StreamWriter(MyStream);                  
                    String[] Vector = PlainVector.Split(',');
                    MyWriter.WriteLine("digraph G {");
                    MyWriter.WriteLine("Inicio [shape=box];");
                    MyWriter.WriteLine("Inicio -> " + Vector[0]);
                    for (int i = 0;i<Vector.Length-1;i++)
                    {
                        MyWriter.WriteLine(Vector[i]+" [shape=box];");
                        MyWriter.WriteLine(Vector[i] + "->" + Vector[i + 1] + ";");
                        MyWriter.WriteLine(Vector[i+1] + " [shape=box];");
                    }
                    int aux = Vector.Length - 1;
                    MyWriter.WriteLine(Vector[Vector.Length - 1] + "->" + "Final" + ";");
                    MyWriter.WriteLine("Final [shape=box];");

                    MyWriter.WriteLine("}");
                    MyWriter.Close();
                    MyStream.Close();
                    MessageBox.Show("Vector Graficado Correctamente", "Grafico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //SE MANDO COMANDO AL SHELL DEL SISTEMA 
                    RutaImg = Path.GetDirectoryName(saveFile.FileName) + "\\" + Path.GetFileNameWithoutExtension(saveFile.FileName);
                    DirImg = saveFile.FileName;
                    String Command = "dot.exe -Tpng " + saveFile.FileName + " -o " + RutaImg + ".png";
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.CreateNoWindow = false;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.Start();
                    cmd.StandardInput.WriteLine(Command);
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    cmd.WaitForExit();
                    Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                    Console.Read();
                }
            }

        }

    }
}
