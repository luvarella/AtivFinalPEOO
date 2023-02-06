using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace atividadeclinica
{
    class NConsulta
    {
        private static List<Consulta> consultas = new List<Consulta>();
        public static void Inserir(Consulta t)
        {
            Abrir();
            // Procurar o maior Id
            int id = 0;
            foreach (Consulta obj in consultas)
                if (obj.Id > id) id = obj.Id;
            t.Id = id + 1;
            consultas.Add(t);
            Salvar();
        }
        public static void Atualizar(Consulta c)
        {
            Abrir();
            // Percorrer a lista de turma procurando o id informado (t.Id)
            foreach (Consulta obj in consultas)
                if (obj.Id == c.Id)
                {
                    obj.Descricao = c.Descricao;
                    obj.Data = c.Data;
                    obj.Local = c.Local;
                    obj.Hora = c.Hora;
                }
            Salvar();
        }
        public static void Excluir(Consulta c)
        {
            Abrir();
            // Percorrer a lista de turma procurando o id informado (t.Id)
            Consulta x = null;
            foreach (Consulta obj in consultas)
                if (obj.Id == c.Id) x = obj;
            if (x != null) consultas.Remove(x);
            Salvar();
        }
        public static List<Consulta> Listar()
        {
            Abrir();
            return consultas;
        }
        public static void Agendar(Paciente p, Medico m)
        {
            p.IdMedico = m.Id;
            Atualizar(p);
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Consulta>));
                f = new StreamReader("./consultas.xml");
                consultas = (List<Consulta>)xml.Deserialize(f);
            }
            catch
            {
                consultas = new List<Consulta>();
            }
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Consulta>));
            StreamWriter f = new StreamWriter("./consultas.xml", false);
            xml.Serialize(f, consultas);
            f.Close();
        }
    }

    }
