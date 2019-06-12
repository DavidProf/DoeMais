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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DoeMais.Controller.SISTEMA;

namespace DoeMais.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => System.Windows.Application.Current.Shutdown();
        }

        private void Button_entrar_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            bool teste = l.logar(textBox_Usuario.Text, textBox_Senha.Text);

            if (teste)
            {
                if (ControlViews.adm)
                {
                    new ControlViews();
                    this.Close();
                }
                else
                {
                    ControlViews.openMenuComum();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor, verifique seu acesso com a sua instituição");
            }
        }
    }
}
