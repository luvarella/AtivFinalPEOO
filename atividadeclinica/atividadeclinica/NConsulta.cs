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
        public static void Inserir(Consulta c)
        {
            Abrir();
            int id = 0;
            foreach (Consulta obj in consultas)
                if (obj.Id > id) id = obj.Id;
            c.Id = id + 1;
            consultas.Add(c);
            Salvar();
        }
        public static void Atualizar(Consulta c)
        {
            Abrir();
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
            Consulta x = null;
            foreach (Consulta obj in consultas)
                if (obj.Id == c.Id) x = obj;
            if (x != null) consultas.Remove(x);
            Salvar();
        }
        public static List<Consulta> ListarConsultas()
        {
            Abrir();
            return consultas;
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
        public static void MarcarConsulta(Medico m, Paciente p, Consulta c)
        {
            Abrir();
            c.IdMedico = m.Id;
            c.IdPaciente = p.Id;
            Salvar();
        }
        public static List<Consulta> ListarMedico(Medico m)
        {
            Abrir();
            List<Consulta> listConsultas = new List<Consulta>();
            foreach (Consulta c in consultas)
            {
                if (c.IdMedico == m.Id)
                {
                    listConsultas.Add(c);
                }
            }
            return listConsultas;
        }
        public static List<Consulta> ListarPaciente(Paciente p)
        {
            Abrir();
            List<Consulta> listConsultas = new List<Consulta>();
            foreach (Consulta c in consultas)
            {
                if (c.IdPaciente == p.Id)
                {
                    listConsultas.Add(c);
                }
            }
            return listConsultas;
        }
    }

    }
