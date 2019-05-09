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

namespace DoeMais.Views.Agendamento
{
    /// <summary>
    /// Interaction logic for AgendamentoDetalhes.xaml
    /// </summary>
    public partial class AgendamentoDetalhes : Window
    {
        public AgendamentoDetalhes()
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closeAgendamentoDetalhes();
        }

        private void Button_voltar_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.voltarAgendamentoDetalhes();
        }
    }
}
