using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyClassReserve.ReserveStudyClass
{
    public class Reservas
    {
        //propriedades
        public DateTime DataReserva { get; set; }
        public TimeSpan HoraReserva { get; set; }
        public string DescricaoDaSala { get; set; }
        public int Capacidade { get; set; }

        private ConfiguracaoReserva configuracao;

        //construtor
        public Reservas(DateTime dataReserva, TimeSpan horaReserva, string descricaoDaSala, int capacidade, ConfiguracaoReserva configuracaoReserva)
        {
            this.configuracao = configuracaoReserva;

            RegistrarData(dataReserva);
            RegistrarHora(horaReserva);
            RegistrarCapacidade(capacidade);

            DescricaoDaSala = descricaoDaSala ?? throw new ArgumentNullException(nameof(descricaoDaSala));
        }

        //métodos para registrar separadamente
        public void RegistrarHora(TimeSpan horaReserva)
        {
            HoraReserva = horaReserva;
        }
        public void RegistrarData(DateTime dataReserva)
        {
            DataReserva = dataReserva;
        }
        public void RegistrarCapacidade(int capacidade)
        {
            if(capacidade <= 0 || capacidade >= 40)
            {
                throw new ArgumentOutOfRangeException(nameof(capacidade), "A capacidade deve ser obrigatoriamente maior que 0 e menor que 40 alunos.");
            }

            Capacidade = capacidade;
        }
        
        //validação da reserva
        public List<string> ValidarReserva()
        {
            List<string> erros = new List<string>();

            if(DataReserva < configuracao.DataMin || DataReserva > configuracao.DataMax)
            {
                erros.Add("A data da reserva está fora do horário permitido.");
            }

            if(HoraReserva < configuracao.HoraMin || HoraReserva > configuracao.HoraMax)
            {
                erros.Add("A hora da reserva está fora do horário permitido.");
            }

            if(Capacidade <= 0 || Capacidade >= 40)
            {
                erros.Add("A capacidade da Sala deve ser maior que 0 e menor que 40.");
            }

            if(string.IsNullOrWhiteSpace(DescricaoDaSala))
            {
                erros.Add("A descrção da sala é obrigatória.");
            }

            return erros;
        }

        //método toostring para exibição amigável dos dados
        public override string ToString()
        {
            return $"Reserva para a sala \"{DescricaoDaSala}\" em {DataReserva:dd/MM/yyyy} ás {HoraReserva}h  com capacaidade para {Capacidade} alunos.";
        }
    }
}