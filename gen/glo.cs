// #define ODBC

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CobraConcertos
{
    public static class glo
    {
        private static string caminhoBase;

        public static bool ODBC = false;

        public static string CaminhoBase
        {
            get
            {
                caminhoBase = AppDomain.CurrentDomain.BaseDirectory;
                return caminhoBase;
            }
            set
            {
                caminhoBase = value;
            }
        }

        public static string connectionString
        {
            get
            {
                if (ODBC)
                {
                    glo.Loga("DSN=OrCarro;");
                    return "connectionString = 'DSN=OrCarro;' ";
                } else
                {
                    return @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + CaminhoBase + @"\OrCarro.mdb;";
                }
            }
        }

        public static DateTime D0 = new DateTime(1, 01, 01).Date;
        public static DateTime D1 = new DateTime(2001, 01, 01).Date;

        #region FormatacaoTela

        public static float LeValor(string valorTexto)
        {
            string valorLimpo = new string(valorTexto.Where(c => char.IsDigit(c) || c == ',' || c == '.').ToArray());
            char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            if (valorLimpo.Contains('.') && valorLimpo.Contains(','))
            {
                valorLimpo = valorLimpo.Replace(".", decimalSeparator.ToString());
            }
            else if (valorLimpo.Contains('.') || valorLimpo.Contains(','))
            {
                valorLimpo = valorLimpo.Replace(',', decimalSeparator).Replace('.', decimalSeparator);
            }
            if (float.TryParse(valorLimpo, out float valorFloat))
            {
                return valorFloat;
            }
            else
            {
                return 0.0f;
            }
        }

        public static string fmtVlr(string input)
        {
            string cleanValue = new string(input.Where(c => char.IsDigit(c) || c == ',' || c == '.').ToArray());
            char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            if (cleanValue.Contains('.') && cleanValue.Contains(','))
            {
                cleanValue = cleanValue.Replace(".", decimalSeparator.ToString());
            }
            else if (cleanValue.Contains('.') || cleanValue.Contains(','))
            {
                cleanValue = cleanValue.Replace(',', decimalSeparator).Replace('.', decimalSeparator);
            }
            if (decimal.TryParse(cleanValue, out decimal value))
            {
                if (value == 0)
                {
                    return "";
                }
                return value.ToString("0.00");
            }
            else
            {
                return input;
            }
        }

        public static int ConvOjbInt(object obj)
        {
            if (obj == null || !int.TryParse(obj.ToString(), out int i))
            {
                return 0;
            }
            return i;
        }

        public static string ConvOjbStr(object obj)
        {
            string str = obj.ToString();
            return str;
        }

        public static string ConvObjStrFormatado(object obj)
        {
            if (obj == null || (decimal.TryParse(obj.ToString(), out decimal num) && num == 0))
            {
                return string.Empty;
            }
            return string.Format("{0,10} ", obj);
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateUID()
        {
            string dateTimePart = DateTime.Now.ToString("ddMMyyyyHHmmss");
            int QtdCarac = 20 - dateTimePart.Length;
            string randomChars = RandomString(QtdCarac);
            return dateTimePart + randomChars;
        }

        public static string fa(string str)
        {
            return "'" + str + "'";
        }

        public static string sv(float vlr)
        {
            string str = vlr.ToString();
            return str.Replace(",", ".");
        }

        public static string sv(decimal vlr)
        {
            string str = vlr.ToString();
            return str.Replace(",", ".");
        }

        public static bool IsDateTimeValid(int year, int month, int day)
        {
            if (year < DateTime.MinValue.Year || year > DateTime.MaxValue.Year)
                return false;
            if (month < 1 || month > 12)
                return false;
            if (day < 1 || day > DateTime.DaysInMonth(year, month))
                return false;

            return true; // A data é válida
        }

        public static string ComplStr(string dado, int Tam, int Tipo)
        {
            // Tipo é o alinhamento
            // 0=Esquerda,
            // 1=Central
            // 2=Direita
            // 3=Direita e se não tiver nada, retorna nada
            int Aux;
            int Aux2;
            string Aux3;
            Aux = dado.Length;
            string Prench = " ";
            if (Aux >= Tam)
            {
                return dado.Substring(0, Tam);
            }
            else
            {
                switch (Tipo)
                {
                    case 0:
                        // A esquerda
                        if (dado.Length < Tam)
                        {
                            dado = dado.PadRight(Tam, Convert.ToChar(Prench));
                        }
                        break;
                    case 1:
                        // Central
                        Aux2 = (Tam - Aux) / 2;
                        Aux3 = new string(Convert.ToChar(Prench), Aux2) + dado + new string(Convert.ToChar(Prench), Aux2);
                        Aux = Aux3.Length;
                        if (Aux < Tam)
                        {
                            Aux3 = Aux3.PadRight(Tam, Convert.ToChar(Prench));
                        }
                        if (Aux > Tam)
                        {
                            Aux3 = Aux3.Substring(0, Tam);
                        }
                        dado = Aux3;
                        break;
                    case 2:
                        // A Direita
                        if (dado.Length < Tam)
                        {
                            dado = dado.PadLeft(Tam, Convert.ToChar(Prench));
                        }
                        break;
                    case 3:
                        // Direita e se não tiver nada, retorna nada
                        if (dado == "0,00")
                        {
                            dado = new string(' ', Tam);
                        }
                        else
                        {
                            // CASO NORMAL
                            dado = dado.PadLeft(Tam, Convert.ToChar(Prench));
                        }
                        break;
                }
                return dado;
            }
        }

        #endregion

        public static void Loga(string message)
        {
            string logFilePath = @"C:\Entregas\Entregas.txt";
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                string Texto = $"{DateTime.Now}: {message}";
                writer.WriteLine(Texto);
                Console.WriteLine(Texto);
            }
        }

        #region DB

        public static DataTable getDados(string query)
        {
            using (OleDbConnection connection = new OleDbConnection(glo.connectionString))
            {
                try
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return null;
        }

        #endregion

    }
}