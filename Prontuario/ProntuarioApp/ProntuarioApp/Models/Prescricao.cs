using System;
using System.Collections.Generic;
using System.Text;

namespace ProntuarioApp.Models
{
    public class Prescricao
    {
        public int Id { get; set; }
        public string Medicamentacao { get; set; }
        public string Queixa { get; set; }
        public string Data { get; set; }
    }
}
