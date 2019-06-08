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
using DoeMais.Controller.ListViewSettings;

namespace DoeMais.Views.Mensagens
{
    /// <summary>
    /// Lógica interna para MensagensWindow.xaml
    /// </summary>
    public partial class MensagensWindow : Window
    {
        public MensagensWindow()
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closeMensagens();
            textBox_dataDe.IsEnabled = false;

            MensagemBD getMensagens = new MensagemBD();
            List<String[]> mensagens = getMensagens.getMensagens();

            foreach (var mensagem in mensagens)
            {
                listView_mensagens.Items.Add(new MensagensRecebidas() { Data = mensagem[2], Nome = mensagem[1], Mensagem = mensagem[3] });
            }
        }

        private void button_voltar_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.voltarMensagens();
        }

        private void button_abrirMensagem_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.startMensagensMais();
        }

        private void checkBox_filtroData_Checked(object sender, RoutedEventArgs e)
        {

            if (checkBox_filtroData.IsChecked == true)
            {
                textBox_dataDe.IsEnabled = true;
            }
        }

        private void button_buscar_Click(object sender, RoutedEventArgs e)
        {
            DoadorBD getDoadorID = new DoadorBD();
            MensagemBD getMensagens = new MensagemBD();

            if (checkBox_filtroData.IsChecked == false)
            {
                String[] doador = getDoadorID.getDoadorId(textBox_CpfCnpj.Text);
                List<String[]> mensagens = getMensagens.getMensagensDoDoador(Convert.ToInt32(doador[0]));

                foreach (var mensagem in mensagens)
                {
                    listView_mensagens.Items.Add(new MensagensRecebidas() { Data = mensagem[0], Nome = mensagem[1], Mensagem = mensagem[3] });
                }
            }
            else if (checkBox_filtroData.IsChecked == true)
            {

            }
        }
    }
}
