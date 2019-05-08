using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoeMais.Views
{
    class ControlViews
    {
        //Todos os controles de janelas devem ser feitps por aqui
        #region Váriaveis de acesso
        public static String tipoDeAcesso = "";
        public static String idFunc = "";
        public static String cpf = "";
        public static Boolean adm = false;
        public static String cnpj = "";
        #endregion

        //variaveis para iniciar e controlar as telas
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
        //Fechar e abrir janela de perfil
        #region agendamento
        public static void startAgendamento()
        {
            if (agendamentoOn)
            {
                agendamentoWindow.Focus();
            }
            else
            {
                agendamentoWindow = new Agendamento.Agendamento();
                agendamentoWindow.Show();
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
                closePerfil();
                itensWindow = new Perfil_Itens.ItensWindow();
                itensWindow.Show();
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
                agendamentoOn = false;
            }
        }

        #endregion
    }
}
