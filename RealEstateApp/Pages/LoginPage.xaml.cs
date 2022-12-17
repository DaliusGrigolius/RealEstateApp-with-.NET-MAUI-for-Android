using RealEstateApp.Services;

namespace RealEstateApp.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        var response = await ApiService.Login(EntEmail.Text, EntPassword.Text);
        if (response)
        {
            while (Navigation.ModalStack.Count > 0)
            {
                await Navigation.PopModalAsync();
            }

            Application.Current.MainPage = new CustomTabbedPage();
        }
        else
        {
            await DisplayAlert("", "Oops, something went wrong..", "OK");
        }
    }

    async void TapJoinNow_Tapped(object sender, TappedEventArgs e)
    {
        while (Navigation.ModalStack.Count > 0)
        {
            await Navigation.PopModalAsync();
        }

        await Navigation.PushModalAsync(new RegisterPage());
    }
}