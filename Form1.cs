using CobraConcertos.dao;
using System;
using System.Data;
using System.Windows.Forms;

namespace CobraConcertos
{
    public partial class Form1 : Form
    {

        private bool ativou = false;

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
            OrcamentoDao Orc = new OrcamentoDao();
            int diaAtual = DateTime.Now.Day;
            if (UltAtu==0)
            {
                Orc.InicializaCobrancas();
                cINI.WriteInt("Cobranca", "Atualizacao", diaAtual);
            } else
            {                
                bool atualizar = (diaAtual != UltAtu);
                if (atualizar)
                {
                    int i = 0;
                }
            }
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
            txNome.Text = row.Cells["Cliente"].Value.ToString();
            txFone.Text = row.Cells["Telefone"].Value.ToString();
            txEmail.Text = row.Cells["email"].Value.ToString();
            txObsConserto.Text = row.Cells["Obs"].Value.ToString();
            txObsCliente.Text = row.Cells["Observacao"].Value.ToString();
            txCgcCpf.Text = row.Cells["CgcCpf"].Value.ToString();
            cbAtrasado.Checked = Convert.ToBoolean(row.Cells["EmAtraso"].Value);
            cbFuncionario.Checked = Convert.ToBoolean(row.Cells["funcionario"].Value);
        }

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
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                MostrarDados(row);
            }
        }



    }

}
