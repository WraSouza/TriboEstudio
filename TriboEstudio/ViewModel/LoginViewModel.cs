using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriboEstudio.FirebaseServices;
using TriboEstudio.Services;

namespace TriboEstudio.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        private string _nomeUsuario;
        private string _senhaUsuario;
        private bool _Result;
        private bool _IsBusy;
        private const string _statusUsuario = "Ativo";
        AlunoServices userServices = new AlunoServices();
        public Command LoginCommand { get; set; }
        public Command AbrirSobreView { get; set; }
        public INavigation navigation { get; set; }
        public Command AbrirSobreAcademiaView { get; set; }

        public LoginViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            LoginCommand = new Command(async () => await LoginCommandAsync());
            AbrirSobreAcademiaView = new Command(async () => await IrParaSobreAcademia());
        }

        public async Task IrParaSobreAcademia()
        {
            await navigation.PushAsync(new View.SobreAcademiaView());
        }

        public string Nome
        {
            get => _nomeUsuario;
            set
            {
                _nomeUsuario = value.ToLower();
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get => _senhaUsuario;
            set
            {
                _senhaUsuario = value;
                OnPropertyChanged();
            }
        }

        //Método para verificar se o login foi realizado com sucesso
        public bool Result
        {
            get => _IsBusy;
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }

        //Método para verificar se o login está sendo realizado para evitar concorrência
        public bool IsBusy
        {
            get => _Result;
            set
            {
                _Result = value;
                OnPropertyChanged();
            }
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;

            try
            {
                bool verificaConexao = Conectividade.VerificaConectividade();

                if (verificaConexao)
                {
                    IsBusy = true;
                    var professorService = new ProfessorServices();
                    Result = await professorService.LoginUser(Nome, Senha);

                    if (Result)
                    {
                        Preferences.Set("Nome", Nome.ToUpper());
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        Mensagem.UsuarioSenhaInvalidos();
                    }

                }
                else
                {
                    Mensagem.MensagemErroConexao();
                }

            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
