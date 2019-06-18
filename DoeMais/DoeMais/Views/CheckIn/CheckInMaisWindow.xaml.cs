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

namespace DoeMais.Views.CheckIn
{
    /// <summary>
    /// Interaction logic for CheckInMaisWindow.xaml
    /// </summary>
    public partial class CheckInMaisWindow : Window
    {
        public CheckInMaisWindow(String codigo, String data, String nome, String cpfcnpj, String domicilio)
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closeCheckInMais();

            textBox_cpfCnpj.Text = cpfcnpj;
            String[] dataHora = data.Split(' ');
            textBox_data.Text = dataHora[0];
            textBox_hora.Text = dataHora[1];
            textBox_nome.Text = nome;
            label_codigo.Content = codigo;

            DoacaoBD doacao = new DoacaoBD();
            ItensDoacao itemDoacao = new ItensDoacao();
            List<String[]> itens = doacao.getItensDaDoacao(Convert.ToInt32(codigo));

            if (domicilio == "0")
            {
                checkBox_retiraDomicilio.IsChecked = false;
            }
            else if (domicilio == "1")
            {
                checkBox_retiraDomicilio.IsChecked = true;
            }

            try
            {
                for (int i = 0; itens.Count > i; i++)
                {
                    listView_itens.Items.Add(new ItensDoacao() { Nome = itens[i][0], Qtd = itens[i][1] });
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível carregar a lista de itens no momento. Tente novamente mais tarde");
            }
        }

        private void button_Concluir_Click(object sender, RoutedEventArgs e)
        {
            DoacaoBD doacao = new DoacaoBD();
            Boolean concluir = doacao.retiraPendenciaDaDoacao(Convert.ToInt32(label_codigo.Content));

            if (concluir)
            {
                MessageBox.Show("Registro de doação concluído com sucesso!");
                ControlViews.closeCheckInMais();
            }
            else
            {
                MessageBox.Show("Erro ao concluir a doação. Tente novamente mais tarde");
            }
        }
    }
}
