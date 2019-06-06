﻿using System;
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
                List<Item> itens = itemAction.getItems();

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
    }
}
