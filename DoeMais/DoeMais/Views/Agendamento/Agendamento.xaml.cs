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

namespace DoeMais.Views.Agendamento
{
    /// <summary>
    /// Lógica interna para Agendamento.xaml
    /// </summary>
    public partial class Agendamento : Window
    {
        public Agendamento()
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closeAgendamento();
        }

        private void Button_detalhes_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.startAgendamentoDetalhes();
        }

        private void button_resetarBusca_Click(object sender, RoutedEventArgs e)
        {
            textBox_data1.Clear();
            textBox_data2.Clear();
            listView_agendamento.Items.Clear();
        }

        private void button_buscar_Click(object sender, RoutedEventArgs e)
        {
            DoacaoBD retiradas = new DoacaoBD();
            ListaAgendamentos lista = new ListaAgendamentos();
            DateTime data1 = Convert.ToDateTime(textBox_data1.Text);
            DateTime data2 = Convert.ToDateTime(textBox_data2.Text);

            try
            {
                List<String[]> doacoes = retiradas.getDoacoesDeDomicilio(data1, data2);

                foreach (var doacao in doacoes)
                {
                    listView_agendamento.Items.Add(new ListaAgendamentos { Data = doacao[1], NomeDoador = doacao[2] });
                }

                if (doacoes.Count == 0)
                {
                    MessageBox.Show("Não há retiradas agendadas nessas datas!");
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível carregar a lista de agendamentos!");
            }
        }
    }
}
