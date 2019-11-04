using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto2_Scanner_LL1Parser;

namespace Proyecto2_Scanner_LL1Parser
{
    public partial class Form1 : Form
    {
        Scanner scanner = new Scanner();
        Parser parser = new Parser();


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
                TxtCodeOutput.Text = parser.GetPythonCode();
                TxtConsoleOutput.Text = parser.GetConsoleOutPut();
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
    }
}
