using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobraConcertos.dao
{
    public class OrcamentoDao
    {
        
        public DataTable getDados(DateTime DT1, DateTime DT2)
        {
            bool Sair = false;
            DataTable dt = null;
            while (Sair==false)
            {
                DateTime dataInicio = DT1.Date;
                DateTime dataFim = DT2.Date;
                string dataInicioStr = dataInicio.ToString("MM/dd/yyyy HH:mm:ss");
                string dataFimStr = dataFim.ToString("MM/dd/yyyy 23:59:59");
                StringBuilder query = new StringBuilder();
                query.Append($@"SELECT ca.ID, c.Nome AS Cliente, ca.Valor, ca.Desconto, ca.VlNota, 
                    v.Nome AS Vendedor, ca.Data,
                    SWITCH(
                        ca.idForma = 0, 'Dinheiro',
                        ca.idForma = 1, 'Cartão',
                        ca.idForma = 2, 'Anotado',
                        ca.idForma = 3, 'Pix',
                        ca.idForma = 4, 'Troca',
                        ca.idForma = 5, 'Despesa',
                        ca.idForma = 6, 'Itau',
                        ca.idForma = 7, 'Sicred' 
                    ) AS Pagamento, ca.Obs,
                    c.NrCli, ca.idVend, ca.idForma, ca.UID 
                    FROM (Caixa ca
                    LEFT JOIN Clientes c ON c.NrCli = ca.idCliente)
                    INNER JOIN Vendedores v ON v.ID = ca.idVend"); 
                query.AppendFormat(" WHERE ca.Data BETWEEN #{0}# AND #{1}#", dataInicioStr, dataFimStr);
                query.Append(" Order By ca.ID desc ");
                dt = DB.ExecutarConsulta(query.ToString());
                if (dt.Rows.Count == 0)
                {
                    string q2 = "Select Data From Caixa Order by Data desc";
                    DataTable dt2 = DB.ExecutarConsulta(q2);
                    if (dt2.Rows.Count == 0)
                    {
                        Sair = true;
                    } else
                    {
                        DT1 = (DateTime)dt2.Rows[0]["Data"];
                        DT2 = DT2.AddDays(1);
                    }                        
                } else
                {
                    Sair = true;
                }

            }
            return dt;
        }

        internal void Atualiza()
        {
            string query = $@"UPDATE Orcamento 
                    SET copiaobs = Obs, 
                        dataalteracao = Date() 
                    WHERE copiaobs <> Obs";
            DB.ExecutarComandoSQL(query);
        }

        internal DataTable getDados()
        {
            StringBuilder query = new StringBuilder();
            query.Append($@"Select O.dataalteracao, O.Cliente, O.Total, O.Obs, 
                    C.Telefone, C.Observacao, C.email, C.CgcCpf, C.EmAtraso, c.funcionario, O.Orcamento  
                    FROM Orcamento O 
                    Inner Join Clientes C on C.Nome = O.Cliente ");
            query.AppendFormat(" WHERE O.Pagamento < #1/1/1990# ");
            query.Append(" AND O.dataalteracao < DateAdd('d', -30, Date()) ");
            query.Append(" Order By O.dataalteracao ");
            DataTable dt = DB.ExecutarConsulta(query.ToString());
            return dt;
        }

        internal void PagouEsse(string orcamentoId)
        {
            string query = "UPDATE Orcamento SET Pagamento = Date() WHERE Orcamento = " + orcamentoId; 
            DB.ExecutarComandoSQL(query);
        }

        internal void InicializaCobrancas()
        {
            DB.ExecutarComandoSQL("ALTER TABLE Orcamento ADD COLUMN DataAlteracao DATE");
            DB.ExecutarComandoSQL("ALTER TABLE Orcamento ADD COLUMN CopiaObs MEMO");
            string SQL = "UPDATE Orcamento SET dataalteracao = Data, copiaobs = Obs WHERE Pagamento < #1/1/1990# ";
            DB.ExecutarComandoSQL(SQL);
        }

        internal void Pagou(string orcamentoIds)
        {
            StringBuilder query = new StringBuilder();
            query.Append($@"UPDATE Orcamento 
                        SET Pagamento = Date() 
                        WHERE Orcamento IN (");
            query.Append(orcamentoIds);
            query.Append(")");
            DB.ExecutarComandoSQL(query.ToString());
        }

        internal void GravaOrc(Int32 nrOrc, string obsOrc = null, string sNome = null)
        {
            if (obsOrc == null && sNome == null)
            {
                // Se nenhum campo foi modificado, não fazer nada
                return;
            }

            StringBuilder query = new StringBuilder();
            query.Append("UPDATE Orcamento SET ");

            List<string> updates = new List<string>();
            if (obsOrc != null)
            {
                // Remover espaços à esquerda
                obsOrc = obsOrc.TrimStart();
                updates.Add($"Obs = '{obsOrc}', copiaobs = '{obsOrc}', dataalteracao = Date()");
            }
            if (sNome != null)
            {
                // Remover espaços à esquerda
                sNome = sNome.TrimStart();
                updates.Add($"Cliente = '{sNome}'");
            }

            query.Append(string.Join(", ", updates));
            query.Append($" WHERE Orcamento = {nrOrc}");

            DB.ExecutarComandoSQL(query.ToString());
        }

        internal void GravaCli(string NmBusca, string sNome, string cgcCpf = null, string obsCliente = null, string sFone = null, string sEmail = null, bool? bAtrasado = null, bool? bFuncionario = null)
        {
            if (string.IsNullOrEmpty(NmBusca))
            {
                // Se o nome do cliente não foi fornecido, lançar uma exceção
                throw new ArgumentException("Nome do cliente não pode ser nulo ou vazio.", nameof(sNome));
            }

            StringBuilder query = new StringBuilder();
            query.Append("UPDATE Clientes SET ");

            List<string> updates = new List<string>();
            if (cgcCpf != null)
            {
                // Remover espaços à esquerda
                cgcCpf = cgcCpf.TrimStart();
                updates.Add($"CgcCpf = '{cgcCpf}'");
            }

            if (obsCliente != null)
            {
                // Remover espaços à esquerda
                obsCliente = obsCliente.TrimStart();
                updates.Add($"Observacao = '{obsCliente}'");
            }

            if (sFone != null)
            {
                // Remover espaços à esquerda
                sFone = sFone.TrimStart();
                updates.Add($"Telefone = '{sFone}'");
            }

            if (sEmail != null)
            {
                // Remover espaços à esquerda
                sEmail = sEmail.TrimStart();
                updates.Add($"email = '{sEmail}'");
            }

            if (bAtrasado.HasValue)
            {
                updates.Add($"EmAtraso = {bAtrasado.Value}");
            }

            if (bFuncionario.HasValue)
            {
                updates.Add($"funcionario = {bFuncionario.Value}");
            }

            if (updates.Count == 0)
            {
                // Se nenhum campo foi modificado, não fazer nada
                return;
            }

            query.Append(string.Join(", ", updates));
            query.Append($" WHERE Nome = '{NmBusca.TrimStart()}'");

            DB.ExecutarComandoSQL(query.ToString());
        }

    }
}
