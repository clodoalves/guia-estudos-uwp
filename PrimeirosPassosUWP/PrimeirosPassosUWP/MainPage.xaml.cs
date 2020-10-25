using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PrimeirosPassosUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void EnviarDados_Click(object sender, RoutedEventArgs e)
        {
            await ValidarCamposObrigatorios();
            await ValidarEmail();
            await ValidarAceiteTermosUso();

            Usuario usuario = MontarObjeto();
        }

        private Usuario MontarObjeto()
        {
            Usuario usuario = new Usuario();
            usuario.Nome = nome.Text.Trim();
            usuario.Email = email.Text.Trim();
            usuario.Sexo = checkF.IsChecked.HasValue ? "Feminino" : "Masculino";
            usuario.DataNascimento = dataNascimento.Date;

            return usuario;
        }

        private async Task ValidarCamposObrigatorios()
        {
            if (string.IsNullOrWhiteSpace(nome.Text) ||
                            string.IsNullOrWhiteSpace(email.Text) ||
                            (!checkM.IsChecked.GetValueOrDefault() && !checkF.IsChecked.GetValueOrDefault()))
            {
                MessageDialog dialog = new MessageDialog("Todos os campos são obrigatórios");
                await dialog.ShowAsync();
                return;
            }
        }

        private async Task ValidarEmail()
        {
            if (!Regex.IsMatch(email.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                MessageDialog dialog = new MessageDialog("E-mail Inválido");
                await dialog.ShowAsync();
                return;
            }       
        }

        private async Task ValidarAceiteTermosUso()
        {
            if (!chkTermosUso.IsChecked.GetValueOrDefault())
            {
                MessageDialog dialog = new MessageDialog("Você deve aceitar os termos de uso");
                await dialog.ShowAsync();
                return;
            }
        }
    }
}
