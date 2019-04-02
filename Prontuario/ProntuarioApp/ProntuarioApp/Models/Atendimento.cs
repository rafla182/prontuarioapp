using System;
using System.Collections.Generic;
using System.Text;

namespace ProntuarioApp.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public string DataAlta { get; set; }
        public string DataAtendimento { get; set; }
        public string TipoAtendimento { get; set; }
        public string Descricao { get; set; }
        public string Medico { get; set; }
        public string Especialidade { get; set; }
        public int PacienteId { get; set; }
    }
}
