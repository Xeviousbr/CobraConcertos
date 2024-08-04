using System;

namespace CobraConcertos.tb
{
    public class Orcamento : IDataEntity
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string Cliente { get; set; }
        public string Carro { get; set; }
        public string Obs { get; set; }
        public string Kms { get; set; }
        public string Kilom { get; set; }
        public string Total { get; set; }
        public int Garantia { get; set; }
        public DateTime Pagamento { get; set; }
        public string ObsMec { get; set; }
        public int Vend { get; set; }
        public string VlrPago { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string CopiaObs { get; set; }
    }
}
