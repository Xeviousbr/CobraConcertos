using CobraConcertos.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CobraConcertos
{
    public partial class Form1 : Form
    {

        private bool atualizando = true;
        private int nrOrc;
        private Color CorOrig;
        private Color CorAlt = Color.FromArgb(255, 255, 200);
        private OrcamentoDao Orc;

        public Form1()
        {
            InitializeComponent();
            SetStartPosition();
        }

        private void SetStartPosition()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = 0;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            INI cINI = new INI();
            int UltAtu = cINI.ReadInt("Cobranca", "Atualizacao", 0);
            Orc = new OrcamentoDao();
            int diaAtual = DateTime.Now.Day;
            if (UltAtu == 0)
            {
                Orc.InicializaCobrancas();
                cINI.WriteInt("Cobranca", "Atualizacao", diaAtual);
            }
            else
            {
                bool atualizar = (diaAtual != UltAtu);
                if (atualizar)
                {
                    Orc.Atualiza();
                    cINI.WriteInt("Cobranca", "Atualizacao", diaAtual);
                }
            }            
            CarregaGrid();
            atualizando = false;
            CorOrig = txNome.BackColor;
        }

        private void CarregaGrid()
        {
            DataTable dados = Orc.getDados();
            dataGridView1.DataSource = dados;
            dataGridView1.Columns["dataalteracao"].Width = 80; // Largura para exibir apenas a data
            dataGridView1.Columns["dataalteracao"].DefaultCellStyle.Format = "dd/MM/yyyy"; // Formato de data
            dataGridView1.Columns["Cliente"].Width = 200; // Largura para 30 caracteres
            dataGridView1.Columns["Total"].Width = 60; // Largura para 6 caracteres
            dataGridView1.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Alinhado à direita
            dataGridView1.Columns["Total"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["Obs"].Width = 120; // Largura para 20 caracteres
            dataGridView1.Columns["Telefone"].Width = 100; // Largura apropriada para dois telefones e uma separação

            // Tornando as outras colunas invisíveis
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "dataalteracao" &&
                    column.Name != "Cliente" &&
                    column.Name != "Total" &&
                    column.Name != "Obs" &&
                    column.Name != "Telefone")
                {
                    column.Visible = false;
                }
            }
        }

        private void MostrarDados(DataGridViewRow row)
        {
            atualizando = true;
            nrOrc = Convert.ToInt32(row.Cells["Orcamento"].Value);
            txNome.Text = row.Cells["Cliente"].Value.ToString();
            txFone.Text = row.Cells["Telefone"].Value.ToString();
            txEmail.Text = row.Cells["email"].Value.ToString();
            txObsConserto.Text = row.Cells["Obs"].Value.ToString();
            txObsCliente.Text = row.Cells["Observacao"].Value.ToString();
            txCgcCpf.Text = row.Cells["CgcCpf"].Value.ToString();
            cbAtrasado.Checked = Convert.ToBoolean(row.Cells["EmAtraso"].Value);
            cbFuncionario.Checked = Convert.ToBoolean(row.Cells["funcionario"].Value);
            if (decimal.TryParse(row.Cells["Total"].Value.ToString(), out decimal total))
            {
                txValor.Text = total.ToString("C2");
            }
            else
            {
                txValor.Text = row.Cells["Total"].Value.ToString(); // Caso o valor não seja um número válido
            }
            ResetTextBoxColors(this);
            atualizando = false;
        }

        #region Eventos

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                MostrarDados(row);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MostraEmCima();
                btPagou.Enabled = (dataGridView1.SelectedRows.Count == 1);
            }
        }

        private void MostraEmCima()
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            MostrarDados(row);
            btPagou.Enabled = (dataGridView1.SelectedRows.Count == 1);
        }

        private void txNome_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey || (e.Control && e.KeyCode == Keys.C))
            {
                // Não fazer nada
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                ResetTextBoxColors(this);
                MostraEmCima();
                btGravar.Enabled = false;
            }
            else
            {
                btGravar.Enabled = true;
                TextBox obj = (TextBox)sender;
                obj.BackColor = CorAlt;
            }
        }

        private void ResetTextBoxColors(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BackColor = CorOrig;
                }
                if (control is CheckBox Ck)
                {
                    Ck.ForeColor = Color.Black;
                }

                // Chamada recursiva para percorrer controles filhos
                if (control.Controls.Count > 0)
                {
                    ResetTextBoxColors(control);
                }
            }
        }

        private void ZeraTextos(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = "";
                }
                if (control is CheckBox Ck)
                {
                    Ck.Checked = false;
                }

                // Chamada recursiva para percorrer controles filhos
                if (control.Controls.Count > 0)
                {
                    ZeraTextos(control);
                }
            }
            ResetTextBoxColors(parent);
        }

        private void cbAtrasado_Click(object sender, EventArgs e)
        {
            if (!atualizando)
            {
                CheckBox obj = (CheckBox)sender;
                obj.ForeColor = Color.Green;
                btGravar.Enabled = true;
            }
        }

        private void btPagou_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja marcar todos os registros como pagos?",
                                                  "Confirmar Atualização",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.Cells["Orcamento"].Value != null)
                    {
                        int orcamentoId = Convert.ToInt32(row.Cells["Orcamento"].Value);
                        sb.Append(orcamentoId).Append(",");
                    }
                }
                sb.Length--;
                Orc.Pagou(sb.ToString());
                CarregaGrid();
            }
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            bool grvCli = false;
            bool grvOrc = false;            
            String CgcCpf = null;
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            if (txCgcCpf.BackColor == CorAlt)
            {
                if (txCgcCpf.Text.Length>0)
                {
                    if (ValidarCPF(txCgcCpf.Text) || ValidarCNPJ(txCgcCpf.Text))
                    {
                        grvCli = true;
                        CgcCpf = txCgcCpf.Text;
                    }
                    else
                    {
                        // Avisar que o CGC ou CPF está errado e sair do método
                        MessageBox.Show("O CGC ou CPF informado está incorreto. Por favor, verifique e tente novamente.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            String sEmail = null;
            if (txEmail.BackColor == CorAlt)
            {
                if (txEmail.Text.Length>0)
                {
                    sEmail = txEmail.Text.TrimStart();
                    if (!ValidarEmail(sEmail))
                    {
                        // Avisar que o email é inválido e sair do método
                        MessageBox.Show("O email informado está incorreto. Por favor, verifique e tente novamente.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }                
                grvCli = true;
            }
            String sNome = null;
            if (txNome.BackColor == CorAlt)
            {
                grvCli = true;
                grvOrc = true;
                sNome = txNome.Text;
                row.Cells["Cliente"].Value = sNome;
            }
            String ObsCliente = null;
            if (txObsCliente.BackColor == CorAlt) {
                grvCli = true;
                ObsCliente = txObsCliente.Text;
            }
            String sFone = null;
            if (txFone.BackColor == CorAlt) {
                grvCli = true;
                sFone = txFone.Text;
            }
            Boolean? bAtrasado = null;
            if (cbAtrasado.ForeColor == Color.Green)
            {
                grvCli = true;
                bAtrasado = cbAtrasado.Checked;
            }
            Boolean? bFuncionario = null;
            if (cbFuncionario.ForeColor == Color.Green)
            {
                grvCli = true;
                bFuncionario = cbFuncionario.Checked;
            }
            String ObsOrc = null;
            if (txObsConserto.BackColor == CorAlt)
            {
                ObsOrc = txObsConserto.Text.TrimStart();
                grvOrc = true;
            }
            if (grvOrc)
            {
                Orc.GravaOrc(nrOrc, ObsOrc, sNome);
                if (ObsOrc != null)
                {
                    ZeraTextos(this);
                    CarregaGrid();
                }
            }
            if (grvCli)
            {
                Orc.GravaCli(txNome.Text, sNome, CgcCpf, ObsCliente, sFone, sEmail, bAtrasado, bFuncionario);
                if (ObsOrc==null)
                {
                    ResetTextBoxColors(this);
                }                
            }
        }

        #endregion

        #region Validacoes

        private bool ValidarCPF(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = cpf.Replace(".", "").Replace("-", "").Trim();

            // Verifica se o comprimento é 11
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (CPF inválido)
            bool todosDigitosIguais = true;
            for (int i = 1; i < 11 && todosDigitosIguais; i++)
            {
                if (cpf[i] != cpf[0])
                    todosDigitosIguais = false;
            }
            if (todosDigitosIguais)
                return false;

            // Calcula os dígitos verificadores
            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        private bool ValidarCNPJ(string cnpj)
        {
            // Remove caracteres não numéricos
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Trim();

            // Verifica se o comprimento é 14
            if (cnpj.Length != 14)
                return false;

            // Verifica se todos os dígitos são iguais (CNPJ inválido)
            bool todosDigitosIguais = true;
            for (int i = 1; i < 14 && todosDigitosIguais; i++)
            {
                if (cnpj[i] != cnpj[0])
                    todosDigitosIguais = false;
            }
            if (todosDigitosIguais)
                return false;

            // Calcula os dígitos verificadores
            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        private bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        #endregion
    }
}
