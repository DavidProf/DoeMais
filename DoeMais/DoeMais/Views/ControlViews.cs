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

        // CadastroFuncionario
        private static CadastroFuncionario.CadastroFuncionarioWindow cadastroFuncionarioWindow;
        private static bool cadastroFuncOn = false;

        // ConsultaFuncionario
        private static ConsultaFuncionario.ConsultaFuncionarioWindow consultaFuncionarioWindow;
        private static bool consultaFuncOn = false;

        // Mensagens
        private static Mensagens.MensagensWindow mensagensWindow;
        private static bool mensagensOn = false;

        // Propaganda
        private static Propaganda.PropagandasWindow propagandasWindow;
        private static bool propagandaOn = false;

        //RegistroDoacao
        private static CadastroDoacao.CadastroDoacaoWindow cadastroDoacaoWindow;
        private static bool cadastroDoacaoOn = false;

        // Check-in
        private static CheckIn.CheckInWindow checkInWindow;
        private static bool checkInOn = false;

        // Check-in Mais
        private static CheckIn.CheckInMaisWindow checkInMaisWindow;
        private static bool checkInMaisOn = false;

        // Estoque
        private static ItensArmazenados.ItensArmazenadosWindow itensArmazenadosWindow;
        private static bool estoqueOn = false;

        // Triagem
        private static Triagem.TriagemWindow triagemWindow;
        private static bool triagemOn = false;

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

        // Fechar e abrir janela de cadastro de funcionários
        #region cadastroFuncionario

        public static void startCadastroFunc()
        {
            if (cadastroFuncOn)
            {
                cadastroFuncionarioWindow.Focus();
            }
            else
            {
                cadastroFuncionarioWindow = new CadastroFuncionario.CadastroFuncionarioWindow();
                cadastroFuncionarioWindow.Show();
                cadastroFuncionarioWindow.Left = menuWindow.Left + 50;
                cadastroFuncionarioWindow.Top = menuWindow.Top - 50;
                cadastroFuncOn = true;
            }
        }

        public static void closeCadastroFunc()
        {
            cadastroFuncionarioWindow.Close();
            cadastroFuncionarioWindow = null;
            menuWindow.Focus();
            cadastroFuncOn = false;
        }

        #endregion

        // Fechar e abrir janela de consulta de funcionários 
        #region consultaFuncionario

        public static void startConsultaFunc()
        {
            if (consultaFuncOn)
            {
                consultaFuncionarioWindow.Focus();
            }
            else
            {
                consultaFuncionarioWindow = new ConsultaFuncionario.ConsultaFuncionarioWindow();
                consultaFuncionarioWindow.Show();
                consultaFuncionarioWindow.Left = menuWindow.Left + 50;
                consultaFuncionarioWindow.Top = menuWindow.Top - 50;
                consultaFuncOn = true;
            }
        }

        public static void closeConsultaFunc()
        {
            consultaFuncionarioWindow.Close();
            consultaFuncionarioWindow = null;
            menuWindow.Focus();
            consultaFuncOn = false;
        }

        #endregion

        // Fechar e abrir janela de consulta de funcionários - detalhes

        // Fechar e abrir janela de mensagens
        #region mensagens
        
        public static void startMensagens()
        {
            if (mensagensOn)
            {
                mensagensWindow.Focus();
            }
            else
            {
                mensagensWindow = new Mensagens.MensagensWindow();
                mensagensWindow.Show();
                mensagensWindow.Left = menuWindow.Left + 50;
                mensagensWindow.Top = menuWindow.Top - 50;
                mensagensOn = true;
            }
        }

        public static void closeMensagens()
        {
            mensagensWindow.Close();
            mensagensWindow = null;
            menuWindow.Focus();
            mensagensOn = false;
        }

        #endregion

        // Fechar e abrir janela de mensagensMais

        // Fechar e abrir janela de propaganda
        #region propagandas

        public static void startPropagandas()
        {
            if (propagandaOn)
            {
                propagandasWindow.Focus();
            }
            else
            {
                propagandasWindow = new Propaganda.PropagandasWindow();
                propagandasWindow.Show();
                propagandasWindow.Left = menuWindow.Left + 50;
                propagandasWindow.Top = propagandasWindow.Top - 50;
                propagandaOn = true;
            }
        }

        public static void closePropagandas()
        {
            propagandasWindow.Close();
            propagandasWindow = null;
            menuWindow.Focus();
            propagandaOn = false;
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
                agendamentoWindow.Left = menuWindow.Left + 50;
                agendamentoWindow.Top = menuWindow.Top - 50;
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

        // Fechar e abrir janela de registro de doações
        #region registroDoacao

        public static void startRegistroDoacao()
        {
            if (cadastroDoacaoOn)
            {
                cadastroDoacaoWindow.Focus();
            }
            else
            {
                cadastroDoacaoWindow = new CadastroDoacao.CadastroDoacaoWindow();
                cadastroDoacaoWindow.Show();
                cadastroDoacaoWindow.Left = menuWindow.Left + 50;
                cadastroDoacaoWindow.Top = menuWindow.Top - 50;
                cadastroDoacaoOn = true;
            }
        }

        public static void closeRegistroDoacao()
        {
            if (cadastroDoacaoOn)
            {
                cadastroDoacaoWindow.Close();
                cadastroDoacaoWindow = null;
                menuWindow.Focus();
                cadastroDoacaoOn = false;
            }
        }

        #endregion

        // Fechar e abrir janela de check-in
        #region checkIn

        public static void startCheckIn()
        {
            if (checkInOn)
            {
                checkInWindow.Focus();
            }
            else
            {
                checkInWindow = new CheckIn.CheckInWindow();
                checkInWindow.Show();
                checkInWindow.Left = menuWindow.Left + 50;
                checkInWindow.Top = menuWindow.Top - 50;
                checkInOn = true;
            }
        }

        public static void closeCheckIn()
        {
            if (checkInOn)
            {
                checkInWindow.Close();
                checkInWindow = null;
                menuWindow.Focus();
                checkInOn = false;
            }
        }

        public static void voltarCheckIn()
        {
            if (checkInOn)
            {
                closeCheckIn();
                menuWindow.Focus();
            }
        }

        #endregion

        // Fechar e abrir janela de checkInMais
        #region checkin mais

        public static void startCheckInMais()
        {
            if (checkInMaisOn)
            {
                checkInMaisWindow.Focus();
            }
            else
            {
                double x = checkInWindow.Left;
                double y = checkInWindow.Top;
                closeCheckIn();
                checkInMaisWindow = new CheckIn.CheckInMaisWindow();
                checkInMaisWindow.Show();
                checkInMaisWindow.Top = y;
                checkInMaisWindow.Left = x;
                checkInMaisOn = true;
            }
        }

        public static void closeCheckInMais()
        {
            if (checkInMaisOn)
            {
                checkInMaisWindow.Close();
                checkInMaisWindow = null;
                menuWindow.Focus();
                checkInMaisOn = false;
            }
        }

        #endregion

        // Fechar e abrir janela de estoque
        #region estoque

        public static void startEstoque()
        {
            if (estoqueOn)
            {
                itensArmazenadosWindow.Focus();
            }
            else
            {
                itensArmazenadosWindow = new ItensArmazenados.ItensArmazenadosWindow();
                itensArmazenadosWindow.Show();
                itensArmazenadosWindow.Left = menuWindow.Left + 50;
                itensArmazenadosWindow.Top = menuWindow.Top - 50;
                estoqueOn = true;
            }
        }

        public static void closeEstoque()
        {
            if (estoqueOn)
            {
                itensArmazenadosWindow.Close();
                itensArmazenadosWindow = null;
                menuWindow.Focus();
                estoqueOn = false;
            }
        }

        #endregion

        // Fechar e abrir janela de triagem
        #region triagem
        public static void startTriagem()
        {
            if (triagemOn)
            {
                triagemWindow.Focus();
            }
            else
            {
                triagemWindow = new Triagem.TriagemWindow();
                triagemWindow.Show();
                triagemWindow.Left = menuWindow.Left + 50;
                triagemWindow.Top = menuWindow.Top - 50;
                triagemOn = true;
            }
        }

        public static void closeTriagem()
        {
            if (triagemOn)
            {
                triagemWindow.Close();
                triagemWindow = null;
                menuWindow.Focus();
                triagemOn = false;
            }
        }

        public static void voltarTriagem()
        {
            if (triagemOn)
            {
                closeTriagem();
                menuWindow.Focus();
            }
        }

        #endregion

        // Fechar e abrir janela de saída

        // Menu de quem não é administrador
        #region menu comum

        public static void openMenuComum()
        {
            menuWindow = new MenuWindow();
            menuWindow.button_cadastrarFuncionarios.IsEnabled = false;
            menuWindow.button_cadastrarFuncionarios.Opacity = 0;
            menuWindow.button_consultarFuncionarios.IsEnabled = false;
            menuWindow.button_consultarFuncionarios.Opacity = 0;
            menuWindow.button_perfil.IsEnabled = false;
            menuWindow.button_perfil.Opacity = 0;
            menuWindow.Show();
        }

        #endregion
    }
}
