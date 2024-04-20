﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBonifacio.dao
{
    public class CaixaDao
    {
        public void Adiciona(int idForma, float compra, int idCliente, string obs, float desc, int idVend)
        {
            String sql = @"INSERT INTO Caixa (idCliente, idForma, Valor, VlNota, Obs, Desconto, idVend, Data) VALUES ("
                + idCliente.ToString() + ", "
                + idForma.ToString() + ", "
                + glo.sv(compra) + ", "
                + glo.sv(compra - desc) + ", "
                + glo.fa(obs) + ", "
                + glo.sv(desc) + ", "
                + idVend.ToString()
                + ",Now)";
            glo.ExecutarComandoSQL(sql);
        }

        public DataTable getDados(DateTime DT)
        {
            bool Sair = false;
            DataTable dt = null;
            while (Sair==false)
            {
                DateTime dataInicio = DT.Date;
                DateTime dataFim = dataInicio.AddDays(1).AddTicks(-1);
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
                        ca.idForma = 5, 'Despesa'
                    ) AS Pagamento, ca.Obs,
                    c.NrCli, ca.idVend, ca.idForma 
                    FROM (Caixa ca
                    LEFT JOIN Clientes c ON c.NrCli = ca.idCliente)
                    INNER JOIN Vendedores v ON v.ID = ca.idVend"); 
                query.AppendFormat(" WHERE ca.Data BETWEEN #{0}# AND #{1}#", dataInicioStr, dataFimStr);
                query.Append(" Order By ca.ID desc ");
                dt = glo.ExecutarConsulta(query.ToString());
                if (dt.Rows.Count == 0)
                {
                    string q2 = "Select Data From Caixa Order by Data desc";
                    DataTable dt2 = glo.ExecutarConsulta(q2);
                    if (dt2.Rows.Count == 0)
                    {
                        Sair = true;
                    } else
                    {
                        DT = (DateTime)dt2.Rows[0]["Data"];
                    }                        
                } else
                {
                    Sair = true;
                }

            }
            return dt;
        }

        public void Edita(int iID, int idForma, float compra, int idCliente, string obs, float desc, int idVend)
        {
            String sql = @"UPDATE Caixa SET 
                              idCliente = " + idCliente.ToString() +
                            ",idForma = " + idForma.ToString() +
                            ",Valor = " + glo.sv(compra) +
                            ",VlNota = " + glo.sv(compra) +
                            ",Obs = " + glo.fa(obs) +
                            ",Desconto = " + glo.sv(desc) +
                            ",idVend = " + idVend.ToString() +
                            " WHERE ID = " + iID.ToString();
            glo.ExecutarComandoSQL(sql);
        }

        public void Exclui(int iID)
        {
            String sql = @"Delete From Caixa WHERE ID = " + iID.ToString();
            glo.ExecutarComandoSQL(sql);
        }
    }
}
