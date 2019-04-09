using System;
using System.Collections.Generic;
using System.Text;

namespace ProntuarioApp.Models
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string DataNasciento { get; set; }
        public int Conselho { get; set; }
    }
}
