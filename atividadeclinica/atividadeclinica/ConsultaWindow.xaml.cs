using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace atividadeclinica
{
    /// <summary>
    /// Lógica interna para MatriculaWindow.xaml
    /// </summary>
    public partial class ConsultaWindow : Window
    {
        public ConsultaWindow()
        {
            InitializeComponent();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listMedicos.ItemsSource = null;
            listMedicos.ItemsSource = NMedico.Listar();
            listPacientes.ItemsSource = null;
            listPacientes.ItemsSource = NPaciente.Listar();
        }

        private void AgendarClick(object sender, RoutedEventArgs e)
        {
            if (listMedicos.SelectedItem != null &&
               listPacientes.SelectedItem != null)
            {
                Paciente p = (Paciente)listPacientes.SelectedItem;
                Medico m = (Medico)listMedicos.SelectedItem;
                //NPaciente.Matricular(p, m);
                ListarClick(sender, e);
                int id = int.Parse(txtId.Text);
                string descricao = txtDescricao.Text;
                string data = txtData.Text;
                string hora = txtHora.Text;
                string local = txtLocal.Text;
                int IdMedico = m.Id;
                int IdPaciente = p.Id;
                Consulta i = new Consulta
                {
                    Id = id,
                    IdMedico = IdMedico,
                    IdPaciente = IdPaciente,
                    Descricao = descricao,
                    Data = data,
                    Hora = hora,
                    Local = local
                };
                NConsulta.Inserir(i);
                ListarClick(sender, e);
            }
            else
            {
                MessageBox.Show("É preciso selecionar um aluno e uma turma");
            }

        }

        private void InserirClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string descricao = txtDescricao.Text;
            string data = txtData.Text;
            string hora = txtHora.Text;
            string local = txtLocal.Text;
            Consulta i = new Consulta
            {
                Id = id,
                Descricao = descricao,
                Data = data,
                Hora = hora,
                Local = local
            };
            NConsulta.Inserir(i);
            ListarClick(sender, e);
        }

    }
}