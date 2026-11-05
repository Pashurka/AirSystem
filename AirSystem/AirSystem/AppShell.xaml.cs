using AirSystem.ViewModels;
using AirSystem.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AirSystem
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        // Обробник події для елемента меню "Вихід"
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            bool confirmExit = await DisplayAlert("Підтвердження", "Ви впевнені, що хочете вийти з додатку?", "Так", "Ні");
            if (confirmExit)
            {
                // Завершення роботи додатку
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }
        }
    }
}
