using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoeMais.Views
{
    class ControlViews
    {
        //Todos os controles de janelas devem ser feitos por aqui
        #region Váriaveis de acesso
        public static String tipoDeAcesso = "";
        public static String idFunc = "";
        public static String cpf = "";
        public static Boolean adm = false;
        public static String cnpj = "";
        #endregion

        #region variaveis para iniciar e controlar as telas
        private static MenuWindow menuWindow;
        //perfil
        private static Perfil_Itens.PerfilWindow perfilWindow;
        private static bool perfilOn = false;
        //Agendamento
        private static Agendamento.Agendamento agendamentoWindow;
        private static bool agendamentoOn = false;
        //Itens
        private static Perfil_Itens.ItensWindow itensWindow;
        private static bool itensOn = false;
        //AgendamentoDetalhes
        private static Agendamento.AgendamentoDetalhes agendamentoDetalhesWindow;
        private static bool agendamentoDetalhesOn = false;
        #endregion
        public ControlViews()
        {
            //colocar validações e mudar de acordo com adm ou não
            menuWindow = new MenuWindow();
            menuWindow.Show();
        }

        //Fechar e abrir janela de perfil
        #region perfil
        public static void startPerfil()
        {
            if (itensOn)
            {
                itensWindow.Focus();
                return;
            }
            if (perfilOn)
            {
                perfilWindow.Focus();
            }
            else
            {
                perfilWindow = new Perfil_Itens.PerfilWindow();
                perfilWindow.Show();
                perfilWindow.Left = menuWindow.Left + 50;
                perfilWindow.Top = menuWindow.Top - 50;
                perfilOn = true;
            }

        }

        public static void closePerfil()
        {
            if (perfilOn)
            {
                perfilWindow.Close();
                perfilWindow = null;
                menuWindow.Focus();
                perfilOn = false;
            }
        }
        #endregion
        //Fechar e abrir janela de seleção de itens que a instituição aceita
        #region itens
        public static void startItens()
        {
            if (itensOn)
            {
                itensWindow.Focus();
            }
            else
            {
                double x = perfilWindow.Left;
                double y = perfilWindow.Top;
                closePerfil();
                itensWindow = new Perfil_Itens.ItensWindow();
                itensWindow.Show();
                itensWindow.Left = x;
                itensWindow.Top = y;
                itensOn = true;
            }
        }

        public static void closeItens()
        {
            if (itensOn)
            {
                itensWindow.Close();
                itensWindow = null;
                menuWindow.Focus();
                itensOn = false;
            }
        }

        #endregion
        //Fechar e abrir janela de agendamento
        #region agendamento
        public static void startAgendamento()
        {
            if (agendamentoDetalhesOn)
            {
                agendamentoDetalhesWindow.Focus();
                return;
            }
            if (agendamentoOn)
            {
                agendamentoWindow.Focus();
            }
            else
            {
                agendamentoWindow = new Agendamento.Agendamento();
                agendamentoWindow.Show();
                agendamentoDetalhesWindow.Left = menuWindow.Left + 50;
                agendamentoDetalhesWindow.Top = menuWindow.Top - 50;
                agendamentoOn = true;
            }
        }

        public static void closeAgendamento()
        {
            if (agendamentoOn)
            {
                agendamentoWindow.Close();
                agendamentoWindow = null;
                menuWindow.Focus();
                agendamentoOn = false;
            }
        }
        #endregion
        //Fechar e abrir janela de agendamentoDetalhes
        #region agendamento detalhes
        public static void startAgendamentoDetalhes()
        {
            if (agendamentoDetalhesOn)
            {
                agendamentoDetalhesWindow.Focus();
            }
            else
            {
                double x = agendamentoWindow.Left;
                double y = agendamentoWindow.Top;
                closeAgendamento();
                agendamentoDetalhesWindow = new Agendamento.AgendamentoDetalhes();
                agendamentoDetalhesWindow.Show();
                agendamentoDetalhesWindow.Top = y;
                agendamentoDetalhesWindow.Left = x;
                agendamentoDetalhesOn = true;
            }
        }

        public static void closeAgendamentoDetalhes()
        {
            if (agendamentoDetalhesOn)
            {
                agendamentoDetalhesWindow.Close();
                agendamentoDetalhesWindow = null;
                menuWindow.Focus();
                agendamentoDetalhesOn = false;
            }
        }

        public static void voltarAgendamentoDetalhes()
        {
            if (agendamentoDetalhesOn)
            {
                closeAgendamentoDetalhes();
                startAgendamento();
            }
        }
        #endregion
    }
}
