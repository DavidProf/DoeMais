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

namespace DoeMais.Views.Triagem
{
    /// <summary>
    /// Lógica interna para TriagemWindow.xaml
    /// </summary>
    public partial class TriagemWindow : Window
    {
        public TriagemWindow()
        {
            InitializeComponent();
            MinimizeWindow.Click += (s, e) => WindowState = WindowState.Minimized;
            CloseApp.Click += (s, e) => ControlViews.closeTriagem();
        }

        private void button_voltar_Click(object sender, RoutedEventArgs e)
        {
            ControlViews.voltarTriagem();
        }
    }
}
