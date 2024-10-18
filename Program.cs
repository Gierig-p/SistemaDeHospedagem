using System;
using System.Runtime.CompilerServices;
using SistemaDeHospedagem.Models;

List<Suite> suitesDisponiveis = new List<Suite>
{
    new Suite("Standard,", 2, 50m),
    new Suite("Luxo,", 4, 100m),
    new Suite("Premium,", 4, 150m)
};

Reserva reserva = new Reserva();


while (true)
{
    Console.WriteLine("\nMenu");
    Console.WriteLine("1. Escolher Suíte");
    Console.WriteLine("2. Cadastrar Hóspede");
    Console.WriteLine("3. Ver quantidade de hóspedes");
    Console.WriteLine("4. Calcular valor total da diária");
    Console.WriteLine("5. Sair");

    Console.Write("\nEscolha uma opção");
    string opcao = Console.ReadLine();
    
    switch (opcao)
    {
        case "1":
            try
            {
                EscolherSuite(reserva, suitesDisponiveis);
            }
            catch (CapacidadeExcedidaException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            EscolherSuite(reserva, suitesDisponiveis);
            break;

        case "2":
            CadastrarHospede(reserva);
            break;

        case "3":
            Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.ReadLine();
            break;
        
        case "4":
            Console.WriteLine($"Valor total da diária: {reserva.CalcularValorDiaria()} reais");
            Console.ReadLine();
            break;

        case "5":
            Console.WriteLine("Saindo...");
            return;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;

        
    }
}

static void EscolherSuite(Reserva reserva, List<Suite> suitesDisponiveis)
{
    int quantidadeHospedes;
    do
    {
        Console.Write("\nQuantas pessoas seram hóspedadas? ");
    } while (!int.TryParse(Console.ReadLine(), out quantidadeHospedes) || quantidadeHospedes <= 0);

    reserva.QuantidadeHospedes = quantidadeHospedes;
    
    var suitesCompativeis = suitesDisponiveis.Where(s => s.CapacidadeSuite >= quantidadeHospedes).ToList();

    if (suitesCompativeis.Count == 0)
    {
        Console.WriteLine("Nenhuma suíte disponível para a quantidade de pessoas.");
        return;
    }

    Console.WriteLine("\nSuítes disponíveis:");

    for (int i = 0; i < suitesDisponiveis.Count; i++)
    {
        Suite suite = suitesDisponiveis[i];
        Console.WriteLine($"{i + 1}. {suite.TipoSuite} - Capacidade: {suite.CapacidadeSuite} pessoas - Diária: {suite.ValorDiaria} reais");
    }
    
    int escolha;
    do
    {
        Console.Write("\nEscolha o número da suíte desejada: ");
    } while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > suitesDisponiveis.Count);

    Suite suiteEscolhida = suitesDisponiveis[escolha - 1];

    int diasReservados;
    do
    {
        Console.Write("Digite a quantidade de dias para a reserva: ");
    } while (!int.TryParse(Console.ReadLine(), out diasReservados) || diasReservados <= 0);

    reserva.EscolherSuite(suiteEscolhida);
    reserva.DiasReservados = diasReservados;
    Console.ReadLine();
}

static void CadastrarHospede(Reserva reserva)
{
    string nomeCompleto;
    do
    {
        Console.Write("Digite o nome completo do hóspede (nome e sobrenome): ");
        nomeCompleto = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(nomeCompleto));

    string[] partesNome = nomeCompleto.Trim().Split(' ');

    if (partesNome.Length < 2)
    {
        Console.WriteLine("Por favor, insira ao menos um nome e um sobrenome.");
        return;
    }

    string nome = partesNome[0];
    string sobrenome = string.Join(" ", partesNome[1..]);

    Pessoa hospede = new Pessoa(nome, sobrenome);
    reserva.CadastrarHospedes(hospede);
    Console.ReadLine();
}




































// Pessoa hospede1 = new Pessoa("João","Marcos");
// Pessoa hospede2 = new Pessoa("Manuela", "Tavares");

// Suite suitePremium = new Suite("Premium", 3, 30);

// Reserva reserva = new Reserva();
// reserva.CadastrarSuite(suitePremium);
// reserva.DiasReservados = 8;

// reserva.CadastrarHospedes(hospede1);
// reserva.CadastrarHospedes(hospede2);

// Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
// Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");