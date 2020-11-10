﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS_Mejora_tu_Salud.Modelo
{
    class Cita
    {
        private string identificacionMedico;
        private string identificacionPaciente;
        private string fechaCita;

        public Cita(string identificacionMedico, string identificacionPaciente, string fechaCita)
        {
            this.IdentificacionMedico = identificacionMedico;
            this.IdentificacionPaciente = identificacionPaciente;
            this.FechaCita = fechaCita;
        }

        public string IdentificacionMedico { get => IdentificacionMedico; set => IdentificacionMedico = value; }
        public string IdentificacionPaciente { get => IdentificacionPaciente; set => IdentificacionPaciente = value; }
        public string FechaCita { get => FechaCita; set => FechaCita = value; }
    }
}
