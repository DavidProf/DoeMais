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

namespace DoeMais.Views.CadastroFuncionario
{
    /// <summary>
    /// Interaction logic for CadastroFuncionarioWindow.xaml
    /// </summary>
    public partial class CadastroFuncionarioWindow : Window
    {
        public CadastroFuncionarioWindow()
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closePerfil();
        }
    }
}
