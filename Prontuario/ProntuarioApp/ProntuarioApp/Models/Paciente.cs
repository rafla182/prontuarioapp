using System;
using System.Collections.Generic;
using System.Text;

namespace ProntuarioApp.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string DataNascimento { get; set; }
        public double Idade { get; set; }
    }
}
