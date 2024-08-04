using CobraConcertos.dao;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
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
            Environment.Exit(0);
        }
    }

}
