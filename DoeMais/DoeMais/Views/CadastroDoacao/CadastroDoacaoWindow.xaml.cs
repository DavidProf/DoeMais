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
using DoeMais.Controller.Objetos;
using DoeMais.Controller.ListViewSettings;

namespace DoeMais.Views.CadastroDoacao
{
    /// <summary>
    /// Lógica interna para CadastroDoacaoWindow.xaml
    /// </summary>
    public partial class CadastroDoacaoWindow : Window
    {
        public CadastroDoacaoWindow()
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closeRegistroDoacao();
            DateTime hoje = DateTime.Today;
            textBox_data.Text = hoje.ToString("dd/MM/yyyy");

            ItemBD itemAction = new ItemBD();

            try
            {
                List<Item> itens = itemAction.getItensInstituicao();

                foreach (var item in itens)
                {
                    comboBox_itens.Items.Add(item.Nome);
                }
            }
            catch
            {
                comboBox_itens.Items.Add("Erro no servidor");
            }
        }

        private void button_cancelar_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.voltarRegistroDoacao();
        }

        private void button_adicionarItem_Click(object sender, RoutedEventArgs e)
        {
            listView_itens.Items.Add(new ItensCadastroDoacao() { Item = comboBox_itens.Text, Qtd = Convert.ToInt32(numeric_itens.Value) });
            comboBox_itens.SelectedIndex = -1;
            numeric_itens.Value = null;
        }

        private void button_removerItem_Click(object sender, RoutedEventArgs e)
        {
            listView_itens.Items.RemoveAt(listView_itens.SelectedIndex);
        }

        private void button_cadastrar_Click(object sender, RoutedEventArgs e)
        {
            DoadorBD doador = new DoadorBD();
            String[] dados = doador.getDoadorParaCadastroDeDoacao(textBox_buscaCPF.Text);

            DoacaoBD doacao = new DoacaoBD();
            String criaDoacao = doacao.addDoacao(Convert.ToInt32(dados[2]), ControlViews.idFunc);

            if (listView_itens.HasItems)
            {
                foreach (ItensCadastroDoacao item in listView_itens.Items)
                {
                    Boolean resultado = doacao.addItemNaDoacao(Convert.ToInt32(criaDoacao), item.Item);
                    MessageBox.Show(item.Item);

                    if (resultado)
                    {
                        MessageBox.Show("Doação registrada com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Erro no servidor. Por favor, tente novamente");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, adicione itens para a doação!");
            }
        }

        private void textBox_buscaCPF_MouseLeave(object sender, MouseEventArgs e)
        {
            DoadorBD doador = new DoadorBD();
            String[] dados = doador.getDoadorParaCadastroDeDoacao(textBox_buscaCPF.Text);
            textBox_nome.Text = dados[0];
            textBox_cpf.Text = dados[1];
        }

        private void checkBox_semCad_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox_semCad.IsChecked == true)
            {
                textBox_buscaCPF.IsReadOnly = true;
            }
            else
            {
                textBox_cpf.IsReadOnly = true;
                textBox_nome.IsReadOnly = true;
            }
        }
    }
}
