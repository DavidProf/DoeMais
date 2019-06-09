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
            textBox_rg.IsReadOnly = true;
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

        private void checkBox_administrador_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
