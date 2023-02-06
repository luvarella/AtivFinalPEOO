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
    public partial class MedicoWindow : Window
    {
        public MedicoWindow()
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
            string especializacao = txtEspecializacao.Text;
            Medico z = new Medico
            {
                Id = id,
                Nome = nome,
                Cpf = cpf,
                Email = email,
                Idade = idade,
                Especializacao = especializacao
            };
            NMedico.Inserir(z);
            ListarClick(sender, e);
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listMedicos.ItemsSource = null;
            listMedicos.ItemsSource = NMedico.Listar();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nome = txtNome.Text;
            string cpf = txtCpf.Text;
            string email = txtEmail.Text;
            string idade = txtIdade.Text;
            string especializacao = txtEspecializacao.Text;
            Medico z = new Medico
            {
                Id = id,
                Nome = nome,
                Cpf = cpf,
                Email = email,
                Idade = idade,
                Especializacao = especializacao
            };
            NMedico.Atualizar(z);
            ListarClick(sender, e);
        }

        private void ExcluirClick(object sender, RoutedEventArgs e)
        {
            if (listMedicos.SelectedItem != null)
            {
                NMedico.Excluir((Medico)listMedicos.SelectedItem);
                ListarClick(sender, e);
            }
            else
                MessageBox.Show("Selecione o médico a ser excluído");
        }

        private void listMedicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listMedicos.SelectedItem != null)
            {
                Medico obj = (Medico)listMedicos.SelectedItem;
                txtId.Text = obj.Id.ToString();
                txtNome.Text = obj.Nome;
                txtCpf.Text = obj.Cpf;
                txtEmail.Text = obj.Email;
                txtIdade.Text = obj.Idade;
                txtEspecializacao.Text = obj.Especializacao;
            }
        }
    }
}
