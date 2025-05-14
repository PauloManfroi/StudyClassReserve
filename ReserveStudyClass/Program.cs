using System;
using System.Collections.Generic;
using StudyClassReserve.ReserveStudyClass;
using System.Text;
using System.Globalization;

class Program
{
    static void Main()
    {
        CultureInfo culturaBR = new CultureInfo("pt-BR");
        try
        {
            // CONFIGURAÇÃO
            Console.WriteLine("CONFIGURAÇÃO DE RESERVAS:");

            Console.Write("Data mínima (dd/MM/yyyy): ");
            DateTime dataMin = DateTime.Parse(Console.ReadLine(), culturaBR);

            Console.Write("Data máxima (dd/MM/yyyy): ");
            DateTime dataMax = DateTime.Parse(Console.ReadLine(), culturaBR);

            Console.Write("Hora mínima (HH:mm): ");
            TimeSpan horaMin = TimeSpan.Parse(Console.ReadLine(), culturaBR);

            Console.Write("Hora máxima (HH:mm): ");
            TimeSpan horaMax = TimeSpan.Parse(Console.ReadLine(), culturaBR);

            var configuracao = new ConfiguracaoReserva(dataMin, dataMax, horaMin, horaMax);

            Console.WriteLine("\nCONFIGURAÇÃO SALVA COM SUCESSO.\n");

            // DADOS DA RESERVA
            Console.WriteLine("DADOS DA RESERVA:");

            Console.Write("Data da reserva (dd/MM/yyyy): ");
            DateTime dataReserva = DateTime.Parse(Console.ReadLine(), culturaBR);

            Console.Write("Hora da reserva (HH:mm): ");
            TimeSpan horaReserva = TimeSpan.Parse(Console.ReadLine(), culturaBR);

            Console.Write("Descrição da sala: ");
            string descricaoDaSala = Console.ReadLine();

            Console.Write("Capacidade da sala: ");
            int capacidade = int.Parse(Console.ReadLine());

            var reserva = new Reservas(dataReserva, horaReserva, descricaoDaSala, capacidade, configuracao);

            // VALIDAR RESERVA
            List<string> erros = reserva.ValidarReserva();

            if (erros.Count == 0)
            {
                Console.WriteLine("\n✅ RESERVA REALIZADA COM SUCESSO:");
                Console.WriteLine(reserva);
            }
            else
            {
                Console.WriteLine("\n❌ ERROS NA RESERVA:");
                foreach (var erro in erros)
                {
                    Console.WriteLine("- " + erro);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Erro: {ex.Message}");
        }
    }
}
