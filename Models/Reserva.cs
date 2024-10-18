using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospesdes { get; set; }
        public Suite SuiteReservada { get; set; }
        public int DiasReservados { get; set; }
        public int QuantidadeHospedes { get; set; }

        public Reserva()
        {
            Hospesdes = new List<Pessoa>();
        }

        public void CadastrarHospedes(Pessoa hospedes)
        {
            if (SuiteReservada == null)
            {
                Console.WriteLine("Por favor, escolha uma suíte antes de adicionar hóspedes.");
                return;
            }
            if (Hospesdes.Count < SuiteReservada.CapacidadeSuite)
            {
                Hospesdes.Add(hospedes);
                Console.WriteLine($"Hóspede {hospedes.NomeComepleto()}  Cadastrado com sucesso.");
            }
            else
            {
                Console.WriteLine("Capacidade da suíte atingida");
            }
        }

        public void EscolherSuite(Suite suite)
        {
            SuiteReservada = suite;
            Console.WriteLine($"Suíte {suite.TipoSuite} selecionada com sucesso.");
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospesdes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            if (SuiteReservada == null)
            {   
                Console.WriteLine("Nenhuma suíte foi selecionada.");
                return 0;
            }
            decimal valorTotal = SuiteReservada.ValorDiaria * DiasReservados;

            if (DiasReservados >= 7)
            {
                valorTotal *= 0.9M;
            }
            return valorTotal;
        }
    }
}