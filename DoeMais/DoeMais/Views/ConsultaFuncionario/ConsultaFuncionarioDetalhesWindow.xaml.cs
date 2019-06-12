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
using DoeMais.BD;
using DoeMais.Controller.Objetos;
using DoeMais.Controller.Util;

namespace DoeMais.Views.ConsultaFuncionario
{
    /// <summary>
    /// Interaction logic for ConsultaFuncionarioDetalhesWindow.xaml
    /// </summary>
    public partial class ConsultaFuncionarioDetalhesWindow : Window
    {
        public ConsultaFuncionarioDetalhesWindow(String cpf)
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closeConsultaFuncDetalhes();

            textBox_nome.IsReadOnly = true;
            textBox_cpf.IsReadOnly = true;
            textBox_rg.IsReadOnly = true;
            textBox_dataDeNascimento.IsReadOnly = true;
            textBox_cep.IsReadOnly = true;
            textBox_logradouro.IsReadOnly = true;
            textBox_uf.IsReadOnly = true;
            textBox_cidade.IsReadOnly = true;
            textBox_bairro.IsReadOnly = true;
            textBox_numero.IsReadOnly = true;
            textBox_complemento.IsReadOnly = true;
            textBox_telefoneA.IsReadOnly = true;
            textBox_telefoneB.IsReadOnly = true;
            textBox_email.IsReadOnly = true;
            groupBox_status.IsHitTestVisible = false;
            groupBox_adm.IsHitTestVisible = false;

            FuncionarioBD dadosFunc = new FuncionarioBD();
            Funcionario func = new Funcionario();

            func = dadosFunc.getDadosFuncionario(cpf);

            textBox_bairro.Text = func.Bairro;
            textBox_cep.Text = func.Cep;
            textBox_cidade.Text = func.Cidade;
            textBox_complemento.Text = func.Complemento;
            textBox_cpf.Text = func.Cpf;
            textBox_dataDeNascimento.Text = func.DataDeNascimento.ToString("dd/MM/aaaa");
            textBox_email.Text = func.Email;
            textBox_logradouro.Text = func.Logradouro;
            textBox_nome.Text = func.Nome;
            textBox_numero.Text = func.Numero;
            textBox_rg.Text = func.Rg;
            textBox_telefoneA.Text = func.TelefoneA;
            textBox_telefoneB.Text = func.TelefoneB;
            textBox_uf.Text = func.Uf;

            if (func.Ativo == true)
            {
                radioButton_ativo.IsChecked = true;
            }
            else
            {
                radioButton_inativo.IsChecked = true;
            }

            if (func.Adm == true)
            {
                checkBox_administrador.IsChecked = true;
            }
        }

        private void button_voltar_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.voltarConsultaFuncDetalhes();
        }

        private void checkBox_alterar_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox_alterar.IsChecked == true)
            {
                textBox_nome.IsReadOnly = false;
                textBox_cep.IsReadOnly = false;
                textBox_numero.IsReadOnly = false;
                textBox_complemento.IsReadOnly = false;
                textBox_telefoneA.IsReadOnly = false;
                textBox_telefoneB.IsReadOnly = false;
                textBox_email.IsReadOnly = false;
                groupBox_status.IsHitTestVisible = true;
                groupBox_adm.IsHitTestVisible = true;
            }
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

        private void button_salvar_Click(object sender, RoutedEventArgs e)
        {
            Funcionario funcAtualizado = new Funcionario();
            //funcAtualizado.Adm
            //funcAtualizado.Ativo
            funcAtualizado.Bairro = textBox_bairro.Text;
            funcAtualizado.Cep = textBox_cep.Text;
            funcAtualizado.Cidade = textBox_cidade.Text;
            funcAtualizado.Complemento = textBox_complemento.Text;
            funcAtualizado.Email = textBox_email.Text;
            funcAtualizado.Logradouro = textBox_logradouro.Text;
            funcAtualizado.Nome = textBox_nome.Text;
            funcAtualizado.Numero = textBox_numero.Text;
            funcAtualizado.TelefoneA = textBox_telefoneA.Text;
            funcAtualizado.TelefoneB = textBox_telefoneB.Text;

            if (checkBox_administrador.IsChecked == true)
            {
                funcAtualizado.Adm = true;
            }
            else
            {
                funcAtualizado.Adm = false;
            }

            if (radioButton_ativo.IsChecked == true)
            {
                funcAtualizado.Ativo = true;
            }
            else if (radioButton_inativo.IsChecked == true)
            {
                funcAtualizado.Ativo = false;
            }

            FuncionarioBD atualizaFunc = new FuncionarioBD();
            Boolean resultado = atualizaFunc.setDadosFuncionario(funcAtualizado);

            if (resultado)
            {
                MessageBox.Show("Dados atualizados com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro no servidor. Por favor, tente novamente mais tarde");
            }
        }
    }
}
