using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobraConcertos.tb
{
    public interface IDataEntity
    {
        int Id { get; set; }
        bool Adicao { get; set; }

        string Nome { get; set; }
    }
}

