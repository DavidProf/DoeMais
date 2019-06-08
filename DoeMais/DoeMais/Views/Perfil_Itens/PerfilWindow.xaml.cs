using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DoeMais.Views.Perfil_Itens
{
    /// <summary>
    /// Interaction logic for PerfilWindow.xaml
    /// </summary>
    public partial class PerfilWindow : Window
    {
        public PerfilWindow()
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closePerfil();

            Instituicao instituicao = new Instituicao();
            InstituicaoBD getDados = new InstituicaoBD();

            instituicao = getDados.getDadosInstituicao(ControlViews.cnpj);

            textBox_bairro.Text = instituicao.Bairro;
            textBox_CEP.Text = instituicao.Cep;
            textBox_cidade.Text = instituicao.Cidade;
            textBox_complemento.Text = instituicao.Complemento;
            textBox_CNPJ.Text = ControlViews.cnpj;
            textBox_email.Text = instituicao.Email;
            textBox_logradouro.Text = instituicao.Logradouro;
            textBox_nomeFantasia.Text = instituicao.NomeFantasia;
            textBox_numero.Text = instituicao.Numero;
            textBox_razaoSocial.Text = instituicao.RazaoSocial;
            textBox_resumoDaEmpresa.Text = instituicao.ResumoEmpresa;
            textBox_telefoneA.Text = instituicao.TelefoneA;
            textBox_telefoneB.Text = instituicao.TelefoneB;
            textBox_UF.Text = instituicao.Uf;
            timePicker_das.Value = instituicao.HoraAbre;
            timePicker_ate.Value = instituicao.HoraFecha;

            if (instituicao.RetiraDoacao == true)
            {
                radioButton_retiraSim.IsChecked = true;
            }

            if (instituicao.DiasAbertos == "Segunda a Sexta")
            {
                checkBox_segunda.IsChecked = true;
                checkBox_terca.IsChecked = true;
                checkBox_quarta.IsChecked = true;
                checkBox_quinta.IsChecked = true;
                checkBox_sexta.IsChecked = true;
            }
            else if (instituicao.DiasAbertos == "Segunda a Sabado")
            {
                checkBox_segunda.IsChecked = true;
                checkBox_terca.IsChecked = true;
                checkBox_quarta.IsChecked = true;
                checkBox_quinta.IsChecked = true;
                checkBox_sexta.IsChecked = true;
                checkBox_sabado.IsChecked = true;
            }
            else if (instituicao.DiasAbertos == "Segunda a Domingo")
            {
                checkBox_segunda.IsChecked = true;
                checkBox_terca.IsChecked = true;
                checkBox_quarta.IsChecked = true;
                checkBox_quinta.IsChecked = true;
                checkBox_sexta.IsChecked = true;
                checkBox_sabado.IsChecked = true;
                checkBox_domingo.IsChecked = true;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void button_selecionarItens_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.startItens();
        }

        private void textBox_CEP_MouseLeave(object sender, MouseEventArgs e)
        {
            EnderecoDados defineEnd = new EnderecoDados();
            Endereco end = new Endereco();
            try
            {
                end = defineEnd.GET(textBox_CEP.Text);
                textBox_bairro.Text = end.Bairro;
                textBox_cidade.Text = end.Cidade;
                textBox_logradouro.Text = end.Logradouro;
                textBox_UF.Text = end.UF;
            }
            catch
            {

            }
        }

        private void button_salvar_Click(object sender, RoutedEventArgs e)
        {
            InstituicaoBD edita = new InstituicaoBD();
            Instituicao instituicao = new Instituicao();

            instituicao.Bairro = textBox_bairro.Text;
            instituicao.Cep = textBox_CEP.Text;
            instituicao.Cidade = textBox_cidade.Text;
            instituicao.Complemento = textBox_complemento.Text;
            //instituicao.DiasAbertos
            instituicao.Email = textBox_email.Text;
            instituicao.HoraAbre = Convert.ToDateTime(timePicker_das.Value);
            instituicao.HoraFecha = Convert.ToDateTime(timePicker_ate.Value);
            instituicao.Logradouro = textBox_logradouro.Text;
            instituicao.NomeFantasia = textBox_nomeFantasia.Text;
            instituicao.Numero = textBox_numero.Text;
            instituicao.ResumoEmpresa = textBox_resumoDaEmpresa.Text;
            instituicao.TelefoneA = textBox_telefoneA.Text;
            instituicao.TelefoneB = textBox_telefoneB.Text;
            instituicao.Uf = textBox_UF.Text;

            if (radioButton_retiraSim.IsChecked == true)
            {
                instituicao.RetiraDoacao = true;
            } 
            else if (radioButton_retiraNao.IsChecked == true)
            {
                instituicao.RetiraDoacao = false;
            }

            if (checkBox_segunda.IsChecked == true && checkBox_terca.IsChecked == true &&
            checkBox_quarta.IsChecked == true && checkBox_quinta.IsChecked == true &&
            checkBox_sexta.IsChecked == true)
            {
                instituicao.DiasAbertos = "Segunda a Sexta";
            }
            else if (checkBox_segunda.IsChecked == true && checkBox_terca.IsChecked == true &&
            checkBox_quarta.IsChecked == true && checkBox_quinta.IsChecked == true &&
            checkBox_sexta.IsChecked == true && checkBox_sabado.IsChecked == true)
            {
                instituicao.DiasAbertos = "Segunda a Sabado";
            }
            else if (checkBox_segunda.IsChecked == true && checkBox_terca.IsChecked == true &&
            checkBox_quarta.IsChecked == true && checkBox_quinta.IsChecked == true &&
            checkBox_sexta.IsChecked == true && checkBox_sabado.IsChecked == true && checkBox_domingo.IsChecked == true)
            {
                instituicao.DiasAbertos = "Segunda a Domingo";
            }

            Boolean update = edita.setDadosInstituicao(instituicao);

            if (update)
            {
                MessageBox.Show("Atualização realizada com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro no servidor. Tente novamente mais tarde");
            }
        }

        private void checkBox_alterar_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox_alterar.IsChecked == true)
            {
                groupBox_dadosGerais.IsHitTestVisible = true;
                textBox_CNPJ.IsReadOnly = true;
                textBox_razaoSocial.IsReadOnly = true;
                groupBox_endereco.IsHitTestVisible = true;
                groupBox_resumoDaEmpresa.IsHitTestVisible = true;
                groupBox_retiraEmDomicilio.IsHitTestVisible = true;
                groupBox_horarioDeFuncionamento.IsHitTestVisible = true;
            }
        }
    }
}
