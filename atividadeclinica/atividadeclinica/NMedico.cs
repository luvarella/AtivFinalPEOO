using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace atividadeclinica
{
    class NMedico
    {
        private static List<Medico> medicos = new List<Medico>();
        public static void Inserir(Medico t)
        {
            Abrir();
            // Procurar o maior Id
            int id = 0;
            foreach (Medico obj in medicos)
                if (obj.Id > id) id = obj.Id;
            t.Id = id + 1;
            medicos.Add(t);
            Salvar();
        }
        public static List<Medico> Listar()
        {
            Abrir();
            return medicos;
        }
        public static void Atualizar(Medico t)
        {
            Abrir();
            foreach (Medico obj in medicos)
                if (obj.Id == t.Id)
                {
                    obj.Nome = t.Nome;
                    obj.Cpf = t.Cpf;
                    obj.Email = t.Email;
                    obj.Idade = t.Idade;
                    obj.Especializacao = t.Especializacao;
                }
            Salvar();
        }
        public static void Excluir(Medico t)
        {
            Abrir();
            Medico x = null;
            foreach (Medico obj in medicos)
                if (obj.Id == t.Id) x = obj;
            if (x != null) medicos.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Medico>));
                f = new StreamReader("./medicos.xml");
                medicos = (List<Medico>)xml.Deserialize(f);
            }
            {
                medicos = new List<Medico>();
            }
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Medico>));
            StreamWriter f = new StreamWriter("./medicos.xml", false);
            xml.Serialize(f, medicos);
            f.Close();
        }

    }
}