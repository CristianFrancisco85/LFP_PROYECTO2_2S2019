namespace Proyecto2_Scanner_LL1Parser
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TxtCodeInput = new System.Windows.Forms.RichTextBox();
            this.TxtCodeOutput = new System.Windows.Forms.RichTextBox();
            this.TxtConsoleOutput = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarTraduccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarDeportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaDeTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaDeSimbolosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.talblaDeErorresLexicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaDeErroresSintacticosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarDocumentosRecientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acerdaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtn)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtCodeInput
            // 
            this.TxtCodeInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.TxtCodeInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtCodeInput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodeInput.ForeColor = System.Drawing.Color.White;
            this.TxtCodeInput.Location = new System.Drawing.Point(22, 79);
            this.TxtCodeInput.Name = "TxtCodeInput";
            this.TxtCodeInput.Size = new System.Drawing.Size(450, 350);
            this.TxtCodeInput.TabIndex = 0;
            this.TxtCodeInput.Text = "";
            // 
            // TxtCodeOutput
            // 
            this.TxtCodeOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.TxtCodeOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtCodeOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodeOutput.ForeColor = System.Drawing.Color.White;
            this.TxtCodeOutput.Location = new System.Drawing.Point(508, 79);
            this.TxtCodeOutput.Name = "TxtCodeOutput";
            this.TxtCodeOutput.Size = new System.Drawing.Size(510, 550);
            this.TxtCodeOutput.TabIndex = 1;
            this.TxtCodeOutput.Text = "";
            // 
            // TxtConsoleOutput
            // 
            this.TxtConsoleOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.TxtConsoleOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtConsoleOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConsoleOutput.ForeColor = System.Drawing.Color.Yellow;
            this.TxtConsoleOutput.Location = new System.Drawing.Point(22, 479);
            this.TxtConsoleOutput.Name = "TxtConsoleOutput";
            this.TxtConsoleOutput.Size = new System.Drawing.Size(450, 150);
            this.TxtConsoleOutput.TabIndex = 2;
            this.TxtConsoleOutput.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Consola";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Entrada C#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(505, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Salida Python";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.CloseBtn);
            this.panel2.Location = new System.Drawing.Point(340, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 30);
            this.panel2.TabIndex = 8;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Image = ((System.Drawing.Image)(resources.GetObject("CloseBtn.Image")));
            this.CloseBtn.Location = new System.Drawing.Point(660, 3);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(24, 24);
            this.CloseBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.TabStop = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.documentoToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(-2, -1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(367, 30);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 26);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar Como";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.GuardarComoToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // documentoToolStripMenuItem
            // 
            this.documentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarTraduccionToolStripMenuItem,
            this.generarDeportesToolStripMenuItem,
            this.limpiarDocumentosRecientesToolStripMenuItem});
            this.documentoToolStripMenuItem.Name = "documentoToolStripMenuItem";
            this.documentoToolStripMenuItem.Size = new System.Drawing.Size(82, 26);
            this.documentoToolStripMenuItem.Text = "Documento";
            // 
            // generarTraduccionToolStripMenuItem
            // 
            this.generarTraduccionToolStripMenuItem.Name = "generarTraduccionToolStripMenuItem";
            this.generarTraduccionToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.generarTraduccionToolStripMenuItem.Text = "Generar Traduccion";
            this.generarTraduccionToolStripMenuItem.Click += new System.EventHandler(this.GenerarTraduccionToolStripMenuItem_Click);
            // 
            // generarDeportesToolStripMenuItem
            // 
            this.generarDeportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tablaDeTokensToolStripMenuItem,
            this.tablaDeSimbolosToolStripMenuItem,
            this.talblaDeErorresLexicosToolStripMenuItem,
            this.tablaDeErroresSintacticosToolStripMenuItem});
            this.generarDeportesToolStripMenuItem.Name = "generarDeportesToolStripMenuItem";
            this.generarDeportesToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.generarDeportesToolStripMenuItem.Text = "Generar Reportes";
            // 
            // tablaDeTokensToolStripMenuItem
            // 
            this.tablaDeTokensToolStripMenuItem.Name = "tablaDeTokensToolStripMenuItem";
            this.tablaDeTokensToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.tablaDeTokensToolStripMenuItem.Text = "Tabla de Tokens";
            this.tablaDeTokensToolStripMenuItem.Click += new System.EventHandler(this.TablaDeTokensToolStripMenuItem_Click);
            // 
            // tablaDeSimbolosToolStripMenuItem
            // 
            this.tablaDeSimbolosToolStripMenuItem.Name = "tablaDeSimbolosToolStripMenuItem";
            this.tablaDeSimbolosToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.tablaDeSimbolosToolStripMenuItem.Text = "Tabla de Simbolos";
            this.tablaDeSimbolosToolStripMenuItem.Click += new System.EventHandler(this.TablaDeSimbolosToolStripMenuItem_Click);
            // 
            // talblaDeErorresLexicosToolStripMenuItem
            // 
            this.talblaDeErorresLexicosToolStripMenuItem.Name = "talblaDeErorresLexicosToolStripMenuItem";
            this.talblaDeErorresLexicosToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.talblaDeErorresLexicosToolStripMenuItem.Text = "Tabla de Erorres Lexicos";
            this.talblaDeErorresLexicosToolStripMenuItem.Click += new System.EventHandler(this.TalblaDeErorresLexicosToolStripMenuItem_Click);
            // 
            // tablaDeErroresSintacticosToolStripMenuItem
            // 
            this.tablaDeErroresSintacticosToolStripMenuItem.Name = "tablaDeErroresSintacticosToolStripMenuItem";
            this.tablaDeErroresSintacticosToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.tablaDeErroresSintacticosToolStripMenuItem.Text = "Tabla de Errores Sintacticos";
            this.tablaDeErroresSintacticosToolStripMenuItem.Click += new System.EventHandler(this.TablaDeErroresSintacticosToolStripMenuItem_Click);
            // 
            // limpiarDocumentosRecientesToolStripMenuItem
            // 
            this.limpiarDocumentosRecientesToolStripMenuItem.Name = "limpiarDocumentosRecientesToolStripMenuItem";
            this.limpiarDocumentosRecientesToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.limpiarDocumentosRecientesToolStripMenuItem.Text = "Limpiar Documentos Recientes";
            this.limpiarDocumentosRecientesToolStripMenuItem.Click += new System.EventHandler(this.LimpiarDocumentosRecientesToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acerdaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acerdaDeToolStripMenuItem
            // 
            this.acerdaDeToolStripMenuItem.Name = "acerdaDeToolStripMenuItem";
            this.acerdaDeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.acerdaDeToolStripMenuItem.Text = "Acerda de ...";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.AbrirToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Archivo C#|*.cs";
            this.openFileDialog1.Title = "Abrir Entrada C#";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Archivo C#|*.cs";
            this.saveFileDialog1.Title = "Guardar Entrada C#";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.Title = "Guardar Archivos de Salida";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1034, 650);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtConsoleOutput);
            this.Controls.Add(this.TxtCodeOutput);
            this.Controls.Add(this.TxtCodeInput);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtn)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TxtCodeInput;
        private System.Windows.Forms.RichTextBox TxtCodeOutput;
        private System.Windows.Forms.RichTextBox TxtConsoleOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox CloseBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarTraduccionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarDeportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablaDeTokensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablaDeSimbolosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem talblaDeErorresLexicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limpiarDocumentosRecientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acerdaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablaDeErroresSintacticosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
    }
}

