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
using DoeMais.Controller.Objetos;
using DoeMais.BD;
using DoeMais.Controller.Util;

namespace DoeMais.Views.CadastroFuncionario
{
    /// <summary>
    /// Interaction logic for CadastroFuncionarioWindow.xaml
    /// </summary>
    public partial class CadastroFuncionarioWindow : Window
    {
        public CadastroFuncionarioWindow()
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closeCadastroFunc();
        }

        private void button_cadastrar_Click(object sender, RoutedEventArgs e)
        {
            Funcionario func = new Funcionario();

            if (checkBox_administrador.IsChecked == true)
            {
                func.Adm = true;
            }
            else
            {
                func.Adm = false;
            }

            func.Bairro = textBox_bairro.Text;
            func.Cep = textBox_cep.Text;
            func.Cidade = textBox_cidade.Text;
            func.Complemento = textBox_complemento.Text;
            func.Cpf = textBox_cpf.Text;
            func.DataDeNascimento = Convert.ToDateTime(textBox_dataDeNascimento.Text);
            func.Email = textBox_email.Text;
            func.IdFuncionario = textBox_cpf.Text;
            func.Logradouro = textBox_logradouro.Text;
            func.Nome = textBox_nome.Text;
            func.Numero = textBox_numero.Text;
            func.Rg = textBox_rg.Text;
            func.Sobrenome = textBox_sobrenome.Text;
            func.TelefoneA = textBox_telefoneA.Text;
            func.TelefoneB = textBox_telefoneB.Text;
            func.Uf = textBox_uf.Text;

            CriarSenhaPadrao senha = new CriarSenhaPadrao();
            string senhaPadrao = senha.senhaRandom(8);

            FuncionarioBD cadastro = new FuncionarioBD();
            string resultado = cadastro.cadastrarFuncionario(func, senhaPadrao);
            MessageBox.Show("Cadastro realizado com sucesso!");

            textBox_bairro.Clear();
            textBox_cep.Clear();
            textBox_cidade.Clear();
            textBox_complemento.Clear();
            textBox_cpf.Clear();
            textBox_dataDeNascimento.Clear();
            textBox_email.Clear();
            textBox_logradouro.Clear();
            textBox_nome.Clear();
            textBox_numero.Clear();
            textBox_rg.Clear();
            textBox_sobrenome.Clear();
            textBox_telefoneA.Clear();
            textBox_telefoneB.Clear();
            textBox_uf.Clear();
            checkBox_administrador.IsChecked = false;
        }

        private void button_cancelar_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.cancelarCadastroFunc();
        }

        private void checkBox_administrador_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_cep_MouseLeave(object sender, MouseEventArgs e)
        {
            EnderecoDados defineEnd = new EnderecoDados();
            Endereco end = new Endereco();
            try
            {
                end = defineEnd.GET(textBox_cep.Text);
                textBox_bairro.Text = end.Bairro;
                textBox_cidade.Text = end.Cidade;
                textBox_logradouro.Text = end.Logradouro;
                textBox_uf.Text = end.UF;
            }
            catch
            {

            }
        }

        private void textBox_cpf_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
