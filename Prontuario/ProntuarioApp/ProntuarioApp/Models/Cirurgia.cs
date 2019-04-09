using System;
using System.Collections.Generic;
using System.Text;

namespace ProntuarioApp.Models
{
    public class Cirurgia
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Procedimento { get; set; }
        public string Situacao { get; set; }
        public string DataRealizacao { get; set; }
        public int IdPrestador { get; set; }
        public string Prestador { get; set; }
    }
}
