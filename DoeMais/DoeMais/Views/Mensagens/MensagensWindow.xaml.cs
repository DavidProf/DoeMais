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

            try
            {
                foreach (String[] mensagem in mensagens)
                {
                    listView_mensagens.Items.Add(new MensagensRecebidas() { Data = mensagem[3], IdDoador = mensagem[1], Nome = mensagem[2], Mensagem = mensagem[4] });
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível carregar a lista de mensagens no momento. Tente novamente mais tarde");
            }
           
        }

        private void button_voltar_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.voltarMensagens();
        }

        private void button_abrirMensagem_Click(object sender, RoutedEventArgs e)
        {
            MensagensRecebidas mensagem = new MensagensRecebidas();

            try
            {
                mensagem = (MensagensRecebidas)listView_mensagens.SelectedItem;
                ControlViews.startMensagensMais(mensagem.IdMensagem, mensagem.Nome, mensagem.IdDoador, mensagem.Mensagem);
            }
            catch
            {
                MessageBox.Show("Por favor, selecione uma mensagem!");
            }
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

            if (textBox_CpfCnpj.Text == "" || textBox_dataDe.Text == "" || textBox_dataAte.Text == "")
            {
                MessageBox.Show("Digite o CPF/CNPJ do doador ou um intervalo de datas para realizar a busca!");
            }

            if (checkBox_filtroData.IsChecked == false)
            {
                try
                {
                    String[] doador = getDoadorID.getDoadorId(textBox_CpfCnpj.Text);
                    List<String[]> mensagens = getMensagens.getMensagensDoDoador(Convert.ToInt32(doador[0]));

                    foreach (var mensagem in mensagens)
                    {
                        listView_mensagens.Items.Add(new MensagensRecebidas() { Data = mensagem[0], Nome = mensagem[1], Mensagem = mensagem[3] });
                    }
                }
                catch
                {
                    MessageBox.Show("Não foi possível carregar as mensagens!");
                }
            }
            else if (checkBox_filtroData.IsChecked == true)
            {
                DateTime data1 = Convert.ToDateTime(textBox_dataDe.Text);
                DateTime data2 = Convert.ToDateTime(textBox_dataAte.Text);

                String data1Formatada = data1.ToString("yyyy-MM-dd HH:mm:ss.fff");
                String data2Formatada = data2.ToString("yyyy-MM-dd HH:mm:ss.fff");

                try
                {
                    List<String[]> mensagens = getMensagens.getMensagensPorData(data1Formatada, data2Formatada);

                    foreach (var mensagem in mensagens)
                    {
                        listView_mensagens.Items.Add(new MensagensRecebidas() { Data = mensagem[0], Nome = mensagem[1], Mensagem = mensagem[3] });
                    }
                }
                catch
                {
                    MessageBox.Show("Não foi possível carregar as mensagens!");
                }
            }
        }
    }
}
