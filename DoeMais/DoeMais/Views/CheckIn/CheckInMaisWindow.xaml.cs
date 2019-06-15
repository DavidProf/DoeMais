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
            textBox_data.Text = data;
            textBox_hora.Text = "depois faz o split";
            textBox_nome.Text = nome;

            DoacaoBD doacao = new DoacaoBD();
            ItensDoacao itemDoacao = new ItensDoacao();
            List<String> itens = doacao.getItensDaDoacao(Convert.ToInt32(codigo));

            try
            {
                foreach (var item in itens)
                {
                    listView_itens.Items.Add(new ItensDoacao() { Nome = item[0].ToString(), Qtd = item[1].ToString() });
                }

                if (domicilio == "0")
                {
                    checkBox_retiraDomicilio.IsChecked = false;
                }
                else if (domicilio == "1")
                {
                    checkBox_retiraDomicilio.IsChecked = true;
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível carregar a lista de itens no momento. Tente novamente mais tarde");
            }
        }
    }
}
