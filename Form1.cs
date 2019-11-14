using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using Proyecto2_Scanner_LL1Parser;

namespace Proyecto2_Scanner_LL1Parser
{
    public partial class Form1 : Form
    {
        Scanner scanner = new Scanner();
        Parser parser = new Parser();
        public static String RutaC, RutaP,Ruta;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TablaDeTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            scanner.GenerateHTMLToken();
        }

        private void TalblaDeErorresLexicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scanner.GenerateHTMLError();
        }

        private void TablaDeErroresSintacticosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parser.GenerateHTMLError();
        }

        private void TablaDeSimbolosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parser.GenerateHTMLSymbol();
        }

        private void GenerarTraduccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scanner = new Scanner();
            scanner.Analysis(TxtCodeInput);
            if (!scanner.Errores)
            {
                parser = new Parser();
                parser.Parsing();
                if (!parser.Errores)
                {
                    TxtCodeOutput.Text = parser.GetPythonCode();
                    TxtConsoleOutput.Text = parser.GetConsoleOutPut();

                    if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        Ruta = saveFileDialog2.FileName;
                        RutaC = Path.GetDirectoryName(Ruta) + "\\" + Path.GetFileNameWithoutExtension(Ruta) + ".cs";
                        RutaP = Path.GetDirectoryName(Ruta) + "\\" + Path.GetFileNameWithoutExtension(Ruta) + ".py";
                        FileStream MyStream = new FileStream(RutaC, FileMode.Create, FileAccess.Write, FileShare.None);
                        StreamWriter MyWriter = new StreamWriter(MyStream);
                        MyWriter.Write(TxtCodeInput.Text);
                        MyWriter.Close();
                        MyStream.Close();
                        FileStream MyStream2 = new FileStream(RutaP, FileMode.Create, FileAccess.Write, FileShare.None);
                        StreamWriter MyWriter2 = new StreamWriter(MyStream2);
                        MyWriter2.Write(TxtCodeOutput.Text);
                        MyWriter2.Close();
                        MyStream2.Close();
                        MessageBox.Show("Guardados Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        Ruta = saveFileDialog2.FileName;
                        parser.GenerateHTMLError();
                    }

                }
            
            }
            else
            {
                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    Ruta = saveFileDialog2.FileName;
                    scanner.GenerateHTMLError();
                }
            }
        }

        private void LimpiarDocumentosRecientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scanner scanner = new Scanner();
            Parser parser = new Parser();
            Program.TablaT = new ArrayList(); 
            Program.TablaEL = new ArrayList();
            Program.TablaES = new ArrayList(); 
            Program.TablaI = new ArrayList(); 
            Program.TablaS = new ArrayList(); 

    }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String RutaA = openFileDialog1.FileName;
                TxtCodeInput.Text = File.ReadAllText(RutaA);
            }
        }

        private void GuardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String RutaG = saveFileDialog1.FileName;
                FileStream MyStream = new FileStream(RutaG, FileMode.Create, FileAccess.Write, FileShare.None);
                StreamWriter MyWriter = new StreamWriter(MyStream);
                MyWriter.Write(TxtCodeInput.Text);
                MyWriter.Close();
                MyStream.Close();
                MessageBox.Show("Guardado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
