using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividadeclinica
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public int Cpf { get; set; }
        public string Email { get; set; }
        public string Especializacao { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Nome} - {Especializacao} - {Idade} - {Cpf} - {Email}";
        }
    }
}
