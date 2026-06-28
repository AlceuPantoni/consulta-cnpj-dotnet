namespace ConsultaCnpj.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lblTitulo = new Label();
            lblSubTitulo = new Label();
            grpArquivoEntrada = new GroupBox();
            lblStatusArquivo = new Label();
            btnCarregarPlanilha = new Button();
            lblLocalArquivo = new Label();
            txtLocalArquivo = new TextBox();
            grpProgresso = new GroupBox();
            lblProgStatus2 = new Label();
            lblProgStatus1 = new Label();
            progBar = new ProgressBar();
            btnCancelar = new Button();
            btnIniciar = new Button();
            btnSalvarResultado = new Button();
            imgLogo = new PictureBox();
            linkApi = new LinkLabel();
            grpLog = new GroupBox();
            txtLogs = new RichTextBox();
            grpArquivoEntrada.SuspendLayout();
            grpProgresso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgLogo).BeginInit();
            grpLog.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(18, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(156, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Consulta CNPJ";
            // 
            // lblSubTitulo
            // 
            lblSubTitulo.AutoSize = true;
            lblSubTitulo.Location = new Point(21, 44);
            lblSubTitulo.Name = "lblSubTitulo";
            lblSubTitulo.Size = new Size(244, 15);
            lblSubTitulo.TabIndex = 1;
            lblSubTitulo.Text = "Consulta automática de CNPJs via ReceitaWS";
            // 
            // grpArquivoEntrada
            // 
            grpArquivoEntrada.Controls.Add(lblStatusArquivo);
            grpArquivoEntrada.Controls.Add(btnCarregarPlanilha);
            grpArquivoEntrada.Controls.Add(lblLocalArquivo);
            grpArquivoEntrada.Controls.Add(txtLocalArquivo);
            grpArquivoEntrada.Location = new Point(18, 95);
            grpArquivoEntrada.Name = "grpArquivoEntrada";
            grpArquivoEntrada.Size = new Size(654, 84);
            grpArquivoEntrada.TabIndex = 2;
            grpArquivoEntrada.TabStop = false;
            grpArquivoEntrada.Text = "Arquivo de entrada";
            // 
            // lblStatusArquivo
            // 
            lblStatusArquivo.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblStatusArquivo.Location = new Point(107, 58);
            lblStatusArquivo.Name = "lblStatusArquivo";
            lblStatusArquivo.Size = new Size(409, 15);
            lblStatusArquivo.TabIndex = 4;
            lblStatusArquivo.Text = "Nenhum arquivo carregado";
            // 
            // btnCarregarPlanilha
            // 
            btnCarregarPlanilha.BackColor = SystemColors.ActiveBorder;
            btnCarregarPlanilha.FlatAppearance.BorderColor = Color.White;
            btnCarregarPlanilha.FlatAppearance.BorderSize = 0;
            btnCarregarPlanilha.FlatStyle = FlatStyle.System;
            btnCarregarPlanilha.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCarregarPlanilha.ForeColor = SystemColors.ActiveCaptionText;
            btnCarregarPlanilha.Location = new Point(525, 30);
            btnCarregarPlanilha.Name = "btnCarregarPlanilha";
            btnCarregarPlanilha.Size = new Size(123, 23);
            btnCarregarPlanilha.TabIndex = 2;
            btnCarregarPlanilha.Text = "Selecionar planilha";
            btnCarregarPlanilha.UseVisualStyleBackColor = false;
            btnCarregarPlanilha.MouseClick += btnCarregarPlanilha_MouseClick;
            // 
            // lblLocalArquivo
            // 
            lblLocalArquivo.AutoSize = true;
            lblLocalArquivo.Location = new Point(6, 34);
            lblLocalArquivo.Name = "lblLocalArquivo";
            lblLocalArquivo.Size = new Size(98, 15);
            lblLocalArquivo.TabIndex = 1;
            lblLocalArquivo.Text = "Local do arquivo:";
            // 
            // txtLocalArquivo
            // 
            txtLocalArquivo.Enabled = false;
            txtLocalArquivo.Location = new Point(107, 30);
            txtLocalArquivo.Name = "txtLocalArquivo";
            txtLocalArquivo.PlaceholderText = "Clique no botão ao lado para selecionar a planilha contendo os CNPJs";
            txtLocalArquivo.ReadOnly = true;
            txtLocalArquivo.Size = new Size(409, 23);
            txtLocalArquivo.TabIndex = 0;
            // 
            // grpProgresso
            // 
            grpProgresso.Controls.Add(lblProgStatus2);
            grpProgresso.Controls.Add(lblProgStatus1);
            grpProgresso.Controls.Add(progBar);
            grpProgresso.Location = new Point(18, 192);
            grpProgresso.Name = "grpProgresso";
            grpProgresso.Size = new Size(654, 100);
            grpProgresso.TabIndex = 3;
            grpProgresso.TabStop = false;
            grpProgresso.Text = "Progresso da consulta";
            // 
            // lblProgStatus2
            // 
            lblProgStatus2.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblProgStatus2.Location = new Point(7, 76);
            lblProgStatus2.Name = "lblProgStatus2";
            lblProgStatus2.Size = new Size(640, 15);
            lblProgStatus2.TabIndex = 2;
            lblProgStatus2.Text = "Consulta não iniciada";
            // 
            // lblProgStatus1
            // 
            lblProgStatus1.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblProgStatus1.Location = new Point(7, 57);
            lblProgStatus1.Name = "lblProgStatus1";
            lblProgStatus1.Size = new Size(640, 15);
            lblProgStatus1.TabIndex = 1;
            lblProgStatus1.Text = "Aguardando seleção de um arquivo válido";
            // 
            // progBar
            // 
            progBar.Location = new Point(7, 23);
            progBar.Name = "progBar";
            progBar.Size = new Size(640, 25);
            progBar.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlDarkDark;
            btnCancelar.FlatStyle = FlatStyle.System;
            btnCancelar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = SystemColors.ButtonFace;
            btnCancelar.Location = new Point(18, 535);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 32);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.MouseClick += btnCancelar_MouseClick;
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = SystemColors.HotTrack;
            btnIniciar.FlatStyle = FlatStyle.System;
            btnIniciar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciar.ForeColor = SystemColors.ButtonFace;
            btnIniciar.Location = new Point(275, 535);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(140, 32);
            btnIniciar.TabIndex = 5;
            btnIniciar.Text = "Iniciar consulta";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.MouseClick += btnIniciar_MouseClick;
            // 
            // btnSalvarResultado
            // 
            btnSalvarResultado.BackColor = Color.Green;
            btnSalvarResultado.FlatStyle = FlatStyle.System;
            btnSalvarResultado.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvarResultado.ForeColor = SystemColors.ButtonFace;
            btnSalvarResultado.Location = new Point(526, 535);
            btnSalvarResultado.Name = "btnSalvarResultado";
            btnSalvarResultado.Size = new Size(140, 32);
            btnSalvarResultado.TabIndex = 6;
            btnSalvarResultado.Text = "Salvar Resultado";
            btnSalvarResultado.UseVisualStyleBackColor = false;
            btnSalvarResultado.MouseClick += btnSalvarResultado_MouseClick;
            // 
            // imgLogo
            // 
            imgLogo.Image = Properties.Resources.logo;
            imgLogo.Location = new Point(526, 7);
            imgLogo.Name = "imgLogo";
            imgLogo.Size = new Size(146, 61);
            imgLogo.SizeMode = PictureBoxSizeMode.Zoom;
            imgLogo.TabIndex = 7;
            imgLogo.TabStop = false;
            // 
            // linkApi
            // 
            linkApi.AutoSize = true;
            linkApi.Location = new Point(530, 72);
            linkApi.Name = "linkApi";
            linkApi.Size = new Size(137, 15);
            linkApi.TabIndex = 8;
            linkApi.TabStop = true;
            linkApi.Text = "https://receitaws.com.br";
            linkApi.LinkClicked += linkApi_LinkClicked;
            // 
            // grpLog
            // 
            grpLog.Controls.Add(txtLogs);
            grpLog.Location = new Point(18, 306);
            grpLog.Name = "grpLog";
            grpLog.Size = new Size(654, 219);
            grpLog.TabIndex = 9;
            grpLog.TabStop = false;
            grpLog.Text = "Logs";
            // 
            // txtLogs
            // 
            txtLogs.BorderStyle = BorderStyle.None;
            txtLogs.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLogs.Location = new Point(5, 17);
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtLogs.Size = new Size(643, 195);
            txtLogs.TabIndex = 0;
            txtLogs.Text = "";
            txtLogs.WordWrap = false;
            // 
            // MainForm
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(684, 577);
            Controls.Add(grpLog);
            Controls.Add(linkApi);
            Controls.Add(imgLogo);
            Controls.Add(btnSalvarResultado);
            Controls.Add(btnIniciar);
            Controls.Add(btnCancelar);
            Controls.Add(grpProgresso);
            Controls.Add(grpArquivoEntrada);
            Controls.Add(lblSubTitulo);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta CNPJ - ReceitaWS";
            grpArquivoEntrada.ResumeLayout(false);
            grpArquivoEntrada.PerformLayout();
            grpProgresso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imgLogo).EndInit();
            grpLog.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubTitulo;
        private GroupBox grpArquivoEntrada;
        private Button btnCarregarPlanilha;
        private Label lblLocalArquivo;
        private TextBox txtLocalArquivo;
        private Label lblStatusArquivo;
        private GroupBox grpProgresso;
        private Label lblProgStatus2;
        private Label lblProgStatus1;
        private ProgressBar progBar;
        private Button btnCancelar;
        private Button btnIniciar;
        private Button btnSalvarResultado;
        private PictureBox imgLogo;
        private LinkLabel linkApi;
        private GroupBox grpLog;
        private RichTextBox txtLogs;
    }
}