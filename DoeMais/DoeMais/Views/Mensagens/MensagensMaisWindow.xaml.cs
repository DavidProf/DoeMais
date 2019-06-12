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
using DoeMais.Controller.ListViewSettings;
using DoeMais.BD;

namespace DoeMais.Views.Mensagens
{
    /// <summary>
    /// Lógica interna para MensagensMaisWindow.xaml
    /// </summary>
    public partial class MensagensMaisWindow : Window
    {
        public MensagensMaisWindow(int idMensagem, String nome, String idDoador, String mensagem)
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closeMensagensMais();

            textBox_codDoador.Text = idDoador;
            textBox_mensagem.Text = mensagem;
            textBox_nomeDoador.Text = nome;
        }

        private void button_Voltar_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.voltarMensagensMais();
        }

        private void button_Enviar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MensagemBD mensagem = new MensagemBD();
                mensagem.enviarMensagem(Convert.ToInt32(textBox_codDoador.Text), textBox_resposta.Text);
                MessageBox.Show("Mensagem enviada com sucesso!");
                textBox_resposta.Clear();
            }
            catch
            {
                MessageBox.Show("Não foi possível enviar a mensagem. Tente novamente mais tarde");
            }
        }
    }
}
