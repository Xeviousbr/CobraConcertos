﻿using System;

namespace CobraConcertos.tb
{
    public class Produtos : IDataEntity
    {
        public int Id { get; set; }

        public int IDBalconista { get; set; }

        public DateTime Data { get; set; }

        public string Quant { get; set; }

        public string Codigo { get; set; }
        public bool Adicao { get; set; }
        public string Nome { get; set; }
        public int idForn { get; set; }
        public string Obs { get; set; }

    }
}
