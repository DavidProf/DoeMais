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

namespace DoeMais.Views
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => System.Windows.Application.Current.Shutdown();
        }

        private void Button_perfil_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.startPerfil();
        }

        private void button_checkin_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.startCheckIn();
        }

        private void button_checarRetiradas_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.startAgendamento();
        }

        private void Button_doacoes_Click(object sender, RoutedEventArgs e)
        {
            grid_doacoes.Visibility = Visibility.Visible;
            grid_instituicao.Visibility = Visibility.Hidden;
            button_instituicao.Style = Application.Current.FindResource("button_transparent") as Style;
            button_doacoes.Style = Application.Current.FindResource("button_gradient") as Style;
        }

        private void Button_instituicao_Click(object sender, RoutedEventArgs e)
        {
            grid_doacoes.Visibility = Visibility.Hidden;
            grid_instituicao.Visibility = Visibility.Visible;
            button_instituicao.Style = Application.Current.FindResource("button_gradient") as Style;
            button_doacoes.Style = Application.Current.FindResource("button_transparent") as Style;
        }

        private void button_cadastrarFuncionarios_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.startCadastroFunc();
        }

        private void button_mensagens_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.startMensagens();
        }

        private void button_propaganda_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.startPropagandas();
        }

        private void button_consultarFuncionarios_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.startConsultaFunc();
        }

        private void button_registrarDoacao_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.startRegistroDoacao();
        }

        private void button_estoque_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.startEstoque();
        }

        private void button_triagem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_saida_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
