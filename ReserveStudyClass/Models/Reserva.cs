using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyClassReserve.ReserveStudyClass
{
    public class Reserva
    {
        //propriedades
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string DescricaoDaSala { get; set; }
        public int Capacidade { get; set; }

        private ConfiguracaoReserva configuracao;

        //construtor
        public Reserva(DateTime data, TimeSpan hora, string descricaoDaSala, int capacidade, ConfiguracaoReserva configuracaoReserva)
        {
            this.configuracao = configuracaoReserva;

            RegistrarData(data);
            RegistrarHora(hora);
            RegistrarCapacidade(capacidade);

            DescricaoDaSala = descricaoDaSala ?? throw new ArgumentNullException(nameof(descricaoDaSala));
        }

        //métodos para registrar separadamente
        public void RegistrarHora(TimeSpan hora)
        {
            Hora = hora;
        }
        public void RegistrarData(DateTime data)
        {
            Data = data;
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

            if(Data < configuracao.DataMin || Data > configuracao.DataMax)
            {
                erros.Add("A data da reserva está fora do horário permitido.");
            }

            if(Hora < configuracao.HoraMin || Hora > configuracao.HoraMax)
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
            return $"Reserva para a sala \"{DescricaoDaSala}\" em {Data:dd/MM/yyyy} ás {Hora}h  com capacaidade para {Capacidade} alunos.";
        }
    }
}