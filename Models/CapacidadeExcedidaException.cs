using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeHospedagem.Models
{
    public class CapacidadeExcedidaException : Exception
    {
        public CapacidadeExcedidaException(string massage) : base(massage)
        {
        }
    }
}