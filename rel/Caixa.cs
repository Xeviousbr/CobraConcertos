﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace TeleBonifacio.rel
{
    public partial class Caixa : Form
    {

        private bool ativou = false;

        private List<Lanctos> relcaixa { get; set; }
        public DateTime DT1 { get; set; }
        public DateTime DT2 { get; set; }

        public Caixa()
        {
            InitializeComponent();
            SetStartPosition();
            rt.AdjustFormComponents(this);
        }

        private void SetStartPosition()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = 0;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private List<Lanctos> CarregaCaixa()
        {
            DateTime? dataInicio = dtpDataIN.Value;
            DateTime dataFim = dtnDtFim.Value;
            int SelTipo = cmbTipo.SelectedIndex;
            string sFiltro = "";
            if (SelTipo>0)
            {
                sFiltro = " and C.idForma = " + retIdForma(cmbTipo.Text);
            }
            string SQL = $@"SELECT C.ID, C.Data, C.Valor, C.Desconto, 
                            C.idForma AS FormaPagto, Obs 
                            FROM Caixa C
                            Where Data Between #{ dataInicio:MM/dd/yyyy HH:ss}# and #{ dataFim:MM/dd/yyyy HH:ss}# {sFiltro} ";
            List<Lanctos> lancamentos = new List<Lanctos>();
            using (OleDbConnection connection = new OleDbConnection(glo.connectionString))
            {
                try
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(SQL, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Lanctos lancamento = new Lanctos();
                                lancamento.ID = (int)reader["ID"];
                                lancamento.DataPagamento = (DateTime)reader["Data"];                                
                                lancamento.Desconto = (decimal)reader["Desconto"];
                                lancamento.idFormaPagto = (int)reader["FormaPagto"];
                                if (lancamento.idFormaPagto == 5)
                                {
                                    lancamento.Entrada = 0;
                                    lancamento.Saida = (decimal)reader["Valor"];
                                }
                                else
                                {
                                    lancamento.Entrada = (decimal)reader["Valor"];
                                    lancamento.Saida = 0;
                                }
                                lancamento.Forma = retFormaId(lancamento.idFormaPagto);
                                lancamento.Saldo = lancamento.Entrada - lancamento.Desconto - lancamento.Saida;
                                lancamento.Obs = (string)reader["Obs"];
                                lancamentos.Add(lancamento);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
            return lancamentos;
        }

        private int retIdForma(string Forma)
        {
            int ret = 5;
            switch (Forma)
            {
                case "Dinheiro":
                    ret = 0;
                    break;
                case "Cartão":
                    ret = 1;
                    break;
                case "Anotado":
                    ret = 2;
                    break;
                case "Pix":
                    ret = 3;
                    break;
                case "Despesa":
                    ret = 5;
                    break;
                case "Itaú":
                    ret = 6;
                    break;
                case "Sicred":
                    ret = 7;
                    break;
            }
            return ret;
        }

        private string retFormaId(int idForma)
        {
            string ret = "";
            switch (idForma)
            {
                case 0:
                    ret = "Dinheiro";
                    break;
                case 1:
                    ret = "Cartão";
                    break;
                case 2:
                    ret = "Anotado";
                    break;
                case 3:
                    ret = "Pix";
                    break;
                case 5:
                    ret = "Despesa";
                    break;
                case 6:
                    ret = "Itau";
                    break;
                case 7:
                    ret = "Sicred";
                    break;
            }
            return ret;
        }

        public void GerarRelCaixa()
        {
            relcaixa = CarregaCaixa();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Extrato de Movimentação do Caixa");
            sb.AppendLine();
            sb.AppendLine($"Período: {dtpDataIN.Value.ToString("dd/MM/yyyy")} a {dtpDataIN.Value.ToString("dd/MM/yyyy")}");
            sb.AppendLine();
            sb.AppendLine("ID       Data     |  Entrada | Desconto |  Saídas |  FormaPagto |  Saldo  | Observação");
            decimal TDinheiro = 0;
            decimal TCartao = 0;
            decimal TPix = 0;
            decimal TDespesa = 0;
            decimal TItau = 0;
            decimal TSicred = 0;
            foreach (var lancos in relcaixa)
            {
                string ID = glo.ComplStr(lancos.ID.ToString(), 4, 2);
                string Data = glo.ComplStr(lancos.DataPagamento.ToString("dd/MM/yyyy"), 10, 2);
                string Entrada = glo.ComplStr(lancos.Entrada.ToString("N2"), 8, 3);
                string Desconto = glo.ComplStr(lancos.Desconto.ToString("N2"), 8, 3);
                string Saidas = glo.ComplStr(lancos.Saida.ToString("N2"), 7, 3);
                string Forma = glo.ComplStr(lancos.Forma, 11, 2);
                string Saldo = glo.ComplStr(lancos.Saldo.ToString("N2"), 7, 2);
                string Obs = lancos.Obs.Substring(0, Math.Min(lancos.Obs.Length, 20));
                sb.AppendLine($"{ID}   {Data}   {Entrada}   {Desconto}   {Saidas}   {Forma}   {Saldo} {Obs}");
                switch (lancos.idFormaPagto)
                {
                    case 0:
                        TDinheiro += lancos.Entrada - lancos.Desconto;
                    break;
                    case 1:
                        TCartao += lancos.Entrada - lancos.Desconto;
                    break;
                    case 3:
                        TPix += lancos.Entrada - lancos.Desconto;
                    break;
                    case 5:
                        TDespesa += lancos.Saida;
                    break;
                    case 6:
                        TItau += lancos.Entrada - lancos.Desconto;
                        break;
                    case 7:
                        TSicred += lancos.Entrada - lancos.Desconto;
                        break;
                        
                }
            }
            sb.AppendLine();

            TotForma(ref sb, $"Dinheiro: ", TDinheiro);
            TotForma(ref sb, $"Cartão:   ", TCartao);
            TotForma(ref sb, $"Pix:      ", TPix);
            TotForma(ref sb, $"Despesas: ", TDespesa);
            TotForma(ref sb, $"Itau:     ", TItau);
            TotForma(ref sb, $"Sicred:   ", TSicred);
            decimal Entradas = TDinheiro + TCartao + TPix + TItau + TSicred;
            decimal saldo = Entradas - TDespesa;
            sb.AppendLine("");
            sb.AppendLine("Total de entradas:"+ glo.ComplStr(Entradas.ToString("N2"), 9, 2));
            sb.AppendLine("Total de saídas  :" + glo.ComplStr(TDespesa.ToString("N2"), 9, 2));
            sb.AppendLine("Saldo            :" + glo.ComplStr(saldo.ToString("N2"), 9, 2));
            textBox1.Text = sb.ToString(); ;
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void TotForma(ref StringBuilder sb,  string Forma, decimal valor)
        {
            if (valor==0)
            {
                if (cmbTipo.SelectedIndex != 0)
                {
                    return;
                }
            }
            sb.AppendLine(Forma + glo.ComplStr(valor.ToString("N2"), 9, 2));
        }

        private void Extrato_Activated(object sender, EventArgs e)
        {
            if (!ativou)
                ativou = true;
            dtpDataIN.Value = this.DT1;            
            dtnDtFim.Value = this.DT2.Date.AddDays(1).AddMinutes(-1);
            GerarRelCaixa();
        }
        
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            GerarRelCaixa();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPageHandler);
            printDocument.Print();
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Courier New", 10);
            float yPos = 0;
            int count = 0;
            string[] lines = textBox1.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                yPos = count * font.GetHeight(e.Graphics);
                e.Graphics.DrawString(line, font, Brushes.Black, new PointF(10, yPos));
                count++;
            }
        }
        
        #region Classes

        private class Lanctos
        {
            public string Forma;
            public int ID;
            public DateTime DataPagamento;
            public decimal Entrada;
            public decimal Desconto;
            public decimal Saida;
            public int idFormaPagto;
            public decimal Saldo;
            public int Quantidade;
            public string Obs;

        }

        #endregion

    }

}