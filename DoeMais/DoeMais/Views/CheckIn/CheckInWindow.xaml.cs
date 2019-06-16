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
    /// Interaction logic for CheckInWindow.xaml
    /// </summary>
    public partial class CheckInWindow : Window
    {
        public CheckInWindow()
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closeCheckIn();
        }

        private void button_detalhes_Click(object sender, RoutedEventArgs e)
        {
            ListaDoacoes doacoes = new ListaDoacoes();

            try
            {
                doacoes = (ListaDoacoes)listView_doacoes.SelectedItem;
                ControlViews.startCheckInMais(doacoes.CodDoacao, doacoes.Data, doacoes.Nome, doacoes.CpfCnpj, doacoes.Domicilio);
            }
            catch
            {
                MessageBox.Show("Por favor, selecione uma doação pendente!");
            }
        }

        private void button_voltar_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.voltarCheckIn();
        }

        private void button_buscar_Click(object sender, RoutedEventArgs e)
        {
            DoacaoBD doaBD = new DoacaoBD();
            ListaDoacoes lista = new ListaDoacoes();

            if (radioButton_nenhum.IsChecked == true)
            {
                textBox_busca.IsReadOnly = true;
            }

            if (radioButton_CPF.IsChecked == true || radioButton_CNPJ.IsChecked == true || radioButton_nome.IsChecked == true || radioButton_nenhum.IsChecked == true)
            {
                if (textBox_busca.Text == "")
                {
                    MessageBox.Show("Digite o CPF/CNPJ ou o nome do doador para realizar a busca!");
                }

                try
                {
                    List<String[]> doacoes = doaBD.getDoacoes(textBox_busca.Text);
                    foreach (var doacao in doacoes)
                    {
                        if (doacao[4] == "0")
                        {
                            listView_doacoes.Items.Add(new ListaDoacoes() { CodDoacao = doacao[0], Data = doacao[1], Nome = doacao[2], CpfCnpj = doacao[3], Domicilio = "Não" });
                        }
                        else if (doacao[4] == "1")
                        {
                            listView_doacoes.Items.Add(new ListaDoacoes() { CodDoacao = doacao[0], Data = doacao[1], Nome = doacao[2], CpfCnpj = doacao[3], Domicilio = "Sim" });
                        }
                    }

                    if (doacoes.Count == 0)
                    {
                        MessageBox.Show("Não há doações pendentes!");
                    }
                }
                catch
                {
                    MessageBox.Show("Erro no servidor. Por favor, tente novamente mais tarde");
                }
            }
        }
    }
}
