using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyClassReserve.ReserveStudyClass
{
    public class ConfiguracaoReserva
    {
        public  DateTime DataMax { get; set; }
        public  DateTime DataMin { get; set; }
        public  TimeSpan HoraMax { get; set; }
        public  TimeSpan HoraMin { get; set; }

        public ConfiguracaoReserva(DateTime dataMax, DateTime dataMin, TimeSpan horaMax, TimeSpan horaMin)
        {
            if (dataMin >= dataMax)
             {
                throw new ArgumentException("A data mínima deve ser menor que a data máxima.");

            }
            if (horaMin >= horaMax)
            {
                throw new ArgumentException("A hora mínima deve ser menor que a hora máxima.");
            }

            DataMax = dataMax;
            DataMin = dataMin;
            HoraMax = horaMax;
            HoraMin = horaMin;

        }
    }
}