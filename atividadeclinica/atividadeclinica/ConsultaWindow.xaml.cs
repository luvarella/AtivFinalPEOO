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
                listMedicos.SelectedItem != null)
            {
                Medico m = (Medico)listMedicos.SelectedItem;
                Paciente p = (Paciente)listPacientes.SelectedItem;
                NConsulta.Agendar(p, m);
                ListarClick(sender, e);
            }
            else
                MessageBox.Show("Selecione um médico e um paciente");
        }
    }
}
