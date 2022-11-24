using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriboEstudio.Model
{
    internal class Professor : Pessoa
    {        
        public decimal Salario { get; set; }
        public int CurrentMonth { get; set; }
        public bool IsSalaryPaid { get; set; }
        
    }
}
