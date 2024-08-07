namespace CobraConcertos
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btGravar = new System.Windows.Forms.Button();
            this.btPagou = new System.Windows.Forms.Button();
            this.txValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txFone = new System.Windows.Forms.TextBox();
            this.labelFone = new System.Windows.Forms.Label();
            this.txNome = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.txEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.txObsConserto = new System.Windows.Forms.TextBox();
            this.labelObsConserto = new System.Windows.Forms.Label();
            this.txObsCliente = new System.Windows.Forms.TextBox();
            this.labelObsCliente = new System.Windows.Forms.Label();
            this.txCgcCpf = new System.Windows.Forms.TextBox();
            this.labelCgcCpf = new System.Windows.Forms.Label();
            this.cbAtrasado = new System.Windows.Forms.CheckBox();
            this.cbFuncionario = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 184);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(637, 300);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btGravar);
            this.panel1.Controls.Add(this.btPagou);
            this.panel1.Controls.Add(this.txValor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txFone);
            this.panel1.Controls.Add(this.labelFone);
            this.panel1.Controls.Add(this.txNome);
            this.panel1.Controls.Add(this.labelNome);
            this.panel1.Controls.Add(this.txEmail);
            this.panel1.Controls.Add(this.labelEmail);
            this.panel1.Controls.Add(this.txObsConserto);
            this.panel1.Controls.Add(this.labelObsConserto);
            this.panel1.Controls.Add(this.txObsCliente);
            this.panel1.Controls.Add(this.labelObsCliente);
            this.panel1.Controls.Add(this.txCgcCpf);
            this.panel1.Controls.Add(this.labelCgcCpf);
            this.panel1.Controls.Add(this.cbAtrasado);
            this.panel1.Controls.Add(this.cbFuncionario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 184);
            this.panel1.TabIndex = 1;
            // 
            // btGravar
            // 
            this.btGravar.Enabled = false;
            this.btGravar.Location = new System.Drawing.Point(550, 149);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 17;
            this.btGravar.Text = "Gravar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btPagou
            // 
            this.btPagou.Location = new System.Drawing.Point(550, 106);
            this.btPagou.Name = "btPagou";
            this.btPagou.Size = new System.Drawing.Size(75, 23);
            this.btPagou.TabIndex = 16;
            this.btPagou.Text = "Pagou";
            this.btPagou.UseVisualStyleBackColor = true;
            this.btPagou.Click += new System.EventHandler(this.btPagou_Click);
            // 
            // txValor
            // 
            this.txValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txValor.Location = new System.Drawing.Point(409, 64);
            this.txValor.Name = "txValor";
            this.txValor.ReadOnly = true;
            this.txValor.Size = new System.Drawing.Size(80, 22);
            this.txValor.TabIndex = 15;
            this.txValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(407, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Valor";
            // 
            // txFone
            // 
            this.txFone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txFone.Location = new System.Drawing.Point(257, 25);
            this.txFone.Name = "txFone";
            this.txFone.Size = new System.Drawing.Size(144, 22);
            this.txFone.TabIndex = 3;
            this.txFone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txNome_KeyUp);
            // 
            // labelFone
            // 
            this.labelFone.AutoSize = true;
            this.labelFone.Location = new System.Drawing.Point(254, 9);
            this.labelFone.Name = "labelFone";
            this.labelFone.Size = new System.Drawing.Size(49, 13);
            this.labelFone.TabIndex = 2;
            this.labelFone.Text = "Telefone";
            // 
            // txNome
            // 
            this.txNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txNome.Location = new System.Drawing.Point(12, 25);
            this.txNome.Name = "txNome";
            this.txNome.Size = new System.Drawing.Size(239, 22);
            this.txNome.TabIndex = 1;
            this.txNome.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txNome_KeyUp);
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(12, 9);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(35, 13);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome";
            // 
            // txEmail
            // 
            this.txEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txEmail.Location = new System.Drawing.Point(12, 64);
            this.txEmail.Name = "txEmail";
            this.txEmail.Size = new System.Drawing.Size(389, 22);
            this.txEmail.TabIndex = 5;
            this.txEmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txNome_KeyUp);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(12, 48);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email";
            // 
            // txObsConserto
            // 
            this.txObsConserto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txObsConserto.Location = new System.Drawing.Point(12, 106);
            this.txObsConserto.Name = "txObsConserto";
            this.txObsConserto.Size = new System.Drawing.Size(532, 22);
            this.txObsConserto.TabIndex = 7;
            this.txObsConserto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txNome_KeyUp);
            // 
            // labelObsConserto
            // 
            this.labelObsConserto.AutoSize = true;
            this.labelObsConserto.Location = new System.Drawing.Point(12, 90);
            this.labelObsConserto.Name = "labelObsConserto";
            this.labelObsConserto.Size = new System.Drawing.Size(125, 13);
            this.labelObsConserto.TabIndex = 6;
            this.labelObsConserto.Text = "Observação do Conserto";
            // 
            // txObsCliente
            // 
            this.txObsCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txObsCliente.Location = new System.Drawing.Point(12, 149);
            this.txObsCliente.Name = "txObsCliente";
            this.txObsCliente.Size = new System.Drawing.Size(532, 22);
            this.txObsCliente.TabIndex = 9;
            this.txObsCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txNome_KeyUp);
            // 
            // labelObsCliente
            // 
            this.labelObsCliente.AutoSize = true;
            this.labelObsCliente.Location = new System.Drawing.Point(12, 133);
            this.labelObsCliente.Name = "labelObsCliente";
            this.labelObsCliente.Size = new System.Drawing.Size(115, 13);
            this.labelObsCliente.TabIndex = 8;
            this.labelObsCliente.Text = "Observação do Cliente";
            // 
            // txCgcCpf
            // 
            this.txCgcCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txCgcCpf.Location = new System.Drawing.Point(510, 64);
            this.txCgcCpf.Name = "txCgcCpf";
            this.txCgcCpf.Size = new System.Drawing.Size(115, 22);
            this.txCgcCpf.TabIndex = 11;
            this.txCgcCpf.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txNome_KeyUp);
            // 
            // labelCgcCpf
            // 
            this.labelCgcCpf.AutoSize = true;
            this.labelCgcCpf.Location = new System.Drawing.Point(507, 48);
            this.labelCgcCpf.Name = "labelCgcCpf";
            this.labelCgcCpf.Size = new System.Drawing.Size(67, 13);
            this.labelCgcCpf.TabIndex = 10;
            this.labelCgcCpf.Text = "CGC ou CPF";
            // 
            // cbAtrasado
            // 
            this.cbAtrasado.Location = new System.Drawing.Point(409, 23);
            this.cbAtrasado.Name = "cbAtrasado";
            this.cbAtrasado.Size = new System.Drawing.Size(80, 24);
            this.cbAtrasado.TabIndex = 12;
            this.cbAtrasado.Text = "Atrasado";
            this.cbAtrasado.Click += new System.EventHandler(this.cbAtrasado_Click);
            // 
            // cbFuncionario
            // 
            this.cbFuncionario.Location = new System.Drawing.Point(510, 21);
            this.cbFuncionario.Name = "cbFuncionario";
            this.cbFuncionario.Size = new System.Drawing.Size(87, 24);
            this.cbFuncionario.TabIndex = 13;
            this.cbFuncionario.Text = "Funcionário";
            this.cbFuncionario.CheckedChanged += new System.EventHandler(this.cbAtrasado_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(637, 484);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Gerenciamento de Cobranças de Consertos";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txNome;
        private System.Windows.Forms.TextBox txEmail;
        private System.Windows.Forms.TextBox txObsConserto;
        private System.Windows.Forms.TextBox txObsCliente;
        private System.Windows.Forms.TextBox txCgcCpf;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox txFone;
        private System.Windows.Forms.Label labelFone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelObsConserto;
        private System.Windows.Forms.Label labelObsCliente;
        private System.Windows.Forms.Label labelCgcCpf;
        private System.Windows.Forms.CheckBox cbAtrasado;
        private System.Windows.Forms.CheckBox cbFuncionario;
        private System.Windows.Forms.TextBox txValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.Button btPagou;
    }
}
