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
    /// Lógica interna para AgendaMedWindow.xaml
    /// </summary>
    public partial class AgendaMedWindow : Window
    {
        public AgendaMedWindow()
        {
            InitializeComponent();
            listMedicos.ItemsSource = NMedico.Listar();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            if (listMedicos.SelectedItem != null)
            {
                Medico m = (Medico)listMedicos.SelectedItem;
                listConsultas.ItemsSource = null;
                listConsultas.ItemsSource = NConsulta.ListarMedico(m);
            }
            else
                MessageBox.Show("É preciso selecionar um médico");
        }
    }
}
