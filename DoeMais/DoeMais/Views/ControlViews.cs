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

        private static MenuWindow menuWindow;
        private static Perfil_Itens.PerfilWindow perfilWindow;
        private static Agendamento.Agendamento agendamentoWindow;


        public ControlViews()
        {
            //colocar validações e mudar de acordo com adm ou não
            menuWindow = new MenuWindow();
            menuWindow.Show();
        }

        //Fechar e abrir janela de perfil
        public static void startPerfil()
        {
            menuWindow.Hide();
            perfilWindow = new Perfil_Itens.PerfilWindow();
            perfilWindow.Show();
        }

        public static void closePerfil()
        {
            perfilWindow.Close();
            perfilWindow = null;
            menuWindow.Show();
        }

        //Fechar e abrir janela de perfil
        public static void startAgendamento()
        {
            menuWindow.Hide();
            agendamentoWindow = new Agendamento.Agendamento();
            agendamentoWindow.Show();
        }

        public static void closeAgendamento()
        {
            agendamentoWindow.Close();
            agendamentoWindow = null;
            menuWindow.Show();
        }
    }
}
