﻿
namespace TeleBonifacio
{
    partial class operCaixa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(operCaixa));
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txDesc = new System.Windows.Forms.TextBox();
            this.lbTotal = new System.Windows.Forms.Label();
            this.dtpDataIN = new System.Windows.Forms.DateTimePicker();
            this.txObs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txCompra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnNovoCliente = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btItau = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.dtnDtFim = new System.Windows.Forms.DateTimePicker();
            this.btExcluir = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btDespeza = new System.Windows.Forms.Button();
            this.btPix = new System.Windows.Forms.Button();
            this.btDinheiro = new System.Windows.Forms.Button();
            this.btCartao = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGridView();
            this.btSicred = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.DisplayMember = "Nome";
            this.cmbVendedor.Location = new System.Drawing.Point(82, 40);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(266, 21);
            this.cmbVendedor.TabIndex = 34;
            this.cmbVendedor.ValueMember = "Id";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "Vendedor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(365, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "Desconto";
            // 
            // txDesc
            // 
            this.txDesc.Location = new System.Drawing.Point(437, 40);
            this.txDesc.Name = "txDesc";
            this.txDesc.Size = new System.Drawing.Size(56, 20);
            this.txDesc.TabIndex = 31;
            this.txDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txDesc_KeyUp);
            // 
            // lbTotal
            // 
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(512, 39);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(83, 23);
            this.lbTotal.TabIndex = 30;
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDataIN
            // 
            this.dtpDataIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpDataIN.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataIN.Location = new System.Drawing.Point(419, 120);
            this.dtpDataIN.Name = "dtpDataIN";
            this.dtpDataIN.Size = new System.Drawing.Size(90, 23);
            this.dtpDataIN.TabIndex = 29;
            this.dtpDataIN.Tag = "H";
            // 
            // txObs
            // 
            this.txObs.Location = new System.Drawing.Point(185, 121);
            this.txObs.Name = "txObs";
            this.txObs.Size = new System.Drawing.Size(228, 20);
            this.txObs.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(96, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Observação";
            // 
            // txCompra
            // 
            this.txCompra.Location = new System.Drawing.Point(437, 12);
            this.txCompra.Name = "txCompra";
            this.txCompra.Size = new System.Drawing.Size(56, 20);
            this.txCompra.TabIndex = 15;
            this.txCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txCompra.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txCompra_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(375, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Compra";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DisplayMember = "Nome";
            this.cmbCliente.Location = new System.Drawing.Point(82, 12);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(266, 21);
            this.cmbCliente.TabIndex = 24;
            this.cmbCliente.ValueMember = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Cliente";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLimpar.Enabled = false;
            this.btnLimpar.Location = new System.Drawing.Point(841, 120);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 16;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnFiltrar.Location = new System.Drawing.Point(619, 120);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 18;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnNovoCliente
            // 
            this.btnNovoCliente.Location = new System.Drawing.Point(12, 115);
            this.btnNovoCliente.Name = "btnNovoCliente";
            this.btnNovoCliente.Size = new System.Drawing.Size(83, 23);
            this.btnNovoCliente.TabIndex = 19;
            this.btnNovoCliente.Text = "Novo Cliente";
            this.btnNovoCliente.Click += new System.EventHandler(this.btnNovoCliente_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btSicred);
            this.panel1.Controls.Add(this.btItau);
            this.panel1.Controls.Add(this.btEditar);
            this.panel1.Controls.Add(this.dtnDtFim);
            this.panel1.Controls.Add(this.btExcluir);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btDespeza);
            this.panel1.Controls.Add(this.btPix);
            this.panel1.Controls.Add(this.btDinheiro);
            this.panel1.Controls.Add(this.btCartao);
            this.panel1.Controls.Add(this.cmbVendedor);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txDesc);
            this.panel1.Controls.Add(this.lbTotal);
            this.panel1.Controls.Add(this.dtpDataIN);
            this.panel1.Controls.Add(this.txObs);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txCompra);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbCliente);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnLimpar);
            this.panel1.Controls.Add(this.btnFiltrar);
            this.panel1.Controls.Add(this.btnNovoCliente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 156);
            this.panel1.TabIndex = 13;
            // 
            // btItau
            // 
            this.btItau.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btItau.Enabled = false;
            this.btItau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btItau.Location = new System.Drawing.Point(485, 79);
            this.btItau.Name = "btItau";
            this.btItau.Size = new System.Drawing.Size(75, 23);
            this.btItau.TabIndex = 43;
            this.btItau.Text = "Itaú";
            this.btItau.Click += new System.EventHandler(this.btItau_Click);
            // 
            // btEditar
            // 
            this.btEditar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btEditar.Location = new System.Drawing.Point(647, 79);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(75, 23);
            this.btEditar.TabIndex = 42;
            this.btEditar.Text = "Editar";
            this.btEditar.UseVisualStyleBackColor = false;
            this.btEditar.Visible = false;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // dtnDtFim
            // 
            this.dtnDtFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtnDtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtnDtFim.Location = new System.Drawing.Point(515, 120);
            this.dtnDtFim.Name = "dtnDtFim";
            this.dtnDtFim.Size = new System.Drawing.Size(90, 23);
            this.dtnDtFim.TabIndex = 41;
            this.dtnDtFim.Tag = "H";
            // 
            // btExcluir
            // 
            this.btExcluir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btExcluir.Location = new System.Drawing.Point(728, 79);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 23);
            this.btExcluir.TabIndex = 40;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = false;
            this.btExcluir.Visible = false;
            this.btExcluir.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button5.Location = new System.Drawing.Point(841, 91);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 39;
            this.button5.Text = "Relatório";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btDespeza
            // 
            this.btDespeza.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDespeza.Enabled = false;
            this.btDespeza.Location = new System.Drawing.Point(404, 78);
            this.btDespeza.Name = "btDespeza";
            this.btDespeza.Size = new System.Drawing.Size(75, 23);
            this.btDespeza.TabIndex = 38;
            this.btDespeza.Text = "Despeza";
            this.btDespeza.Click += new System.EventHandler(this.btTroco_Click);
            // 
            // btPix
            // 
            this.btPix.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btPix.Enabled = false;
            this.btPix.Location = new System.Drawing.Point(323, 79);
            this.btPix.Name = "btPix";
            this.btPix.Size = new System.Drawing.Size(75, 23);
            this.btPix.TabIndex = 37;
            this.btPix.Text = "Pix";
            this.btPix.Click += new System.EventHandler(this.btPix_Click);
            // 
            // btDinheiro
            // 
            this.btDinheiro.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDinheiro.Enabled = false;
            this.btDinheiro.Location = new System.Drawing.Point(161, 79);
            this.btDinheiro.Name = "btDinheiro";
            this.btDinheiro.Size = new System.Drawing.Size(75, 23);
            this.btDinheiro.TabIndex = 36;
            this.btDinheiro.Text = "Dinheiro";
            this.btDinheiro.Click += new System.EventHandler(this.btDinheiro_Click);
            // 
            // btCartao
            // 
            this.btCartao.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btCartao.Enabled = false;
            this.btCartao.Location = new System.Drawing.Point(242, 79);
            this.btCartao.Name = "btCartao";
            this.btCartao.Size = new System.Drawing.Size(75, 23);
            this.btCartao.TabIndex = 35;
            this.btCartao.Text = "Cartão";
            this.btCartao.Click += new System.EventHandler(this.btCartao_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowUserToAddRows = false;
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.Location = new System.Drawing.Point(0, 156);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid1.Size = new System.Drawing.Size(928, 216);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid1_CellClick);
            // 
            // btSicred
            // 
            this.btSicred.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btSicred.Enabled = false;
            this.btSicred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSicred.Location = new System.Drawing.Point(566, 79);
            this.btSicred.Name = "btSicred";
            this.btSicred.Size = new System.Drawing.Size(75, 23);
            this.btSicred.TabIndex = 44;
            this.btSicred.Text = "Sicred";
            this.btSicred.Click += new System.EventHandler(this.btSicred_Click);
            // 
            // operCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 372);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "operCaixa";
            this.Text = "Operação de Caixa";
            this.Load += new System.EventHandler(this.operCaixa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbVendedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txDesc;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.DateTimePicker dtpDataIN;
        private System.Windows.Forms.TextBox txObs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txCompra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnNovoCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btDespeza;
        private System.Windows.Forms.Button btPix;
        private System.Windows.Forms.Button btDinheiro;
        private System.Windows.Forms.Button btCartao;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.DateTimePicker dtnDtFim;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.DataGridView dataGrid1;
        private System.Windows.Forms.Button btItau;
        private System.Windows.Forms.Button btSicred;
    }
}

