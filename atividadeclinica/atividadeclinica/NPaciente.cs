using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace atividadeclinica
{
    class NPaciente
    {
        private static List<Paciente> pacientes = new List<Paciente>();
        public static void Inserir(Paciente t)
        {
            Abrir();
            int id = 0;
            foreach (Paciente obj in pacientes)
                if (obj.Id > id) id = obj.Id;
            t.Id = id + 1;
            pacientes.Add(t);
            Salvar();
        }
        public static List<Paciente> Listar()
        {
            Abrir();
            return pacientes;
        }
        public static void Atualizar(Paciente t)
        {
            Abrir();
            foreach (Paciente obj in pacientes)
                if (obj.Id == t.Id)
                {
                    obj.Nome = t.Nome;
                    obj.Cpf = t.Cpf;
                    obj.Email = t.Email;
                    obj.Idade = t.Idade;
                    obj.Estado = t.Estado;
                    obj.Cidade = t.Cidade;
                }
            Salvar();
        }
        public static void Excluir(Paciente t)
        {
            Abrir();
            Paciente x = null;
            foreach (Paciente obj in pacientes)
                if (obj.Id == t.Id) x = obj;
            if (x != null) pacientes.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Paciente>));
                f = new StreamReader("./pacientes.xml");
                pacientes = (List<Paciente>)xml.Deserialize(f);
            }
            catch
            {
                pacientes = new List<Paciente>();
            }
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Paciente>));
            StreamWriter f = new StreamWriter("./pacientes.xml", false);
            xml.Serialize(f, pacientes);
            f.Close();
        }
    }
}
