using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividadeclinica
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Idade { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public int IdMedico { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Nome} - {Cpf} - {Idade} - {Estado} - {Cidade} {Email} - Médico: {IdMedico}";
        }
    }
}
