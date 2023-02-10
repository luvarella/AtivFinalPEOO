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
    /// Lógica interna para AgendaPacWindow.xaml
    /// </summary>
    public partial class AgendaPacWindow : Window
    {
        public AgendaPacWindow()
        {
            InitializeComponent();
            listPacientes.ItemsSource = NPaciente.Listar();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            if (listPacientes.SelectedItem != null)
            {
                Paciente p = (Paciente)listPacientes.SelectedItem;
                listConsultas.ItemsSource = null;
                listConsultas.ItemsSource = NConsulta.ListarPaciente(p);
            }
            else
                MessageBox.Show("É preciso selecionar um paciente");
        }
    }
}
