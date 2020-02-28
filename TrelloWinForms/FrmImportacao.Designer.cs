namespace TrelloWinForms
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbxPathTrello = new System.Windows.Forms.GroupBox();
            this.btnLocalizar = new System.Windows.Forms.Button();
            this.txtPathArquivo = new System.Windows.Forms.TextBox();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            this.cbxCartArquivado = new System.Windows.Forms.CheckBox();
            this.gbxImportacoes = new System.Windows.Forms.GroupBox();
            this.rbWebApi = new System.Windows.Forms.RadioButton();
            this.rbArquivo = new System.Windows.Forms.RadioButton();
            this.btnImportar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.gbxPathTrello.SuspendLayout();
            this.gbxFiltros.SuspendLayout();
            this.gbxImportacoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbxPathTrello);
            this.groupBox1.Controls.Add(this.gbxFiltros);
            this.groupBox1.Controls.Add(this.btnImportar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 270);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // gbxPathTrello
            // 
            this.gbxPathTrello.Controls.Add(this.btnLocalizar);
            this.gbxPathTrello.Controls.Add(this.txtPathArquivo);
            this.gbxPathTrello.Location = new System.Drawing.Point(0, 12);
            this.gbxPathTrello.Name = "gbxPathTrello";
            this.gbxPathTrello.Size = new System.Drawing.Size(345, 53);
            this.gbxPathTrello.TabIndex = 11;
            this.gbxPathTrello.TabStop = false;
            this.gbxPathTrello.Text = "Path Arquivo Trello";
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLocalizar.Location = new System.Drawing.Point(247, 17);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(83, 23);
            this.btnLocalizar.TabIndex = 4;
            this.btnLocalizar.Text = "Localizar .json";
            this.btnLocalizar.UseVisualStyleBackColor = true;
            // 
            // txtPathArquivo
            // 
            this.txtPathArquivo.Enabled = false;
            this.txtPathArquivo.Location = new System.Drawing.Point(6, 19);
            this.txtPathArquivo.Name = "txtPathArquivo";
            this.txtPathArquivo.Size = new System.Drawing.Size(235, 20);
            this.txtPathArquivo.TabIndex = 3;
            this.txtPathArquivo.Text = "C:\\temp\\trello.json";
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.Controls.Add(this.cbxCartArquivado);
            this.gbxFiltros.Controls.Add(this.gbxImportacoes);
            this.gbxFiltros.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbxFiltros.Location = new System.Drawing.Point(468, 16);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Size = new System.Drawing.Size(171, 251);
            this.gbxFiltros.TabIndex = 10;
            this.gbxFiltros.TabStop = false;
            this.gbxFiltros.Text = "Filtros";
            // 
            // cbxCartArquivado
            // 
            this.cbxCartArquivado.AutoSize = true;
            this.cbxCartArquivado.Location = new System.Drawing.Point(11, 68);
            this.cbxCartArquivado.Name = "cbxCartArquivado";
            this.cbxCartArquivado.Size = new System.Drawing.Size(154, 17);
            this.cbxCartArquivado.TabIndex = 10;
            this.cbxCartArquivado.Text = "Importar Cartão Arquivados";
            this.cbxCartArquivado.UseVisualStyleBackColor = true;
            // 
            // gbxImportacoes
            // 
            this.gbxImportacoes.Controls.Add(this.rbWebApi);
            this.gbxImportacoes.Controls.Add(this.rbArquivo);
            this.gbxImportacoes.Location = new System.Drawing.Point(6, 19);
            this.gbxImportacoes.Name = "gbxImportacoes";
            this.gbxImportacoes.Size = new System.Drawing.Size(159, 42);
            this.gbxImportacoes.TabIndex = 9;
            this.gbxImportacoes.TabStop = false;
            this.gbxImportacoes.Text = "Opções de Importação";
            // 
            // rbWebApi
            // 
            this.rbWebApi.AutoSize = true;
            this.rbWebApi.Checked = true;
            this.rbWebApi.Location = new System.Drawing.Point(82, 19);
            this.rbWebApi.Name = "rbWebApi";
            this.rbWebApi.Size = new System.Drawing.Size(71, 17);
            this.rbWebApi.TabIndex = 1;
            this.rbWebApi.TabStop = true;
            this.rbWebApi.Text = "Web API ";
            this.rbWebApi.UseVisualStyleBackColor = true;
            this.rbWebApi.CheckedChanged += new System.EventHandler(this.rbArquivo_CheckedChanged);
            this.rbWebApi.Click += new System.EventHandler(this.rbArquivo_Click);
            // 
            // rbArquivo
            // 
            this.rbArquivo.AutoSize = true;
            this.rbArquivo.Location = new System.Drawing.Point(6, 19);
            this.rbArquivo.Name = "rbArquivo";
            this.rbArquivo.Size = new System.Drawing.Size(61, 17);
            this.rbArquivo.TabIndex = 0;
            this.rbArquivo.Text = "Arquivo";
            this.rbArquivo.UseVisualStyleBackColor = true;
            this.rbArquivo.CheckedChanged += new System.EventHandler(this.rbArquivo_CheckedChanged);
            this.rbArquivo.Click += new System.EventHandler(this.rbArquivo_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnImportar.Location = new System.Drawing.Point(365, 28);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(99, 23);
            this.btnImportar.TabIndex = 8;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Logs do processo.";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 84);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(630, 156);
            this.listBox1.TabIndex = 6;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 250);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(642, 20);
            this.progressBar1.TabIndex = 5;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 270);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importação de Arquivos - Trello";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxPathTrello.ResumeLayout(false);
            this.gbxPathTrello.PerformLayout();
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            this.gbxImportacoes.ResumeLayout(false);
            this.gbxImportacoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        protected internal System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.GroupBox gbxImportacoes;
        private System.Windows.Forms.RadioButton rbWebApi;
        private System.Windows.Forms.RadioButton rbArquivo;
        private System.Windows.Forms.GroupBox gbxFiltros;
        private System.Windows.Forms.CheckBox cbxCartArquivado;
        private System.Windows.Forms.GroupBox gbxPathTrello;
        private System.Windows.Forms.Button btnLocalizar;
        private System.Windows.Forms.TextBox txtPathArquivo;
    }
}

