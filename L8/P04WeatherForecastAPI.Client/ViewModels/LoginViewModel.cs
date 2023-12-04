using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P06Shop.Shared.Auth;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.AuthService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        private readonly IMessageDialogService _messageDialogService;

        public static string Token { get; set; } = string.Empty;

        public LoginViewModel(IAuthService authService, IMessageDialogService messageDialogService)
        {
            UserLoginDTO = new UserLoginDTO();
            _authService = authService;
            _messageDialogService = messageDialogService;
        }

        [ObservableProperty]
        private UserLoginDTO userLoginDTO;

         
        public async Task Login(string password)
        {
            UserLoginDTO.Password = password;
            var response = await _authService.Login(UserLoginDTO);
            if (response.Success)
            {
                Token = response.Data;
                _messageDialogService.ShowMessage("Hello " + UserLoginDTO.Email);
            }
            else
            {
                _messageDialogService.ShowMessage("Wrong credentials");
            }
            
        }

        [RelayCommand]
        public async Task MouseEnter()
        {
             
        }




    }

}
