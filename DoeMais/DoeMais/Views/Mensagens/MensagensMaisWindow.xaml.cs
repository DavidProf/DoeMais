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
        public MensagensMaisWindow(String id)
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closeMensagensMais();

            List<String[]> mensagens = new List<String[]>();
            MensagemBD getMensagem = new MensagemBD();

            mensagens = getMensagem.getMensagensDoDoador(Convert.ToInt32(id));

            foreach (var mensagem in mensagens)
            {
               
            }

        }

        private void button_Voltar_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.voltarMensagensMais();
        }
    }
}
