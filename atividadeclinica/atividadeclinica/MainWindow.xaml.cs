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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace atividadeclinica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Consulta_Click(object sender, RoutedEventArgs e)
        {
            ConsultaWindow c = new ConsultaWindow();
            c.ShowDialog();
        }

        private void Medico_Click(object sender, RoutedEventArgs e)
        {
            MedicoWindow c = new MedicoWindow();
            c.ShowDialog();
        }

        private void Paciente_Click(object sender, RoutedEventArgs e)
        {
            PacienteWindow c = new PacienteWindow();
            c.ShowDialog();
        }

        private void AgendaMed_Click(object sender, RoutedEventArgs e)
        {
            AgendaMedWindow c = new AgendaMedWindow();
            c.ShowDialog();
        }

        private void AgendaPac_Click(object sender, RoutedEventArgs e)
        {
            AgendaPacWindow c = new AgendaPacWindow();
            c.ShowDialog();
        }
    }
}
