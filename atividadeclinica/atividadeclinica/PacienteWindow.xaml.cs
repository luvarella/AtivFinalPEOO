using System;
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
    /// Lógica interna para PacienteWindow.xaml
    /// </summary>
    public partial class PacienteWindow : Window
    {
        public PacienteWindow()
        {
            InitializeComponent();
        }

        private void InserirClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nome = txtNome.Text;
            string cpf = txtCpf.Text;
            string email = txtEmail.Text;
            string idade = txtIdade.Text;
            string estado = txtEstado.Text;
            string cidade = txtCidade.Text;
            Paciente t = new Paciente
            {
                Id = id,
                Nome = nome,
                Cpf = cpf,
                Email = email,
                Idade = idade,
                Estado = estado,
                Cidade = cidade
            };
            NPaciente.Inserir(t);
            ListarClick(sender, e);
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listPacientes.ItemsSource = null;
            listPacientes.ItemsSource = NPaciente.Listar();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nome = txtNome.Text;
            string cpf = txtCpf.Text;
            string email = txtEmail.Text;
            string idade = txtIdade.Text;
            string estado = txtEstado.Text;
            string cidade = txtCidade.Text;
            Paciente t = new Paciente
            {
                Id = id,
                Nome = nome,
                Cpf = cpf,
                Email = email,
                Idade = idade,
                Estado = estado,
                Cidade = cidade
            };
            NPaciente.Atualizar(t);
            ListarClick(sender, e);
        }

        private void ExcluirClick(object sender, RoutedEventArgs e)
        {
            if (listPacientes.SelectedItem != null)
            {
                NPaciente.Excluir((Paciente)listPacientes.SelectedItem);
                ListarClick(sender, e);
            }
            else
                MessageBox.Show("Selecione o paciente a ser excluído");
        }

        private void listPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listPacientes.SelectedItem != null)
            {
                Paciente obj = (Paciente)listPacientes.SelectedItem;
                txtId.Text = obj.Id.ToString();
                txtNome.Text = obj.Nome;
                txtCpf.Text = obj.Cpf;
                txtEmail.Text = obj.Email;
                txtIdade.Text = obj.Idade;
                txtEstado.Text = obj.Estado;
                txtCidade.Text = obj.Cidade;
            }
        }
    }
}