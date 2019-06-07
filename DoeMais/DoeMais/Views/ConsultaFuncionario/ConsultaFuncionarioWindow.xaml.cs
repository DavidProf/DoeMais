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

namespace DoeMais.Views.ConsultaFuncionario
{
    /// <summary>
    /// Interaction logic for ConsultaFuncionarioWindow.xaml
    /// </summary>
    public partial class ConsultaFuncionarioWindow : Window
    {
        public ConsultaFuncionarioWindow()
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closeConsultaFunc();
            textBox_Busca.Opacity = 0;
        }

        private void button_voltar_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.voltarConsultaFunc();
        }

        private void radioButton_nenhum_Checked(object sender, RoutedEventArgs e)
        {
            textBox_Busca.Opacity = 0;
        }

        private void radioButton_CPF_Checked(object sender, RoutedEventArgs e)
        {
            textBox_Busca.Opacity = 1;
        }

        private void radioButton_Nome_Checked(object sender, RoutedEventArgs e)
        {
            textBox_Busca.Opacity = 1;
        }

        private void button_buscar_Click(object sender, RoutedEventArgs e)
        {
            FuncionarioBD getFunc = new FuncionarioBD();
           // getFunc.getFuncionarios(//nome ou cpf, adicionar checkbox se ativo ou inativo)
        }
    }
}
